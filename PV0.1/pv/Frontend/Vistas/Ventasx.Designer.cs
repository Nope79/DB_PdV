﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;
using pv.Backend;

namespace pv.Frontend.Vistas
{
    partial class Ventasx
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventasx));
            this.btnback = new System.Windows.Forms.Button();
            this.dtventas = new System.Windows.Forms.DataGridView();
            this.lblhello = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblventas = new System.Windows.Forms.Label();
            this.tbfolio = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.btnnormal = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnfiltro = new System.Windows.Forms.Button();
            this.dtpfin = new System.Windows.Forms.DateTimePicker();
            this.dtpinicio = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dtventas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnback.Location = new System.Drawing.Point(25, 568);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(90, 35);
            this.btnback.TabIndex = 3;
            this.btnback.Text = "Regresar";
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // dtventas
            // 
            this.dtventas.AllowUserToAddRows = false;
            this.dtventas.AllowUserToDeleteRows = false;
            this.dtventas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtventas.Location = new System.Drawing.Point(56, 98);
            this.dtventas.Name = "dtventas";
            this.dtventas.ReadOnly = true;
            this.dtventas.RowHeadersWidth = 62;
            this.dtventas.RowTemplate.Height = 28;
            this.dtventas.Size = new System.Drawing.Size(1146, 331);
            this.dtventas.TabIndex = 4;
            // 
            // lblhello
            // 
            this.lblhello.AutoSize = true;
            this.lblhello.Font = new System.Drawing.Font("Wide Latin", 26F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblhello.Location = new System.Drawing.Point(-11, 14);
            this.lblhello.Name = "lblhello";
            this.lblhello.Size = new System.Drawing.Size(835, 64);
            this.lblhello.TabIndex = 5;
            this.lblhello.Text = "Ventas Realizadas";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblventas);
            this.panel1.Controls.Add(this.tbfolio);
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.btnnormal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnfiltro);
            this.panel1.Controls.Add(this.dtpfin);
            this.panel1.Controls.Add(this.dtpinicio);
            this.panel1.Controls.Add(this.lblhello);
            this.panel1.Controls.Add(this.btnback);
            this.panel1.Controls.Add(this.dtventas);
            this.panel1.Location = new System.Drawing.Point(0, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1334, 618);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(661, 435);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 47);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(367, 435);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // lblventas
            // 
            this.lblventas.AutoSize = true;
            this.lblventas.Location = new System.Drawing.Point(877, 542);
            this.lblventas.Name = "lblventas";
            this.lblventas.Size = new System.Drawing.Size(156, 20);
            this.lblventas.TabIndex = 17;
            this.lblventas.Text = "Productos vendidos: ";
            // 
            // tbfolio
            // 
            this.tbfolio.Location = new System.Drawing.Point(881, 565);
            this.tbfolio.MaxLength = 9;
            this.tbfolio.Name = "tbfolio";
            this.tbfolio.Size = new System.Drawing.Size(145, 26);
            this.tbfolio.TabIndex = 16;
            this.tbfolio.TextChanged += new System.EventHandler(this.tbfolio_TextChanged);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::pv.Properties.Resources._9004860_arrow_direction_left_back_icon;
            this.pictureBox7.Location = new System.Drawing.Point(47, 528);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(42, 34);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 15;
            this.pictureBox7.TabStop = false;
            // 
            // btnnormal
            // 
            this.btnnormal.Location = new System.Drawing.Point(47, 471);
            this.btnnormal.Name = "btnnormal";
            this.btnnormal.Size = new System.Drawing.Size(107, 35);
            this.btnnormal.TabIndex = 11;
            this.btnnormal.Text = "Sin filtro";
            this.btnnormal.UseVisualStyleBackColor = true;
            this.btnnormal.Click += new System.EventHandler(this.btnnormal_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(620, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "FIN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 450);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "INICIO";
            // 
            // btnfiltro
            // 
            this.btnfiltro.Location = new System.Drawing.Point(425, 568);
            this.btnfiltro.Name = "btnfiltro";
            this.btnfiltro.Size = new System.Drawing.Size(124, 35);
            this.btnfiltro.TabIndex = 8;
            this.btnfiltro.Text = "Filtro por fecha";
            this.btnfiltro.UseVisualStyleBackColor = true;
            this.btnfiltro.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpfin
            // 
            this.dtpfin.Location = new System.Drawing.Point(535, 480);
            this.dtpfin.Name = "dtpfin";
            this.dtpfin.Size = new System.Drawing.Size(200, 26);
            this.dtpfin.TabIndex = 7;
            // 
            // dtpinicio
            // 
            this.dtpinicio.Location = new System.Drawing.Point(242, 480);
            this.dtpinicio.Name = "dtpinicio";
            this.dtpinicio.Size = new System.Drawing.Size(200, 26);
            this.dtpinicio.TabIndex = 6;
            // 
            // Ventasx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 610);
            this.Controls.Add(this.panel1);
            this.Name = "Ventasx";
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.Ventasx_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtventas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.DataGridView dtventas;
        private System.Windows.Forms.Label lblhello;
        private Panel panel1;
        private DateTimePicker dtpfin;
        private DateTimePicker dtpinicio;
        private Label label2;
        private Label label1;
        private Button btnfiltro;
        private Button btnnormal;
        private PictureBox pictureBox7;
        private Label lblventas;
        private TextBox tbfolio;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}
