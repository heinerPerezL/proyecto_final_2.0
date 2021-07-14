using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Viaje // Declaración de variables tabla Viaje
    {
        string id_Traking;
        string fk_conductor;
        string lugar_I;
        string lugar_F;
        string tipo_C;
        string horas_E;
        DateTime inicio_Registro;
        string estado;
        string comentario;

        public string Id_Traking { get => id_Traking; set => id_Traking = value; }

        public string Lugar_I { get => lugar_I; set => lugar_I = value; }
        public string Lugar_F { get => lugar_F; set => lugar_F = value; }
        public string Tipo_C { get => tipo_C; set => tipo_C = value; }
        public string Horas_E { get => horas_E; set => horas_E = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public string Fk_conductor { get => fk_conductor; set => fk_conductor = value; }
        public DateTime Inicio_Registro { get => inicio_Registro; set => inicio_Registro = value; }
    }
}
