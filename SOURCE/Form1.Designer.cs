﻿
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
            this.deviceDescription1 = new Aml.Editor.Plugin.DeviceDescription();
            this.SuspendLayout();
            // 
            // deviceDescription1
            // 
            this.deviceDescription1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.deviceDescription1.BackColor = System.Drawing.Color.Transparent;
            this.deviceDescription1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceDescription1.Location = new System.Drawing.Point(0, 0);
            this.deviceDescription1.Margin = new System.Windows.Forms.Padding(0);
            this.deviceDescription1.MinimumSize = new System.Drawing.Size(1750, 866);
            this.deviceDescription1.Name = "deviceDescription1";
            this.deviceDescription1.Size = new System.Drawing.Size(1813, 888);
            this.deviceDescription1.TabIndex = 0;
            this.deviceDescription1.Load += new System.EventHandler(this.deviceDescription1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deviceDescription1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Aml.Editor.Plugin.DeviceDescription deviceDescription1;
    }
}

