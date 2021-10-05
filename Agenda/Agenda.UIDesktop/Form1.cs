using Agenda.DAL;
using Agenda.Domain;
using System;
using System.Windows.Forms;

namespace Agenda.UIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contatos contatos = new Contatos();
            contatos.Adicionar(new Contato 
            {
                Nome = txtContato.Text 
            });
        }
    }
}
