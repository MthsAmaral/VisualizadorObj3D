using ProcessamentoImagens.classes;
using System;
using System.Drawing;
using System.Windows.Forms;
using VisualizadorObj3D.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace VisualizadorObj3D
{
    public partial class Form1 : Form
    {
        private Obj3D obj3d; // Variável para armazenar o objeto 3D carregado
        private Point ultimaPosicaoObj;

   
        private double escala = 1; // 1 por default
        //translação
        private bool arrastando = false;
        private double translacaoX = 0;
        private double translacaoY = 0;
        //rotação
        private bool rotacionando = false;
        private double rotacaoX = 0;
        private double rotacaoY = 0;
        // Flags
        private bool ehProjecao = false;
        private bool eliminarFacesOcultas = false;
        //Projecao Ortografica
        public static char c = ' ';



        public Form1()
        {
            InitializeComponent();


            // Permite que o PictureBox receba foco (necessário para o MouseWheel)
            pictureBox1.MouseEnter += (s, e) => pictureBox1.Focus();
            // Registra o evento MouseWheel manualmente
            pictureBox1.MouseWheel += pictureBox1_MouseWheel;
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

                // zera estados do mouse
                arrastando = false;
                rotacionando = false;

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

                Redesenhar();
            }
        }





        //TRANSLAÇÃO = esquerdo do mouse
        //ROTAÇÃO = direito do mouse

        //botão pressionado pega posição do mouse e ativa arrastar
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

        //acumula translação ou rotação e redesenha se arrastando igual a true
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
                    
                }
                Redesenhar();
            }
            
        }

        //	Botão solto para de arrastar
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                arrastando = false;
            }
            else if(e.Button == MouseButtons.Right)
            {
                rotacionando = false;
            }
        }

        private void Redesenhar()
        {
            obj3d.ResetarMatrizAcumulada();//reseta a matriz acumulada para identidade antes de aplicar as transformações atuais


            // primeiro translação, depois rotação e por último escala
            obj3d.MultiplicaMatrizTranslacao(translacaoX, -translacaoY, 0);
            
            obj3d.MultiplicaMatrizRotacao((int)rotacaoX, 'x');
            obj3d.MultiplicaMatrizRotacao((int)rotacaoY, 'y');
            
            obj3d.MultiplicaMatrizEscala(escala, escala, escala);

            Bitmap imagem = obj3d.Desenhar(pictureBox1.Width, pictureBox1.Height, 1.0, ehProjecao, c, eliminarFacesOcultas);
            pictureBox1.Image = imagem;
        }




        //====================================================================================================================================================
        // ======= PROJEÇÕES =======
        private void btAplicar_Click(object sender, EventArgs e)
        {
            if (obj3d != null)
            {
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
                }
                else
                {
                    c = ' ';
                }

                ehProjecao = true;
                eliminarFacesOcultas = checkBoxEliminarFacesOcultas.Checked;

                Redesenhar();
            }
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


                ehProjecao = false;
                c = ' ';

                eliminarFacesOcultas = false;

                Bitmap imagem = obj3d.Desenhar(pictureBox1.Width, pictureBox1.Height, 1.0, ehProjecao, c, eliminarFacesOcultas);
                pictureBox1.Image = imagem;
            }
        }




        //====================================================================================================================================================
        // ======= Z-Buffer =======
        private void btnZBuffer_Click(object sender, EventArgs e)
        {
            obj3d.PreencherObjeto3D(Color.Red);
            pictureBox1.Image = obj3d.bitmap;
        }





    }
}
