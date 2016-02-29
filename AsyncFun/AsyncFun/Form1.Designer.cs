namespace AsyncFun
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
            this.btnCallMethod = new System.Windows.Forms.Button();
            this.btnMultiAwaits = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCallMethod
            // 
            this.btnCallMethod.Location = new System.Drawing.Point(12, 12);
            this.btnCallMethod.Name = "btnCallMethod";
            this.btnCallMethod.Size = new System.Drawing.Size(260, 23);
            this.btnCallMethod.TabIndex = 0;
            this.btnCallMethod.Text = "button1";
            this.btnCallMethod.UseVisualStyleBackColor = true;
            this.btnCallMethod.Click += new System.EventHandler(this.btnCallMethod_Click);
            // 
            // btnMultiAwaits
            // 
            this.btnMultiAwaits.Location = new System.Drawing.Point(12, 41);
            this.btnMultiAwaits.Name = "btnMultiAwaits";
            this.btnMultiAwaits.Size = new System.Drawing.Size(260, 23);
            this.btnMultiAwaits.TabIndex = 1;
            this.btnMultiAwaits.Text = "button1";
            this.btnMultiAwaits.UseVisualStyleBackColor = true;
            this.btnMultiAwaits.Click += new System.EventHandler(this.btnMultiAwaits_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnMultiAwaits);
            this.Controls.Add(this.btnCallMethod);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCallMethod;
        private System.Windows.Forms.Button btnMultiAwaits;
    }
}

