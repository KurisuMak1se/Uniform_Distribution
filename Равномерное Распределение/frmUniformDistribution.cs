using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace Равномерное_Распределение
{
    public partial class frmUniformDistribution : Form
    {
        Pen LineColor = new Pen(Color.White, 2);
        Graphics GrpCircle, GrpElements, GrpLines, GrpText;
        // GrpCircle - отрисовка окружности, по которой распределяются элементы
        //GrpElements - отрисовка как не маркированных, так и маркированных элементов
        SolidBrush ElementsClr = new SolidBrush(Color.White), ElementsMrkClr = new SolidBrush(Color.OrangeRed);
        // ElementsClr - Цвет элементов, ElementsMrkClr - Цвет Маркированных элементов
        Pen ClrCircle = new Pen(Color.White, 3);
        // ClrCircle - Цвет окружности, по которой распределяются элементы
        float Angle = -90;
        // Angle - угол поворота элемента, относительно центра окружности
        bool AllSteps = false;
        //AllSteps - определяет, что выбрана отрисовка всех шагов алгоритма Евклида
        int CheckIndex = -1, StepDistance = 0, AdditionalAngle = 0;
        // CheckIndex - выбранный шаг алгоритма Евклида для отрисовки, StepDistance - расстояние между внутренними и внешними окружностями
        // AdditionalAngle - дополнительный угол для равномерного расположения элементов
        int[] AlgOneStep = new int[4];
        // AlgOneStep - вектор первого шага алгоритма Евклида 
        //number - определяет количество проделанных обычных серий
        int crdCircleX, crdCicleY, DiameterCircle;
        // Координаты и диаметры окружности
        int RegulationDiametr = 40;
        // Параметр пользовательской настройки диаметра элементов
        Form frmInformation;
        // Дочерняя форма информации
        Font MyFont = new Font("Times new roman", 12);
        // Шрифт для текста станций и нумерации
        int IndentText = 40;
        // Параметр пользовательской настройки отступа текста от внешней окружности
        int StartNumbering = 1;
        // Начало нумерации
        Form frmStartingNumbering;
        // Дочерняя форма настройки начала нумерации
        TextBox TBInputNumbering;
        // Текстовое поле для ввода нумерации
        float Projection;
        // Радиус окружности
        PointF CenterHolst;
        // Центр холста
        Form frmFont;
        Button btnFontDone;
        ComboBox CBFontStyle;
        ComboBox CBFontSize;
        Label LblFontStyle;
        Label LblFontSize;
        // Компоненты настройки шрифта
        bool HourRotate = true;
        // Флажок поворота по/против часовой
        bool StepNumbering2 = false;
        // Флажок нумерации с шагом 2
        string[] Stations;
        // Массив наименований станций выбранной линии
        bool OutputStations = false;
        // Флажок вывода станций
        FileStream FSLines;
        // Поток файла станций
        StreamReader SRLines;
        // Поток чтения станций
        public frmUniformDistribution()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Определяет, какой шаг алгоритма Евклида будет изображён
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StepsEvklid_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (CBStepsEvklid.SelectedIndex != 0 & CBStepsEvklid.SelectedIndex != CBStepsEvklid.Items.Count - 1)
            {
                UpElementsToolStripMenuItem.Enabled = false;
                DownElementsToolStripMenuItem.Enabled = false;
                UpMarkingToolStripMenuItem.Enabled = false;
                DownMarkingToolStripMenuItem.Enabled = false;
                btnInputElements.Enabled = false;
            }
            else
            {
                UpElementsToolStripMenuItem.Enabled = true;
                DownElementsToolStripMenuItem.Enabled = true;
                UpMarkingToolStripMenuItem.Enabled = true;
                DownMarkingToolStripMenuItem.Enabled = true;
                btnInputElements.Enabled = true;
            }
            if (CBStepsEvklid.SelectedIndex + 1 == CBStepsEvklid.Items.Count)
            {
                AllSteps = true;
            }
            else
            {
                CheckIndex = CBStepsEvklid.SelectedIndex;
                AllSteps = false;
            }
            UniformDistribution();
        }
        /// <summary>
        /// Инициализация динамического интерфейса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUniformDistribution_Resize(object sender, EventArgs e)
        {
            Panel.Location = new Point(Width / 6 + 20, MainMenu.Height);
            Panel.Height = Height - MainMenu.Height - 40;
            Panel.Width = Width - Panel.Location.X * 2;
            picDraw.Location = new Point(0, 0);
            picDraw.Width = Panel.Width;
            picDraw.Height = Panel.Height;
            LVInformation.Width = Panel.Location.X;
            LVInformation.Height = Panel.Height;
            LVInformation.Location = new Point(0, Panel.Location.Y);
            CBStepsEvklid.Location = new Point(Panel.Location.X + Panel.Width, Panel.Location.Y);
            CBStepsEvklid.Width = Width - (Panel.Location.X + Panel.Width) - 16;
            LblInputEl.Width = CBStepsEvklid.Width;
            LblInputEl.Location = new Point(CBStepsEvklid.Location.X + 27, CBStepsEvklid.Location.Y + CBStepsEvklid.Height * 2);
            LblInputEl.Height = 50;
            InputTxtElements.Width = CBStepsEvklid.Width / 2;
            InputTxtElements.Location = new Point(CBStepsEvklid.Location.X + CBStepsEvklid.Width / 2 - InputTxtElements.Width / 2, LblInputEl.Location.Y + LblInputEl.Height);
            LblInputElMrk.Location = new Point(CBStepsEvklid.Location.X + 18, InputTxtElements.Location.Y + CBStepsEvklid.Height * 2);
            InputTxtMarkElements.Width = CBStepsEvklid.Width / 2;
            InputTxtMarkElements.Location = new Point(CBStepsEvklid.Location.X + CBStepsEvklid.Width / 2 - InputTxtMarkElements.Width / 2, LblInputElMrk.Location.Y + LblInputElMrk.Height);
            btnInputElements.Location = new Point(CBStepsEvklid.Location.X, InputTxtMarkElements.Location.Y + CBStepsEvklid.Height * 2);
            btnInputElements.Width = Width - btnInputElements.Location.X - 16;
            btnInputElements.Height = 50;
            btnRotateLeft.Location = new Point(btnInputElements.Location.X, btnInputElements.Location.Y + btnInputElements.Height);
            btnRotateLeft.Width = btnInputElements.Width / 2;
            btnRotateRight.Location = new Point(btnInputElements.Location.X + btnRotateLeft.Width, btnInputElements.Location.Y + btnInputElements.Height);
            btnRotateRight.Width = btnInputElements.Width / 2;
            DiameterCircle = (picDraw.Width / 2 + picDraw.Height / 2) * 2 / 3;
            crdCircleX = picDraw.Width / 2 - DiameterCircle / 2;
            crdCicleY = picDraw.Height / 2 - DiameterCircle / 2;
            clsElements.Diametr = picDraw.Width / RegulationDiametr;
            Projection = picDraw.Width / 2 - crdCircleX;
            CenterHolst = new PointF(picDraw.Width / 2, picDraw.Height / 2);
            UniformDistribution();
        }
        /// <summary>
        /// Инициализация интерфейса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUniformDistribution_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            MainMenu.BackColor = Color.White;
        }
        /// <summary>
        /// Считывает с текстовых полей количество элементов и количество их маркировки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputElements_Click(object sender, EventArgs e)
        {
            Int32.TryParse(InputTxtElements.Text, out AlgOneStep[0]);
            Int32.TryParse(InputTxtMarkElements.Text, out AlgOneStep[2]);
            InputTxtElements.Clear();
            InputTxtMarkElements.Clear();
            UniformDistribution();
        }
        /// <summary>
        /// Защищает ввод от букв
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputTxtElements_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) & e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Защищает ввод от букв
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputTxtMarkElements_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) & e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Увеличивает количество элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlgOneStep[0]++;
            OutputStations = false;
            UniformDistribution();
        }
        /// <summary>
        /// Уменьшает количество элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AlgOneStep[0] != 0)
            {
                AlgOneStep[0]--;
            }
            OutputStations = false;
            UniformDistribution();
        }
        /// <summary>
        /// Увеличивает количество маркированных элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpMarkingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AlgOneStep[2] != AlgOneStep[0] / 2)
            {
                AlgOneStep[2]++;
            }
            UniformDistribution();
        }
        /// <summary>
        /// Уменьшает количество маркированных элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownMarkingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AlgOneStep[2] != 0)
            {
                AlgOneStep[2]--;
            }
            UniformDistribution();
        }
        /// <summary>
        /// Уменьшает диаметр элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpDiametrElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RegulationDiametr - 10 != 20)
            {
                RegulationDiametr -= 10;
                clsElements.Diametr = picDraw.Width / RegulationDiametr;
                UniformDistribution();
            }
        }
        /// <summary>
        /// Увеличивает диаметр элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownDiametrElementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (RegulationDiametr + 10 != 70)
            {
                RegulationDiametr += 10;
                clsElements.Diametr = picDraw.Width / RegulationDiametr;
                UniformDistribution();
            }
        }
        /// <summary>
        /// Выставляет начало нумерации по умолчанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberingDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNumbering = 1;
            UniformDistribution();
        }
        /// <summary>
        /// Открывает окно с расширенной информацией о шагах алгоритма Евклида
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InformationOfStepsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView LVAdditionalInformation = new ListView();
            frmInformation = new Form();
            frmInformation.Text = "Информация о шагах алгоритма Евклида";
            frmInformation.Width = 750;
            frmInformation.Height = 400;
            frmInformation.MaximizeBox = false;
            frmInformation.FormBorderStyle = FormBorderStyle.Fixed3D;
            LVAdditionalInformation.Parent = frmInformation;
            LVAdditionalInformation.Location = new Point(0, 0);
            LVAdditionalInformation.Width = frmInformation.Width - 16;
            LVAdditionalInformation.Height = frmInformation.Height - 39;
            LVAdditionalInformation.View = View.List;
            LVAdditionalInformation.Font = MyFont;
            for (int i = 0; i < clsStep.EvklidAlgoritm.GetLength(0); i++)
            {
                LVAdditionalInformation.Items.Add($"{i + 1} шаг алгоритма Евклида");
                LVAdditionalInformation.Items.Add($"Кол-во элементов: {clsStep.EvklidAlgoritm[i, 0]}");
                LVAdditionalInformation.Items.Add($"Кол-во выбираемых элементов: {clsStep.EvklidAlgoritm[i, 2]}");
                LVAdditionalInformation.Items.Add($"Кол-во больших серий: {clsStep.EvklidAlgoritm[i, 3]}");
                LVAdditionalInformation.Items.Add($"Промежуток маркировки: {clsStep.EvklidAlgoritm[i, 1]}");
                LVAdditionalInformation.Items.Add("");
            }
            frmInformation.Show();
        }
        /// <summary>
        /// Открывает окно с настройкой начала нумерации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberingRangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Объявление дочерных компонентов
            Label LblNumbering = new Label();
            Button BtnInitNumbering = new Button();
            TBInputNumbering = new TextBox();
            // Инициализация дочерной формы
            frmStartingNumbering = new Form();
            frmStartingNumbering.Text = "Начало нумерации";
            frmStartingNumbering.Width = 325;
            frmStartingNumbering.Height = 150;
            frmStartingNumbering.MaximizeBox = false;
            frmStartingNumbering.FormBorderStyle = FormBorderStyle.Fixed3D;
            // Инициализация ярлыка
            LblNumbering.Parent = frmStartingNumbering;
            LblNumbering.Width = 150;
            LblNumbering.Text = "Введите начало нумерации";
            LblNumbering.Location = new Point(frmStartingNumbering.Width / 2 - LblNumbering.Width / 2 - 8, 0);
            // Инициализация текстового поля
            TBInputNumbering.Parent = frmStartingNumbering;
            TBInputNumbering.Width = 275;
            TBInputNumbering.Location = new Point(frmStartingNumbering.Width / 2 - TBInputNumbering.Width / 2 - 8, LblNumbering.Height);
            TBInputNumbering.KeyPress += TBInputNumbering_KeyPress;
            // Инициализация кнопки
            BtnInitNumbering.Parent = frmStartingNumbering;
            BtnInitNumbering.Text = "Ввести";
            BtnInitNumbering.Width = 275;
            BtnInitNumbering.Height = 60;
            BtnInitNumbering.Location = new Point(frmStartingNumbering.Width / 2 - BtnInitNumbering.Width / 2 - 8,
                                                  TBInputNumbering.Height + LblNumbering.Height);
            BtnInitNumbering.Click += BtnInitNumbering_Click;
            frmStartingNumbering.Show();
        }
        /// <summary>
        /// Защищает ввод от букв
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TBInputNumbering_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) & e.KeyChar != (char)Keys.Back & e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Подтверждает настройку начало нумерации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInitNumbering_Click(object sender, EventArgs e)
        {
            Int32.TryParse(TBInputNumbering.Text, out StartNumbering);
            frmStartingNumbering.Close();
            UniformDistribution();
        }
        /// <summary>
        /// Настраивает направление нумерации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HourNumberingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HourRotate)
            {
                HourNumberingToolStripMenuItem.Text = "Провести по часовой";
                HourRotate = false;
            }
            else
            {
                HourNumberingToolStripMenuItem.Text = "Провести против часовой";
                HourRotate = true;
            }
            UniformDistribution();
        }
        /// <summary>
        /// Настраивает шаг нумерации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StepNumberingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StepNumbering2)
            {
                StepNumberingToolStripMenuItem.Text = "Провести с шагом 2";
                StepNumbering2 = false;
            }
            else
            {
                StepNumberingToolStripMenuItem.Text = "Провести с шагом 1";
                StepNumbering2 = true;
            }
            UniformDistribution();
        }
        /// <summary>
        /// Открывает проводник для выбора линии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoiseLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialogLines.ShowDialog();
        }
        /// <summary>
        /// Считывает выбранную линию из файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileDialogLines_FileOk(object sender, CancelEventArgs e)
        {
            FSLines = new FileStream(OpenFileDialogLines.FileName, FileMode.Open);
            SRLines = new StreamReader(FSLines);
            Stations = SRLines.ReadToEnd().Split('%');
            SRLines.Close();
            FSLines.Close();
            AlgOneStep = new int[] {Stations.Length, 0, clsStep.EvklidAlgoritm[0, 2], 0 };
            OutputStations = true;
            CBStepsEvklid.SelectedIndex = 0;
        }
        /// <summary>
        /// Поворачивает последовательность влево
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            clsStep.RotateSteps--;
            UniformDistribution();
        }
        /// <summary>
        /// Поворачивает последовательность вправо
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            clsStep.RotateSteps++;
            UniformDistribution();
        }
        /// <summary>
        /// Открывает окно с настройкой шрифта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFont = new Form(); // Инициализации дочерной формы
            frmFont.BackColor = Color.White;
            frmFont.Text = "Настройка шрифта";
            frmFont.Width = 600;
            frmFont.Height = 300;
            frmFont.MaximizeBox = false;
            frmFont.FormBorderStyle = FormBorderStyle.Fixed3D;
            btnFontDone = new Button(); // Инициализация кнопки подтверждения настройки
            btnFontDone.Parent = frmFont;
            btnFontDone.Text = "Подтвердить";
            btnFontDone.Width = 85;
            btnFontDone.Height = 25;
            btnFontDone.Location = new Point(frmFont.Width / 2 - btnFontDone.Width / 2 - 16, frmFont.Height - btnFontDone.Height - 50);
            btnFontDone.Click += BtnFontDone_Click;
            LblFontStyle = new Label(); // Инициализация ярлыка "Стиль шрифта"
            LblFontStyle.Parent = frmFont;
            LblFontStyle.Text = "Стиль шрифта";
            LblFontStyle.Font = LblInputEl.Font;
            LblFontStyle.Width = (int)GrpText.MeasureString(LblFontStyle.Text, LblFontStyle.Font).Width + 4;
            LblFontStyle.Location = new Point(frmFont.Width / 4 - LblFontStyle.Width / 2 - 16, 0);
            LblFontSize = new Label(); // Инициализация ярлыка "Размер шрифта"
            LblFontSize.Parent = frmFont;
            LblFontSize.Text = "Размер шрифта";
            LblFontSize.Font = LblInputEl.Font;
            LblFontSize.Width = (int)GrpText.MeasureString(LblFontSize.Text, LblFontSize.Font).Width + 5;
            LblFontSize.Location = new Point(3 * frmFont.Width / 4 - LblFontSize.Width / 2 - 16, 0);
            CBFontStyle = new ComboBox(); // Инициализация выпадающего списка стилей шрифта
            CBFontStyle.Parent = frmFont;
            CBFontStyle.Width = LblFontStyle.Width;
            CBFontStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            CBFontStyle.Location = new Point(LblFontStyle.Location.X, LblFontStyle.Height);
            CBFontSize = new ComboBox(); // Инициализация выпадающего списка размера шрифта
            CBFontSize.Parent = frmFont;
            CBFontSize.Width = LblFontSize.Width / 2;
            CBFontSize.DropDownStyle = ComboBoxStyle.DropDownList;
            CBFontSize.Location = new Point(LblFontSize.Location.X + LblFontSize.Width / 4, LblFontSize.Height);
            for(int i = 2; i < 73; i += 2)
            {
                CBFontSize.Items.Add(i.ToString());
            }
            frmFont.Show();
        }
        /// <summary>
        /// Подтверждает пользовательскую настроку шрифта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFontDone_Click(object sender, EventArgs e)
        {
            MyFont = null;
            MyFont = new Font("Times New Roman", float.Parse(CBFontSize.SelectedItem.ToString()));
            frmFont.Close();
            UniformDistribution();
        }
        /// <summary>
        /// Увеличивает отступ текста от внешней окружности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpIndentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IndentText != 100)
            {
                IndentText += 10;
            }
            UniformDistribution();
        }
        /// <summary>
        /// Уменьшает отступ текста от внешней окружности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownIndentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(IndentText != 0)
            {
                IndentText -= 10;
            }
            UniformDistribution();
        }
        /// <summary>
        /// Инвертирует цвет компонентов холста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReversColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (picDraw.BackColor == Color.Black)
            {
                ClrCircle = new Pen(Color.Black, 3);
                ElementsClr = new SolidBrush(Color.Black);
                ElementsMrkClr = new SolidBrush(Color.GreenYellow);
                picDraw.BackColor = Color.White;
                LineColor = new Pen(Color.Black, 2);
            }
            else
            {
                ClrCircle = new Pen(Color.White, 3);
                ElementsClr = new SolidBrush(Color.White);
                ElementsMrkClr = new SolidBrush(Color.OrangeRed);
                picDraw.BackColor = Color.Black;
                LineColor = new Pen(Color.White, 2);
            }
            UniformDistribution();
        }
        /// <summary>
        /// Выполняет основные процессы равномерного распределения элементов
        /// </summary>
        private void UniformDistribution()
        {
            clsStep.AlgoritmEvklid(AlgOneStep);
            StepsItems();
            StepsInformation();
            InitializationSteps();
            if (OutputStations)
                InitializationAndAligmentCrdStation();
            Drawing();
            if (AllSteps)
                EjectionLines();
            TextDrawing();
        }
        /// <summary>
        /// Заполнение комбинированного списка, для выбора шага алгоритма Евклида
        /// </summary>
        private void StepsItems()
        {
            CBStepsEvklid.Items.Clear();
            for (int i = 0; i < clsStep.EvklidAlgoritm.GetLength(0); i++)
            {
                CBStepsEvklid.Items.Add($"{i + 1} шаг алгоритма Евклида");
            }
            CBStepsEvklid.Items.Add("Все шаги алгоритма Евклида");
        }
        /// <summary>
        /// Инициализирует шаги
        /// </summary>
        private void InitializationSteps()
        {
            clsStep.MyCol.Clear();
            StepDistance = Math.Abs((crdCircleX - (picDraw.Width / 2 - picDraw.Width / 40)) / clsStep.EvklidAlgoritm.GetLength(0));
            for (int i = 0; i < clsStep.EvklidAlgoritm.GetLength(0); i++)
            {
                clsStep.MyCol.Add(new clsStep(i));
                if (clsStep.EvklidAlgoritm[i, 0] != 0)
                {
                    Math.DivRem(360, clsStep.EvklidAlgoritm[i, 0], out AdditionalAngle);
                }
                if (clsStep.EvklidAlgoritm[i, 0] == 2)
                {
                    Angle += HourRotate ? 45 : -45;
                }
                else if (clsStep.EvklidAlgoritm[i, 0] == 4)
                {
                    Angle += HourRotate ? 30 : -30;
                }
                else if(clsStep.EvklidAlgoritm[i, 0] == 3)
                {
                    Angle += HourRotate ? 60 : -60;
                }
                for (int j = 0; j < clsStep.EvklidAlgoritm[i, 0]; j++)
                {
                    clsStep.MyCol[i].ElOfMark[j] = new clsElements(CenterHolst.X - clsElements.Diametr / 2 + Projection * (float)Math.Cos(Angle * Math.PI / 180),
                                                                   CenterHolst.Y - clsElements.Diametr / 2 + Projection * (float)Math.Sin(Angle * Math.PI / 180));
                    if (AllSteps)
                    {
                        clsStep.MyCol[i].ElOfMark[j].Projection(StepDistance * i, Angle - 180);
                    }
                    if (AdditionalAngle != 0)
                    {
                        Angle += HourRotate ? 360 / clsStep.EvklidAlgoritm[i, 0] + 1 : -(360 / clsStep.EvklidAlgoritm[i, 0] + 1);
                        AdditionalAngle--;
                    }
                    else
                    {
                        Angle += HourRotate ? 360 / clsStep.EvklidAlgoritm[i, 0] : -360 / clsStep.EvklidAlgoritm[i, 0];
                    }
                }
                Angle = -90;
            }
            if (clsStep.EvklidAlgoritm[0, 2] != 0)
            {
                clsStep.MyCol = clsStep.SortElements();
            }
        }
        /// <summary>
        /// Инициализация и выравнивание координат текстовых блоков станций
        /// </summary>
        void InitializationAndAligmentCrdStation()
        {
            float ProjectionTextCrdX;
            float ProjectionTextCrdY;
            double DifferenceCrdYStation, DifferenceCrdXStation;
            if (clsStep.EvklidAlgoritm[0, 0] != 0)
            {
                Math.DivRem(360, clsStep.EvklidAlgoritm[0, 0], out AdditionalAngle);
            }
            for (int i = 0; i < clsStep.MyCol[0].ElOfMark.Length; i++)
            {
                if (Angle <= 90)
                {
                    ProjectionTextCrdY = clsElements.Diametr * (float)((Angle / 180) - 1);
                }
                else
                {
                    ProjectionTextCrdY = clsElements.Diametr * (float)-(Angle / 180);
                }
                if (Angle <= 0)
                {
                    ProjectionTextCrdX = GrpText.MeasureString(Stations[i].Split('!')[0], MyFont).Width * (float)0.5 * Angle / 90;
                }
                else if (Angle <= 180)
                {
                    ProjectionTextCrdX = GrpText.MeasureString(Stations[i].Split('!')[0], MyFont).Width * (float)-(0.5 * Angle / 90);
                }
                else
                {
                    ProjectionTextCrdX = GrpText.MeasureString(Stations[i].Split('!')[0], MyFont).Width * (float)((0.5 * Angle / 90) - 2);
                }
                clsStep.MyCol[0].ElOfMark[i].StationCrdX = CenterHolst.X + (Projection + IndentText) 
                                                           * (float)Math.Cos(Angle * Math.PI / 180) + ProjectionTextCrdX;
                clsStep.MyCol[0].ElOfMark[i].StationCrdY = clsElements.Diametr / 2 + CenterHolst.Y + (Projection + IndentText) * (float)Math.Sin(Angle * Math.PI / 180)
                                                                          + ProjectionTextCrdY - (i == 0 ? MyFont.Height : 0);
                if (AdditionalAngle != 0)
                {
                    Angle += HourRotate ? 360 / clsStep.EvklidAlgoritm[0, 0] + 1 : -(360 / clsStep.EvklidAlgoritm[0, 0] + 1);
                    AdditionalAngle--;
                }
                else
                {
                    Angle += HourRotate ? 360 / clsStep.EvklidAlgoritm[0, 0] : -360 / clsStep.EvklidAlgoritm[0, 0];
                }
            }
            Angle = -90;
            for (int i = 0; i < clsStep.MyCol[0].ElOfMark.Length; i++)
            {
                DifferenceCrdYStation = Math.Abs(clsStep.MyCol[0].ElOfMark[i].StationCrdY - clsStep.MyCol[0].ElOfMark[(i + 1) % clsStep.MyCol[0].ElOfMark.Length].StationCrdY);
                while (DifferenceCrdYStation < MyFont.Height)
                {
                    if (i < clsStep.MyCol[0].ElOfMark.Length / 2)
                    {
                        clsStep.MyCol[0].ElOfMark[(i + 1) % clsStep.MyCol[0].ElOfMark.Length].StationCrdY++;
                    }
                    else
                    {
                        clsStep.MyCol[0].ElOfMark[(i + 1) % clsStep.MyCol[0].ElOfMark.Length].StationCrdY--;
                    }
                    DifferenceCrdYStation = Math.Abs(clsStep.MyCol[0].ElOfMark[i].StationCrdY - clsStep.MyCol[0].ElOfMark[(i + 1) % clsStep.MyCol[0].ElOfMark.Length].StationCrdY);
                }
            }
            if (clsStep.EvklidAlgoritm[0, 0] != 0)
            {
                Math.DivRem(360, clsStep.EvklidAlgoritm[0, 0], out AdditionalAngle);
            }
            for (int i = 0; Angle < 90; i++)
            {
                for (int j = i + 1; j < clsStep.MyCol[0].ElOfMark.Length; j++)
                {
                    DifferenceCrdXStation = Math.Abs(clsStep.MyCol[0].ElOfMark[i].StationCrdX - clsStep.MyCol[0].ElOfMark[j].StationCrdX);
                    DifferenceCrdYStation = Math.Abs(clsStep.MyCol[0].ElOfMark[i].StationCrdY - clsStep.MyCol[0].ElOfMark[j].StationCrdY);
                    while (DifferenceCrdXStation < (GrpText.MeasureString(Stations[i].Split('!')[0], MyFont).Width + GrpText.MeasureString(Stations[j].Split('!')[0], MyFont).Width) / 2 & DifferenceCrdYStation < MyFont.Height)
                    {
                        clsStep.MyCol[0].ElOfMark[i].StationCrdX++;
                        clsStep.MyCol[0].ElOfMark[j].StationCrdX--;
                        DifferenceCrdXStation = Math.Abs(clsStep.MyCol[0].ElOfMark[i].StationCrdX - clsStep.MyCol[0].ElOfMark[j].StationCrdX);
                    }
                }
                if (AdditionalAngle != 0)
                {
                    Angle += HourRotate ? 360 / clsStep.EvklidAlgoritm[0, 0] + 1 : -(360 / clsStep.EvklidAlgoritm[0, 0] + 1);
                    AdditionalAngle--;
                }
                else
                {
                    Angle += HourRotate ? 360 / clsStep.EvklidAlgoritm[0, 0] : -360 / clsStep.EvklidAlgoritm[0, 0];
                }
            }
        }
        /// <summary>
        /// Выводит информацию о каждом шаге алгоритма Евклида
        /// </summary>
        void StepsInformation()
        {
            LVInformation.Items.Clear();
            for (int i = 0; i < clsStep.EvklidAlgoritm.GetLength(0); i++)
            {
                LVInformation.Items.Add($"{i + 1} шаг алгоритма Евклида");
                LVInformation.Items.Add($"Кол-во элементов: {clsStep.EvklidAlgoritm[i, 0]}");
                LVInformation.Items.Add($"Кол-во выбираемых элементов: {clsStep.EvklidAlgoritm[i, 2]}");
                LVInformation.Items.Add($"Кол-во больших серий: {clsStep.EvklidAlgoritm[i, 3]}");
                LVInformation.Items.Add($"Промежуток маркировки: {clsStep.EvklidAlgoritm[i, 1]}");
                LVInformation.Items.Add("");
            }
        }
        /// <summary>
        /// Отрисовка выброса линий
        /// </summary>
        void EjectionLines()
        {
            GrpLines = picDraw.CreateGraphics();
            int AdditionalIndex;
            for(int i = 0; i < clsStep.EvklidAlgoritm.GetLength(0) - 1; i++)
            {
                AdditionalIndex = 0;
                for(int j = 0; j < clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 1 - i].ElOfMark.Length; j++)

                {
                    if (clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 1 - i].ElOfMark[j].Marking)
                    {
                        for(int k = 0; k < clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].SmallSeria + 1; k++)
                        {
                            GrpLines.DrawLine(LineColor, clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 1 - i].ElOfMark[j].CrdX + clsElements.Diametr / 2,
                                              clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 1 - i].ElOfMark[j].CrdY + clsElements.Diametr / 2,
                                              clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].ElOfMark[i == clsStep.EvklidAlgoritm.GetLength(0) - 2 ? (k + AdditionalIndex +
                                              clsStep.RotateSteps) % clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].ElOfMark.Length : k + AdditionalIndex].CrdX + clsElements.Diametr / 2,
                                              clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].ElOfMark[i == clsStep.EvklidAlgoritm.GetLength(0) - 2 ? (k + AdditionalIndex +
                                              clsStep.RotateSteps) % clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].ElOfMark.Length : k + AdditionalIndex].CrdY + clsElements.Diametr / 2);
                        }
                        AdditionalIndex += clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].SmallSeria + 1;
                    }
                    else
                    {
                        for (int k = 0; k < clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].SmallSeria; k++)
                        {
                            GrpLines.DrawLine(LineColor, clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 1 - i].ElOfMark[j].CrdX + clsElements.Diametr / 2,
                                              clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 1 - i].ElOfMark[j].CrdY + clsElements.Diametr / 2,
                                              clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].ElOfMark[i == clsStep.EvklidAlgoritm.GetLength(0) - 2 ? (k + AdditionalIndex +
                                              clsStep.RotateSteps) % clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].ElOfMark.Length : k + AdditionalIndex].CrdX + clsElements.Diametr / 2,
                                              clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].ElOfMark[i == clsStep.EvklidAlgoritm.GetLength(0) - 2 ? (k + AdditionalIndex +
                                              clsStep.RotateSteps) % clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].ElOfMark.Length : k + AdditionalIndex].CrdY + clsElements.Diametr / 2);
                        }
                        AdditionalIndex += clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].SmallSeria;
                    }
                }
            }
        }
        /// <summary>
        /// Отрисовка последовательностей шагов
        /// </summary>
        void Drawing()
        {
            picDraw.Refresh();
            GrpElements = picDraw.CreateGraphics();
            GrpCircle = picDraw.CreateGraphics();
            for (int i = 0; i < clsStep.EvklidAlgoritm.GetLength(0); i++)
            {
                GrpCircle.DrawEllipse(ClrCircle, crdCircleX + StepDistance * i, crdCicleY + StepDistance * i,
                                      DiameterCircle - 2 * StepDistance * i, DiameterCircle - 2 * StepDistance * i);
                if (!AllSteps)
                {
                    i = CheckIndex != -1 ? CheckIndex : 0;
                }
                for (int j = 0; j < clsStep.MyCol[i].ElOfMark.Length; j++)
                {
                    if (clsStep.MyCol[i].ElOfMark[j].Marking)
                    {
                        GrpElements.FillEllipse(ElementsMrkClr, clsStep.MyCol[i].ElOfMark[j].CrdX,
                                                clsStep.MyCol[i].ElOfMark[j].CrdY, clsElements.Diametr,
                                                clsElements.Diametr);
                    }
                    else
                    {
                        GrpElements.FillEllipse(ElementsClr, clsStep.MyCol[i].ElOfMark[j].CrdX,
                                                clsStep.MyCol[i].ElOfMark[j].CrdY, clsElements.Diametr,
                                                clsElements.Diametr);
                    }
                }
                if (!AllSteps)
                    break;
            }
        }
        /// <summary>
        /// Отрисовка текста на внешней окружности
        /// </summary>
        void TextDrawing()
        {
            int MarkNumbering = 1;
            GrpText = picDraw.CreateGraphics();
            CheckIndex = (AllSteps || CheckIndex == -1) ? 0 : CheckIndex;
            if (clsStep.EvklidAlgoritm[CheckIndex, 0] == 2)
            {
                Angle += HourRotate ? 45 : -45;
            }
            else if (clsStep.EvklidAlgoritm[CheckIndex, 0] == 4)
            {
                Angle += HourRotate ? 30 : -30;
            }
            else if (clsStep.EvklidAlgoritm[CheckIndex, 0] == 3)
            {
                Angle += HourRotate ? 60 : -60;
            }
            if (clsStep.EvklidAlgoritm[CheckIndex, 0] != 0)
            {
                Math.DivRem(360, clsStep.EvklidAlgoritm[CheckIndex, 0], out AdditionalAngle);
            }
            for (int i = 0; i < clsStep.MyCol[CheckIndex].ElOfMark.Length; i++)
            {
                if (OutputStations)
                {
                    GrpText.DrawString(Stations[i].Split('!')[0], MyFont, ElementsClr,
                                       clsStep.MyCol[CheckIndex].ElOfMark[i].StationCrdX,
                                       clsStep.MyCol[CheckIndex].ElOfMark[i].StationCrdY);
                }
                else
                {
                    clsStep.MyCol[CheckIndex].ElOfMark[i].Numbering = i + StartNumbering;
                    if (clsStep.MyCol[CheckIndex].ElOfMark[i].Marking)
                    {
                        clsStep.MyCol[CheckIndex].ElOfMark[i].MarkingNumbering = MarkNumbering;
                        MarkNumbering++;
                    }
                    if (StepNumbering2 & i % 2 == 0)
                    {
                        GrpText.DrawString(clsStep.MyCol[CheckIndex].ElOfMark[i].ToString(),
                                                MyFont, ElementsClr,
                                                CenterHolst.X - GrpText.MeasureString(clsStep.MyCol[CheckIndex].ElOfMark[i].ToString(), MyFont).Width / 2
                                                + (Projection + IndentText) * (float)Math.Cos(Angle * Math.PI / 180),
                                                CenterHolst.Y - clsElements.Diametr / 2 + (Projection + IndentText) * (float)Math.Sin(Angle * Math.PI / 180));
                    }
                    else if(!StepNumbering2)
                    {
                        GrpText.DrawString(clsStep.MyCol[CheckIndex].ElOfMark[i].ToString(),
                                            MyFont, ElementsClr,
                                            CenterHolst.X - GrpText.MeasureString(clsStep.MyCol[CheckIndex].ElOfMark[i].ToString(), MyFont).Width / 2
                                            + (Projection + IndentText) * (float)Math.Cos(Angle * Math.PI / 180),
                                            CenterHolst.Y - clsElements.Diametr / 2 + (Projection + IndentText) * (float)Math.Sin(Angle * Math.PI / 180));
                    }
                    if (AdditionalAngle != 0)
                    {
                        Angle += HourRotate ? 360 / clsStep.EvklidAlgoritm[CheckIndex, 0] + 1 : -360 / clsStep.EvklidAlgoritm[CheckIndex, 0] - 1;
                        AdditionalAngle--;
                    }
                    else
                    {
                        Angle += HourRotate ? 360 / clsStep.EvklidAlgoritm[CheckIndex, 0] : -360 / clsStep.EvklidAlgoritm[CheckIndex, 0];
                    }
                }
            }
            Angle = -90;
           // OutputStations = false;
        }
    }
}