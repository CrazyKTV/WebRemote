namespace crazyKTV
{
    partial class transparentButton
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.transparentControl1 = new crazyKTV.TransparentControl();
            this.button1 = new System.Windows.Forms.Button();
            // 
            // transparentControl1
            // 
            this.transparentControl1.BackColor = System.Drawing.Color.Transparent;
            this.transparentControl1.Image = null;
            this.transparentControl1.Location = new System.Drawing.Point(0, 0);
            this.transparentControl1.Name = "transparentControl1";
            this.transparentControl1.Size = new System.Drawing.Size(0, 0);
            this.transparentControl1.TabIndex = 0;
            this.transparentControl1.Text = "transparentControl1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;

        }

        #endregion

        private TransparentControl transparentControl1;
        private System.Windows.Forms.Button button1;
    }
}
