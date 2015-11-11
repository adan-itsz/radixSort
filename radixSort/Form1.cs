using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace radixSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int longitud;
        int[] array;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                longitud = Convert.ToInt32(txtBoxLongitud.Text);
                array = new int[longitud];
                dataGridView1.Columns.Add("", "arreglo original");
                for (int i = 0; i < array.Length  - 1; i++)
                {
                    dataGridView1.Rows.Add();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("llene correctamente");
            }
        }

        private void btnLlenar_Click(object sender, EventArgs e)
        {
            Random rando= new Random();
            int num;
            for (int i = 0; i < longitud; i++)
            {
                num=rando.Next(100,999);
                array[i] = num;
                dataGridView1[0, i].Value = num;
            }
        }

        public void radixSort(int[]arreglo)
        {
            int numBytes = 3;
            int cont;
            int aux;
            int contadorAcomodo=0;
            int columna = 0;
            Queue<int>[] cola = new Queue<int>[10];
            for (int i = 0; i < 10; i++)
            {
                cola[i]= new Queue<int>();
              //inicializar colas
            }
                for (int i = 1; i <= numBytes; i++)
                {
                    cont = 0;
                    aux = 0;
                    for (int j = 0; j < arreglo.Length; j++)
                    {
                        aux = arreglo[j];
                        if (i == 1)
                        {
                            cont = aux % 10;
                        }
                        else  if (i == 2)
                        {
                            cont = aux / 10;
                            cont = cont % 10;
                        }
                        else
                        {
                            cont = aux / 100;
                        }
                        cola[cont].Enqueue(aux);
                    }
                    

                        for (int j = 0; j < 10; j++)
                        {
                            while (cola.Count() != 0)
                            {
                                if (cola[j].Count == 0)
                                {
                                    break;
                                }
                                arreglo[contadorAcomodo++] = cola[j].Dequeue();
                            }

                        }
                    contadorAcomodo = 0;
                    //mostar en el DGV
                        dataGridView1.Columns.Add("", " ");
                        columna++;
                  
                    for (int x = 0; x < arreglo.Length; x++)
                    {
                        dataGridView1[columna, x].Value = arreglo[x];
                    }

                }
		        
	        

        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            radixSort(array);
        }
    }
}
