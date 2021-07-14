using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace cliente
{
    public partial class FormCliente : Form
    {
        TcpClient clienteRed; // Cliente TCP para conectar con el servidor.
        IPEndPoint serverEndPoint; // Punto de conexion con el servidor.

        ASCIIEncoding decodificador; // Codificador para transformar de bytes a string y viceversa.
        NetworkStream clienteStream; // Cadena de escritura para enviar datos al socket.

        public FormCliente()
        {
            InitializeComponent();
            clienteRed = new TcpClient();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16830);
            clienteRed = new TcpClient();
            clienteRed.Connect(serverEndPoint);
            clienteStream = clienteRed.GetStream();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
         // en esta parte se reciben los datos de ingreso del usuario y se envia al servidor para
         // verificar en la BD si existen, depende de la respuesta del servidor se procede
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string Usuario = loginUsuario.Text; // se capturan los datos ingresados
            string Password = loginPassword.Text;

            string mensaje = "validar" + "," + Usuario + "," + Password; // se guarda en la variable mensaje 
                                                                         // para luego codificarlos y enviar
            clienteStream = clienteRed.GetStream();                      // al servidor
            decodificador = new ASCIIEncoding();
            byte[] buffer = decodificador.GetBytes(mensaje);
            clienteStream.Write(buffer, 0, buffer.Length);
            clienteStream.Flush();

            byte[] mensajeServidor = new byte[1000];    // se recibe mensaje del servidor
            int bytesRead;
            String lastMessage;
            bytesRead = clienteStream.Read(mensajeServidor, 0, 1000);
            System.Diagnostics.Debug.WriteLine(decodificador.GetString(mensajeServidor, 0, bytesRead));
            lastMessage = decodificador.GetString(mensajeServidor, 0, bytesRead);

            switch (lastMessage) // según el mensaje recibo se procede
            {
                case "1":
                    MessageBox.Show("Por el momento se encuentra inactivo, en breve sera activado");
                    break;

                case "2":
                    MessageBox.Show(" Usuario no existe, favor registrarse");
                    break;
                case "3":
                    new frmViaje(Usuario).Show();
                    break;

            }
            loginUsuario.Text = ""; // se limpian los campos
            loginPassword.Text= "";

        }


        // se llama al formulario de registro de conductor
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegistro r = new frmRegistro();
            r.Show();
        }
    }
}
