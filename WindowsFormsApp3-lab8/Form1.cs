using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3_lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 2;
            dataGridView1.ColumnCount = 2;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.RowCount = (int)numericUpDown1.Value;
            dataGridView1.ColumnCount = (int)numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        // product of elements in raw with all positive elements
        {
            int[,] matrix = WriteToArray();
            int count = 0;

            int n = dataGridView1.Rows.Count;
            for (int j = 0; j < 3; j++) 
            {
                count = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (matrix[i, j] == 0)
                    {
                        count++;
                    }
                    if (count > 1) ;
                }
            }
        }

        static void print(int[][] a)
        {
            for (int i = 0; i < a.Length; i++, Console.WriteLine())
                for (int j = 0; j < a[i].Length; j++)
                    Console.Write("{0,5}", a[i][j]);

        }
   
        public int[,] WriteToArray()
        {
            int[,] DataValue = new int[dataGridView1.Rows.Count, dataGridView1.Columns.Count];
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    DataValue[row.Index, col.Index] = Convert.ToInt32(dataGridView1.Rows[row.Index].Cells[col.Index].Value);
                }
            }
            return DataValue;
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            dataGridView1.RowCount = (int)numericUpDown1.Value;
            dataGridView1.ColumnCount = (int)numericUpDown1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[,] matrix = WriteToArray();
            int n = dataGridView1.Rows.Count; 
            int m = dataGridView1.Rows.Count; 
            int i, j, z, temp1 = 0, temp2 = 0, maxi = 0;
           
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m - 1; j++)
                {
                    z = j + 1;
                    
                    while (z < m)
                    {
                        if (matrix[i, j] == matrix[i, z])
                        {
                            temp1++;
                        }
                        z++;
                    }
                }

                if (temp1 > temp2)
                {
                    temp2 = temp1;
                    maxi = i;
                }
                temp1 = 1;
            }
            
            if (maxi == -1)
            {
                MessageBox.Show("не існує однакових елементів");
            }
            else
            {
                MessageBox.Show(" індекс рядка = ", maxi.ToString());
            }
            Console.Read();
        }
    }
}
    
