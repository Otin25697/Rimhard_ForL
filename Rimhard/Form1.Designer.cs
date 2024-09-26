namespace Rimhard
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
            this.butcustom = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butcustom
            // 
            this.butcustom.BackColor = System.Drawing.Color.Transparent;
            this.butcustom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butcustom.FlatAppearance.BorderSize = 0;
            this.butcustom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butcustom.Font = new System.Drawing.Font("DB HelvethaicaMon X Bd Cond", 27.84906F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butcustom.ForeColor = System.Drawing.Color.Tomato;
            this.butcustom.Location = new System.Drawing.Point(425, 345);
            this.butcustom.Name = "butcustom";
            this.butcustom.Size = new System.Drawing.Size(420, 71);
            this.butcustom.TabIndex = 0;
            this.butcustom.Text = "เริ่มซื้อขาย";
            this.butcustom.UseVisualStyleBackColor = false;
            this.butcustom.Click += new System.EventHandler(this.Btbcustomer);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("DB HelvethaicaMon X Bd Cond", 27.84906F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.MediumTurquoise;
            this.button2.Location = new System.Drawing.Point(425, 453);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(420, 72);
            this.button2.TabIndex = 1;
            this.button2.Text = "สำหรับพนักงาน";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Btemployee);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::Rimhard.Properties.Resources.reinfo;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(1134, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 56);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Btinfo);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = global::Rimhard.Properties.Resources.Untitled_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 632);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.butcustom);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximumSize = new System.Drawing.Size(1920, 1006);
            this.MinimumSize = new System.Drawing.Size(1280, 671);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butcustom;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

