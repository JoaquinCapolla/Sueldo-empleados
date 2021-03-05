using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sueldo_empleados
{
    public partial class Form1 : Form
    {
        List<DatosEmpleado> datosempleados= new List<DatosEmpleado>();
        List<DatosSueldo> datossueldo = new List<DatosSueldo>();
        List<Calculo> calculo = new List<Calculo>();
        public Form1()
        {
            InitializeComponent();
            String appPath = Path.GetDirectoryName(Application.ExecutablePath);
            StreamWriter writer1 = new StreamWriter(appPath + "\\DatosEmpleado.txt", true);
            StreamWriter writer2 = new StreamWriter(appPath + "\\DatosSueldo.txt", true);
            writer1.Close();
            writer2.Close();
            Leer();
            Mostrar();
        }
        private void Mostrar()
        {
            dataGridView_sueldo.DataSource = null;
            dataGridView_sueldo.DataSource = datossueldo;
            dataGridView_sueldo.Refresh();
            dataGridView_empleado.DataSource = null;
            dataGridView_empleado.DataSource = datosempleados;
            dataGridView_empleado.Refresh();
        }
        private void Guardar()
        {
            File.Delete("DatosEmpleado.txt");
            String appPath = Path.GetDirectoryName(Application.ExecutablePath);
            StreamWriter writer1 = new StreamWriter(appPath + "\\DatosEmpleado.txt", true);

            for (int i = 0; i < datosempleados.Count; i++)
            {
                writer1.WriteLine(datosempleados[i].Codigo);
                writer1.WriteLine(datosempleados[i].Nombre);
                writer1.WriteLine(datosempleados[i].Sueldo_hora);
            }
            writer1.Close();

            File.Delete("DatosSueldo.txt");
            StreamWriter writer2 = new StreamWriter(appPath + "\\DatosSueldo.txt", true);

            for (int i = 0; i < datossueldo.Count; i++)
            {
                writer2.WriteLine(datossueldo[i].Codigo);
                writer2.WriteLine(datossueldo[i].Horasmes);
                writer2.WriteLine(datossueldo[i].Mes);
            }
            writer2.Close();

        }
        private void Leer()
        {
            datosempleados.Clear();
            datossueldo.Clear();
            comboBox1.Items.Clear();
            String appPath = Path.GetDirectoryName(Application.ExecutablePath);
            StreamReader reader1 = new StreamReader(appPath + "\\DatosEmpleado.txt");
            while (reader1.Peek() > -1)
            {
                DatosEmpleado datosemTemp = new DatosEmpleado();

                datosemTemp.Codigo = Convert.ToInt32(reader1.ReadLine());
                datosemTemp.Nombre = reader1.ReadLine();
                datosemTemp.Sueldo_hora = float.Parse(reader1.ReadLine());
                comboBox1.Items.Add(datosemTemp.Codigo);
                datosempleados.Add(datosemTemp);
            }
            reader1.Close();

            StreamReader reader2 = new StreamReader(appPath + "\\DatosSueldo.txt");

            while (reader2.Peek() > -1)
            {
                DatosSueldo datossuTemp = new DatosSueldo();

                datossuTemp.Codigo = Convert.ToInt32(reader2.ReadLine());
                datossuTemp.Horasmes = Convert.ToInt32(reader2.ReadLine());
                datossuTemp.Mes = reader2.ReadLine();
                datossueldo.Add(datossuTemp);
            }
            reader2.Close();
        }
        private void dataGridView_empleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_sueldo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            float tempa = 0;
            float tempb = 0;
            DatosEmpleado datosemTemp = new DatosEmpleado();

            datosemTemp.Codigo = Convert.ToInt32(txt_numero.Text);
            datosemTemp.Nombre = txt_nombre.Text;
            datosemTemp.Sueldo_hora = float.Parse(txt_sueldo.Text);
            tempa = datosemTemp.Sueldo_hora;
            datosempleados.Add(datosemTemp);

            DatosSueldo datossuTemp = new DatosSueldo();

            datossuTemp.Codigo = Convert.ToInt32(txt_numero.Text);
            datossuTemp.Horasmes = Convert.ToInt32(txt_horas.Text);
            tempb = datossuTemp.Horasmes;
            datossuTemp.Mes = cmb_mes.Text;
            datossueldo.Add(datossuTemp);

            txt_numero.Text = "";
            txt_nombre.Text = "";
            txt_sueldo.Text = "";
            txt_horas.Text = "";
            cmb_mes.Text = "";
            Guardar();
            Leer();
            Mostrar();
        }

        private void btn_calcular_Click(object sender, EventArgs e)
        {
            calculo.Clear();
            Leer();
            for(int i = 0; i < datosempleados.Count; i++)
            {
                for(int j = 0; j < datossueldo.Count; j++)
                {
                    if(datosempleados[i].Codigo == datossueldo[j].Codigo)
                    {
                        Calculo calculoTemp = new Calculo();
                        calculoTemp.Codigo = datosempleados[i].Codigo;
                        calculoTemp.Nombre = datosempleados[i].Nombre;
                        calculoTemp.Sueldo = datosempleados[i].Sueldo_hora*datossueldo[i].Horasmes;
                        calculoTemp.Mes1= datossueldo[i].Mes;
                        calculo.Add(calculoTemp);
                    }
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = calculo;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int noEmpleado = Convert.ToInt32(comboBox1.SelectedItem);
            DatosEmpleado datosEmpleado = datosempleados.Find(p => p.Codigo == noEmpleado);
            label9.Text = datosEmpleado.Codigo.ToString();
            label10.Text = datosEmpleado.Nombre;
            label11.Text = datosEmpleado.Sueldo_hora.ToString();
        }
    }
}
