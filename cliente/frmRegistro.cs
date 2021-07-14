using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace cliente
{
    public partial class frmRegistro : Form
    {
        private Conductor c;
        
        TcpClient clienteRed; // Cliente TCP para conectar con el servidor.
        IPEndPoint serverEndPoint; // Punto de conexion con el servidor.

        ASCIIEncoding decodificador; // Codificador para transformar de bytes a string y viceversa.
        NetworkStream clienteStream; // Cadena de escritura para enviar datos al socket.

        public frmRegistro()
        {
            InitializeComponent();
            c = new Conductor();
            clienteRed = new TcpClient();

           
        }

        private void frmRegistro_Load(object sender, EventArgs e)
        {
            serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16830);
            clienteRed = new TcpClient();
            clienteRed.Connect(serverEndPoint);
            clienteStream = clienteRed.GetStream();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Conductor rc = new Conductor(); // se capturan los datos del formulario para registrar conductor

            rc.Id = Rid.Text;
            rc.Nombre = Rnombre.Text;
            rc.Apellido1 = Rapellido1.Text;
            rc.Apellido2 = Rapellido2.Text;
            rc.Usuario = Rusuario.Text;
            rc.Pasword = Rpwd.Text;
            rc.Marca = Rmarca.Text;
            rc.Modelo = Rmodelo.Text;
            rc.Placa = Rplaca.Text;
            rc.Estado = "inactivo";
            String mensaje = "insert"+ "," +rc.Id + "," + rc.Nombre + "," + rc.Apellido1 + "," + rc.Apellido2 + "," + rc.Usuario + "," + rc.Pasword + "," + rc.Marca + "," + rc.Modelo + "," + rc.Placa + "," + rc.Estado ;
                
            clienteStream = clienteRed.GetStream();
            decodificador = new ASCIIEncoding();
            byte[] buffer = decodificador.GetBytes(mensaje);
            clienteStream.Write(buffer, 0, buffer.Length);
            clienteStream.Flush();  // se envia el mensaje al servidor

            limpiar();


        }

        private void limpiar() // método que limpia las variables del formulario
        {
            Rid.Text = "";
            Rnombre.Text = "";
            Rapellido1.Text = "";
            Rapellido2.Text = "";
            Rusuario.Text = "";
            Rpwd.Text = "";
            Rmarca.Text = "";
            Rmodelo.Text = "";
            Rplaca.Text = "";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        
    }
}
