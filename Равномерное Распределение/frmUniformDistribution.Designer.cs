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
            this.DrawElPlus = new System.Windows.Forms.Button();
            this.DrawElMinus = new System.Windows.Forms.Button();
            this.PickElPlus = new System.Windows.Forms.Button();
            this.PickElMinus = new System.Windows.Forms.Button();
            this.StepsEvklid = new System.Windows.Forms.ComboBox();
            this.clrcircle = new System.Windows.Forms.Label();
            this.Information = new System.Windows.Forms.ListView();
            this.Panel = new System.Windows.Forms.Panel();
            this.picDraw = new System.Windows.Forms.PictureBox();
            this.InputTxtElements = new System.Windows.Forms.TextBox();
            this.InputTxtMarkElements = new System.Windows.Forms.TextBox();
            this.InputElements = new System.Windows.Forms.Button();
            this.LblInputEl = new System.Windows.Forms.Label();
            this.LblInputElMrk = new System.Windows.Forms.Label();
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDraw)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawElPlus
            // 
            this.DrawElPlus.BackColor = System.Drawing.SystemColors.Window;
            this.DrawElPlus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DrawElPlus.Location = new System.Drawing.Point(471, 101);
            this.DrawElPlus.Name = "DrawElPlus";
            this.DrawElPlus.Size = new System.Drawing.Size(317, 37);
            this.DrawElPlus.TabIndex = 0;
            this.DrawElPlus.Text = "Увеличить кол-во элементов";
            this.DrawElPlus.UseVisualStyleBackColor = false;
            this.DrawElPlus.Click += new System.EventHandler(this.DrawElPlus_Click);
            // 
            // DrawElMinus
            // 
            this.DrawElMinus.BackColor = System.Drawing.SystemColors.Window;
            this.DrawElMinus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DrawElMinus.Location = new System.Drawing.Point(12, 101);
            this.DrawElMinus.Name = "DrawElMinus";
            this.DrawElMinus.Size = new System.Drawing.Size(453, 37);
            this.DrawElMinus.TabIndex = 1;
            this.DrawElMinus.Text = "Уменьшить кол-во элементов";
            this.DrawElMinus.UseVisualStyleBackColor = false;
            this.DrawElMinus.Click += new System.EventHandler(this.DrawElMinus_Click);
            // 
            // PickElPlus
            // 
            this.PickElPlus.BackColor = System.Drawing.SystemColors.Window;
            this.PickElPlus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PickElPlus.Location = new System.Drawing.Point(12, 52);
            this.PickElPlus.Name = "PickElPlus";
            this.PickElPlus.Size = new System.Drawing.Size(453, 43);
            this.PickElPlus.TabIndex = 2;
            this.PickElPlus.Text = "Увеличить кол-во маркированных элементов";
            this.PickElPlus.UseVisualStyleBackColor = false;
            this.PickElPlus.Click += new System.EventHandler(this.PickElPlus_Click);
            // 
            // PickElMinus
            // 
            this.PickElMinus.BackColor = System.Drawing.SystemColors.Window;
            this.PickElMinus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PickElMinus.Location = new System.Drawing.Point(12, 2);
            this.PickElMinus.Name = "PickElMinus";
            this.PickElMinus.Size = new System.Drawing.Size(453, 44);
            this.PickElMinus.TabIndex = 3;
            this.PickElMinus.Text = "Уменьшить кол-во маркированных элементов";
            this.PickElMinus.UseVisualStyleBackColor = false;
            this.PickElMinus.Click += new System.EventHandler(this.PickElMinus_Click);
            // 
            // StepsEvklid
            // 
            this.StepsEvklid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StepsEvklid.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StepsEvklid.FormattingEnabled = true;
            this.StepsEvklid.Location = new System.Drawing.Point(282, 339);
            this.StepsEvklid.Name = "StepsEvklid";
            this.StepsEvklid.Size = new System.Drawing.Size(121, 27);
            this.StepsEvklid.TabIndex = 6;
            this.StepsEvklid.SelectedIndexChanged += new System.EventHandler(this.StepsEvklid_SelectedIndexChanged);
            // 
            // clrcircle
            // 
            this.clrcircle.AutoSize = true;
            this.clrcircle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clrcircle.Location = new System.Drawing.Point(514, 158);
            this.clrcircle.Name = "clrcircle";
            this.clrcircle.Size = new System.Drawing.Size(276, 32);
            this.clrcircle.TabIndex = 7;
            this.clrcircle.Text = "Инвертировать цвет";
            this.clrcircle.Click += new System.EventHandler(this.clrcircle_Click);
            // 
            // Information
            // 
            this.Information.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Information.HideSelection = false;
            this.Information.Location = new System.Drawing.Point(12, 158);
            this.Information.Name = "Information";
            this.Information.Size = new System.Drawing.Size(121, 97);
            this.Information.TabIndex = 8;
            this.Information.UseCompatibleStateImageBehavior = false;
            this.Information.View = System.Windows.Forms.View.Tile;
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
            this.InputElements.Location = new System.Drawing.Point(560, 391);
            this.InputElements.Name = "InputElements";
            this.InputElements.Size = new System.Drawing.Size(135, 23);
            this.InputElements.TabIndex = 12;
            this.InputElements.Text = "Ввести";
            this.InputElements.UseVisualStyleBackColor = true;
            this.InputElements.Click += new System.EventHandler(this.InputElements_Click);
            // 
            // LblInputEl
            // 
            this.LblInputEl.AutoSize = true;
            this.LblInputEl.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblInputEl.Location = new System.Drawing.Point(389, 310);
            this.LblInputEl.Name = "LblInputEl";
            this.LblInputEl.Size = new System.Drawing.Size(347, 26);
            this.LblInputEl.TabIndex = 13;
            this.LblInputEl.Text = "Введите количество элементов";
            // 
            // LblInputElMrk
            // 
            this.LblInputElMrk.AutoSize = true;
            this.LblInputElMrk.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblInputElMrk.Location = new System.Drawing.Point(39, 391);
            this.LblInputElMrk.Name = "LblInputElMrk";
            this.LblInputElMrk.Size = new System.Drawing.Size(530, 26);
            this.LblInputElMrk.TabIndex = 14;
            this.LblInputElMrk.Text = "Введите количество маркированных элементов";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblInputElMrk);
            this.Controls.Add(this.LblInputEl);
            this.Controls.Add(this.InputElements);
            this.Controls.Add(this.InputTxtMarkElements);
            this.Controls.Add(this.InputTxtElements);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.Information);
            this.Controls.Add(this.clrcircle);
            this.Controls.Add(this.StepsEvklid);
            this.Controls.Add(this.PickElMinus);
            this.Controls.Add(this.PickElPlus);
            this.Controls.Add(this.DrawElMinus);
            this.Controls.Add(this.DrawElPlus);
            this.Name = "frmMain";
            this.Text = "Равномерное распределение";
            this.Load += new System.EventHandler(this.frmUniformDistribution_Load);
            this.Resize += new System.EventHandler(this.frmUniformDistribution_Resize);
            this.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDraw)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DrawElPlus;
        private System.Windows.Forms.Button DrawElMinus;
        private System.Windows.Forms.Button PickElPlus;
        private System.Windows.Forms.Button PickElMinus;
        private System.Windows.Forms.ComboBox StepsEvklid;
        private System.Windows.Forms.Label clrcircle;
        private System.Windows.Forms.ListView Information;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.PictureBox picDraw;
        private System.Windows.Forms.TextBox InputTxtElements;
        private System.Windows.Forms.TextBox InputTxtMarkElements;
        private System.Windows.Forms.Button InputElements;
        private System.Windows.Forms.Label LblInputEl;
        private System.Windows.Forms.Label LblInputElMrk;
    }
}

