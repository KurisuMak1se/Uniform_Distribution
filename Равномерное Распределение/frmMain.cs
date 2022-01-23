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

namespace Равномерное_Распределение
{
    public partial class frmMain : Form
    {
        Pen LineColor = new Pen(Color.White, 2);
        Graphics GrpCircle, GrpElements, GrpLines;
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
        // SeriesAndIntervals - Считает количество меньших серий, после определяет промежуток больших серий, LengthMas - Количество строк в матрице шагов алгоритма Евклида
        // CheckIndex - выбранный шаг алгоритма Евклида для отрисовки, StepDistance - расстояние между внутренними и внешними окружностями
        // AdditionalAngle - дополнительный угол для равномерного расположения элементов
        int[] AlgOneStep = new int[4];
        // AlgOneStep - вектор первого шага алгоритма Евклида 
        //number - определяет количество проделанных обычных серий
        int crdCircleX, crdCicleY, DiameterCircle;
        // Координаты и диаметры окружности и элементов
        public frmMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Увеличивает количество маркированных элементов на единицу до половины общего количества элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PickElPlus_Click(object sender, EventArgs e)
        {
            if (AlgOneStep[2] != AlgOneStep[0] / 2)
            {
                AlgOneStep[2] += 1;
            }
            UniformDistribution();
        }
        /// <summary>
        /// Определяет, какой шаг алгоритма Евклида будет изображён
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StepsEvklid_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (StepsEvklid.SelectedIndex != 0 & StepsEvklid.SelectedIndex != StepsEvklid.Items.Count - 1)
            {
                DrawElPlus.Enabled = false;
                DrawElMinus.Enabled = false;
                PickElPlus.Enabled = false;
                PickElMinus.Enabled = false;
                InputElements.Enabled = false;
            }
            else
            {
                DrawElPlus.Enabled = true;
                DrawElMinus.Enabled = true;
                PickElPlus.Enabled = true;
                PickElMinus.Enabled = true;
                InputElements.Enabled = true;
            }
            if (StepsEvklid.SelectedIndex + 1 == StepsEvklid.Items.Count)
            {
                AllSteps = true;
            }
            else
            {
                CheckIndex = StepsEvklid.SelectedIndex;
                AllSteps = false;
            }
            UniformDistribution();
        }
        /// <summary>
        /// Уменьшает количество маркированных элементов на единицу до нуля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PickElMinus_Click(object sender, EventArgs e)
        {
            if (AlgOneStep[2] != 0)
            {
                AlgOneStep[2] -= 1;
            }
            UniformDistribution();
        }
        /// <summary>
        /// Инициализация динамического интерфейса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Resize(object sender, EventArgs e)
        {
            Panel.Location = new Point(Width * 3 / 10, Height / 6);
            Panel.Height = Height * 3 / 4;
            Panel.Width = Height * 3 / 4;
            picDraw.Location = new Point(0, 0);
            picDraw.Width = Panel.Width;
            picDraw.Height = Panel.Height;
            DrawElPlus.Width = Panel.Width / 4;
            DrawElPlus.Height = Panel.Height / 6;
            DrawElPlus.Location = new Point(Panel.Location.X, Panel.Location.Y - DrawElPlus.Height);
            DrawElMinus.Width = Panel.Width / 4;
            DrawElMinus.Height = Panel.Height / 6;
            DrawElMinus.Location = new Point(Panel.Location.X + DrawElMinus.Width, Panel.Location.Y - DrawElMinus.Height);
            PickElPlus.Width = Panel.Width / 4;
            PickElPlus.Height = Panel.Height / 6;
            PickElPlus.Location = new Point(Panel.Location.X + PickElPlus.Width * 2, Panel.Location.Y - PickElPlus.Height);
            PickElMinus.Width = Panel.Width / 4;
            PickElMinus.Height = Panel.Height / 6;
            PickElMinus.Location = new Point(Panel.Location.X + PickElPlus.Width * 3, Panel.Location.Y - PickElPlus.Height);
            StepsEvklid.Location = new Point(Panel.Location.X + Panel.Width, Panel.Location.Y);
            StepsEvklid.Width = LblInputElMrk.Width;
            clrcircle.Width = 160;
            clrcircle.Location = new Point(StepsEvklid.Location.X, StepsEvklid.Location.Y - StepsEvklid.Height);
            Information.Width = Panel.Location.X;
            Information.Height = Panel.Height + PickElPlus.Height;
            Information.Location = new Point(0, PickElPlus.Location.Y);
            LblInputEl.Location = new Point(StepsEvklid.Location.X, StepsEvklid.Location.Y + StepsEvklid.Height);
            InputTxtElements.Location = new Point(StepsEvklid.Location.X, LblInputEl.Location.Y + LblInputEl.Height);
            InputTxtElements.Width = LblInputElMrk.Width;
            LblInputElMrk.Location = new Point(InputTxtElements.Location.X, InputTxtElements.Location.Y + InputTxtElements.Height);
            InputTxtMarkElements.Location = new Point(LblInputElMrk.Location.X, LblInputElMrk.Location.Y + LblInputElMrk.Height);
            InputTxtMarkElements.Width = LblInputElMrk.Width;
            InputElements.Location = new Point(InputTxtMarkElements.Location.X, InputTxtMarkElements.Location.Y + InputTxtMarkElements.Height);
            InputElements.Width = LblInputElMrk.Width;
            InputElements.Height = PickElMinus.Height;
            DiameterCircle = picDraw.Width * 4 / 5;
            crdCircleX = picDraw.Width / 2 - DiameterCircle / 2;
            crdCicleY = picDraw.Height / 2 - DiameterCircle / 2;
            clsElements.Diametr = picDraw.Width / 30;
            UniformDistribution();
        }
        /// <summary>
        /// Инициализация интерфейса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        private void InputElements_Click(object sender, EventArgs e)
        {
            Int32.TryParse(InputTxtElements.Text, out AlgOneStep[0]);
            Int32.TryParse(InputTxtMarkElements.Text, out AlgOneStep[2]);
            InputTxtElements.Clear();
            InputTxtMarkElements.Clear();
            UniformDistribution();
        }
        private void InputTxtElements_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) & e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void InputTxtMarkElements_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) & e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        ///  Уменьшает на единицу общее количество элементов до нуля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawElMinus_Click(object sender, EventArgs e)
        {
            if (AlgOneStep[0] != 0)
            {
                AlgOneStep[0] -= 1;
            }
            UniformDistribution();
        }
        /// <summary>
        /// Увеличевает на единицу общее количество элементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawElPlus_Click(object sender, EventArgs e)
        {
            AlgOneStep[0] += 1;
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
            Drawing();
            if (AllSteps)
                EjectionLines();
        }
        /// <summary>
        /// Инверсия цвета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clrcircle_Click(object sender, EventArgs e)
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
        /// Заполнение комбинированного списка, для выбора шага алгоритма Евклида
        /// </summary>
        private void StepsItems()
        {
            StepsEvklid.Items.Clear();
            for (int i = 0; i < clsStep.EvklidAlgoritm.GetLength(0); i++)
            {
                StepsEvklid.Items.Add($"{i + 1} шаг алгоритма Евклида");
            }
            StepsEvklid.Items.Add("Все шаги алгоритма Евклида");
        }
        /// <summary>
        /// Отрисовывает равномерно распределённые элементы на окружности
        /// </summary>
        private void InitializationSteps()
        {
            clsStep.MyCol.Clear();
            float CenterHolst = picDraw.Width / 2 - clsElements.Diametr / 2;
            float ProjectionFirstStep = picDraw.Width / 2 - crdCircleX;
            StepDistance = Math.Abs((crdCircleX - (picDraw.Width / 2 - picDraw.Width / 40)) / clsStep.EvklidAlgoritm.GetLength(0));
            for (int i = 0; i < clsStep.EvklidAlgoritm.GetLength(0); i++)
            {
                clsStep.MyCol.Add(new clsStep(i));
                if (clsStep.EvklidAlgoritm[i, 0] != 0)
                {
                    Math.DivRem(360, clsStep.EvklidAlgoritm[i, 0], out AdditionalAngle);
                }
                for (int j = 0; j < clsStep.EvklidAlgoritm[i, 0]; j++)
                {
                    if (j != 0)
                    {
                        if (clsStep.EvklidAlgoritm[i, 0] != 0)
                        {
                            if (AdditionalAngle != 0)
                            {
                                Angle += 360 / clsStep.EvklidAlgoritm[i, 0] + 1;
                                AdditionalAngle--;
                            }
                            else
                            {
                                Angle += 360 / clsStep.EvklidAlgoritm[i, 0];
                            }
                        }
                    }
                    clsStep.MyCol[i].ElOfMark[j] = new clsElements(CenterHolst + ProjectionFirstStep * (float)Math.Cos(Angle * Math.PI / 180),
                                                                   CenterHolst + ProjectionFirstStep * (float)Math.Sin(Angle * Math.PI / 180));
                    if (AllSteps)
                    {
                        clsStep.MyCol[i].ElOfMark[j].Projection(StepDistance * i, Angle - 180);
                    }
                }
                Angle = -90;
            }
        }
        /// <summary>
        /// Выводит информацию о каждом шаге алгоритма Евклида
        /// </summary>
        void StepsInformation()
        {
            Information.Items.Clear();
            for (int i = 0; i < clsStep.EvklidAlgoritm.GetLength(0); i++)
            {
                Information.Items.Add($"{i + 1} шаг алгоритма Евклида");
                Information.Items.Add($"Кол-во элементов: {clsStep.EvklidAlgoritm[i, 0]}");
                Information.Items.Add($"Кол-во выбираемых элементов: {clsStep.EvklidAlgoritm[i, 2]}");
                Information.Items.Add($"Кол-во больших серий: {clsStep.EvklidAlgoritm[i, 3]}");
                Information.Items.Add($"Промежуток маркировки: {clsStep.EvklidAlgoritm[i, 1]}");
                Information.Items.Add("");
            }
        }
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
                                              clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].ElOfMark[k + AdditionalIndex].CrdX + clsElements.Diametr / 2,
                                              clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].ElOfMark[k + AdditionalIndex].CrdY + clsElements.Diametr / 2);
                        }
                        AdditionalIndex += clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].SmallSeria + 1;
                    }
                    else
                    {
                        for (int k = 0; k < clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].SmallSeria; k++)
                        {
                            GrpLines.DrawLine(LineColor, clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 1 - i].ElOfMark[j].CrdX + clsElements.Diametr / 2,
                                              clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 1 - i].ElOfMark[j].CrdY + clsElements.Diametr / 2,
                                              clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].ElOfMark[k + AdditionalIndex].CrdX + clsElements.Diametr / 2,
                                              clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].ElOfMark[k + AdditionalIndex].CrdY + clsElements.Diametr / 2);
                        }
                        AdditionalIndex += clsStep.MyCol[clsStep.EvklidAlgoritm.GetLength(0) - 2 - i].SmallSeria;
                    }
                }
            }
        }
        void Drawing()
        {
            picDraw.Refresh();
            GrpElements = picDraw.CreateGraphics();
            GrpCircle = picDraw.CreateGraphics();
            if (clsStep.EvklidAlgoritm[0, 2] != 0)
            {
                clsStep.MyCol = clsStep.SortElements();
            }
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
    }
}