using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_repaso_3
{
    public partial class Form1 : Form
    {
        List<Propiedades> propiedad = new List<Propiedades>();
        List<Propietarios> propietario = new List<Propietarios>();
        List<Reporte_propiedad> reporte = new List<Reporte_propiedad>();
   
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //cargar_Propiedades();
            //cargar_Propietarios();
           
        }
        private void cargar_Propiedades()
        {
            string fileName = "Propiedades.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Propiedades propiedades = new Propiedades();
                propiedades.No_casa = reader.ReadLine();
                propiedades.Dpi = Convert.ToInt64(reader.ReadLine());
                propiedades.Cuota_mantenimiento= int.Parse(reader.ReadLine());
                propiedad.Add(propiedades);
            }
            reader.Close();
        }
   
        private void cargar_Propietarios ()
        {
            string fileName = "Propietarios.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Propietarios propietarios = new Propietarios();
                propietarios.Dpi = Convert.ToInt64(reader.ReadLine());
                propietarios.Nombre = reader.ReadLine();
                propietarios.Apellido = reader.ReadLine();
                propietario.Add(propietarios);
            }
            reader.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            cargar_Propiedades();
            cargar_Propietarios();
            if (reporte.Count == 0)
            {
                reporte.Clear();
               
                foreach (Propietarios propietarios in propietario)
                {
                    List<Propiedades> propiedadesDelPropietario = propiedad.Where(p => p.Dpi == propietarios.Dpi).ToList();
                    int contador = 0;
                    foreach (Propiedades propiedad in propiedadesDelPropietario)
                    {
                        if (contador < 3)
                        {

                            Reporte_propiedad reportes = new Reporte_propiedad();
                            reportes.Nombre = propietarios.Nombre;
                            reportes.Apellido = propietarios.Apellido;
                            reportes.No_casa = propiedad.No_casa;
                            reportes.Cuota_mantenimiento = propiedad.Cuota_mantenimiento;
                            reporte.Add(reportes);
                        }
                    }
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reporte;
            dataGridView1.Refresh();

        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (reporte.Count > 0)
            {
                reporte = reporte.OrderByDescending(d => d.Cuota_mantenimiento).ToList();
                List<Reporte_propiedad> cuotasAltas = reporte.OrderByDescending(d => d.Cuota_mantenimiento).Take(3).ToList();
                List<Reporte_propiedad> cuotasBajas = reporte.OrderBy(d => d.Cuota_mantenimiento).Take(3).ToList();
                dataGridView3.DataSource = cuotasAltas;
                dataGridView3.Refresh();
                dataGridView4.DataSource = cuotasBajas;
                dataGridView4.Refresh();
                dataGridView2.DataSource = reporte;
                dataGridView2.Refresh();

                Reporte_propiedad propietarioCuotaAlta = reporte.OrderByDescending(d => d.Cuota_mantenimiento).FirstOrDefault();
                if (propietarioCuotaAlta != null)
                {
                    label1.Text = $"El propietario {propietarioCuotaAlta.Nombre} {propietarioCuotaAlta.Apellido} tiene la cuota total más alta: {propietarioCuotaAlta.Cuota_mantenimiento}";
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
