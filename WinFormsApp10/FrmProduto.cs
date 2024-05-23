using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp10
{
    public partial class FrmProduto : Form
    {
        private Produto produto = new Produto();
        private Operacao operacao = new Operacao();
        public FrmProduto(int id, Operacao operacaoEnum)
        {
            InitializeComponent();

            produto.id = id;
            operacao = operacaoEnum;

            Despachante();
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {

        }

        private async void Despachante()
        {
            await PreencherComboBoxUnidadeMedida();
            await PreencherComboBoxCategoria();

            if (operacao == Operacao.Consultar)
            {
                produto = await produto.ObterProdutoAsync(produto.id);
                btnGerarPdf.Visible = true;
                pictureBox1.Visible = true;
                if (produto != null)
                    PreencherCampos(produto);
                Button GerarPdf = new Button();
                GerarPdf.Text = "Gerar PDF";
                GerarPdf.Location = new Point(10, 10);
                GerarPdf.Click += new EventHandler(btnGerarPdf_Click);
                this.Controls.Add(btnGerarPdf);
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox txt = (TextBox)item;
                        txt.ReadOnly = true;
                    }
                    else if (item is ComboBox)
                    {
                        ComboBox cb = (ComboBox)item;
                        cb.Enabled = false;
                    }
                }
            }
            else if (operacao == Operacao.Alterar)
            {
                produto = await produto.AlterarProdutoAsync(produto.id);
                if (produto != null)
                    PreencherCampos(produto);

                button1.Visible = true;

            }
            else if (operacao == Operacao.Adicionar)
            {
                button1.Visible = true;
            }
            else if (operacao == Operacao.Excluir)
            {
                produto = await produto.DeletarProdutoAsync(produto.id);
                if (produto != null)
                    PreencherCampos(produto);

                button1.Visible = true;

            }

        }
        public void PreencherCampos(Produto produto)
        {
            textBox1.Text = produto.id.ToString();
            textBox2.Text = produto.descricao;
            comboBox2.SelectedValue = produto.un;
            comboBox1.SelectedValue = produto.idCategoria.ToString();
            textBox4.Text = produto.precoCusto.ToString();
            textBox5.Text = produto.precoVenda.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGerarPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Salvar arquivo PDF";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Paragraph("Informações do Produto"));
                    pdfDoc.Add(new Paragraph($"ID: {produto.id}"));
                    pdfDoc.Add(new Paragraph($"Nome: {produto.descricao}"));
                    pdfDoc.Add(new Paragraph($"Descrição: {produto.un}"));
                    pdfDoc.Add(new Paragraph($"Categoria: {produto.idCategoria.ToString()}"));
                    pdfDoc.Add(new Paragraph($"Preço de Custo: {produto.precoCusto}"));
                    pdfDoc.Add(new Paragraph($"Preço de Venda: {produto.precoVenda}"));
                    pdfDoc.Close();
                }
            }
        }

        private async Task<bool> PreencherComboBoxUnidadeMedida()
        {
            List<UnidadeMedida> unidadeMedidas = await new UnidadeMedida().ObterUnidadeMedidaAsyncAll();
            comboBox2.DisplayMember = "descricao";
            comboBox2.ValueMember = "sigla";
            comboBox2.DataSource = unidadeMedidas;
            comboBox2.SelectedIndex = -1;
            return true;
         
        }
        private async Task<bool> PreencherComboBoxCategoria()
        {
            List<ProdutoCategoria> categorias = await new ProdutoCategoria().ObterProdutoCategoriaAsyncAll();
            comboBox1.DisplayMember = "descricao";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = categorias;
            comboBox1.SelectedIndex = -1;   
            return true;
          
        }

    }
}
