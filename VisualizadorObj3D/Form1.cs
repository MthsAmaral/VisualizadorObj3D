using ProcessamentoImagens.classes;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace VisualizadorObj3D
{
    public partial class Form1 : Form
    {


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
                Obj3D obj3d = new Obj3D(openFileDialog.FileName);

               

                Bitmap imagem = obj3d.Desenhar(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = imagem;
            }
        }
    }
}
