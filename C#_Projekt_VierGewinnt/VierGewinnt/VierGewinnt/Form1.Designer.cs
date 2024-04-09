namespace VierGewinnt
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.vierGewinnt1 = new VierGewinnt();
            this.SuspendLayout();
            // 
            // vierGewinnt1
            // 
            this.vierGewinnt1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vierGewinnt1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.vierGewinnt1.Location = new System.Drawing.Point(0, 1);
            this.vierGewinnt1.Name = "vierGewinnt1";
            this.vierGewinnt1.Size = new System.Drawing.Size(583, 591);
            this.vierGewinnt1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 591);
            this.Controls.Add(this.vierGewinnt1);
            this.MinimumSize = new System.Drawing.Size(600, 630);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private VierGewinnt vierGewinnt1;
    }
}

