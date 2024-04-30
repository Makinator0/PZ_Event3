namespace PZ_Event3
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxRoom1 = new System.Windows.Forms.ListBox();
            this.listBoxRoom2 = new System.Windows.Forms.ListBox();
            this.listBoxRoom3 = new System.Windows.Forms.ListBox();
            this.SerButton = new System.Windows.Forms.Button();
            this.DeSerButton = new System.Windows.Forms.Button();
            this.DelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(56, 413);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "Створення";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(573, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // listBoxRoom1
            // 
            this.listBoxRoom1.FormattingEnabled = true;
            this.listBoxRoom1.Location = new System.Drawing.Point(56, 131);
            this.listBoxRoom1.Name = "listBoxRoom1";
            this.listBoxRoom1.Size = new System.Drawing.Size(250, 238);
            this.listBoxRoom1.TabIndex = 4;
            // 
            // listBoxRoom2
            // 
            this.listBoxRoom2.FormattingEnabled = true;
            this.listBoxRoom2.Location = new System.Drawing.Point(320, 131);
            this.listBoxRoom2.Name = "listBoxRoom2";
            this.listBoxRoom2.Size = new System.Drawing.Size(250, 238);
            this.listBoxRoom2.TabIndex = 5;
            // 
            // listBoxRoom3
            // 
            this.listBoxRoom3.FormattingEnabled = true;
            this.listBoxRoom3.Location = new System.Drawing.Point(576, 131);
            this.listBoxRoom3.Name = "listBoxRoom3";
            this.listBoxRoom3.Size = new System.Drawing.Size(250, 238);
            this.listBoxRoom3.TabIndex = 6;
            // 
            // SerButton
            // 
            this.SerButton.Location = new System.Drawing.Point(241, 413);
            this.SerButton.Name = "SerButton";
            this.SerButton.Size = new System.Drawing.Size(139, 58);
            this.SerButton.TabIndex = 7;
            this.SerButton.Text = "SerButton";
            this.SerButton.UseVisualStyleBackColor = true;
            this.SerButton.Click += new System.EventHandler(this.SerButton_Click);
            // 
            // DeSerButton
            // 
            this.DeSerButton.Location = new System.Drawing.Point(408, 413);
            this.DeSerButton.Name = "DeSerButton";
            this.DeSerButton.Size = new System.Drawing.Size(139, 58);
            this.DeSerButton.TabIndex = 8;
            this.DeSerButton.Text = "DeSerButton";
            this.DeSerButton.UseVisualStyleBackColor = true;
            this.DeSerButton.Click += new System.EventHandler(this.DeSerButton_Click);
            // 
            // DelButton
            // 
            this.DelButton.Location = new System.Drawing.Point(576, 413);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(139, 58);
            this.DelButton.TabIndex = 9;
            this.DelButton.Text = "Видалення";
            this.DelButton.UseVisualStyleBackColor = true;
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 552);
            this.Controls.Add(this.DelButton);
            this.Controls.Add(this.DeSerButton);
            this.Controls.Add(this.SerButton);
            this.Controls.Add(this.listBoxRoom3);
            this.Controls.Add(this.listBoxRoom2);
            this.Controls.Add(this.listBoxRoom1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxRoom1;
        private System.Windows.Forms.ListBox listBoxRoom2;
        private System.Windows.Forms.ListBox listBoxRoom3;
        private System.Windows.Forms.Button SerButton;
        private System.Windows.Forms.Button DeSerButton;
        private System.Windows.Forms.Button DelButton;
    }
}

