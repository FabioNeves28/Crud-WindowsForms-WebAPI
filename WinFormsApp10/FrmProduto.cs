using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
           
            if (operacao == Operacao.Consultar)
            {
                produto = await produto.ObterProdutoAsync(produto.id);
                if (produto != null)
                    PreencherCampos(produto);
            }
            else if (operacao == Operacao.Alterar)
            {
                produto = await produto.AlterarProdutoAsync(produto.id);
            }
            else if (operacao == Operacao.Adicionar)
            {

            }
            else if (operacao == Operacao.Excluir)
            {
                produto = await produto.DeletarProdutoAsync(produto.id);
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
    }
}
