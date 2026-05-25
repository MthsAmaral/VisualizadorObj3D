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
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBoxZBuffer = new System.Windows.Forms.CheckBox();
            this.btnEscolherCorZBuffer = new System.Windows.Forms.Button();
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
            this.trackBarLuzX = new System.Windows.Forms.TrackBar();
            this.trackBarLuzY = new System.Windows.Forms.TrackBar();
            this.trackBarLuzZ = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBarKs = new System.Windows.Forms.TrackBar();
            this.trackBarKd = new System.Windows.Forms.TrackBar();
            this.trackBarKa = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.trackBarN = new System.Windows.Forms.TrackBar();
            this.checkBoxLuz = new System.Windows.Forms.CheckBox();
            this.buttonEscolherCorLuz = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbDifusa = new System.Windows.Forms.RadioButton();
            this.rbAmbiente = new System.Windows.Forms.RadioButton();
            this.rbTotal = new System.Windows.Forms.RadioButton();
            this.rbEspecular = new System.Windows.Forms.RadioButton();
            this.buttonAplicarLuz = new System.Windows.Forms.Button();
            this.buttonLimparLuz = new System.Windows.Forms.Button();
            this.cbAlgortimo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelCabecalho.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuzX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuzY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuzZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarN)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(713, 593);
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
            this.panelCabecalho.Size = new System.Drawing.Size(713, 56);
            this.panelCabecalho.TabIndex = 2;
            // 
            // btnRedefinirObjOriginal
            // 
            this.btnRedefinirObjOriginal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
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
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(743, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 655);
            this.panel1.TabIndex = 3;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(105, 256);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(194, 25);
            this.textBox5.TabIndex = 15;
            this.textBox5.Text = "Iluminação e Sombreamento";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cbAlgortimo);
            this.panel3.Controls.Add(this.buttonLimparLuz);
            this.panel3.Controls.Add(this.buttonAplicarLuz);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.checkBoxLuz);
            this.panel3.Controls.Add(this.buttonEscolherCorLuz);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.trackBarN);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.trackBarKs);
            this.panel3.Controls.Add(this.trackBarKd);
            this.panel3.Controls.Add(this.trackBarKa);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.trackBarLuzZ);
            this.panel3.Controls.Add(this.trackBarLuzY);
            this.panel3.Controls.Add(this.trackBarLuzX);
            this.panel3.Location = new System.Drawing.Point(17, 287);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(367, 356);
            this.panel3.TabIndex = 14;
            // 
            // checkBoxZBuffer
            // 
            this.checkBoxZBuffer.AutoSize = true;
            this.checkBoxZBuffer.Location = new System.Drawing.Point(16, 175);
            this.checkBoxZBuffer.Name = "checkBoxZBuffer";
            this.checkBoxZBuffer.Size = new System.Drawing.Size(64, 17);
            this.checkBoxZBuffer.TabIndex = 14;
            this.checkBoxZBuffer.Text = "Z-Buffer";
            this.checkBoxZBuffer.UseVisualStyleBackColor = true;
            this.checkBoxZBuffer.CheckedChanged += new System.EventHandler(this.checkBoxZBuffer_CheckedChanged);
            // 
            // btnEscolherCorZBuffer
            // 
            this.btnEscolherCorZBuffer.BackColor = System.Drawing.SystemColors.Window;
            this.btnEscolherCorZBuffer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEscolherCorZBuffer.FlatAppearance.BorderSize = 0;
            this.btnEscolherCorZBuffer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEscolherCorZBuffer.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEscolherCorZBuffer.Location = new System.Drawing.Point(87, 171);
            this.btnEscolherCorZBuffer.Name = "btnEscolherCorZBuffer";
            this.btnEscolherCorZBuffer.Size = new System.Drawing.Size(84, 23);
            this.btnEscolherCorZBuffer.TabIndex = 15;
            this.btnEscolherCorZBuffer.Text = "Escolher Cor";
            this.btnEscolherCorZBuffer.UseVisualStyleBackColor = false;
            this.btnEscolherCorZBuffer.Click += new System.EventHandler(this.btnEscolherCorZBuffer_Click);
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
            this.panel2.Controls.Add(this.checkBoxZBuffer);
            this.panel2.Controls.Add(this.btnEscolherCorZBuffer);
            this.panel2.Location = new System.Drawing.Point(17, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(367, 208);
            this.panel2.TabIndex = 5;
            // 
            // btnLimparProjecoes
            // 
            this.btnLimparProjecoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnLimparProjecoes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLimparProjecoes.FlatAppearance.BorderSize = 0;
            this.btnLimparProjecoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparProjecoes.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimparProjecoes.Location = new System.Drawing.Point(288, 140);
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
            this.checkBoxEliminarFacesOcultas.Location = new System.Drawing.Point(16, 146);
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
            this.btAplicar.Location = new System.Drawing.Point(205, 140);
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
            // trackBarLuzX
            // 
            this.trackBarLuzX.Location = new System.Drawing.Point(16, 19);
            this.trackBarLuzX.Name = "trackBarLuzX";
            this.trackBarLuzX.Size = new System.Drawing.Size(155, 45);
            this.trackBarLuzX.TabIndex = 17;
            this.trackBarLuzX.Scroll += new System.EventHandler(this.trackBarLuzX_Scroll);
            // 
            // trackBarLuzY
            // 
            this.trackBarLuzY.Location = new System.Drawing.Point(16, 81);
            this.trackBarLuzY.Name = "trackBarLuzY";
            this.trackBarLuzY.Size = new System.Drawing.Size(145, 45);
            this.trackBarLuzY.TabIndex = 18;
            this.trackBarLuzY.Scroll += new System.EventHandler(this.trackBarLuzY_Scroll);
            // 
            // trackBarLuzZ
            // 
            this.trackBarLuzZ.Location = new System.Drawing.Point(16, 145);
            this.trackBarLuzZ.Name = "trackBarLuzZ";
            this.trackBarLuzZ.Size = new System.Drawing.Size(145, 45);
            this.trackBarLuzZ.TabIndex = 19;
            this.trackBarLuzZ.Scroll += new System.EventHandler(this.trackBarLuzZ_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Luz X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Luz Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Luz Z";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "kS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "kd";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(233, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "ka";
            // 
            // trackBarKs
            // 
            this.trackBarKs.LargeChange = 1;
            this.trackBarKs.Location = new System.Drawing.Point(186, 145);
            this.trackBarKs.Maximum = 100;
            this.trackBarKs.Name = "trackBarKs";
            this.trackBarKs.Size = new System.Drawing.Size(145, 45);
            this.trackBarKs.TabIndex = 25;
            this.trackBarKs.Value = 1;
            this.trackBarKs.Scroll += new System.EventHandler(this.trackBarKs_Scroll);
            // 
            // trackBarKd
            // 
            this.trackBarKd.LargeChange = 1;
            this.trackBarKd.Location = new System.Drawing.Point(186, 81);
            this.trackBarKd.Maximum = 100;
            this.trackBarKd.Name = "trackBarKd";
            this.trackBarKd.Size = new System.Drawing.Size(145, 45);
            this.trackBarKd.TabIndex = 24;
            this.trackBarKd.Scroll += new System.EventHandler(this.trackBarKd_Scroll);
            // 
            // trackBarKa
            // 
            this.trackBarKa.LargeChange = 1;
            this.trackBarKa.Location = new System.Drawing.Point(186, 19);
            this.trackBarKa.Maximum = 100;
            this.trackBarKa.Name = "trackBarKa";
            this.trackBarKa.Size = new System.Drawing.Size(155, 45);
            this.trackBarKa.TabIndex = 23;
            this.trackBarKa.Scroll += new System.EventHandler(this.trackBarKa_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(233, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "n";
            // 
            // trackBarN
            // 
            this.trackBarN.LargeChange = 1;
            this.trackBarN.Location = new System.Drawing.Point(186, 196);
            this.trackBarN.Maximum = 256;
            this.trackBarN.Minimum = 1;
            this.trackBarN.Name = "trackBarN";
            this.trackBarN.Size = new System.Drawing.Size(145, 45);
            this.trackBarN.TabIndex = 29;
            this.trackBarN.Value = 1;
            this.trackBarN.Scroll += new System.EventHandler(this.trackBarN_Scroll);
            // 
            // checkBoxLuz
            // 
            this.checkBoxLuz.AutoSize = true;
            this.checkBoxLuz.Location = new System.Drawing.Point(16, 315);
            this.checkBoxLuz.Name = "checkBoxLuz";
            this.checkBoxLuz.Size = new System.Drawing.Size(43, 17);
            this.checkBoxLuz.TabIndex = 31;
            this.checkBoxLuz.Text = "Luz";
            this.checkBoxLuz.UseVisualStyleBackColor = true;
            this.checkBoxLuz.CheckedChanged += new System.EventHandler(this.checkBoxLuz_CheckedChanged);
            // 
            // buttonEscolherCorLuz
            // 
            this.buttonEscolherCorLuz.BackColor = System.Drawing.SystemColors.Window;
            this.buttonEscolherCorLuz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonEscolherCorLuz.FlatAppearance.BorderSize = 0;
            this.buttonEscolherCorLuz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEscolherCorLuz.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEscolherCorLuz.Location = new System.Drawing.Point(66, 311);
            this.buttonEscolherCorLuz.Name = "buttonEscolherCorLuz";
            this.buttonEscolherCorLuz.Size = new System.Drawing.Size(84, 23);
            this.buttonEscolherCorLuz.TabIndex = 32;
            this.buttonEscolherCorLuz.Text = "Escolher Cor";
            this.buttonEscolherCorLuz.UseVisualStyleBackColor = false;
            this.buttonEscolherCorLuz.Click += new System.EventHandler(this.buttonEscolherCorLuz_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.rbDifusa);
            this.groupBox2.Controls.Add(this.rbAmbiente);
            this.groupBox2.Controls.Add(this.rbTotal);
            this.groupBox2.Controls.Add(this.rbEspecular);
            this.groupBox2.Location = new System.Drawing.Point(16, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 56);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // rbDifusa
            // 
            this.rbDifusa.AutoSize = true;
            this.rbDifusa.Location = new System.Drawing.Point(243, 13);
            this.rbDifusa.Name = "rbDifusa";
            this.rbDifusa.Size = new System.Drawing.Size(55, 17);
            this.rbDifusa.TabIndex = 3;
            this.rbDifusa.TabStop = true;
            this.rbDifusa.Text = "Difusa";
            this.rbDifusa.UseVisualStyleBackColor = true;
            // 
            // rbAmbiente
            // 
            this.rbAmbiente.AutoSize = true;
            this.rbAmbiente.Location = new System.Drawing.Point(119, 13);
            this.rbAmbiente.Name = "rbAmbiente";
            this.rbAmbiente.Size = new System.Drawing.Size(69, 17);
            this.rbAmbiente.TabIndex = 2;
            this.rbAmbiente.TabStop = true;
            this.rbAmbiente.Text = "Ambiente";
            this.rbAmbiente.UseVisualStyleBackColor = true;
            // 
            // rbTotal
            // 
            this.rbTotal.AutoSize = true;
            this.rbTotal.Location = new System.Drawing.Point(18, 13);
            this.rbTotal.Name = "rbTotal";
            this.rbTotal.Size = new System.Drawing.Size(49, 17);
            this.rbTotal.TabIndex = 0;
            this.rbTotal.TabStop = true;
            this.rbTotal.Text = "Total";
            this.rbTotal.UseVisualStyleBackColor = true;
            // 
            // rbEspecular
            // 
            this.rbEspecular.AutoSize = true;
            this.rbEspecular.Location = new System.Drawing.Point(18, 34);
            this.rbEspecular.Name = "rbEspecular";
            this.rbEspecular.Size = new System.Drawing.Size(72, 17);
            this.rbEspecular.TabIndex = 1;
            this.rbEspecular.TabStop = true;
            this.rbEspecular.Text = "Especular";
            this.rbEspecular.UseVisualStyleBackColor = true;
            // 
            // buttonAplicarLuz
            // 
            this.buttonAplicarLuz.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonAplicarLuz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonAplicarLuz.FlatAppearance.BorderSize = 0;
            this.buttonAplicarLuz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAplicarLuz.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAplicarLuz.Location = new System.Drawing.Point(205, 309);
            this.buttonAplicarLuz.Name = "buttonAplicarLuz";
            this.buttonAplicarLuz.Size = new System.Drawing.Size(68, 23);
            this.buttonAplicarLuz.TabIndex = 16;
            this.buttonAplicarLuz.Text = "Aplicar";
            this.buttonAplicarLuz.UseVisualStyleBackColor = false;
            this.buttonAplicarLuz.Click += new System.EventHandler(this.buttonAplicarLuz_Click);
            // 
            // buttonLimparLuz
            // 
            this.buttonLimparLuz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonLimparLuz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonLimparLuz.FlatAppearance.BorderSize = 0;
            this.buttonLimparLuz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLimparLuz.Font = new System.Drawing.Font("Ebrima", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLimparLuz.Location = new System.Drawing.Point(288, 309);
            this.buttonLimparLuz.Name = "buttonLimparLuz";
            this.buttonLimparLuz.Size = new System.Drawing.Size(68, 23);
            this.buttonLimparLuz.TabIndex = 16;
            this.buttonLimparLuz.Text = "Limpar";
            this.buttonLimparLuz.UseVisualStyleBackColor = false;
            this.buttonLimparLuz.Click += new System.EventHandler(this.buttonLimparLuz_Click);
            // 
            // cbAlgortimo
            // 
            this.cbAlgortimo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlgortimo.FormattingEnabled = true;
            this.cbAlgortimo.Items.AddRange(new object[] {
            "Flat",
            "Gouraud",
            "Phong"});
            this.cbAlgortimo.Location = new System.Drawing.Point(28, 196);
            this.cbAlgortimo.Name = "cbAlgortimo";
            this.cbAlgortimo.Size = new System.Drawing.Size(121, 21);
            this.cbAlgortimo.TabIndex = 33;
            this.cbAlgortimo.SelectedIndexChanged += new System.EventHandler(this.cbAlgortimo_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1167, 671);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelCabecalho);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelCabecalho.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuzX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuzY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuzZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarN)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.cbAlgortimo.SelectedIndex = 0;
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
        private System.Windows.Forms.CheckBox checkBoxZBuffer;
        private System.Windows.Forms.Button btnEscolherCorZBuffer;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarLuzZ;
        private System.Windows.Forms.TrackBar trackBarLuzY;
        private System.Windows.Forms.TrackBar trackBarLuzX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBarKs;
        private System.Windows.Forms.TrackBar trackBarKd;
        private System.Windows.Forms.TrackBar trackBarKa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trackBarN;
        private System.Windows.Forms.CheckBox checkBoxLuz;
        private System.Windows.Forms.Button buttonEscolherCorLuz;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbDifusa;
        private System.Windows.Forms.RadioButton rbAmbiente;
        private System.Windows.Forms.RadioButton rbTotal;
        private System.Windows.Forms.RadioButton rbEspecular;
        private System.Windows.Forms.Button buttonLimparLuz;
        private System.Windows.Forms.Button buttonAplicarLuz;
        private System.Windows.Forms.ComboBox cbAlgortimo;
    }
}

