using ProcessamentoImagens.classes;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace VisualizadorObj3D
{
    public partial class Form1 : Form
    {
        private double escala = 1; // 1 por default
        private Obj3D obj3d; // Variável para armazenar o objeto 3D carregado

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAbrirArquivo_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Arquivos de Objetos 3D (*.obj)|*.obj";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                obj3d = new Obj3D(openFileDialog.FileName);
                obj3d.MultiplicaMatrizEscala(1,1,1);

                Bitmap imagem = obj3d.Desenhar(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = imagem;
            }
        }

        // Evento do MouseWheel para aumentar ou diminuir a escala do objeto 3D
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                escala += 0.1; // Aumenta a escala em 10%
            }
            else
            {
                escala -= 0.1; // Diminui a escala em 10%
                if (escala < 0.1) // Evita que a escala fique muito pequena
                {
                    escala = 0.1;
                }
            }

            // Aplicar a escala na matriz de transformação do objeto 3D
            obj3d.MultiplicaMatrizEscala(escala, escala, escala);

            // Redesenha o objeto
            obj3d.Desenhar(pictureBox1.Width, pictureBox1.Height);

        }
    }
}
