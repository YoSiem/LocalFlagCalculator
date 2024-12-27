namespace LocalFlagCalculator.LocalFlagCalculator
{
    partial class FlagCalculator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            Button_Copy = new Button();
            Button_Import = new Button();
            Button_Reset = new Button();
            tabControl1 = new TabControl();
            PAGE_LOCAL_FLAG = new TabPage();
            PAGE_STATE_TIME = new TabPage();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox1.Location = new Point(244, 357);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(170, 23);
            textBox1.TabIndex = 19;
            // 
            // Button_Copy
            // 
            Button_Copy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Button_Copy.Location = new Point(163, 356);
            Button_Copy.Name = "Button_Copy";
            Button_Copy.Size = new Size(75, 24);
            Button_Copy.TabIndex = 21;
            Button_Copy.Text = "Copy";
            Button_Copy.UseVisualStyleBackColor = true;
            Button_Copy.Click += Button_Copy_Click;
            // 
            // Button_Import
            // 
            Button_Import.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Button_Import.Location = new Point(420, 356);
            Button_Import.Name = "Button_Import";
            Button_Import.Size = new Size(75, 24);
            Button_Import.TabIndex = 22;
            Button_Import.Text = "Import";
            Button_Import.UseVisualStyleBackColor = true;
            Button_Import.Click += Button_Import_Click;
            // 
            // Button_Reset
            // 
            Button_Reset.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Button_Reset.Location = new Point(284, 386);
            Button_Reset.Name = "Button_Reset";
            Button_Reset.Size = new Size(89, 29);
            Button_Reset.TabIndex = 27;
            Button_Reset.Text = "Reset";
            Button_Reset.UseVisualStyleBackColor = true;
            Button_Reset.Click += Button_Reset_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(PAGE_LOCAL_FLAG);
            tabControl1.Controls.Add(PAGE_STATE_TIME);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(650, 350);
            tabControl1.TabIndex = 28;
            // 
            // PAGE_LOCAL_FLAG
            // 
            PAGE_LOCAL_FLAG.BackColor = Color.DarkGray;
            PAGE_LOCAL_FLAG.Location = new Point(4, 24);
            PAGE_LOCAL_FLAG.Margin = new Padding(0, 0, 0, 300);
            PAGE_LOCAL_FLAG.Name = "PAGE_LOCAL_FLAG";
            PAGE_LOCAL_FLAG.Padding = new Padding(3);
            PAGE_LOCAL_FLAG.Size = new Size(642, 322);
            PAGE_LOCAL_FLAG.TabIndex = 0;
            PAGE_LOCAL_FLAG.Text = "Local Flag";
            // 
            // PAGE_STATE_TIME
            // 
            PAGE_STATE_TIME.BackColor = Color.DarkGray;
            PAGE_STATE_TIME.Location = new Point(4, 24);
            PAGE_STATE_TIME.Name = "PAGE_STATE_TIME";
            PAGE_STATE_TIME.Padding = new Padding(3);
            PAGE_STATE_TIME.Size = new Size(642, 322);
            PAGE_STATE_TIME.TabIndex = 1;
            PAGE_STATE_TIME.Text = "State Time";
            // 
            // FlagCalculator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(649, 430);
            Controls.Add(tabControl1);
            Controls.Add(Button_Reset);
            Controls.Add(textBox1);
            Controls.Add(Button_Copy);
            Controls.Add(Button_Import);
            Name = "FlagCalculator";
            Text = "FlagCalculator YSM";
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Button Button_Copy;
        private Button Button_Import;
        private Button Button_Reset;
        private TabControl tabControl1;
        private TabPage PAGE_LOCAL_FLAG;
        private TabPage PAGE_STATE_TIME;
    }
}