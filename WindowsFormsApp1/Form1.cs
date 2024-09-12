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

        

        private void btnInserir_Click(object sender, EventArgs e)
        {
            dgvProdutos.Rows.Add(txtProduto.Text, txtQuantidade.Text, txtValorUnitario.Text);
            double quantidade = double.Parse(txtQuantidade.Text);
            double valor = double.Parse(txtValorUnitario.Text);
            ValorT += quantidade * valor;
            ValorTotal.Text = ValorT.ToString();

            txtProduto.Clear();
            txtQuantidade.Clear();
            txtValorUnitario.Clear();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.RowCount > 0)
            {
                double removerValor = double.Parse(dgvProdutos.CurrentRow.Cells["Quantidade"].Value.ToString()) *
                    double.Parse(dgvProdutos.CurrentRow.Cells["Valor"].Value.ToString());

                double totalAlterado = ValorT - removerValor;

                Venda.Text = dgvProdutos.RowCount.ToString();

                ValorTotal.Text = totalAlterado.ToString("c");

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
                dgvProdutos.CurrentRow.Cells[1].Value = txtAlterar.Text;
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
            ValorTotal.Text = 0.ToString("c");
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
                ValorTotal.Text = 0.ToString("c");
                VendaContar -= 1;
                Venda.Text = VendaContar.ToString();
            }
            else { MessageBox.Show("Não existem vendas registradas ainda!", "Erro", MessageBoxButtons.OK); }
        }
    }
}
