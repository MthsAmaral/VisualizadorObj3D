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
            this.lbKa2 = new System.Windows.Forms.Label();
            this.lbKd2 = new System.Windows.Forms.Label();
            this.lbKs2 = new System.Windows.Forms.Label();
            this.lbN2 = new System.Windows.Forms.Label();
            this.lbLuzZ = new System.Windows.Forms.Label();
            this.lbLuzY = new System.Windows.Forms.Label();
            this.lbLuzX = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbN = new System.Windows.Forms.Label();
            this.cbAlgortimo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbDifusa = new System.Windows.Forms.RadioButton();
            this.rbAmbiente = new System.Windows.Forms.RadioButton();
            this.rbTotal = new System.Windows.Forms.RadioButton();
            this.rbEspecular = new System.Windows.Forms.RadioButton();
            this.checkBoxLuz = new System.Windows.Forms.CheckBox();
            this.buttonEscolherCorLuz = new System.Windows.Forms.Button();
            this.trackBarN = new System.Windows.Forms.TrackBar();
            this.lbKs = new System.Windows.Forms.Label();
            this.lbKd = new System.Windows.Forms.Label();
            this.lbKa = new System.Windows.Forms.Label();
            this.trackBarKs = new System.Windows.Forms.TrackBar();
            this.trackBarKd = new System.Windows.Forms.TrackBar();
            this.trackBarKa = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarLuzZ = new System.Windows.Forms.TrackBar();
            this.trackBarLuzY = new System.Windows.Forms.TrackBar();
            this.trackBarLuzX = new System.Windows.Forms.TrackBar();
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
            this.checkBoxZBuffer = new System.Windows.Forms.CheckBox();
            this.btnEscolherCorZBuffer = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelCabecalho.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuzZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuzY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuzX)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(411, 655);
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
            this.textBox5.Text = "Iluminação e Tonalização";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbKa2);
            this.panel3.Controls.Add(this.lbKd2);
            this.panel3.Controls.Add(this.lbKs2);
            this.panel3.Controls.Add(this.lbN2);
            this.panel3.Controls.Add(this.lbLuzZ);
            this.panel3.Controls.Add(this.lbLuzY);
            this.panel3.Controls.Add(this.lbLuzX);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.lbN);
            this.panel3.Controls.Add(this.cbAlgortimo);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.checkBoxLuz);
            this.panel3.Controls.Add(this.buttonEscolherCorLuz);
            this.panel3.Controls.Add(this.trackBarN);
            this.panel3.Controls.Add(this.lbKs);
            this.panel3.Controls.Add(this.lbKd);
            this.panel3.Controls.Add(this.lbKa);
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
            this.panel3.Size = new System.Drawing.Size(375, 356);
            this.panel3.TabIndex = 14;
            // 
            // lbKa2
            // 
            this.lbKa2.AutoSize = true;
            this.lbKa2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbKa2.Location = new System.Drawing.Point(337, 3);
            this.lbKa2.Name = "lbKa2";
            this.lbKa2.Size = new System.Drawing.Size(28, 13);
            this.lbKa2.TabIndex = 43;
            this.lbKa2.Text = "10.0";
            // 
            // lbKd2
            // 
            this.lbKd2.AutoSize = true;
            this.lbKd2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbKd2.Location = new System.Drawing.Point(337, 54);
            this.lbKd2.Name = "lbKd2";
            this.lbKd2.Size = new System.Drawing.Size(28, 13);
            this.lbKd2.TabIndex = 42;
            this.lbKd2.Text = "10.0";
            // 
            // lbKs2
            // 
            this.lbKs2.AutoSize = true;
            this.lbKs2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbKs2.Location = new System.Drawing.Point(337, 113);
            this.lbKs2.Name = "lbKs2";
            this.lbKs2.Size = new System.Drawing.Size(28, 13);
            this.lbKs2.TabIndex = 41;
            this.lbKs2.Text = "10.0";
            // 
            // lbN2
            // 
            this.lbN2.AutoSize = true;
            this.lbN2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbN2.Location = new System.Drawing.Point(337, 161);
            this.lbN2.Name = "lbN2";
            this.lbN2.Size = new System.Drawing.Size(28, 13);
            this.lbN2.TabIndex = 40;
            this.lbN2.Text = "10.0";
            // 
            // lbLuzZ
            // 
            this.lbLuzZ.AutoSize = true;
            this.lbLuzZ.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbLuzZ.Location = new System.Drawing.Point(121, 129);
            this.lbLuzZ.Name = "lbLuzZ";
            this.lbLuzZ.Size = new System.Drawing.Size(28, 13);
            this.lbLuzZ.TabIndex = 39;
            this.lbLuzZ.Text = "10.0";
            // 
            // lbLuzY
            // 
            this.lbLuzY.AutoSize = true;
            this.lbLuzY.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbLuzY.Location = new System.Drawing.Point(121, 70);
            this.lbLuzY.Name = "lbLuzY";
            this.lbLuzY.Size = new System.Drawing.Size(28, 13);
            this.lbLuzY.TabIndex = 38;
            this.lbLuzY.Text = "10.0";
            // 
            // lbLuzX
            // 
            this.lbLuzX.AutoSize = true;
            this.lbLuzX.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbLuzX.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbLuzX.Location = new System.Drawing.Point(123, 3);
            this.lbLuzX.Name = "lbLuzX";
            this.lbLuzX.Size = new System.Drawing.Size(28, 13);
            this.lbLuzX.TabIndex = 37;
            this.lbLuzX.Text = "10.0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(130, 279);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Mostrar Componente";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(209, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Modelos de Tonalização";
            // 
            // lbN
            // 
            this.lbN.AutoSize = true;
            this.lbN.Location = new System.Drawing.Point(202, 161);
            this.lbN.Name = "lbN";
            this.lbN.Size = new System.Drawing.Size(67, 13);
            this.lbN.TabIndex = 34;
            this.lbN.Text = "n - Shininess";
            // 
            // cbAlgortimo
            // 
            this.cbAlgortimo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlgortimo.FormattingEnabled = true;
            this.cbAlgortimo.Items.AddRange(new object[] {
            "Phong",
            "Gouraud",
            "Flat"});
            this.cbAlgortimo.Location = new System.Drawing.Point(202, 241);
            this.cbAlgortimo.Name = "cbAlgortimo";
            this.cbAlgortimo.Size = new System.Drawing.Size(130, 21);
            this.cbAlgortimo.TabIndex = 33;
            this.cbAlgortimo.SelectedIndexChanged += new System.EventHandler(this.cbAlgortimo_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox2.Controls.Add(this.rbDifusa);
            this.groupBox2.Controls.Add(this.rbAmbiente);
            this.groupBox2.Controls.Add(this.rbTotal);
            this.groupBox2.Controls.Add(this.rbEspecular);
            this.groupBox2.Location = new System.Drawing.Point(16, 295);
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
            this.rbDifusa.CheckedChanged += new System.EventHandler(this.rbDifusa_CheckedChanged);
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
            this.rbAmbiente.CheckedChanged += new System.EventHandler(this.rbAmbiente_CheckedChanged);
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
            this.rbTotal.CheckedChanged += new System.EventHandler(this.rbTotal_CheckedChanged);
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
            this.rbEspecular.CheckedChanged += new System.EventHandler(this.rbEspecular_CheckedChanged);
            // 
            // checkBoxLuz
            // 
            this.checkBoxLuz.AutoSize = true;
            this.checkBoxLuz.Location = new System.Drawing.Point(16, 196);
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
            this.buttonEscolherCorLuz.Location = new System.Drawing.Point(65, 190);
            this.buttonEscolherCorLuz.Name = "buttonEscolherCorLuz";
            this.buttonEscolherCorLuz.Size = new System.Drawing.Size(84, 23);
            this.buttonEscolherCorLuz.TabIndex = 32;
            this.buttonEscolherCorLuz.Text = "Escolher Cor";
            this.buttonEscolherCorLuz.UseVisualStyleBackColor = false;
            this.buttonEscolherCorLuz.Click += new System.EventHandler(this.buttonEscolherCorLuz_Click);
            // 
            // trackBarN
            // 
            this.trackBarN.LargeChange = 1;
            this.trackBarN.Location = new System.Drawing.Point(186, 177);
            this.trackBarN.Maximum = 256;
            this.trackBarN.Minimum = 1;
            this.trackBarN.Name = "trackBarN";
            this.trackBarN.Size = new System.Drawing.Size(179, 45);
            this.trackBarN.TabIndex = 29;
            this.trackBarN.Value = 10;
            this.trackBarN.Scroll += new System.EventHandler(this.trackBarN_Scroll);
            // 
            // lbKs
            // 
            this.lbKs.AutoSize = true;
            this.lbKs.Location = new System.Drawing.Point(202, 113);
            this.lbKs.Name = "lbKs";
            this.lbKs.Size = new System.Drawing.Size(130, 13);
            this.lbKs.TabIndex = 28;
            this.lbKs.Text = "ks - Coeficiente Especular";
            // 
            // lbKd
            // 
            this.lbKd.AutoSize = true;
            this.lbKd.Location = new System.Drawing.Point(203, 54);
            this.lbKd.Name = "lbKd";
            this.lbKd.Size = new System.Drawing.Size(120, 13);
            this.lbKd.TabIndex = 27;
            this.lbKd.Text = "kd - Coefieciente Difuso";
            // 
            // lbKa
            // 
            this.lbKa.AutoSize = true;
            this.lbKa.Location = new System.Drawing.Point(202, 3);
            this.lbKa.Name = "lbKa";
            this.lbKa.Size = new System.Drawing.Size(128, 13);
            this.lbKa.TabIndex = 26;
            this.lbKa.Text = "ka - Coeficiente Ambiente";
            // 
            // trackBarKs
            // 
            this.trackBarKs.LargeChange = 1;
            this.trackBarKs.Location = new System.Drawing.Point(185, 129);
            this.trackBarKs.Maximum = 100;
            this.trackBarKs.Name = "trackBarKs";
            this.trackBarKs.Size = new System.Drawing.Size(189, 45);
            this.trackBarKs.TabIndex = 25;
            this.trackBarKs.Value = 50;
            this.trackBarKs.Scroll += new System.EventHandler(this.trackBarKs_Scroll);
            // 
            // trackBarKd
            // 
            this.trackBarKd.LargeChange = 1;
            this.trackBarKd.Location = new System.Drawing.Point(186, 70);
            this.trackBarKd.Maximum = 100;
            this.trackBarKd.Name = "trackBarKd";
            this.trackBarKd.Size = new System.Drawing.Size(188, 45);
            this.trackBarKd.TabIndex = 24;
            this.trackBarKd.Value = 80;
            this.trackBarKd.Scroll += new System.EventHandler(this.trackBarKd_Scroll);
            // 
            // trackBarKa
            // 
            this.trackBarKa.LargeChange = 1;
            this.trackBarKa.Location = new System.Drawing.Point(186, 17);
            this.trackBarKa.Maximum = 100;
            this.trackBarKa.Name = "trackBarKa";
            this.trackBarKa.Size = new System.Drawing.Size(188, 45);
            this.trackBarKa.TabIndex = 23;
            this.trackBarKa.Value = 20;
            this.trackBarKa.Scroll += new System.EventHandler(this.trackBarKa_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Luz Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Luz Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Luz X";
            // 
            // trackBarLuzZ
            // 
            this.trackBarLuzZ.Location = new System.Drawing.Point(6, 145);
            this.trackBarLuzZ.Maximum = 100;
            this.trackBarLuzZ.Minimum = -100;
            this.trackBarLuzZ.Name = "trackBarLuzZ";
            this.trackBarLuzZ.Size = new System.Drawing.Size(145, 45);
            this.trackBarLuzZ.TabIndex = 19;
            this.trackBarLuzZ.Value = 100;
            this.trackBarLuzZ.Scroll += new System.EventHandler(this.trackBarLuzZ_Scroll);
            // 
            // trackBarLuzY
            // 
            this.trackBarLuzY.Location = new System.Drawing.Point(6, 81);
            this.trackBarLuzY.Maximum = 100;
            this.trackBarLuzY.Minimum = -100;
            this.trackBarLuzY.Name = "trackBarLuzY";
            this.trackBarLuzY.Size = new System.Drawing.Size(145, 45);
            this.trackBarLuzY.TabIndex = 18;
            this.trackBarLuzY.Value = 100;
            this.trackBarLuzY.Scroll += new System.EventHandler(this.trackBarLuzY_Scroll);
            // 
            // trackBarLuzX
            // 
            this.trackBarLuzX.Location = new System.Drawing.Point(6, 19);
            this.trackBarLuzX.Maximum = 100;
            this.trackBarLuzX.Minimum = -100;
            this.trackBarLuzX.Name = "trackBarLuzX";
            this.trackBarLuzX.Size = new System.Drawing.Size(155, 45);
            this.trackBarLuzX.TabIndex = 17;
            this.trackBarLuzX.Value = 50;
            this.trackBarLuzX.Scroll += new System.EventHandler(this.trackBarLuzX_Scroll);
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
            this.panel2.Size = new System.Drawing.Size(375, 208);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1171, 671);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuzZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuzY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuzX)).EndInit();
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
        private System.Windows.Forms.Label lbKs;
        private System.Windows.Forms.Label lbKd;
        private System.Windows.Forms.Label lbKa;
        private System.Windows.Forms.TrackBar trackBarKs;
        private System.Windows.Forms.TrackBar trackBarKd;
        private System.Windows.Forms.TrackBar trackBarKa;
        private System.Windows.Forms.TrackBar trackBarN;
        private System.Windows.Forms.CheckBox checkBoxLuz;
        private System.Windows.Forms.Button buttonEscolherCorLuz;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbDifusa;
        private System.Windows.Forms.RadioButton rbAmbiente;
        private System.Windows.Forms.RadioButton rbTotal;
        private System.Windows.Forms.RadioButton rbEspecular;
        private System.Windows.Forms.ComboBox cbAlgortimo;
        private System.Windows.Forms.Label lbN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbKa2;
        private System.Windows.Forms.Label lbKd2;
        private System.Windows.Forms.Label lbKs2;
        private System.Windows.Forms.Label lbN2;
        private System.Windows.Forms.Label lbLuzZ;
        private System.Windows.Forms.Label lbLuzY;
        private System.Windows.Forms.Label lbLuzX;
    }
}

