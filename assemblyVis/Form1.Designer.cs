namespace assemblyVis
{
    partial class nasmVis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button4 = new System.Windows.Forms.Button();
            this.forwardBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.registers = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.codeTxt = new System.Windows.Forms.RichTextBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.enterButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.binaryButton = new System.Windows.Forms.Button();
            this.hexButton = new System.Windows.Forms.Button();
            this.stackText = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(569, 480);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(171, 43);
            this.button4.TabIndex = 27;
            this.button4.Text = "Clear Text";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // forwardBtn
            // 
            this.forwardBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.forwardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forwardBtn.ForeColor = System.Drawing.Color.White;
            this.forwardBtn.Location = new System.Drawing.Point(384, 433);
            this.forwardBtn.Name = "forwardBtn";
            this.forwardBtn.Size = new System.Drawing.Size(179, 41);
            this.forwardBtn.TabIndex = 26;
            this.forwardBtn.Text = "Step Forward";
            this.forwardBtn.UseVisualStyleBackColor = true;
            this.forwardBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(569, 434);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 40);
            this.button2.TabIndex = 25;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(853, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Stack and Registers ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(512, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Console";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(517, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Preview";
            // 
            // registers
            // 
            this.registers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.registers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.registers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registers.ForeColor = System.Drawing.SystemColors.Window;
            this.registers.Location = new System.Drawing.Point(746, 323);
            this.registers.Multiline = true;
            this.registers.Name = "registers";
            this.registers.ReadOnly = true;
            this.registers.Size = new System.Drawing.Size(370, 201);
            this.registers.TabIndex = 18;
            this.registers.Text = "EAX: 00000000\r\nEBX: 00000000\r\nECX: 00000000\r\nEDX: 00000000\r\nESI: 00000000\r\nEDI: 0" +
    "0000000\r\nEDP: 00000000\r\nESP: 00000000\r\n";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox3.HideSelection = false;
            this.textBox3.Location = new System.Drawing.Point(391, 201);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(342, 130);
            this.textBox3.TabIndex = 17;
            // 
            // button5
            // 
            this.button5.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(384, 480);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(179, 43);
            this.button5.TabIndex = 16;
            this.button5.Text = "Run";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(391, 38);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(342, 127);
            this.textBox2.TabIndex = 15;
            this.textBox2.WordWrap = false;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // codeTxt
            // 
            this.codeTxt.AcceptsTab = true;
            this.codeTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.codeTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.codeTxt.ForeColor = System.Drawing.SystemColors.Window;
            this.codeTxt.Location = new System.Drawing.Point(12, 168);
            this.codeTxt.Name = "codeTxt";
            this.codeTxt.Size = new System.Drawing.Size(360, 355);
            this.codeTxt.TabIndex = 28;
            this.codeTxt.Text = "asm_main:\npush ebp\nmov ebp, esp\n; ********** CODE STARTS HERE **********\n    \n\t\n\n" +
    "; *********** CODE ENDS HERE ***********\nmov eax, 0\nmov esp, ebp\npop ebp\nret";
            this.codeTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textUser
            // 
            this.textUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.textUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textUser.ForeColor = System.Drawing.SystemColors.Window;
            this.textUser.Location = new System.Drawing.Point(391, 370);
            this.textUser.Multiline = true;
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(279, 58);
            this.textUser.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(512, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "User Input";
            // 
            // enterButton
            // 
            this.enterButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.enterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.enterButton.ForeColor = System.Drawing.Color.White;
            this.enterButton.Location = new System.Drawing.Point(676, 370);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(64, 58);
            this.enterButton.TabIndex = 31;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(981, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 41);
            this.button1.TabIndex = 32;
            this.button1.Text = "Decimal";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // binaryButton
            // 
            this.binaryButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.binaryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.binaryButton.ForeColor = System.Drawing.Color.White;
            this.binaryButton.Location = new System.Drawing.Point(857, 276);
            this.binaryButton.Name = "binaryButton";
            this.binaryButton.Size = new System.Drawing.Size(118, 41);
            this.binaryButton.TabIndex = 33;
            this.binaryButton.Text = "Binary";
            this.binaryButton.UseVisualStyleBackColor = true;
            this.binaryButton.Click += new System.EventHandler(this.binaryButton_Click);
            // 
            // hexButton
            // 
            this.hexButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.hexButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hexButton.ForeColor = System.Drawing.Color.White;
            this.hexButton.Location = new System.Drawing.Point(746, 276);
            this.hexButton.Name = "hexButton";
            this.hexButton.Size = new System.Drawing.Size(105, 41);
            this.hexButton.TabIndex = 34;
            this.hexButton.Text = "Hex";
            this.hexButton.UseVisualStyleBackColor = true;
            this.hexButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // stackText
            // 
            this.stackText.AcceptsTab = true;
            this.stackText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.stackText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stackText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.stackText.ForeColor = System.Drawing.SystemColors.Window;
            this.stackText.Location = new System.Drawing.Point(746, 38);
            this.stackText.Name = "stackText";
            this.stackText.ShowSelectionMargin = true;
            this.stackText.Size = new System.Drawing.Size(370, 232);
            this.stackText.TabIndex = 35;
            this.stackText.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(12, 38);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(360, 124);
            this.richTextBox1.TabIndex = 36;
            this.richTextBox1.Text = "segment .data\n\nsegment .bss\n\nsegment .text\n\tglobal  asm_main";
            // 
            // nasmVis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1133, 540);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.stackText);
            this.Controls.Add(this.hexButton);
            this.Controls.Add(this.binaryButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textUser);
            this.Controls.Add(this.codeTxt);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.forwardBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.registers);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "nasmVis";
            this.Text = "Assembly Visualizer";
            this.Load += new System.EventHandler(this.nasmVis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button forwardBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox registers;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RichTextBox codeTxt;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button binaryButton;
        private System.Windows.Forms.Button hexButton;
        public System.Windows.Forms.RichTextBox stackText;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

