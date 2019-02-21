using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SihirliKareler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n=18;
        int k;
        int x, y;
        int tempx, tempy;
        Color color;
        void Ciz()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (int i = 0; i < n; i++)// sutunlar
            {
                dataGridView1.Columns.Add("", "");
                dataGridView1.Columns[i].Width = 35;

            }
            for (int i = 0; i < n; i++)//satirlar
            {
                dataGridView1.Rows.Add();
            }
            color = dataGridView1.Rows[0].Cells[0].Style.BackColor;
            dataGridView1.Columns.Add("", "");//toplamlar için
            dataGridView1.Columns[n].DefaultCellStyle.BackColor = Color.Red;
            dataGridView1.Columns[n].Width = 60;
            dataGridView1.Rows.Add();// toplamlar için
            dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Red;
        }
        void N()//N
        {
            x = n - 1;
            y = (n - 1) / 2;
            dataGridView1.Rows[y].Cells[x].Value = "1";
            for (int i = 2; i <= n*n; i++)
            {
                x++;
                y++;
                if (x == n)
                    x = x % n;
                if (y == n)
                    y = y % n;
                if (dataGridView1.Rows[y].Cells[x].Value != null)
                {
                    x = tempx;
                    y = tempy;
                    if (x == 0)
                        x = n - 1;
                    else
                        x--;

                    if (x == n )
                        x= x % n;
                    

                }
                dataGridView1.Rows[y].Cells[x].Value = i.ToString();

                tempx = x;
                tempy = y;
            }
        }
        void N4()//4N
        {
            x = 0;
            y = 0;
            for (int i = 0; i < n*n; i++)
            {

                if ( ( ( n / 4 > x || x > (n-n/4)-1)&&(n / 4 > y || y > (n - n / 4) - 1) ) || ((n / 4 <= x && x <= (n - n / 4) - 1) && (n / 4 <= y && y <= (n - n / 4) - 1))  )
                    dataGridView1.Rows[y].Cells[x].Value = ((x + 1) + (y ) * n).ToString();
              else
                    dataGridView1.Rows[y].Cells[x].Value = (n-x + (n-1-y) *n).ToString();


                x++;
                if (x == n || x < 0)
                {
                    x = x % n;
                    y++;
                }
               
            }
        }
        void N4P1()//4N+1
        {
            k = n / 2;
            x = k - 1;
            y = (k - 1) / 2;
            dataGridView1.Rows[y].Cells[x].Value = "1";//A
            dataGridView1.Rows[y+k].Cells[x+k].Value = 1 + k*k ;//B
            dataGridView1.Rows[y ].Cells[x + k].Value = 1+2*k * k;//C
            dataGridView1.Rows[y+k].Cells[x ].Value = 1+3*k * k;//D

            for (int i = 2; i <= k*k; i++)
            {
                x++;
                y++;
                if (x == k)
                    x = x % k;
                if (y == k)
                    y = y % k;
                if (dataGridView1.Rows[y].Cells[x].Value != null)
                {
              
                    x = tempx;
                    y = tempy;
                    if (x == 0)
                        x = k- 1;
                    else
                        x--;
                    if (x == k )
                        x= x % k;                  

                }
                dataGridView1.Rows[y].Cells[x].Value = i.ToString();//A
                dataGridView1.Rows[y + k].Cells[x + k].Value = (i + k * k).ToString();//B
                dataGridView1.Rows[y].Cells[x + k].Value = (i + k * 2 * k).ToString();//C
                dataGridView1.Rows[y + k].Cells[x].Value = (i + k * 3 * k).ToString();//D
                tempx = x;
                tempy = y;
            }
            int temp;
            for (int a = 0; a < (n-2)/4;a++)
            {
            for (int i = 0; i < k; i++)
                 {
                
                //A VE D ARASIDNA DEĞİŞİM
                temp = Convert.ToInt32(dataGridView1.Rows[i].Cells[a].Value.ToString());
                dataGridView1.Rows[i].Cells[a].Value = dataGridView1.Rows[i + k].Cells[a].Value;
                dataGridView1.Rows[i + k].Cells[a].Value = temp.ToString();
              
                    if(a<(n-2)/4-1)// B VE C ARASINDA DEĞİŞİM
                    {
                        temp = Convert.ToInt32(dataGridView1.Rows[i + k].Cells[n - 1 - a].Value.ToString());
                        dataGridView1.Rows[i + k].Cells[n - 1 - a].Value = dataGridView1.Rows[i].Cells[n - 1 - a].Value;
                        dataGridView1.Rows[i].Cells[n - 1 - a].Value = temp.ToString();
                    }
            
                  
              
                }
            }
            //orta ve 1. sutun a ve d arası değişim
            temp = Convert.ToInt32(dataGridView1.Rows[(k-1)/2].Cells[(k - 1) / 2].Value.ToString());
            dataGridView1.Rows[(k - 1) / 2].Cells[(k - 1) / 2].Value = dataGridView1.Rows[(k - 1) / 2 + k].Cells[(k - 1) / 2].Value;
            dataGridView1.Rows[(k - 1) / 2 + k].Cells[(k - 1) / 2].Value = temp.ToString();

            temp = Convert.ToInt32(dataGridView1.Rows[(k - 1) / 2].Cells[0].Value.ToString());
            dataGridView1.Rows[(k - 1) / 2].Cells[0].Value = dataGridView1.Rows[(k - 1) / 2 + k].Cells[0].Value;
            dataGridView1.Rows[(k - 1) / 2 + k].Cells[0].Value = temp.ToString();
         
        }
       void Topla()
        {
            int toplam=0;   
            for (int b = 0; b < n; b++)
            {
                for (int i = 0; i < n; i++)
                {
                    toplam += Convert.ToInt32(dataGridView1.Rows[b].Cells[i].Value.ToString());
                }
                dataGridView1.Rows[b].Cells[n].Value = toplam.ToString();
                toplam = 0;
            }
            for (int b = 0; b < n; b++)
            {
                for (int i = 0; i < n; i++)
                {
                    toplam += Convert.ToInt32(dataGridView1.Rows[i].Cells[b].Value.ToString());
                }
                dataGridView1.Rows[n].Cells[b].Value = toplam.ToString();
                toplam = 0;
            }
            for (int b = 0; b < n; b++)
            {
                toplam += Convert.ToInt32(dataGridView1.Rows[b].Cells[b].Value.ToString());

            }
            dataGridView1.Rows[n].Cells[n].Value = toplam.ToString();

        }
      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_ciz_Click(object sender, EventArgs e)
        {
            try
            {
                
                n = Convert.ToInt32(textBox1.Text);
                if (n<3)
                {
                    MessageBox.Show("En küçük değer 3 giriniz.");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sadece 2 den büyük sayı giriniz.");
                return;
            }

            Ciz();
          
         
           if (n % 2 == 1)
            {
                N();
            }
            else if ((n/2) % 2 == 0 )
            {
                N4();
               
            }
            else if ((n / 2) % 2 == 1)
            {
                N4P1();
            }
            Topla();
        }
    }
}
