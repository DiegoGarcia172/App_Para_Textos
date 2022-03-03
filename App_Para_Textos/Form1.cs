using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;

using System.Windows.Forms;

namespace App_Para_Textos
{
    public partial class Form1 : Form
    {
        Process Proceso = new Process();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            StreamWriter escribir = new StreamWriter(@"E:\Nueva carpeta (2)\Archivo.txt", true);
            try
            {
                escribir.WriteLine(txtNombre.Text );
                escribir.WriteLine( txtApellido.Text);
                escribir.WriteLine("\n");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
               
            }
            escribir.Close();

        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            StreamReader Leer = new StreamReader(@"E:\Nueva carpeta (2)\Archivo.txt", true);
            String Linea;

            try
            {
                Linea = Leer.ReadLine();
                while (Linea != null) 
                {
                    Rtxt1.AppendText(Linea + "\n");
                    Linea = Leer.ReadLine();
                } 
            }
            catch (Exception)
            {
                MessageBox.Show("Error");

            }
            Leer.Close();



        }

        private void Form_Activate()
        {
            txtApellido.Clear();
            txtNombre.Clear();
            Rtxt1.Clear();
        }
        private void Abrir_Word()
        {
            OpenFileDialog abrir  = new OpenFileDialog();
        
            if (abrir.ShowDialog()==DialogResult.OK)
            {
                string Direccion = abrir.FileName;
                Proceso.StartInfo.FileName = Direccion;
                Proceso.Start();
                
            }

        }
        private void btnOpenFile_Click(object sender, System.EventArgs e)
        {
           
        }

        private  void btnRefresh_Click(object sender, EventArgs e)
        {
            Form_Activate();
            Abrir_Word();

            SaveFileDialog GUARDAR = new SaveFileDialog();
            GUARDAR.Filter = "Documento de texto|*.docx*";
            GUARDAR.Title = "Guardar RichTextBox";
            GUARDAR.FileName = "Sin Titulo 1 ";
            var resultado = GUARDAR.ShowDialog();
            if (resultado==DialogResult.OK)
            {
                StreamWriter escribir = new StreamWriter(GUARDAR.FileName);
                foreach (object line in Rtxt1.Lines)
                {
                    escribir.WriteLine(line);
                }
                escribir.Close();
            }

            //OpenFileDialog nuevo = new OpenFileDialog();
            //if (nuevo.ShowDialog() == DialogResult.OK)
            //{
            //    Rtxt1.LoadFile(nuevo.FileName, RichTextBoxStreamType.RichText);
            //}


        }

        private void Rtxt1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ABRIR = new OpenFileDialog();
            ABRIR.Filter = "Documento de texto|*.docx*";
            ABRIR.Title = "Guardar RichTextBox";
            ABRIR.FileName = "Sin Titulo 1 ";
            var resultado = ABRIR.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                StreamReader Leer = new StreamReader(ABRIR.FileName);
                Rtxt1.Text = Leer.ReadToEnd();
                Leer.Close();
            }

        }
    }
}
