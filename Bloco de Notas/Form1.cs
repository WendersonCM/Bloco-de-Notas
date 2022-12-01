using System.CodeDom;

namespace Bloco_de_Notas
{
    public partial class Frm1 : Form
    {
        private OpenFileDialog AbrirDialogo;
        private SaveFileDialog SalvarDialogo;
        private FontDialog FonteDialogo;

        public Frm1()
        {
            InitializeComponent();
        }

        private void Frm1_Load(object sender, EventArgs e)
        {
            FonteDialogo = new FontDialog();
        }

        private void CriarNovo()
        {
            try
            {
                if (string.IsNullOrEmpty(this.richTextBox1.Text))
                {
                    this.Text = "Sem título";
                    this.richTextBox1.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Arquivo Não Foi Salvo!");
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void AbrirArquivo()
        {
            try
            {
                AbrirDialogo = new OpenFileDialog();

                if (AbrirDialogo.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Text = File.ReadAllText(AbrirDialogo.FileName);
                    this.Text = AbrirDialogo.FileName;
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                AbrirDialogo = null;
            }
        }
        private void SalvarArquivo()
        {
            try
            {
                SalvarDialogo = new SaveFileDialog();
                SalvarDialogo.Filter = "Arquivo de Texto (*.txt) | *.txt";

                if (SalvarDialogo.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(SalvarDialogo.FileName, this.richTextBox1.Text);
                    this.Text = SalvarDialogo.FileName;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                AbrirDialogo = null;
            }
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalvarArquivo();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CriarNovo();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirArquivo();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fonteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(FonteDialogo.ShowDialog() == DialogResult.OK)
                {
                    this.richTextBox1.Font = FonteDialogo.Font;
                } 
            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }
    }
}