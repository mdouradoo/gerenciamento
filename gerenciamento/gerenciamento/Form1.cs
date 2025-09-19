using gerenciamento.objeto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gerenciamento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            //chamo o metodo da conexao
            conexao com = new conexao();
            com.getConexao();
            // chama o objeto do financeiro
            financeiro finan = new financeiro();
            finan.id = Convert.ToInt32(txtCodigo.Text);
            finan.descricao = txtDescricao.Text;
            finan.servico = cboServico.Text;
            finan.tipo = cboTipo.Text;
            finan.valor = decimal.Parse(txtValor.Text);
            finan.pgto = data_Lancamento.Checked;
            finan.data_lancamento = Data_lancamento.Value;
            if (finan.editar(com) == true)
            {
                MessageBox.Show("Editado com sucesso!");
            }
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            //chamo o metodo da conexao
            conexao com = new conexao();
            com.getConexao();
            // chama o objeto do financeiro
            financeiro financeiro = new financeiro();
            financeiro.id = Convert.ToInt32(txtCodigo.Text);
            if (financeiro.Excluir(com) == true)
            {
                MessageBox.Show("Excluido com sucesso");
                dataGridView1.Refresh();
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            conexao com = new conexao();
            com.getConexao();
            if (string.IsNullOrEmpty(txtPesquisar.Text))
            {
                dataGridView1.DataSource = com.obterdados("select * from financeiro");
            }
            else
            {
                dataGridView1.DataSource = com.obterdados("select * from financeiro where descricao like '%" + txtPesquisar.Text + "%' or data_lancamento like '%" + txtPesquisar.Text + "%'");
            }
        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            conexao con = new conexao();
            con.getConexao();
            //chamando o objeto financeiro
            financeiro fin = new financeirocs();
            //populando as informações
            fin.data_lancamento = Data_lancamento.Value;
            fin.descricao = txtDescricao.Text;
            fin.servico = cboServico.Text;
            fin.valor = decimal.Parse(txtValor.Text);
            fin.tipo = cboTipo.Text;
            fin.pgto = data_Lancamento.Checked;
            if (fin.cadastrar(con) == true)
            {
                MessageBox.Show("Cadastrado com sucesso");
                dataGridView1.Refresh();// atualiza o grid
            }
        }

        private void chkpagamento_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
       