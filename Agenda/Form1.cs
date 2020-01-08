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

        private OperacaoEnum acao;

        public frmAgendaContatos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HabilitarIncluirExcluirAlterar(false);
            HabilitarSalvarExcluir(true);
            HabilitarCampos(true);

            acao = OperacaoEnum.INCLUIR;
        }

        private void frmAgendaContatos_Shown(object sender, EventArgs e)
        {
            HabilitarSalvarExcluir(false);
            HabilitarCampos(false);
            carregarListaContatos();
        }

        private void frmAgendaContatos_Load(object sender, EventArgs e)
        {

        }

        private void HabilitarIncluirExcluirAlterar(bool status)
        {
            btnIncluir.Enabled = status;
            btnExcluir.Enabled = status;
            btnAlterar.Enabled = status;
        }

        private void HabilitarSalvarExcluir(bool status)
        {
            btnSalvar.Enabled = status;
            btnCancelar.Enabled = status;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            //Declaracao de vars

            Contato contato;
            List<Contato> listContatos;

            contato = new Contato
            {
                Nome = txbNome.Text,
                Email = txbEmail.Text,
                NumeroTelefone = txbTelefone.Text,
            };

            listContatos = new List<Contato>();

            //Manipulação da lista

            foreach (Contato item in lbxContatos.Items)
            {
                listContatos.Add(item);
            }

            if (acao == OperacaoEnum.ALTERAR)
            {
                int index = lbxContatos.SelectedIndex;
                listContatos.RemoveAt(index);
                listContatos.Insert(index, contato);
            }
            else
            {
                listContatos.Add(contato);
            }

            //Métodos de finalização processo

            ManipuladorArquivos.EscreverArquivo(listContatos);
            limparCampos();
            carregarListaContatos();
            HabilitarCampos(false);
            HabilitarIncluirExcluirAlterar(true);
            HabilitarSalvarExcluir(false);
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
            HabilitarIncluirExcluirAlterar(true);
            HabilitarCampos(false);
            HabilitarSalvarExcluir(false);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            HabilitarIncluirExcluirAlterar(false);
            HabilitarSalvarExcluir(true);
            HabilitarCampos(true);

            acao = OperacaoEnum.ALTERAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente remover este contato ?", "Mensagem", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int index = lbxContatos.SelectedIndex;
                lbxContatos.SelectedIndex = 0;
                lbxContatos.Items.RemoveAt(index);
                List<Contato> lista = new List<Contato>();
                foreach(Contato contato in lbxContatos.Items)
                {
                    lista.Add(contato);
                }
                ManipuladorArquivos.EscreverArquivo(lista);
                carregarListaContatos();
                limparCampos();
            }
            HabilitarCampos(false);
        }

        private void HabilitarCampos(bool status)
        {
            txbNome.Enabled = status;
            txbEmail.Enabled = status;
            txbTelefone.Enabled = status;
        }

        private void lbxContatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Contato contato = (Contato) lbxContatos.Items[lbxContatos.SelectedIndex];
            txbNome.Text = contato.Nome;
            txbEmail.Text = contato.Email;
            txbTelefone.Text = contato.NumeroTelefone;
        }
    }
}
