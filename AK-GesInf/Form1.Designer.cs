namespace AK_GesInf
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
            this.icd10View = new System.Windows.Forms.ListView();
            this.listViewSearchBox = new System.Windows.Forms.TextBox();
            this.listViewSearchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // icd10View
            // 
            this.icd10View.GridLines = true;
            this.icd10View.Location = new System.Drawing.Point(12, 72);
            this.icd10View.Name = "icd10View";
            this.icd10View.Size = new System.Drawing.Size(760, 420);
            this.icd10View.TabIndex = 0;
            this.icd10View.UseCompatibleStateImageBehavior = false;
            // 
            // listViewSearchBox
            // 
            this.listViewSearchBox.Location = new System.Drawing.Point(13, 46);
            this.listViewSearchBox.Name = "listViewSearchBox";
            this.listViewSearchBox.Size = new System.Drawing.Size(641, 20);
            this.listViewSearchBox.TabIndex = 1;
            // 
            // listViewSearchButton
            // 
            this.listViewSearchButton.Location = new System.Drawing.Point(660, 43);
            this.listViewSearchButton.Name = "listViewSearchButton";
            this.listViewSearchButton.Size = new System.Drawing.Size(112, 23);
            this.listViewSearchButton.TabIndex = 2;
            this.listViewSearchButton.Text = "Search";
            this.listViewSearchButton.UseVisualStyleBackColor = true;
            this.listViewSearchButton.Click += new System.EventHandler(this.listViewSearchButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.listViewSearchButton);
            this.Controls.Add(this.listViewSearchBox);
            this.Controls.Add(this.icd10View);
            this.Name = "Form1";
            this.Text = "ICD 10 - AK GesInf";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView icd10View;
        private System.Windows.Forms.TextBox listViewSearchBox;
        private System.Windows.Forms.Button listViewSearchButton;
    }
}

