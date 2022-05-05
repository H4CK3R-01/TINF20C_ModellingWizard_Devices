
namespace App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.deviceDescription1 = new Aml.Editor.Plugin.DeviceDescription(new Aml.Editor.Plugin.MWController());
            this.SuspendLayout();
            // 
            // deviceDescription1
            // 
            this.deviceDescription1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deviceDescription1.BackColor = System.Drawing.Color.Transparent;
            this.deviceDescription1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceDescription1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceDescription1.Location = new System.Drawing.Point(0, 0);
            this.deviceDescription1.Margin = new System.Windows.Forms.Padding(0);
            this.deviceDescription1.Name = "deviceDescription1";
            this.deviceDescription1.Size = new System.Drawing.Size(884, 461);
            this.deviceDescription1.TabIndex = 0;
            this.deviceDescription1.Load += new System.EventHandler(this.deviceDescription1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.deviceDescription1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modelling Wizard für Gerätemodelle";
            this.ResumeLayout(false);

        }

        #endregion

        private Aml.Editor.Plugin.DeviceDescription deviceDescription1;
    }
}

