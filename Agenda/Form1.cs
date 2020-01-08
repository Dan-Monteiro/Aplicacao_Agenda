using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class frmAgendaContatos : Form
    {
        public frmAgendaContatos()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnableIncluirExcluirAlterar(false);
            EnableSalvarExcluir(true);
        }

        private void frmAgendaContatos_Shown(object sender, EventArgs e)
        {
            EnableSalvarExcluir(false);
            carregarListaContatos();
        }

        private void frmAgendaContatos_Load(object sender, EventArgs e)
        {

        }

        private void EnableIncluirExcluirAlterar(bool status)
        {
            btnIncluir.Enabled = status;
            btnExcluir.Enabled = status;
            btnAlterar.Enabled = status;
        }

        private void EnableSalvarExcluir(bool status)
        {
            btnSalvar.Enabled = status;
            btnCancelar.Enabled = status;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato
            {
                Nome = txbNome.Text,
                Email = txbEmail.Text,
                NumeroTelefone = txbTelefone.Text,
            };
            List<Contato> listContatos = new List<Contato>();
            foreach(Contato item in lbxContatos.Items)
            {
                listContatos.Add(item);
            }
            listContatos.Add(contato);
            ManipuladorArquivos.EscreverArquivo(listContatos);
            limparCampos();
            carregarListaContatos();
            EnableIncluirExcluirAlterar(true);
            EnableSalvarExcluir(false);
        }

        private void carregarListaContatos()
        {
            lbxContatos.Items.Clear();
            lbxContatos.Items.AddRange(ManipuladorArquivos.LerArquivo().ToArray());
        }

        private void limparCampos()
        {
            txbNome.Text = "";
            txbEmail.Text = "";
            txbTelefone.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EnableIncluirExcluirAlterar(true);
            EnableSalvarExcluir(false);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            EnableIncluirExcluirAlterar(false);
            EnableSalvarExcluir(true);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            EnableIncluirExcluirAlterar(false);
            EnableSalvarExcluir(true);
        }
    }
}
