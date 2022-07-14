namespace Равномерное_Распределение
{
    partial class frmUniformDistribution
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUniformDistribution));
            this.CBStepsEvklid = new System.Windows.Forms.ComboBox();
            this.LVInformation = new System.Windows.Forms.ListView();
            this.Panel = new System.Windows.Forms.Panel();
            this.picDraw = new System.Windows.Forms.PictureBox();
            this.InputTxtElements = new System.Windows.Forms.TextBox();
            this.InputTxtMarkElements = new System.Windows.Forms.TextBox();
            this.btnInputElements = new System.Windows.Forms.Button();
            this.LblInputEl = new System.Windows.Forms.Label();
            this.LblInputElMrk = new System.Windows.Forms.Label();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChoiseLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpDiametrElementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownDiametrElementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReversColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NumberingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputNumberingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NumberingRangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NumberingDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HourNumberingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StepNumberingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpElementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownElementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpMarkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownMarkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InformationOfStepsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileDialogLines = new System.Windows.Forms.OpenFileDialog();
            this.btnRotateLeft = new System.Windows.Forms.Button();
            this.btnRotateRight = new System.Windows.Forms.Button();
            this.UpIndentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownIndentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDraw)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBStepsEvklid
            // 
            this.CBStepsEvklid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBStepsEvklid.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBStepsEvklid.FormattingEnabled = true;
            this.CBStepsEvklid.Location = new System.Drawing.Point(282, 339);
            this.CBStepsEvklid.Name = "CBStepsEvklid";
            this.CBStepsEvklid.Size = new System.Drawing.Size(121, 27);
            this.CBStepsEvklid.TabIndex = 6;
            this.CBStepsEvklid.SelectedIndexChanged += new System.EventHandler(this.StepsEvklid_SelectedIndexChanged);
            // 
            // LVInformation
            // 
            this.LVInformation.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LVInformation.HideSelection = false;
            this.LVInformation.Location = new System.Drawing.Point(12, 158);
            this.LVInformation.Name = "LVInformation";
            this.LVInformation.Size = new System.Drawing.Size(121, 97);
            this.LVInformation.TabIndex = 8;
            this.LVInformation.UseCompatibleStateImageBehavior = false;
            this.LVInformation.View = System.Windows.Forms.View.Tile;
            // 
            // Panel
            // 
            this.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Panel.Controls.Add(this.picDraw);
            this.Panel.Location = new System.Drawing.Point(235, 158);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(270, 149);
            this.Panel.TabIndex = 9;
            // 
            // picDraw
            // 
            this.picDraw.BackColor = System.Drawing.Color.Black;
            this.picDraw.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picDraw.Location = new System.Drawing.Point(118, 62);
            this.picDraw.Name = "picDraw";
            this.picDraw.Size = new System.Drawing.Size(100, 50);
            this.picDraw.TabIndex = 0;
            this.picDraw.TabStop = false;
            // 
            // InputTxtElements
            // 
            this.InputTxtElements.Location = new System.Drawing.Point(560, 339);
            this.InputTxtElements.Name = "InputTxtElements";
            this.InputTxtElements.Size = new System.Drawing.Size(100, 22);
            this.InputTxtElements.TabIndex = 10;
            this.InputTxtElements.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputTxtElements_KeyPress);
            // 
            // InputTxtMarkElements
            // 
            this.InputTxtMarkElements.Location = new System.Drawing.Point(689, 339);
            this.InputTxtMarkElements.Name = "InputTxtMarkElements";
            this.InputTxtMarkElements.Size = new System.Drawing.Size(100, 22);
            this.InputTxtMarkElements.TabIndex = 11;
            this.InputTxtMarkElements.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputTxtMarkElements_KeyPress);
            // 
            // InputElements
            // 
            this.btnInputElements.Location = new System.Drawing.Point(560, 391);
            this.btnInputElements.Name = "InputElements";
            this.btnInputElements.Size = new System.Drawing.Size(135, 23);
            this.btnInputElements.TabIndex = 12;
            this.btnInputElements.Text = "Ввести";
            this.btnInputElements.UseVisualStyleBackColor = true;
            this.btnInputElements.Click += new System.EventHandler(this.InputElements_Click);
            // 
            // LblInputEl
            // 
            this.LblInputEl.AutoSize = true;
            this.LblInputEl.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblInputEl.Location = new System.Drawing.Point(595, 108);
            this.LblInputEl.Name = "LblInputEl";
            this.LblInputEl.Size = new System.Drawing.Size(258, 26);
            this.LblInputEl.TabIndex = 13;
            this.LblInputEl.Text = "Ввод кол-ва элементов";
            // 
            // LblInputElMrk
            // 
            this.LblInputElMrk.AutoSize = true;
            this.LblInputElMrk.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblInputElMrk.Location = new System.Drawing.Point(595, 134);
            this.LblInputElMrk.Name = "LblInputElMrk";
            this.LblInputElMrk.Size = new System.Drawing.Size(282, 26);
            this.LblInputElMrk.TabIndex = 14;
            this.LblInputElMrk.Text = "Ввод кол-ва маркировки";
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ViewToolStripMenuItem,
            this.NumberingToolStripMenuItem,
            this.UpElementsToolStripMenuItem,
            this.DownElementsToolStripMenuItem,
            this.UpMarkingToolStripMenuItem,
            this.DownMarkingToolStripMenuItem,
            this.InformationOfStepsToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1568, 28);
            this.MainMenu.TabIndex = 15;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChoiseLineToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // ChoiseLineToolStripMenuItem
            // 
            this.ChoiseLineToolStripMenuItem.Name = "ChoiseLineToolStripMenuItem";
            this.ChoiseLineToolStripMenuItem.Size = new System.Drawing.Size(203, 26);
            this.ChoiseLineToolStripMenuItem.Text = "Выбрать линию";
            this.ChoiseLineToolStripMenuItem.Click += new System.EventHandler(this.ChoiseLineToolStripMenuItem_Click);
            // 
            // ViewToolStripMenuItem
            // 
            this.ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpDiametrElementsToolStripMenuItem,
            this.DownDiametrElementsToolStripMenuItem,
            this.ReversColorsToolStripMenuItem,
            this.UpIndentToolStripMenuItem,
            this.DownIndentToolStripMenuItem,
            this.FontToolStripMenuItem});
            this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            this.ViewToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.ViewToolStripMenuItem.Text = "Вид";
            // 
            // UpDiametrElementsToolStripMenuItem
            // 
            this.UpDiametrElementsToolStripMenuItem.Name = "UpDiametrElementsToolStripMenuItem";
            this.UpDiametrElementsToolStripMenuItem.Size = new System.Drawing.Size(313, 26);
            this.UpDiametrElementsToolStripMenuItem.Text = "Увеличить диаметр элементов";
            this.UpDiametrElementsToolStripMenuItem.Click += new System.EventHandler(this.UpDiametrElementsToolStripMenuItem_Click);
            // 
            // DownDiametrElementsToolStripMenuItem
            // 
            this.DownDiametrElementsToolStripMenuItem.Name = "DownDiametrElementsToolStripMenuItem";
            this.DownDiametrElementsToolStripMenuItem.Size = new System.Drawing.Size(313, 26);
            this.DownDiametrElementsToolStripMenuItem.Text = "Уменьшить диаметр элементов";
            this.DownDiametrElementsToolStripMenuItem.Click += new System.EventHandler(this.DownDiametrElementsToolStripMenuItem_Click);
            // 
            // ReversColorsToolStripMenuItem
            // 
            this.ReversColorsToolStripMenuItem.Name = "ReversColorsToolStripMenuItem";
            this.ReversColorsToolStripMenuItem.Size = new System.Drawing.Size(313, 26);
            this.ReversColorsToolStripMenuItem.Text = "Инвертировать цвет";
            this.ReversColorsToolStripMenuItem.Click += new System.EventHandler(this.ReversColorsToolStripMenuItem_Click);
            // 
            // FontToolStripMenuItem
            // 
            this.FontToolStripMenuItem.Name = "FontToolStripMenuItem";
            this.FontToolStripMenuItem.Size = new System.Drawing.Size(313, 26);
            this.FontToolStripMenuItem.Text = "Шрифт";
            this.FontToolStripMenuItem.Click += new System.EventHandler(this.FontToolStripMenuItem_Click);
            // 
            // NumberingToolStripMenuItem
            // 
            this.NumberingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InputNumberingToolStripMenuItem,
            this.HourNumberingToolStripMenuItem,
            this.StepNumberingToolStripMenuItem});
            this.NumberingToolStripMenuItem.Name = "NumberingToolStripMenuItem";
            this.NumberingToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.NumberingToolStripMenuItem.Text = "Нумерация";
            // 
            // InputNumberingToolStripMenuItem
            // 
            this.InputNumberingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NumberingRangeToolStripMenuItem,
            this.NumberingDefaultToolStripMenuItem});
            this.InputNumberingToolStripMenuItem.Name = "InputNumberingToolStripMenuItem";
            this.InputNumberingToolStripMenuItem.Size = new System.Drawing.Size(275, 26);
            this.InputNumberingToolStripMenuItem.Text = "Ввести";
            // 
            // NumberingRangeToolStripMenuItem
            // 
            this.NumberingRangeToolStripMenuItem.Name = "NumberingRangeToolStripMenuItem";
            this.NumberingRangeToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.NumberingRangeToolStripMenuItem.Text = "Начать со значения...";
            this.NumberingRangeToolStripMenuItem.Click += new System.EventHandler(this.NumberingRangeToolStripMenuItem_Click);
            // 
            // NumberingDefaultToolStripMenuItem
            // 
            this.NumberingDefaultToolStripMenuItem.Name = "NumberingDefaultToolStripMenuItem";
            this.NumberingDefaultToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.NumberingDefaultToolStripMenuItem.Text = "По умолчанию";
            this.NumberingDefaultToolStripMenuItem.Click += new System.EventHandler(this.NumberingDefaultToolStripMenuItem_Click);
            // 
            // HourNumberingToolStripMenuItem
            // 
            this.HourNumberingToolStripMenuItem.Name = "HourNumberingToolStripMenuItem";
            this.HourNumberingToolStripMenuItem.Size = new System.Drawing.Size(275, 26);
            this.HourNumberingToolStripMenuItem.Text = "Провести против часовой";
            this.HourNumberingToolStripMenuItem.Click += new System.EventHandler(this.HourNumberingToolStripMenuItem_Click);
            // 
            // StepNumberingToolStripMenuItem
            // 
            this.StepNumberingToolStripMenuItem.Name = "StepNumberingToolStripMenuItem";
            this.StepNumberingToolStripMenuItem.Size = new System.Drawing.Size(275, 26);
            this.StepNumberingToolStripMenuItem.Text = "Провести с шагом 2";
            this.StepNumberingToolStripMenuItem.Click += new System.EventHandler(this.StepNumberingToolStripMenuItem_Click);
            // 
            // UpElementsToolStripMenuItem
            // 
            this.UpElementsToolStripMenuItem.Name = "UpElementsToolStripMenuItem";
            this.UpElementsToolStripMenuItem.Size = new System.Drawing.Size(257, 24);
            this.UpElementsToolStripMenuItem.Text = "Увеличить количество элементов";
            this.UpElementsToolStripMenuItem.Click += new System.EventHandler(this.UpElementsToolStripMenuItem_Click);
            // 
            // DownElementsToolStripMenuItem
            // 
            this.DownElementsToolStripMenuItem.Name = "DownElementsToolStripMenuItem";
            this.DownElementsToolStripMenuItem.Size = new System.Drawing.Size(264, 24);
            this.DownElementsToolStripMenuItem.Text = "Уменьшить количество элементов";
            this.DownElementsToolStripMenuItem.Click += new System.EventHandler(this.DownElementsToolStripMenuItem_Click);
            // 
            // UpMarkingToolStripMenuItem
            // 
            this.UpMarkingToolStripMenuItem.Name = "UpMarkingToolStripMenuItem";
            this.UpMarkingToolStripMenuItem.Size = new System.Drawing.Size(269, 24);
            this.UpMarkingToolStripMenuItem.Text = "Увеличить количество маркировки";
            this.UpMarkingToolStripMenuItem.Click += new System.EventHandler(this.UpMarkingToolStripMenuItem_Click);
            // 
            // DownMarkingToolStripMenuItem
            // 
            this.DownMarkingToolStripMenuItem.Name = "DownMarkingToolStripMenuItem";
            this.DownMarkingToolStripMenuItem.Size = new System.Drawing.Size(276, 24);
            this.DownMarkingToolStripMenuItem.Text = "Уменьшить количество маркировки";
            this.DownMarkingToolStripMenuItem.Click += new System.EventHandler(this.DownMarkingToolStripMenuItem_Click);
            // 
            // InformationOfStepsToolStripMenuItem
            // 
            this.InformationOfStepsToolStripMenuItem.Name = "InformationOfStepsToolStripMenuItem";
            this.InformationOfStepsToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.InformationOfStepsToolStripMenuItem.Text = "Информация";
            this.InformationOfStepsToolStripMenuItem.Click += new System.EventHandler(this.InformationOfStepsToolStripMenuItem_Click);
            // 
            // OpenFileDialogLines
            // 
            this.OpenFileDialogLines.FileName = "OpenFileDialogLines";
            this.OpenFileDialogLines.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialogLines_FileOk);
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRotateLeft.CausesValidation = false;
            this.btnRotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnRotateLeft.Image")));
            this.btnRotateLeft.Location = new System.Drawing.Point(1307, 158);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(82, 96);
            this.btnRotateLeft.TabIndex = 16;
            this.btnRotateLeft.UseVisualStyleBackColor = false;
            this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRotateRight.CausesValidation = false;
            this.btnRotateRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRotateRight.Image")));
            this.btnRotateRight.Location = new System.Drawing.Point(1219, 158);
            this.btnRotateRight.Name = "btnRotateRight";
            this.btnRotateRight.Size = new System.Drawing.Size(82, 96);
            this.btnRotateRight.TabIndex = 17;
            this.btnRotateRight.UseVisualStyleBackColor = false;
            this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // UpIndentToolStripMenuItem
            // 
            this.UpIndentToolStripMenuItem.Name = "UpIndentToolStripMenuItem";
            this.UpIndentToolStripMenuItem.Size = new System.Drawing.Size(313, 26);
            this.UpIndentToolStripMenuItem.Text = "Увеличить отступ";
            this.UpIndentToolStripMenuItem.Click += new System.EventHandler(this.UpIndentToolStripMenuItem_Click);
            // 
            // DownIndentToolStripMenuItem
            // 
            this.DownIndentToolStripMenuItem.Name = "DownIndentToolStripMenuItem";
            this.DownIndentToolStripMenuItem.Size = new System.Drawing.Size(313, 26);
            this.DownIndentToolStripMenuItem.Text = "Уменьшить отступ";
            this.DownIndentToolStripMenuItem.Click += new System.EventHandler(this.DownIndentToolStripMenuItem_Click);
            // 
            // frmUniformDistribution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1568, 450);
            this.Controls.Add(this.btnRotateRight);
            this.Controls.Add(this.btnRotateLeft);
            this.Controls.Add(this.LblInputElMrk);
            this.Controls.Add(this.LblInputEl);
            this.Controls.Add(this.btnInputElements);
            this.Controls.Add(this.InputTxtMarkElements);
            this.Controls.Add(this.InputTxtElements);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.LVInformation);
            this.Controls.Add(this.CBStepsEvklid);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "frmUniformDistribution";
            this.Text = "Равномерное распределение";
            this.Load += new System.EventHandler(this.frmUniformDistribution_Load);
            this.Resize += new System.EventHandler(this.frmUniformDistribution_Resize);
            this.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDraw)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox CBStepsEvklid;
        private System.Windows.Forms.ListView LVInformation;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.PictureBox picDraw;
        private System.Windows.Forms.TextBox InputTxtElements;
        private System.Windows.Forms.TextBox InputTxtMarkElements;
        private System.Windows.Forms.Button btnInputElements;
        private System.Windows.Forms.Label LblInputEl;
        private System.Windows.Forms.Label LblInputElMrk;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem ViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpDiametrElementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownDiametrElementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReversColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpElementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownElementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpMarkingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownMarkingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NumberingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InformationOfStepsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InputNumberingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NumberingRangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NumberingDefaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HourNumberingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StepNumberingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChoiseLineToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogLines;
        private System.Windows.Forms.Button btnRotateLeft;
        private System.Windows.Forms.Button btnRotateRight;
        private System.Windows.Forms.ToolStripMenuItem FontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpIndentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownIndentToolStripMenuItem;
    }
}

