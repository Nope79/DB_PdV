namespace pv.Frontend.Vistas
{
    partial class Ventas_Mes
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
            this.cbmes = new System.Windows.Forms.ComboBox();
            this.dtmes = new System.Windows.Forms.DataGridView();
            this.btnback = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.cbanio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtmes)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // cbmes
            // 
            this.cbmes.FormattingEnabled = true;
            this.cbmes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre ",
            "Noviembre",
            "Diciembre"});
            this.cbmes.Location = new System.Drawing.Point(80, 105);
            this.cbmes.Name = "cbmes";
            this.cbmes.Size = new System.Drawing.Size(121, 28);
            this.cbmes.TabIndex = 0;
            this.cbmes.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dtmes
            // 
            this.dtmes.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtmes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtmes.Location = new System.Drawing.Point(228, 71);
            this.dtmes.Name = "dtmes";
            this.dtmes.RowHeadersWidth = 62;
            this.dtmes.RowTemplate.Height = 28;
            this.dtmes.Size = new System.Drawing.Size(989, 384);
            this.dtmes.TabIndex = 1;
            this.dtmes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtmes_CellContentClick);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(13, 445);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(102, 40);
            this.btnback.TabIndex = 2;
            this.btnback.Text = "Regresar";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbanio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.cbmes);
            this.panel1.Controls.Add(this.btnback);
            this.panel1.Controls.Add(this.dtmes);
            this.panel1.Location = new System.Drawing.Point(-1, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1311, 530);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Stencil", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Azure;
            this.label2.Location = new System.Drawing.Point(13, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(456, 52);
            this.label2.TabIndex = 18;
            this.label2.Text = "Ventas Mensuales";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::pv.Properties.Resources._9004860_arrow_direction_left_back_icon;
            this.pictureBox7.Location = new System.Drawing.Point(33, 379);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(67, 60);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 17;
            this.pictureBox7.TabStop = false;
            // 
            // cbanio
            // 
            this.cbanio.FormattingEnabled = true;
            this.cbanio.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cbanio.Location = new System.Drawing.Point(80, 163);
            this.cbanio.Name = "cbanio";
            this.cbanio.Size = new System.Drawing.Size(121, 28);
            this.cbanio.TabIndex = 19;
            this.cbanio.SelectedIndexChanged += new System.EventHandler(this.cbanio_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Mes:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Año:";
            // 
            // Ventas_Mes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 492);
            this.Controls.Add(this.panel1);
            this.Name = "Ventas_Mes";
            this.Text = "Ventas_Mes";
            this.Load += new System.EventHandler(this.Ventas_Mes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtmes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbmes;
        private System.Windows.Forms.DataGridView dtmes;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbanio;
        private System.Windows.Forms.Label label3;
    }
}