
namespace Battlefield_2_Multiplayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DragPanel = new System.Windows.Forms.Panel();
            this.version_label = new System.Windows.Forms.Label();
            this.shorcut_btn = new System.Windows.Forms.Button();
            this.server_address_field = new System.Windows.Forms.TextBox();
            this.connect_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.minimize_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.DragPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DragPanel
            // 
            this.DragPanel.BackColor = System.Drawing.Color.Transparent;
            this.DragPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DragPanel.Controls.Add(this.version_label);
            this.DragPanel.Controls.Add(this.shorcut_btn);
            this.DragPanel.Controls.Add(this.server_address_field);
            this.DragPanel.Controls.Add(this.connect_btn);
            this.DragPanel.Controls.Add(this.pictureBox1);
            this.DragPanel.Controls.Add(this.minimize_btn);
            this.DragPanel.Controls.Add(this.close_btn);
            this.DragPanel.Location = new System.Drawing.Point(0, 1);
            this.DragPanel.MaximumSize = new System.Drawing.Size(930, 464);
            this.DragPanel.MinimumSize = new System.Drawing.Size(930, 464);
            this.DragPanel.Name = "DragPanel";
            this.DragPanel.Size = new System.Drawing.Size(930, 464);
            this.DragPanel.TabIndex = 0;
            this.DragPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DragPanel_Paint);
            this.DragPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseDown);
            this.DragPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseMove);
            this.DragPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DragPanel_MouseUp);
            // 
            // version_label
            // 
            this.version_label.AutoSize = true;
            this.version_label.Location = new System.Drawing.Point(862, 442);
            this.version_label.Name = "version_label";
            this.version_label.Size = new System.Drawing.Size(59, 13);
            this.version_label.TabIndex = 5;
            this.version_label.Text = "version 1.2";
            // 
            // shorcut_btn
            // 
            this.shorcut_btn.BackColor = System.Drawing.SystemColors.Control;
            this.shorcut_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shorcut_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.shorcut_btn.Location = new System.Drawing.Point(175, 347);
            this.shorcut_btn.Name = "shorcut_btn";
            this.shorcut_btn.Size = new System.Drawing.Size(184, 39);
            this.shorcut_btn.TabIndex = 4;
            this.shorcut_btn.Text = "Create shortcut";
            this.shorcut_btn.UseVisualStyleBackColor = false;
            this.shorcut_btn.Click += new System.EventHandler(this.shorcut_btn_Click);
            // 
            // server_address_field
            // 
            this.server_address_field.AutoCompleteCustomSource.AddRange(new string[] {
            "127.0.0.1",
            "localhost"});
            this.server_address_field.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.server_address_field.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.server_address_field.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.server_address_field.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server_address_field.Location = new System.Drawing.Point(59, 290);
            this.server_address_field.MinimumSize = new System.Drawing.Size(250, 40);
            this.server_address_field.Name = "server_address_field";
            this.server_address_field.Size = new System.Drawing.Size(300, 32);
            this.server_address_field.TabIndex = 1;
            this.server_address_field.Text = "server address here...";
            this.server_address_field.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.server_address_field.Enter += new System.EventHandler(this.textBox1_Enter);
            this.server_address_field.KeyDown += new System.Windows.Forms.KeyEventHandler(this.server_address_field_KeyDown);
            this.server_address_field.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.server_address_field_KeyPress);
            // 
            // connect_btn
            // 
            this.connect_btn.BackColor = System.Drawing.SystemColors.Control;
            this.connect_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connect_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.connect_btn.Location = new System.Drawing.Point(59, 347);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(110, 39);
            this.connect_btn.TabIndex = 2;
            this.connect_btn.Text = "Connect";
            this.connect_btn.UseVisualStyleBackColor = false;
            this.connect_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Battlefield_2_Multiplayer.Properties.Resources._1665_1_;
            this.pictureBox1.Location = new System.Drawing.Point(12, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // minimize_btn
            // 
            this.minimize_btn.BackColor = System.Drawing.Color.Transparent;
            this.minimize_btn.FlatAppearance.BorderSize = 0;
            this.minimize_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize_btn.Image = global::Battlefield_2_Multiplayer.Properties.Resources.minimize2;
            this.minimize_btn.Location = new System.Drawing.Point(865, 3);
            this.minimize_btn.Name = "minimize_btn";
            this.minimize_btn.Size = new System.Drawing.Size(28, 23);
            this.minimize_btn.TabIndex = 2;
            this.minimize_btn.UseVisualStyleBackColor = false;
            this.minimize_btn.Click += new System.EventHandler(this.minimize_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.Color.Transparent;
            this.close_btn.FlatAppearance.BorderSize = 0;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_btn.Image = global::Battlefield_2_Multiplayer.Properties.Resources.close_btn;
            this.close_btn.Location = new System.Drawing.Point(899, 3);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(28, 23);
            this.close_btn.TabIndex = 1;
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Battlefield_2_Multiplayer.Properties.Resources.Application_background;
            this.ClientSize = new System.Drawing.Size(930, 465);
            this.ControlBox = false;
            this.Controls.Add(this.DragPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragPanel.ResumeLayout(false);
            this.DragPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DragPanel;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Button minimize_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button connect_btn;
        private System.Windows.Forms.TextBox server_address_field;
        private System.Windows.Forms.Button shorcut_btn;
        private System.Windows.Forms.Label version_label;
    }
}

