namespace WinFormsApp10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            lblMensagem.Text = "Carregando...";
            var produto = new Produto();
            if (await produto.ObterProdutosAsyncAll() == null)
            {
                lblMensagem.Text = "Erro ao carregar produtos";
                return;
            }
            else
                lblMensagem.Text = "";
            var produtos = await produto.ObterProdutosAsyncAll();

            dataGridView1.DataSource = produtos;

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                using (var frm = new FrmProduto(id, Operacao.Consultar))
                {
                    frm.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("Nenhum produto selecionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                using (var frm = new FrmProduto(id, Operacao.Alterar))
                {
                    frm.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("Nenhum produto selecionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmProduto(0, Operacao.Adicionar)) 
                frm.ShowDialog();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                using (var frm = new FrmProduto(id, Operacao.Adicionar))
                {
                    frm.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("Nenhum produto selecionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




        }
    }
}
