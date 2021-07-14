using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Entidades;

namespace cliente
{
    public partial class    frmViaje : Form
    {
        TcpClient clienteRed; // Cliente TCP para conectar con el servidor.
        IPEndPoint serverEndPoint; // Punto de conexion con el servidor.

        ASCIIEncoding decodificador; // Codificador para transformar de bytes a string y viceversa.
        NetworkStream clienteStream; // Cadena de escritura para enviar datos al socket.

        private Viaje v;
        string idConductor;
        public frmViaje(string usuario)
        {
            InitializeComponent();
            this.idConductor = usuario;
            v = new Viaje();
            clienteRed = new TcpClient();
            aleatorio();
        }

        // se capturan los datos de registro para Viaje
        private void button1_Click(object sender, EventArgs e)
        {
            Viaje v= new Viaje();
            DateTime fecha = DateTime.Today; // establece la fecha y hora actual

            v.Id_Traking = txtTracking.Text;
            v.Fk_conductor = this.idConductor;
            v.Lugar_I = txtlugarInicio.Text;
            v.Lugar_F= TxtDestino.Text;
            v.Tipo_C= txtCarga.Text;
            v.Horas_E=txtHoras.Text;
            v.Inicio_Registro = fecha;  
            v.Estado = cbxEV.Text;
            v.Comentario= txtComentario.Text;

           
            String mensaje = "insertV" + "," + v.Id_Traking + ","  + v.Fk_conductor +"," + v.Lugar_I + "," + v.Lugar_F + "," + v.Tipo_C + "," + v.Horas_E + "," + v.Inicio_Registro + "," + v.Estado + "," + v.Comentario;
           
           
            clienteStream = clienteRed.GetStream();
            decodificador = new ASCIIEncoding();
            byte[] buffer = decodificador.GetBytes(mensaje);
            clienteStream.Write(buffer, 0, buffer.Length);
            clienteStream.Flush(); // envia el mensaje al servidor

            Limpiar();
        }
        private void Limpiar() // limpia las variables del formulario
        {
            txtTracking.Text = "";
            txtlugarInicio.Text = "";
            TxtDestino.Text = "";
            txtCarga.Text = "";
            txtHoras.Text = "";
            txtComentario.Text = "";
        }

        private void aleatorio() //método que genera numero aleatorio
        {
            int n;
            Random R = new Random();
            n = R.Next(1000, 4000);
            txtTracking.Text = n.ToString();
        }

      
      
        private void frmViaje_Load(object sender, EventArgs e)
        {
            serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16830);
            clienteRed = new TcpClient();
            clienteRed.Connect(serverEndPoint);
            clienteStream = clienteRed.GetStream();
        }

        private void cbxEV_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxEV.Items.ToString(); // selecciona el estado seleccionado del vieje
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
