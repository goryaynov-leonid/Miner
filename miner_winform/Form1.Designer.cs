namespace miner_winform
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.layer1 = new System.Windows.Forms.PictureBox();
            this.layer2 = new System.Windows.Forms.PictureBox();
            this.layer3 = new System.Windows.Forms.PictureBox();
            this.labelLayer1 = new System.Windows.Forms.Label();
            this.labelLayer2 = new System.Windows.Forms.Label();
            this.labelLayer3 = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.textWidth = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelDepth = new System.Windows.Forms.Label();
            this.textHeight = new System.Windows.Forms.TextBox();
            this.textDepth = new System.Windows.Forms.TextBox();
            this.btnTurnLeft = new System.Windows.Forms.Button();
            this.btnTurnRight = new System.Windows.Forms.Button();
            this.labelMines = new System.Windows.Forms.Label();
            this.labelMineCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textLives = new System.Windows.Forms.TextBox();
            this.labelLives = new System.Windows.Forms.Label();
            this.labelCountLives = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.layer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layer3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 428);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(65, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStartClick);
            // 
            // layer1
            // 
            this.layer1.Location = new System.Drawing.Point(12, 12);
            this.layer1.Name = "layer1";
            this.layer1.Size = new System.Drawing.Size(252, 252);
            this.layer1.TabIndex = 1;
            this.layer1.TabStop = false;
            this.layer1.Paint += new System.Windows.Forms.PaintEventHandler(this.Layer1Paint);
            this.layer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.layer1_MouseDown);
            // 
            // layer2
            // 
            this.layer2.Location = new System.Drawing.Point(270, 12);
            this.layer2.Name = "layer2";
            this.layer2.Size = new System.Drawing.Size(252, 252);
            this.layer2.TabIndex = 2;
            this.layer2.TabStop = false;
            this.layer2.Paint += new System.Windows.Forms.PaintEventHandler(this.layer2_Paint);
            this.layer2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.layer2_MouseDown);
            // 
            // layer3
            // 
            this.layer3.Location = new System.Drawing.Point(529, 12);
            this.layer3.Name = "layer3";
            this.layer3.Size = new System.Drawing.Size(252, 252);
            this.layer3.TabIndex = 3;
            this.layer3.TabStop = false;
            this.layer3.Paint += new System.Windows.Forms.PaintEventHandler(this.layer3_Paint);
            this.layer3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.layer3_MouseDown);
            // 
            // labelLayer1
            // 
            this.labelLayer1.AutoSize = true;
            this.labelLayer1.Location = new System.Drawing.Point(13, 271);
            this.labelLayer1.Name = "labelLayer1";
            this.labelLayer1.Size = new System.Drawing.Size(0, 13);
            this.labelLayer1.TabIndex = 4;
            // 
            // labelLayer2
            // 
            this.labelLayer2.AutoSize = true;
            this.labelLayer2.Location = new System.Drawing.Point(275, 271);
            this.labelLayer2.Name = "labelLayer2";
            this.labelLayer2.Size = new System.Drawing.Size(0, 13);
            this.labelLayer2.TabIndex = 5;
            // 
            // labelLayer3
            // 
            this.labelLayer3.AutoSize = true;
            this.labelLayer3.Location = new System.Drawing.Point(528, 267);
            this.labelLayer3.Name = "labelLayer3";
            this.labelLayer3.Size = new System.Drawing.Size(0, 13);
            this.labelLayer3.TabIndex = 6;
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(9, 324);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(68, 13);
            this.labelWidth.TabIndex = 7;
            this.labelWidth.Text = "Width (3-10):";
            // 
            // textWidth
            // 
            this.textWidth.Location = new System.Drawing.Point(119, 324);
            this.textWidth.Name = "textWidth";
            this.textWidth.Size = new System.Drawing.Size(100, 20);
            this.textWidth.TabIndex = 8;
            this.textWidth.Text = "3";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(9, 350);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(71, 13);
            this.labelHeight.TabIndex = 9;
            this.labelHeight.Text = "Height (3-10):";
            // 
            // labelDepth
            // 
            this.labelDepth.AutoSize = true;
            this.labelDepth.Location = new System.Drawing.Point(9, 376);
            this.labelDepth.Name = "labelDepth";
            this.labelDepth.Size = new System.Drawing.Size(69, 13);
            this.labelDepth.TabIndex = 10;
            this.labelDepth.Text = "Depth (3-10):";
            // 
            // textHeight
            // 
            this.textHeight.Location = new System.Drawing.Point(119, 350);
            this.textHeight.Name = "textHeight";
            this.textHeight.Size = new System.Drawing.Size(100, 20);
            this.textHeight.TabIndex = 11;
            this.textHeight.Text = "3";
            // 
            // textDepth
            // 
            this.textDepth.Location = new System.Drawing.Point(119, 376);
            this.textDepth.Name = "textDepth";
            this.textDepth.Size = new System.Drawing.Size(100, 20);
            this.textDepth.TabIndex = 12;
            this.textDepth.Text = "3";
            // 
            // btnTurnLeft
            // 
            this.btnTurnLeft.Enabled = false;
            this.btnTurnLeft.Location = new System.Drawing.Point(234, 270);
            this.btnTurnLeft.Name = "btnTurnLeft";
            this.btnTurnLeft.Size = new System.Drawing.Size(30, 23);
            this.btnTurnLeft.TabIndex = 13;
            this.btnTurnLeft.Text = "<<";
            this.btnTurnLeft.UseVisualStyleBackColor = true;
            this.btnTurnLeft.Visible = false;
            this.btnTurnLeft.Click += new System.EventHandler(this.btnTurnLeft_Click);
            // 
            // btnTurnRight
            // 
            this.btnTurnRight.Enabled = false;
            this.btnTurnRight.Location = new System.Drawing.Point(492, 270);
            this.btnTurnRight.Name = "btnTurnRight";
            this.btnTurnRight.Size = new System.Drawing.Size(30, 23);
            this.btnTurnRight.TabIndex = 14;
            this.btnTurnRight.Text = ">>";
            this.btnTurnRight.UseVisualStyleBackColor = true;
            this.btnTurnRight.Visible = false;
            this.btnTurnRight.Click += new System.EventHandler(this.btnTurnRight_Click);
            // 
            // labelMines
            // 
            this.labelMines.AutoSize = true;
            this.labelMines.Location = new System.Drawing.Point(275, 331);
            this.labelMines.Name = "labelMines";
            this.labelMines.Size = new System.Drawing.Size(0, 13);
            this.labelMines.TabIndex = 15;
            // 
            // labelMineCount
            // 
            this.labelMineCount.AutoSize = true;
            this.labelMineCount.Location = new System.Drawing.Point(380, 331);
            this.labelMineCount.Name = "labelMineCount";
            this.labelMineCount.Size = new System.Drawing.Size(0, 13);
            this.labelMineCount.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(637, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Created by Leonid Goryaynov";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Count of lives";
            // 
            // textLives
            // 
            this.textLives.Location = new System.Drawing.Point(119, 403);
            this.textLives.Name = "textLives";
            this.textLives.Size = new System.Drawing.Size(100, 20);
            this.textLives.TabIndex = 19;
            this.textLives.Text = "1";
            // 
            // labelLives
            // 
            this.labelLives.AutoSize = true;
            this.labelLives.Location = new System.Drawing.Point(275, 357);
            this.labelLives.Name = "labelLives";
            this.labelLives.Size = new System.Drawing.Size(0, 13);
            this.labelLives.TabIndex = 20;
            // 
            // labelCountLives
            // 
            this.labelCountLives.AutoSize = true;
            this.labelCountLives.Location = new System.Drawing.Point(380, 357);
            this.labelCountLives.Name = "labelCountLives";
            this.labelCountLives.Size = new System.Drawing.Size(0, 13);
            this.labelCountLives.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 460);
            this.Controls.Add(this.labelCountLives);
            this.Controls.Add(this.labelLives);
            this.Controls.Add(this.textLives);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMineCount);
            this.Controls.Add(this.labelMines);
            this.Controls.Add(this.btnTurnRight);
            this.Controls.Add(this.btnTurnLeft);
            this.Controls.Add(this.textDepth);
            this.Controls.Add(this.textHeight);
            this.Controls.Add(this.labelDepth);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.textWidth);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.labelLayer3);
            this.Controls.Add(this.labelLayer2);
            this.Controls.Add(this.labelLayer1);
            this.Controls.Add(this.layer3);
            this.Controls.Add(this.layer2);
            this.Controls.Add(this.layer1);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.layer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layer3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox layer1;
        private System.Windows.Forms.PictureBox layer2;
        private System.Windows.Forms.PictureBox layer3;
        private System.Windows.Forms.Label labelLayer1;
        private System.Windows.Forms.Label labelLayer2;
        private System.Windows.Forms.Label labelLayer3;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.TextBox textWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelDepth;
        private System.Windows.Forms.TextBox textHeight;
        private System.Windows.Forms.TextBox textDepth;
        private System.Windows.Forms.Button btnTurnLeft;
        private System.Windows.Forms.Button btnTurnRight;
        private System.Windows.Forms.Label labelMines;
        private System.Windows.Forms.Label labelMineCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textLives;
        private System.Windows.Forms.Label labelLives;
        private System.Windows.Forms.Label labelCountLives;
    }
}

