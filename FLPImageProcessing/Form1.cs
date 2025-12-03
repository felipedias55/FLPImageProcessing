using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace FLPImageProcessing
{
    public partial class Form1 : Form
    {
        private string selectedImagePath;
        private int imageVersion = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Imagens (*.png;*.jpg)|*.png;*.jpg",
                Title = "Selecione uma imagem"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                pictureBoxEdges.ImageLocation = imagePath;

                btnProcessImage.Enabled = true;
                btnCancel.Enabled = true;

                Console.WriteLine($"Imagem carregada de: {imagePath}");
            }
        }

        private async void btnProcessImage_Click(object sender, EventArgs e)
        {
            try
            {
                string imagePath = pictureBoxEdges.ImageLocation;
                if (string.IsNullOrEmpty(imagePath))
                {
                    MessageBox.Show("Por favor, selecione uma imagem antes de processar.");
                    return;
                }

                progressBar.Visible = true;
                lblLoading.Visible = true;
                progressBar.Value = 0;
                progressBar.Style = ProgressBarStyle.Marquee;

                await ProcessImage(imagePath);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar imagem: {ex.Message}");
                progressBar.Style = ProgressBarStyle.Continuous;
                progressBar.Value = 0;
            }
        }

        private async Task ProcessImage(string imagePath)
        {
            try
            {
                string pythonPath = @"C:\Users\felip\AppData\Local\Programs\Python\Python313\python.exe";
                string scriptPath = @"C:\Users\felip\source\repos\FLPImageProcessing\FLPImageProcessing\Utils\image_processing.py";
                string finalImagePath = @"C:\Users\felip\source\repos\FLPImageProcessing\FLPImageProcessing\Utils\Images\imagem_final_colorida.png";

                if (!File.Exists(imagePath))
                {
                    MessageBox.Show("A imagem não foi encontrada no caminho especificado.");
                    return;
                }

                ProcessStartInfo start = new ProcessStartInfo
                {
                    FileName = pythonPath,
                    Arguments = $"\"{scriptPath}\" \"{imagePath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(start))
                {

                    string output = await process.StandardOutput.ReadToEndAsync();
                    Console.WriteLine(output);

                    string error = await process.StandardError.ReadToEndAsync();
                    if (!string.IsNullOrEmpty(error))
                    {
                        MessageBox.Show($"Erro no script Python: {error}");
                    }

                    await process.WaitForExitAsync();

                    if (process.ExitCode != 0)
                    {
                        MessageBox.Show($"Erro ao processar imagem: Código de saída {process.ExitCode}");
                        return;
                    }

                    pictureBoxQuantized.ImageLocation = finalImagePath;

                    progressBar.Style = ProgressBarStyle.Continuous;
                    progressBar.Value = 100;
                    lblLoading.Visible = false;

                    MessageBox.Show("Processamento concluído com sucesso!");

                    btnChange.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar imagem: {ex.Message}");
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string pathColorida = @"C:\Users\felip\source\repos\FLPImageProcessing\FLPImageProcessing\Utils\Images\imagem_final_colorida.png";
            string pathPB = @"C:\Users\felip\source\repos\FLPImageProcessing\FLPImageProcessing\Utils\Images\imagem_final_pb.png";
            string pathContorno = @"C:\Users\felip\source\repos\FLPImageProcessing\FLPImageProcessing\Utils\Images\contornos.png";

            if (!File.Exists(pathColorida) || !File.Exists(pathPB) || !File.Exists(pathContorno))
            {
                MessageBox.Show("As imagens colorida, preto e branco ou contorno não foram encontradas. Por favor, processe a imagem primeiro.");
                return;
            }

            switch (imageVersion)
            {
                case 0:
                    pictureBoxQuantized.Image = Image.FromFile(pathPB);
                    btnChange.Text = "Exibir Contornos";
                    imageVersion = 1;
                break;
                case 1:
                    pictureBoxQuantized.Image = Image.FromFile(pathContorno);
                    btnChange.Text = "Exibir Colorido";
                    imageVersion = 2;
                break;
                case 2:
                    pictureBoxQuantized.Image = Image.FromFile(pathColorida);
                    btnChange.Text = "Exibir Preto e Branco";
                    imageVersion = 0;
                break;
            }
        }

        private void pictureBoxEdges_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxQuantized_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pictureBoxEdges.ImageLocation = null;
            pictureBoxQuantized.ImageLocation = null;
            pictureBoxQuantized.Image = null;

            progressBar.Visible = false;
            lblLoading.Visible = false;
            progressBar.Value = 0;
            progressBar.Style = ProgressBarStyle.Marquee;

            btnProcessImage.Enabled = false;
            btnChange.Enabled = false;
            MessageBox.Show("Operação Cancelada!");
        }
    }
}
