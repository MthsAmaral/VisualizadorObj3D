namespace VisualizadorObj3D
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAbrirArquivo = new System.Windows.Forms.Button();
            this.panelCabecalho = new System.Windows.Forms.Panel();
            this.btnRedefinirObjOriginal = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLimparProjecoes = new System.Windows.Forms.Button();
            this.checkBoxEliminarFacesOcultas = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb1Ponto = new System.Windows.Forms.RadioButton();
            this.rbCabinete = new System.Windows.Forms.RadioButton();
            this.rbLateral = new System.Windows.Forms.RadioButton();
            this.rbCavaleira = new System.Windows.Forms.RadioButton();
            this.rbFrontal = new System.Windows.Forms.RadioButton();
            this.rbSuperior = new System.Windows.Forms.RadioButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btAplicar = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelCabecalho.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(713, 535);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAbrirArquivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAbrirArquivo.FlatAppearance.BorderSize = 0;
            this.btnAbrirArquivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirArquivo.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirArquivo.Location = new System.Drawing.Point(14, 8);
            this.btnAbrirArquivo.Name = "btnAbrirArquivo";
            this.btnAbrirArquivo.Size = new System.Drawing.Size(68, 37);
            this.btnAbrirArquivo.TabIndex = 1;
            this.btnAbrirArquivo.Text = "Abrir Arquivo";
            this.btnAbrirArquivo.UseVisualStyleBackColor = false;
            this.btnAbrirArquivo.Click += new System.EventHandler(this.btnAbrirArquivo_Click);
            // 
            // panelCabecalho
            // 
            this.panelCabecalho.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelCabecalho.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelCabecalho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCabecalho.Controls.Add(this.btnRedefinirObjOriginal);
            this.panelCabecalho.Controls.Add(this.btnAbrirArquivo);
            this.panelCabecalho.Location = new System.Drawing.Point(12, 4);
            this.panelCabecalho.Name = "panelCabecalho";
            this.panelCabecalho.Size = new System.Drawing.Size(1129, 56);
            this.panelCabecalho.TabIndex = 2;
            // 
            // btnRedefinirObjOriginal
            // 
            this.btnRedefinirObjOriginal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRedefinirObjOriginal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRedefinirObjOriginal.FlatAppearance.BorderSize = 0;
            this.btnRedefinirObjOriginal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedefinirObjOriginal.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRedefinirObjOriginal.Location = new System.Drawing.Point(100, 8);
            this.btnRedefinirObjOriginal.Name = "btnRedefinirObjOriginal";
            this.btnRedefinirObjOriginal.Size = new System.Drawing.Size(113, 37);
            this.btnRedefinirObjOriginal.TabIndex = 2;
            this.btnRedefinirObjOriginal.Text = "Redefinir Objeto Original";
            this.btnRedefinirObjOriginal.UseVisualStyleBackColor = false;
            this.btnRedefinirObjOriginal.Click += new System.EventHandler(this.btnRedefinirObjOriginal_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(743, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 535);
            this.panel1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(153, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Projeção";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnLimparProjecoes);
            this.panel2.Controls.Add(this.checkBoxEliminarFacesOcultas);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.btAplicar);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Location = new System.Drawing.Point(17, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(367, 210);
            this.panel2.TabIndex = 5;
            // 
            // btnLimparProjecoes
            // 
            this.btnLimparProjecoes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLimparProjecoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLimparProjecoes.FlatAppearance.BorderSize = 0;
            this.btnLimparProjecoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparProjecoes.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparProjecoes.Location = new System.Drawing.Point(288, 169);
            this.btnLimparProjecoes.Name = "btnLimparProjecoes";
            this.btnLimparProjecoes.Size = new System.Drawing.Size(68, 23);
            this.btnLimparProjecoes.TabIndex = 13;
            this.btnLimparProjecoes.Text = "Limpar";
            this.btnLimparProjecoes.UseVisualStyleBackColor = false;
            this.btnLimparProjecoes.Click += new System.EventHandler(this.btnLimparProjecoes_Click);
            // 
            // checkBoxEliminarFacesOcultas
            // 
            this.checkBoxEliminarFacesOcultas.AutoSize = true;
            this.checkBoxEliminarFacesOcultas.Location = new System.Drawing.Point(16, 144);
            this.checkBoxEliminarFacesOcultas.Name = "checkBoxEliminarFacesOcultas";
            this.checkBoxEliminarFacesOcultas.Size = new System.Drawing.Size(133, 17);
            this.checkBoxEliminarFacesOcultas.TabIndex = 12;
            this.checkBoxEliminarFacesOcultas.Text = "Eliminar Faces Ocultas";
            this.checkBoxEliminarFacesOcultas.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.rb1Ponto);
            this.groupBox1.Controls.Add(this.rbCabinete);
            this.groupBox1.Controls.Add(this.rbLateral);
            this.groupBox1.Controls.Add(this.rbCavaleira);
            this.groupBox1.Controls.Add(this.rbFrontal);
            this.groupBox1.Controls.Add(this.rbSuperior);
            this.groupBox1.Location = new System.Drawing.Point(16, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 89);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // rb1Ponto
            // 
            this.rb1Ponto.AutoSize = true;
            this.rb1Ponto.Location = new System.Drawing.Point(243, 13);
            this.rb1Ponto.Name = "rb1Ponto";
            this.rb1Ponto.Size = new System.Drawing.Size(62, 17);
            this.rb1Ponto.TabIndex = 3;
            this.rb1Ponto.TabStop = true;
            this.rb1Ponto.Text = "1 Ponto";
            this.rb1Ponto.UseVisualStyleBackColor = true;
            // 
            // rbCabinete
            // 
            this.rbCabinete.AutoSize = true;
            this.rbCabinete.Location = new System.Drawing.Point(119, 13);
            this.rbCabinete.Name = "rbCabinete";
            this.rbCabinete.Size = new System.Drawing.Size(67, 17);
            this.rbCabinete.TabIndex = 2;
            this.rbCabinete.TabStop = true;
            this.rbCabinete.Text = "Cabinete";
            this.rbCabinete.UseVisualStyleBackColor = true;
            // 
            // rbLateral
            // 
            this.rbLateral.AutoSize = true;
            this.rbLateral.Location = new System.Drawing.Point(18, 13);
            this.rbLateral.Name = "rbLateral";
            this.rbLateral.Size = new System.Drawing.Size(57, 17);
            this.rbLateral.TabIndex = 0;
            this.rbLateral.TabStop = true;
            this.rbLateral.Text = "Lateral";
            this.rbLateral.UseVisualStyleBackColor = true;
            // 
            // rbCavaleira
            // 
            this.rbCavaleira.AutoSize = true;
            this.rbCavaleira.Location = new System.Drawing.Point(119, 36);
            this.rbCavaleira.Name = "rbCavaleira";
            this.rbCavaleira.Size = new System.Drawing.Size(69, 17);
            this.rbCavaleira.TabIndex = 1;
            this.rbCavaleira.TabStop = true;
            this.rbCavaleira.Text = "Cavaleira";
            this.rbCavaleira.UseVisualStyleBackColor = true;
            // 
            // rbFrontal
            // 
            this.rbFrontal.AutoSize = true;
            this.rbFrontal.Location = new System.Drawing.Point(18, 36);
            this.rbFrontal.Name = "rbFrontal";
            this.rbFrontal.Size = new System.Drawing.Size(57, 17);
            this.rbFrontal.TabIndex = 1;
            this.rbFrontal.TabStop = true;
            this.rbFrontal.Text = "Frontal";
            this.rbFrontal.UseVisualStyleBackColor = true;
            // 
            // rbSuperior
            // 
            this.rbSuperior.AutoSize = true;
            this.rbSuperior.Location = new System.Drawing.Point(18, 59);
            this.rbSuperior.Name = "rbSuperior";
            this.rbSuperior.Size = new System.Drawing.Size(64, 17);
            this.rbSuperior.TabIndex = 2;
            this.rbSuperior.TabStop = true;
            this.rbSuperior.Text = "Superior";
            this.rbSuperior.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(259, 17);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(97, 22);
            this.textBox4.TabIndex = 11;
            this.textBox4.Text = "Perspectiva";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btAplicar
            // 
            this.btAplicar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btAplicar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btAplicar.FlatAppearance.BorderSize = 0;
            this.btAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAplicar.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAplicar.Location = new System.Drawing.Point(210, 169);
            this.btAplicar.Name = "btAplicar";
            this.btAplicar.Size = new System.Drawing.Size(68, 23);
            this.btAplicar.TabIndex = 3;
            this.btAplicar.Text = "Aplicar";
            this.btAplicar.UseVisualStyleBackColor = false;
            this.btAplicar.Click += new System.EventHandler(this.btAplicar_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(135, 17);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 10;
            this.textBox3.Text = "Oblíqua";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(16, 17);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(98, 22);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "Ortográfica";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1167, 645);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelCabecalho);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelCabecalho.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAbrirArquivo;
        private System.Windows.Forms.Panel panelCabecalho;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnRedefinirObjOriginal;
        private System.Windows.Forms.Button btAplicar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb1Ponto;
        private System.Windows.Forms.RadioButton rbCabinete;
        private System.Windows.Forms.RadioButton rbLateral;
        private System.Windows.Forms.RadioButton rbCavaleira;
        private System.Windows.Forms.RadioButton rbFrontal;
        private System.Windows.Forms.RadioButton rbSuperior;
        private System.Windows.Forms.CheckBox checkBoxEliminarFacesOcultas;
        private System.Windows.Forms.Button btnLimparProjecoes;
    }
}

