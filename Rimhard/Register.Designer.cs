namespace Rimhard
{
    partial class Register
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
            this.button2 = new System.Windows.Forms.Button();
            this.Txtname = new Guna.UI2.WinForms.Guna2TextBox();
            this.Txtsurname = new Guna.UI2.WinForms.Guna2TextBox();
            this.Txttell = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("DB HelvethaicaMon X Bd Cond", 18.33962F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(263, 934);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_cancel);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("DB HelvethaicaMon X Bd Cond", 18.33962F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(615, 934);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 50);
            this.button2.TabIndex = 4;
            this.button2.Text = "Submit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Txtname
            // 
            this.Txtname.BorderColor = System.Drawing.Color.Transparent;
            this.Txtname.BorderThickness = 0;
            this.Txtname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txtname.DefaultText = "";
            this.Txtname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Txtname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Txtname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txtname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txtname.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(247)))));
            this.Txtname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txtname.Font = new System.Drawing.Font("DB Helvethaica X Bd Cond", 27.84906F, System.Drawing.FontStyle.Bold);
            this.Txtname.ForeColor = System.Drawing.Color.Black;
            this.Txtname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txtname.Location = new System.Drawing.Point(284, 493);
            this.Txtname.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Txtname.Name = "Txtname";
            this.Txtname.PasswordChar = '\0';
            this.Txtname.PlaceholderText = "Name";
            this.Txtname.SelectedText = "";
            this.Txtname.Size = new System.Drawing.Size(414, 74);
            this.Txtname.TabIndex = 5;
            this.Txtname.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // Txtsurname
            // 
            this.Txtsurname.BorderColor = System.Drawing.Color.Transparent;
            this.Txtsurname.BorderThickness = 0;
            this.Txtsurname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txtsurname.DefaultText = "";
            this.Txtsurname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Txtsurname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Txtsurname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txtsurname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txtsurname.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(247)))));
            this.Txtsurname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txtsurname.Font = new System.Drawing.Font("DB Helvethaica X Bd Cond", 27.84906F, System.Drawing.FontStyle.Bold);
            this.Txtsurname.ForeColor = System.Drawing.Color.Black;
            this.Txtsurname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txtsurname.Location = new System.Drawing.Point(284, 654);
            this.Txtsurname.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Txtsurname.Name = "Txtsurname";
            this.Txtsurname.PasswordChar = '\0';
            this.Txtsurname.PlaceholderText = "Surname";
            this.Txtsurname.SelectedText = "";
            this.Txtsurname.Size = new System.Drawing.Size(414, 74);
            this.Txtsurname.TabIndex = 6;
            // 
            // Txttell
            // 
            this.Txttell.BorderColor = System.Drawing.Color.Transparent;
            this.Txttell.BorderThickness = 0;
            this.Txttell.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txttell.DefaultText = "";
            this.Txttell.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Txttell.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Txttell.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txttell.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Txttell.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(255)))), ((int)(((byte)(247)))));
            this.Txttell.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txttell.Font = new System.Drawing.Font("DB Helvethaica X Bd Cond", 27.84906F, System.Drawing.FontStyle.Bold);
            this.Txttell.ForeColor = System.Drawing.Color.Black;
            this.Txttell.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Txttell.Location = new System.Drawing.Point(284, 805);
            this.Txttell.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Txttell.Name = "Txttell";
            this.Txttell.PasswordChar = '\0';
            this.Txttell.PlaceholderText = "Tel";
            this.Txttell.SelectedText = "";
            this.Txttell.Size = new System.Drawing.Size(414, 74);
            this.Txttell.TabIndex = 7;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Rimhard.Properties.Resources.register;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 1059);
            this.Controls.Add(this.Txttell);
            this.Controls.Add(this.Txtsurname);
            this.Controls.Add(this.Txtname);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("DB HelvethaicaMon X Bd Cond", 27.84906F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 10, 8, 10);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Guna.UI2.WinForms.Guna2TextBox Txtname;
        private Guna.UI2.WinForms.Guna2TextBox Txtsurname;
        private Guna.UI2.WinForms.Guna2TextBox Txttell;
    }
}