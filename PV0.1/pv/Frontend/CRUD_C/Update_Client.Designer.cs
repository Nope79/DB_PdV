namespace pv.Frontend
{
    partial class Update_Clients
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox tbname;
        private System.Windows.Forms.TextBox tbphone;
        private System.Windows.Forms.TextBox tbage;
        private System.Windows.Forms.RadioButton rbmale;
        private System.Windows.Forms.RadioButton rbfemale;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblphone;
        private System.Windows.Forms.Label lblage;
        private System.Windows.Forms.Label lblgender;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tbname = new System.Windows.Forms.TextBox();
            this.tbphone = new System.Windows.Forms.TextBox();
            this.tbage = new System.Windows.Forms.TextBox();
            this.rbmale = new System.Windows.Forms.RadioButton();
            this.rbfemale = new System.Windows.Forms.RadioButton();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnback = new System.Windows.Forms.Button();
            this.lblname = new System.Windows.Forms.Label();
            this.lblphone = new System.Windows.Forms.Label();
            this.lblage = new System.Windows.Forms.Label();
            this.lblgender = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.f = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbname
            // 
            this.tbname.Location = new System.Drawing.Point(115, 23);
            this.tbname.Name = "tbname";
            this.tbname.Size = new System.Drawing.Size(200, 26);
            this.tbname.TabIndex = 0;
            // 
            // tbphone
            // 
            this.tbphone.Location = new System.Drawing.Point(115, 78);
            this.tbphone.Name = "tbphone";
            this.tbphone.Size = new System.Drawing.Size(200, 26);
            this.tbphone.TabIndex = 1;
            // 
            // tbage
            // 
            this.tbage.Location = new System.Drawing.Point(115, 129);
            this.tbage.Name = "tbage";
            this.tbage.Size = new System.Drawing.Size(200, 26);
            this.tbage.TabIndex = 2;
            // 
            // rbmale
            // 
            this.rbmale.AutoSize = true;
            this.rbmale.Location = new System.Drawing.Point(115, 177);
            this.rbmale.Name = "rbmale";
            this.rbmale.Size = new System.Drawing.Size(105, 24);
            this.rbmale.TabIndex = 3;
            this.rbmale.TabStop = true;
            this.rbmale.Text = "Masculino";
            this.rbmale.UseVisualStyleBackColor = true;
            // 
            // rbfemale
            // 
            this.rbfemale.AutoSize = true;
            this.rbfemale.Location = new System.Drawing.Point(226, 177);
            this.rbfemale.Name = "rbfemale";
            this.rbfemale.Size = new System.Drawing.Size(105, 24);
            this.rbfemale.TabIndex = 4;
            this.rbfemale.TabStop = true;
            this.rbfemale.Text = "Femenino";
            this.rbfemale.UseVisualStyleBackColor = true;
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnupdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnupdate.Location = new System.Drawing.Point(226, 206);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(94, 33);
            this.btnupdate.TabIndex = 5;
            this.btnupdate.Text = "Actualizar";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(14, 206);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(84, 33);
            this.btnback.TabIndex = 6;
            this.btnback.Text = "Volver";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(29, 26);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(69, 20);
            this.lblname.TabIndex = 7;
            this.lblname.Text = "Nombre:";
            // 
            // lblphone
            // 
            this.lblphone.AutoSize = true;
            this.lblphone.Location = new System.Drawing.Point(23, 78);
            this.lblphone.Name = "lblphone";
            this.lblphone.Size = new System.Drawing.Size(75, 20);
            this.lblphone.TabIndex = 8;
            this.lblphone.Text = "Teléfono:";
            // 
            // lblage
            // 
            this.lblage.AutoSize = true;
            this.lblage.Location = new System.Drawing.Point(47, 135);
            this.lblage.Name = "lblage";
            this.lblage.Size = new System.Drawing.Size(51, 20);
            this.lblage.TabIndex = 9;
            this.lblage.Text = "Edad:";
            // 
            // lblgender
            // 
            this.lblgender.AutoSize = true;
            this.lblgender.Location = new System.Drawing.Point(47, 177);
            this.lblgender.Name = "lblgender";
            this.lblgender.Size = new System.Drawing.Size(49, 20);
            this.lblgender.TabIndex = 10;
            this.lblgender.Text = "Sexo:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.f);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-2, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 393);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.lblname);
            this.panel2.Controls.Add(this.btnback);
            this.panel2.Controls.Add(this.tbname);
            this.panel2.Controls.Add(this.btnupdate);
            this.panel2.Controls.Add(this.lblgender);
            this.panel2.Controls.Add(this.rbfemale);
            this.panel2.Controls.Add(this.lblphone);
            this.panel2.Controls.Add(this.rbmale);
            this.panel2.Controls.Add(this.tbphone);
            this.panel2.Controls.Add(this.lblage);
            this.panel2.Controls.Add(this.tbage);
            this.panel2.Location = new System.Drawing.Point(140, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 244);
            this.panel2.TabIndex = 11;
            // 
            // f
            // 
            this.f.AutoSize = true;
            this.f.Font = new System.Drawing.Font("Niagara Solid", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.f.Location = new System.Drawing.Point(14, 0);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(240, 43);
            this.f.TabIndex = 118;
            this.f.Text = "Actualizar de Clientes";
            // 
            // Update_Clients
            // 
            this.ClientSize = new System.Drawing.Size(610, 340);
            this.Controls.Add(this.panel1);
            this.Name = "Update_Clients";
            this.Text = "Actualizar Cliente";
            this.Load += new System.EventHandler(this.Update_Clients_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label f;
    }
}
