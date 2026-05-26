using VisualizadorObj3D.classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisualizadorObj3D
{
    public partial class Form1 : Form
    {
        private Obj3D obj3d; // Variável para armazenar o objeto 3D carregado

        // TRANSFORMAÇÕES BÁSICAS
        // escala
        private double escala = 1; // 1 por default
        // translação
        private bool arrastando = false;
        private double translacaoX = 0;
        private double translacaoY = 0;
        // rotação
        private bool rotacionando = false;
        private double rotacaoX = 0;
        private double rotacaoY = 0;

        // Flags
        private bool ehProjecao = false;
        private bool eliminarFacesOcultas = false;

        //Projecao -> denota o tipo de projeção utilizada
        public static char c = ' ';

        private Timer timerRender;
        private bool precisaRedesenhar = false;
        private Color corZBuffer = Color.White;
        private Point ultimaPosicaoObj;

        // Luz
        private bool usarLuz = false;
        private double luzX = 0, luzY = 0, luzZ = 0;
        private Color corLuz = Color.White;
        // Tonalização
        private double ka = 0, kd = 0, ks = 0;
        private int nEspecular = 0;
        private String tipoTonalizacao = "flat";
        private String componente = "total";

        // Distancia Focal
        public static int distanciaFocal = 100;
        public Form1()
        {
            InitializeComponent();
            Inicializar();
            
            // Permite que o PictureBox receba foco (necessário para o MouseWheel)
            pictureBox1.MouseEnter += (s, e) => pictureBox1.Focus();
            // Registra o evento MouseWheel manualmente
            pictureBox1.MouseWheel += pictureBox1_MouseWheel;

            timerRender = new Timer();
            timerRender.Interval = 16; // Aproximadamente 60 FPS
            timerRender.Tick += TimerRender_Tick;
            timerRender.Start();
            
        }
        private void Inicializar()
        {
            luzX = trackBarLuzX.Value / 100.0;
            luzY = trackBarLuzY.Value / 100.0;
            luzZ = trackBarLuzZ.Value / 100.0;
            ka = trackBarKa.Value / 100.0;
            kd = trackBarKd.Value / 100.0;
            ks = trackBarKs.Value / 100.0;
            nEspecular = trackBarN.Value;
            lbLuzX.Text = luzX.ToString("0.00");
            lbLuzY.Text = luzY.ToString("0.00");
            lbLuzZ.Text = luzZ.ToString("0.00");
            lbKa2.Text = ka.ToString("0.00");
            lbKd2.Text = kd.ToString("0.00");
            lbKs2.Text = ks.ToString("0.00");
            lbN2.Text = nEspecular.ToString();
            trackBarDistanciaFocal.Visible = false;
            lbDistanciaFocal.Visible = false;
            label4.Visible = false;
            AtivarDesativarComponentesIluminacao(usarLuz);
        }
        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Arquivos de Objetos 3D (*.obj)|*.obj";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                escala = 1; //escala para o valor padrão quando carregar um novo objeto
                translacaoX = translacaoY = 0; // reseta translação para o valor padrão
                rotacaoX = rotacaoY = 0;

                obj3d = new Obj3D(openFileDialog.FileName);
                obj3d.MultiplicaMatrizEscala(1,1,1);

                Bitmap imagem = obj3d.Desenhar(pictureBox1.Width, pictureBox1.Height, 1.0, ehProjecao, c, eliminarFacesOcultas);
                pictureBox1.Image = imagem;
            }
        }

        private void btnRedefinirObjOriginal_Click(object sender, EventArgs e)
        {
            if(obj3d != null)
            {
                // volta valores padrão
                escala = 1;
                translacaoX = 0;
                translacaoY = 0;
                rotacaoX = 0;
                rotacaoY = 0;

                // desativa projeção
                ehProjecao = false;
                c = ' ';

                // desmarca os radio buttons de projeção
                rbFrontal.Checked = false;
                rbLateral.Checked = false;
                rbSuperior.Checked = false;
                rbCavaleira.Checked = false;
                rbCabinete.Checked = false;
                rb1Ponto.Checked = false;
                desativarDistanciaFocal();
                // zera estados do mouse
                arrastando = false;
                rotacionando = false;

                checkBoxZBuffer.Checked = false;

                // restaura a matriz acumulada para identidade
                obj3d.ResetarMatrizAcumulada();

                eliminarFacesOcultas = false;

                // redesenha o objeto original
                Bitmap imagem = obj3d.Desenhar(pictureBox1.Width,pictureBox1.Height,1.0,ehProjecao,c, eliminarFacesOcultas);
                pictureBox1.Image = imagem;
            }
        }

        //====================================================================================================================================================
        // ======= TRANSFORMAÇÕES =======
        //====================================================================================================================================================
        // MouseWheel(scroll) para aumentar ou diminuir a ESCALA
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if(obj3d != null)
            {
                if (e.Delta > 0)
                {
                    escala += 0.5; // Aumenta a escala em x%
                }
                else
                {
                    escala -= 0.5; // Diminui a escala em x%
                    if (escala < 0.1) // Evita que a escala fique muito pequena
                    {
                        escala = 0.1;
                    }
                }

                //Redesenhar("escala");
                precisaRedesenhar = true;
            }
        }

        /**
            TRANSLAÇÃO = esquerdo do mouse
            ROTAÇÃO = direito do mouse

            botão pressionado pega posição do mouse e ativa arrastar
        */
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                arrastando = true;
                ultimaPosicaoObj = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                rotacionando = true;
                ultimaPosicaoObj = e.Location;
            }
        }

        // acumula translação ou rotação e redesenha se arrastando igual a true
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(obj3d != null)
            {
                if (arrastando)
                {
                    // Calcula a diferença de posição do mouse
                    int deltaX = e.X - ultimaPosicaoObj.X; // quanto andou horizontalmente
                    int deltaY = e.Y - ultimaPosicaoObj.Y; // quanto andou verticalmente

                    translacaoX += deltaX;
                    translacaoY += deltaY;

                    ultimaPosicaoObj = e.Location;

                    // mudo os valores de rotação na matriz AQUI!

                    //redesenha aqui
                    //Redesenhar("translacao");
                    precisaRedesenhar = true;
                }
                else if(rotacionando)
                {
                    double deltaX = e.X - ultimaPosicaoObj.X;
                    double deltaY = e.Y - ultimaPosicaoObj.Y;

                    // Movimento horizontal do mouse → rotação no eixo Y
                    // Movimento vertical do mouse   → rotação no eixo X
                    rotacaoY += deltaX * 0.5; // 0.5 = sensibilidade
                    rotacaoX += deltaY * 0.5;

                    ultimaPosicaoObj = e.Location;

                    // mudo os valores de rotação na matriz AQUI!

                    //redesenha aqui
                    //Redesenhar("rotacao");
                    precisaRedesenhar = true;
                }
            }
        }

        //	Botão solto para de arrastar
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                arrastando = false;
            else if(e.Button == MouseButtons.Right)
                rotacionando = false;

            if(obj3d != null)
                precisaRedesenhar = true;
        }

        private void Redesenhar(string operacao)
        {
            // se a flag utilizar luz estiver atvada, então na verdade é para repreencher
            if(usarLuz)
            {
                Repreencher("");
                return;
            }

            if(operacao.ToLower().Equals("rotacao"))
            {
                obj3d.MultiplicaMatrizRotacao((int)rotacaoX, 'x');
                obj3d.MultiplicaMatrizRotacao((int)rotacaoY, 'y');
            }
            else if(operacao.ToLower().Equals("translacao"))
            {
                obj3d.MultiplicaMatrizTranslacao(translacaoX, -translacaoY, 0);
            }
            else if(operacao.ToLower().Equals("escala"))
            {
                obj3d.MultiplicaMatrizEscala(escala, escala, escala);
            }

            Bitmap imagem = obj3d.Desenhar(pictureBox1.Width, pictureBox1.Height, 1.0, ehProjecao, c, eliminarFacesOcultas);
            
            if(checkBoxZBuffer.Checked)
            {
                obj3d.PreencherObjeto3D(corZBuffer, usarLuz, tipoTonalizacao, ehProjecao, c,
                    corLuz, luzX, luzY,  luzZ,  ka,  kd,  ks, nEspecular, componente);
                pictureBox1.Image = obj3d.bitmap;
            }
            else
                pictureBox1.Image = imagem;
        }

        private void Repreencher(string operacao)
        {
            if(operacao.Equals("iluminacao")) // --> teoricamente o usarLuz vai estar ativo
            {
                //para garantir
                usarLuz = true;
            }
            else
            {
                obj3d.ResetarMatrizAcumulada();
                obj3d.MultiplicaMatrizTranslacao(translacaoX, -translacaoY, 0);
                obj3d.MultiplicaMatrizRotacao((int)rotacaoX, 'x');
                obj3d.MultiplicaMatrizRotacao((int)rotacaoY, 'y');
                obj3d.MultiplicaMatrizEscala(escala, escala, escala);
            }

            // chamo o preencher objeto novamente com a matriz atualizada
            obj3d.PreencherObjeto3D(corZBuffer, usarLuz, tipoTonalizacao, ehProjecao, c,
                    corLuz, luzX, luzY,  luzZ,  ka,  kd,  ks, nEspecular, componente);
            pictureBox1.Image = obj3d.bitmap;
        }

        //====================================================================================================================================================
        // ======= PROJEÇÕES =======
        private void btAplicar_Click(object sender, EventArgs e)
        {
            if (obj3d != null)
            {
                desativarDistanciaFocal();
                if (rbLateral.Checked)
                {
                    c = 'l';
                }
                else if (rbFrontal.Checked)
                {
                    c = 'f';
                }
                else if (rbSuperior.Checked)
                {
                    c = 's';
                }
                else if (rbCavaleira.Checked)
                {
                    c = 'c';
                }
                else if (rbCabinete.Checked)
                {
                    c = 'b';
                }
                else if (rb1Ponto.Checked)
                {
                    c = 'p';
                    trackBarDistanciaFocal.Visible = true;
                    lbDistanciaFocal.Visible = true;
                    label4.Visible = true;
                }
                else
                {
                    c = ' ';
                }

                ehProjecao = true;
                eliminarFacesOcultas = checkBoxEliminarFacesOcultas.Checked;

                Redesenhar(""); // vai atualizar as informações de projeção apenas
            }
        }
        private void desativarDistanciaFocal()
        {
            trackBarDistanciaFocal.Visible = false;
            lbDistanciaFocal.Visible = false;
            label4.Visible = false;
        }
        private void btnLimparProjecoes_Click(object sender, EventArgs e)
        {
            if (obj3d != null)
            {
                // desmarca os radio buttons de projeção
                rbFrontal.Checked = false;
                rbLateral.Checked = false;
                rbSuperior.Checked = false;
                rbCavaleira.Checked = false;
                rbCabinete.Checked = false;
                rb1Ponto.Checked = false;
                checkBoxEliminarFacesOcultas.Checked = false;
                checkBoxZBuffer.Checked = false;
                desativarDistanciaFocal();

                ehProjecao = false;
                c = ' ';

                eliminarFacesOcultas = false;

                Bitmap imagem = obj3d.Desenhar(pictureBox1.Width, pictureBox1.Height, 1.0, ehProjecao, c, eliminarFacesOcultas);
                pictureBox1.Image = imagem;
            }
        }

        //====================================================================================================================================================
        // ======= Z-Buffer =======
        private void checkBoxZBuffer_CheckedChanged(object sender, EventArgs e)
        {
            if (obj3d != null)
                Redesenhar(""); // não vai alterar nenhuma transformação geométrica
        }

        private void TimerRender_Tick(object sender, EventArgs e)
        {
            if (precisaRedesenhar && obj3d != null)
            {
                precisaRedesenhar = false;
                //reseta a matriz acumulada para identidade antes de aplicar as transformações atuais
                obj3d.ResetarMatrizAcumulada();
                obj3d.MultiplicaMatrizTranslacao(translacaoX, -translacaoY, 0);
                obj3d.MultiplicaMatrizRotacao((int)rotacaoX, 'x');
                obj3d.MultiplicaMatrizRotacao((int)rotacaoY, 'y');
                obj3d.MultiplicaMatrizEscala(escala, escala, escala);
                
                if(usarLuz)
                {
                    Repreencher("iluminacao");
                }
                else
                {
                    if(checkBoxZBuffer.Checked)
                    {
                        obj3d.PreencherObjeto3D(corZBuffer, usarLuz, tipoTonalizacao, ehProjecao, c,
                            corLuz, luzX, luzY,  luzZ,  ka,  kd,  ks, nEspecular, componente);
                        pictureBox1.Image = obj3d.bitmap;
                    }
                    else
                        pictureBox1.Image = obj3d.Desenhar(pictureBox1.Width, pictureBox1.Height, 1.0, ehProjecao, c, eliminarFacesOcultas);
                }
            }
        }

        private void btnEscolherCorZBuffer_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.AnyColor = true;
            colorDialog.Color = corZBuffer;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                corZBuffer = colorDialog.Color;
                btnEscolherCorZBuffer.BackColor = corZBuffer;

                // Ajusta a cor do texto para legibilidade
                double brilho = (corZBuffer.R * 0.299) + (corZBuffer.G * 0.587) + (corZBuffer.B * 0.114);
                if (brilho < 186)
                    btnEscolherCorZBuffer.ForeColor = Color.White;
                else
                    btnEscolherCorZBuffer.ForeColor = Color.Black;


                if (obj3d != null && checkBoxZBuffer.Checked)
                    Redesenhar(""); //não vai modificar nenhuma transformação geométrica
            }
        }

        
        // LUZ

        private void buttonEscolherCorLuz_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.AnyColor = true;
            colorDialog.Color = corLuz;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                corLuz = colorDialog.Color;
                buttonEscolherCorLuz.BackColor = corLuz;

                double brilho = (corLuz.R * 0.299) + (corLuz.G * 0.587) + (corLuz.B * 0.114);
                if (brilho < 186)
                    buttonEscolherCorLuz.ForeColor = Color.White;
                else
                    buttonEscolherCorLuz.ForeColor = Color.Black;

                if (obj3d != null && usarLuz)
                    Redesenhar(""); //não vai modificar nenhuma transformação geométrica
            }
        }

        private void checkBoxLuz_CheckedChanged(object sender, EventArgs e) // aqui
        {
            // esse usar luz retorna true ou false --> usar iluminação ou não
            usarLuz = checkBoxLuz.Checked;

            // ativar desativar componentes de iluminação
            AtivarDesativarComponentesIluminacao(usarLuz);

            // seta t
            precisaRedesenhar = true;
        }
        
        private void AtivarDesativarComponentesIluminacao(bool flag)
        {
            trackBarKa.Visible = flag;
            lbKa.Visible = flag;
            lbKa2.Visible = flag;
            
            trackBarKd.Visible = flag;
            lbKd.Visible = flag;
            lbKd2.Visible = flag;
            
            trackBarKs.Visible = flag;
            lbKs.Visible = flag;
            lbKs2.Visible = flag;
            
            trackBarN.Visible = flag;
            lbN.Visible = flag;
            lbN2.Visible = flag;
            
            trackBarLuzX.Visible = flag;
            lbLuzX.Visible = flag;
            label1.Visible = flag;
            
            trackBarLuzY.Visible = flag;
            lbLuzY.Visible = flag;
            label2.Visible = flag;
            
            trackBarLuzZ.Visible = flag;
            lbLuzZ.Visible = flag;
            label3.Visible = flag;


            label8.Visible = flag;
            cbAlgortimo.Visible = flag;
            //cbAlgortimo.SelectedIndex = 2;

            label9.Visible = flag;
            groupBox2.Visible = flag;
            //rbTotal.Checked = true;
        }

        private void trackBarLuzX_Scroll(object sender, EventArgs e)
        {
            luzX = trackBarLuzX.Value / 100.0;
            lbLuzX.Text = luzX.ToString("0.00"); //definir duas casas decimais

            //repreencher
            Repreencher("iluminacao");
            precisaRedesenhar = true;
        }

        private void trackBarLuzY_Scroll(object sender, EventArgs e)
        {
            luzY = trackBarLuzY.Value / 100.0;
            lbLuzY.Text = luzY.ToString("0.00");

            //repreencher
            Repreencher("iluminacao");
            precisaRedesenhar = true;
        }

        private void trackBarLuzZ_Scroll(object sender, EventArgs e)
        {
            luzZ = trackBarLuzZ.Value / 100.0;
            lbLuzZ.Text = luzZ.ToString("0.00");

            //repreencher
            Repreencher("iluminacao");
            precisaRedesenhar = true;
        }
        
        private void trackBarKa_Scroll(object sender, EventArgs e)
        {
            ka = trackBarKa.Value / 100.0;
            lbKa2.Text = ka.ToString("0.00");

            //repreencher
            Repreencher("iluminacao");
            precisaRedesenhar = true;
        }

        private void rbTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTotal.Checked)
                componente = "total";

            //repreencher
            Repreencher("iluminacao");
            precisaRedesenhar = true;
        }

        private void rbAmbiente_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAmbiente.Checked)
                componente = "ambiente";

            //repreencher
            Repreencher("iluminacao");
            precisaRedesenhar = true;
        }

        private void rbDifusa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDifusa.Checked)
                componente = "difusa";

            //repreencher
            Repreencher("iluminacao");
            precisaRedesenhar = true;
        }

        private void rbEspecular_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEspecular.Checked)
                componente = "especular";

            //repreencher
            Repreencher("iluminacao");
            precisaRedesenhar = true;
        }

        private void trackBarDistanciaFocal_Scroll(object sender, EventArgs e)
        {
            distanciaFocal = trackBarDistanciaFocal.Value;
            lbDistanciaFocal.Text = distanciaFocal.ToString();
            precisaRedesenhar = true;
        }

        private void trackBarKd_Scroll(object sender, EventArgs e)
        {
            kd = trackBarKd.Value / 100.0;
            lbKd2.Text = kd.ToString("0.00");

            //repreencher
            Repreencher("iluminacao");
            precisaRedesenhar = true;
        }

        private void trackBarKs_Scroll(object sender, EventArgs e)
        {
            ks = trackBarKs.Value / 100.0;
            lbKs2.Text = ks.ToString("0.00");

            //repreencher
            Repreencher("iluminacao");
            precisaRedesenhar = true;
        }

        private void trackBarN_Scroll(object sender, EventArgs e)
        {
            nEspecular = trackBarN.Value;
            lbN2.Text = nEspecular.ToString();

            //repreencher
            Repreencher("iluminacao");
            precisaRedesenhar = true;
        }

        // Escolher Algortimo
        private void cbAlgortimo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoTonalizacao = cbAlgortimo.SelectedItem.ToString().ToLower();
            
            //repreencher
            Repreencher("iluminacao");
            precisaRedesenhar = true;
        }
    }
}
