using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_repaso_3
{
    class Propiedades
    {
        string no_casa;
        long dpi;
        int cuota_mantenimiento;

        public string No_casa { get => no_casa; set => no_casa = value; }
        public long Dpi { get => dpi; set => dpi = value; }
        public int Cuota_mantenimiento { get => cuota_mantenimiento; set => cuota_mantenimiento = value; }
    }
}
