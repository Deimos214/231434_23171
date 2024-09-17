using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Venda.Text = "0";
        }

        double ValorT;

        int VendaContar;

        double contador = 0;

        private void btnInserir_Click(object sender, EventArgs e)
        {
            dgvProdutos.Rows.Add(txtProduto.Text, txtQuantidade.Text, txtValorUnitario.Text);
            

            contador += Convert.ToDouble(txtQuantidade.Text) * Convert.ToDouble(txtValorUnitario.Text);
            lblValorTotal.Text = contador.ToString();
            txtProduto.Clear();
            txtQuantidade.Clear();
            txtValorUnitario.Clear();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.RowCount > 0)
            {
                
                double removerValor = Convert.ToDouble(dgvProdutos.CurrentRow.Cells[1].Value) * Convert.ToDouble(dgvProdutos.CurrentRow.Cells[2].Value);

                contador -= removerValor;

                lblValorTotal.Text = contador.ToString();
                dgvProdutos.Rows.RemoveAt(dgvProdutos.CurrentCell.RowIndex);
            }

                txtProduto.Clear();
            txtQuantidade.Clear();
            txtValorUnitario.Clear();
            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            if (txtAlterar.Text != "")
            {
                contador -= double.Parse(dgvProdutos.CurrentRow.Cells[1].Value.ToString()) * double.Parse(dgvProdutos.CurrentRow.Cells[2].Value.ToString());
                dgvProdutos.CurrentRow.Cells[1].Value = txtAlterar.Text;
                txtAlterar.Clear();
                if (dgvProdutos.RowCount > 0)
                {
                    double total = double.Parse(dgvProdutos.CurrentRow.Cells[1].Value.ToString()) * double.Parse(dgvProdutos.CurrentRow.Cells[2].Value.ToString());
                    contador += total;
                    lblValorTotal.Text = contador.ToString("C");
                }
                MessageBox.Show("Quantidade alterada com sucesso", "Exclusão",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProdutos.RowCount > 0)
            {
                txtAlterar.Text = dgvProdutos.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            txtProduto.Clear();
            txtQuantidade.Clear();
            txtValorUnitario.Clear();
            txtAlterar.Clear();
            dgvProdutos.Rows.Clear();
            lblValorTotal.Text = 0.ToString("c");
            VendaContar += 1;
            Venda.Text = VendaContar.ToString();
        }

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtValorUnitario_TextChanged(object sender, EventArgs e)
        {

        }

        private void ValorTotal_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Venda.Text != "0")
            {
                txtProduto.Clear();
                txtQuantidade.Clear();
                txtValorUnitario.Clear();
                txtAlterar.Clear();
                dgvProdutos.Rows.Clear();
                lblValorTotal.Text = 0.ToString("c");
                VendaContar -= 1;
                Venda.Text = VendaContar.ToString();
            }
            else { MessageBox.Show("Não existem vendas registradas ainda!", "Erro", MessageBoxButtons.OK); }
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAlterar.Text = dgvProdutos.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
