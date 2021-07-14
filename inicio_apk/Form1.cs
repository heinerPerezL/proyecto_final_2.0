using cliente;
using servidor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inicio_apk
{
    public partial class Form1 : Form
    {
        bool servidor_inicio;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (servidor_inicio)     // válida si el servidor esta iniciado, si ya lo esta envía mensaje
            {
                MessageBox.Show("el servidor esta iniciado");
            }
            else
            {
                servidor_inicio = true; // si el servidor esta inicia llama al formulario de servidor
                FormServidor servidorFrm = new FormServidor();
                servidorFrm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!servidor_inicio) // si aún no se a inicia, indica hacerlo
            {
                MessageBox.Show("Por favor inicie servidor");
            }
            else // si ya esta iniciado llama al formulario de iniciar sesión
            {
                FormCliente clienteFrm = new FormCliente();
                clienteFrm.Show();
                
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
