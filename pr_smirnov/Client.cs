using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr34
{
    public partial class Client : Form
    {
        int InactivityTimeout = 30;

        Timer Timer;
        DateTime lastActivity;
        public Client(string FIO)
        {
            InitializeComponent();
            label1.Text = FIO;
            Timer = new Timer();
            Timer.Interval = 1000;
            Timer.Tick += timer1_Tick;
            lastActivity = DateTime.Now;
            Timer.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client_Product product = new Client_Product();
            product.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client_Order order = new Client_Order();
            order.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - lastActivity).TotalSeconds >= InactivityTimeout)
            {
                Timer.Stop();
                MessageBox.Show("Вы слишком долго бездействовали\n" +
                    "Повторите вход", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void Client_MouseMove(object sender, MouseEventArgs e)
        {
            lastActivity = DateTime.Now;
        }

        private void Client_KeyDown(object sender, KeyEventArgs e)
        {
            lastActivity = DateTime.Now;
        }
    }
}
