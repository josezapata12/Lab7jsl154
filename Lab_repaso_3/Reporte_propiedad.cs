using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_repaso_3
{
    class Reporte_propiedad
    {
        string nombre;
        string apellido;
        string no_casa;
        int cuota_mantenimiento;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string No_casa { get => no_casa; set => no_casa = value; }
        public int Cuota_mantenimiento { get => cuota_mantenimiento; set => cuota_mantenimiento = value; }
    }
}
