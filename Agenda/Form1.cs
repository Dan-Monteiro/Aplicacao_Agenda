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
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
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
            EnableIncluirExcluirAlterar(true);
            EnableSalvarExcluir(false);
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
