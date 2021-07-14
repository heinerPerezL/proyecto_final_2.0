using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
   public class Conductor // declaracón de variables Tabla  Conductor
    {
        string id;
        string nombre;
        string apellido1;
        string apellido2;
        string usuario;
        string pasword;
        string marca;
        string modelo;
        string placa;
        string estado;

       

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido1 { get => apellido1; set => apellido1 = value; }
        public string Apellido2 { get => apellido2; set => apellido2 = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Pasword { get => pasword; set => pasword = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Placa { get => placa; set => placa = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
