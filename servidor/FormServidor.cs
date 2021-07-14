using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace servidor
{
    public partial class FormServidor : Form
    {
        private TcpListener escuchaTCP;
        private Thread escuchaHilo;
        private string mensajeString;
        int clientesConectados;
        BDconexion cnx;
       
        public FormServidor()
        {
            InitializeComponent();
            cnx = new BDconexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgwMostrarViajes.DataSource = llenarTbl().Tables[0]; // llena las tabla de los viajes en el servidor
        }

        private void FormServidor_Load(object sender, EventArgs e)
        {
            dgwMostrarViajes.DataSource = llenarTbl();
            CheckForIllegalCrossThreadCalls = false;
            this.escuchaTCP = new TcpListener(IPAddress.Any, 16830);
            this.escuchaHilo = new Thread(new ThreadStart(escuchandoClientes));
            this.escuchaHilo.Start();
        }

        private void escuchandoClientes()
        {
            this.escuchaTCP.Start();
            
            while (true)
            {
                //bloquea a un cliente hasta que el servidor lo escuche this.tcpListener.AcceptTcpClient();
                TcpClient cliente = this.escuchaTCP.AcceptTcpClient();
                lock (this)
                {
                    clientesConectados++;
                    cantClientes.Text = clientesConectados.ToString();
                    
                }
                Thread clienteHilo = new Thread(new ParameterizedThreadStart(comunicacionCliente));//hilo que recibe un metodo de objeto
                clienteHilo.Start(cliente);
            }
        }

        public DataSet llenarTbl() // envía la consulta a la BD clase bd conexión
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblViaje");
            return cnx.Mostrar(cmd);
        }

        public DataSet llenarTblChofer() //envía la consulta a la BD clase bd conexión
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblConductor");
            return cnx.Mostrar(cmd);
        }

        private void comunicacionCliente(Object cliente)
        {
            TcpClient tcpCliente = (TcpClient)cliente;//proporciona las conexiones del parametro que recibe 
            NetworkStream clienteStream = tcpCliente.GetStream();//toma los datos de la conexion por red
            ASCIIEncoding encoder = new ASCIIEncoding();//objeto que codifica bytes
           // byte[] buffer = encoder.GetBytes("conectado");//guarda el mensaje en el array

          //  clienteStream.Write(buffer, 0, buffer.Length);//toma el mensaje a enviar
           // clienteStream.Flush();//envia el mensaje 

            byte[] mensajeByte = new byte[4096];//vector donde se almacena el mensaje que recibimos del cliente;

            int leerBytes;//cantida de bytes del mensaje enviado por el cliente
            BDconexion bd = new BDconexion();


            while (true)
            {
                leerBytes = 0;

                try
                {
                    leerBytes = clienteStream.Read(mensajeByte, 0, 4096);//toma el mensaje para leer
                }
                catch 
                {

                    break;
                }

                if (leerBytes == 0)
                {
                    lock(this){
                        clientesConectados--;
                        cantClientes.Text = clientesConectados.ToString();

                    }
                    break;
                }

                //mensaje ha sido recibido con éxito
                encoder = new ASCIIEncoding();
                System.Diagnostics.Debug.WriteLine(encoder.GetString(mensajeByte, 0, leerBytes));
                mensajeString = encoder.GetString(mensajeByte, 0, leerBytes);//convierte el mensaje de byte a string
                
                String[] solicitud = mensajeString.Split(',');

                // segun el dato recibido, se procede
                switch (solicitud[0])
                {
                    case "insert": // inserta los datos de conductor en la BD

                        bd.comando("INSERT INTO tblConductor (Id_Conductor,Nombre,Apellido1,Apellido2,Usuario,Password,Marca_camion,Modelo,Placa,Estado_Conductor) VALUES ('" + solicitud[1] + "','" + solicitud[2] + "', '" + solicitud[3] + "', '" + solicitud[4] + "', '" + solicitud[5] + "', '" + solicitud[6] + "', '" + solicitud[7] + "', '" + solicitud[8] + "', '" + solicitud[9] + "', '" + solicitud[10] + "')");
                        break;

                    case "validar":
                            bool encontrar;
                            bool estado;
                        encontrar = bd.buscar(solicitud[1], solicitud[2]);
                        estado = bd.verEstado(solicitud[1]);
                        if (encontrar)
                        {
                            if (estado)
                            {
                                 byte[] existe = encoder.GetBytes("1");//guarda el mensaje en el array
                          clienteStream.Write(existe, 0, existe.Length);//toma el mensaje a enviar
                                clienteStream.Flush();
                               
                            }
                            else
                            {
                                byte[] existe = encoder.GetBytes("3");//guarda el mensaje en el array
                                clienteStream.Write(existe, 0, existe.Length);//toma el mensaje a enviar
                                clienteStream.Flush();
                            }
                        }
                        else
                        {
                             byte[] existe = encoder.GetBytes("2");//guarda el mensaje en el array
                          clienteStream.Write(existe, 0, existe.Length);//toma el mensaje a enviar
                            clienteStream.Flush();
                        }
                            
                        break;

                    case "insertV": // inserta los datos del registro del Viaje en la BD
                         
                      bd.comando("INSERT INTO tblViaje (Id_Traking, FK_Conductor, Lugar_Inicio, Lugar_Fin, Tipo_Carga, Horas_Estimadas, Inicio_Registro, Estado_viaje, Comentario) VALUES ('" + solicitud[1] + "','" + solicitud[2] + "', '" + solicitud[3] + "', '" + solicitud[4] + "', '" + solicitud[5] + "', '" + solicitud[6] + "', '" + solicitud[7]+ "', '" + solicitud[8] +  "','" + solicitud[9] + "')");
                     // bd.comando()
                        break;
                }

            }//fin while
            tcpCliente.Close();
            lock (this)
            {
                clientesConectados--;
                cantClientes.Text = clientesConectados.ToString();
            }

        }//fin comunicacion

        private void btnLCond_Click(object sender, EventArgs e)
        {
            dgwMostrarViajes.DataSource = llenarTblChofer().Tables[0]; // llena la tabla Conductor
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dgwMostrarViajes.DataSource = llenarTbl().Tables[0]; // llena la tabla Viajes
        }

        private void cbxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxEstado.Items.ToString(); // toma el dato seleccionado en el combobox
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String estado = dgwMostrarViajes.CurrentRow.Cells[9].Value.ToString();
            string id = dgwMostrarViajes.CurrentRow.Cells[0].Value.ToString();
            if (estado == "inactivo")
            {
                estado = cbxEstado.Text;
                SqlCommand cmd = new SqlCommand(" UPDATE tblConductor SET Estado_Conductor = '" + estado + "' WHERE Id_Conductor = '" + id + "' ");
                cnx.Mostrar(cmd);

            }
            else
            {
                estado = cbxEstado.Text;
                SqlCommand cmd = new SqlCommand(" UPDATE tblConductor SET Estado_Conductor = '" + estado + "' WHERE Id_Conductor = '" + id + "' ");
                cnx.Mostrar(cmd);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgwMostrarViajes.DataSource = filtrarTblChofer().Tables[0];

        }
        public DataSet filtrarTblChofer()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblConductor WHERE Estado_Conductor = 'inactivo'");
            return cnx.Mostrar(cmd);
        }
    }
}
