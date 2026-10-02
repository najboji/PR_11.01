using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pr34
{
    public partial class Admin : Form
    {
        int InactivityTimeout = 30;

        Timer Timer;
        DateTime lastActivity;
        public Admin(string FIO)
        {
            InitializeComponent();
            label1.Text = FIO;
            Timer = new Timer();
            Timer.Interval = 1000;
            Timer.Tick += timer1_Tick;
            lastActivity = DateTime.Now;
            Timer.Start();
        }
        string StrCon = @"host=localhost;uid=root;pwd=root;";
        string NameBD = "pr33_smirnov";
        string script = File.ReadAllText("Resources/dump/script.sql");

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Product product = new Admin_Product();
            product.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Order order = new Admin_Order();
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

        private void Admin_KeyDown(object sender, KeyEventArgs e)
        {
            lastActivity = DateTime.Now;
        }

        private void Admin_MouseMove(object sender, MouseEventArgs e)
        {
            lastActivity = DateTime.Now;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(StrCon))
                {
                    con.Open();
                    bool exists;
                    MySqlCommand cmd = new MySqlCommand($"SHOW DATABASES LIKE '{NameBD}'", con);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        exists = reader.Read();
                    }
                    if (exists)
                    {
                        MessageBox.Show("БД уже существует");
                    }
                    else
                    {
                        MySqlCommand cmd1 = new MySqlCommand(script, con);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("БД успешно восстановлена");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(StrCon))
                {
                    con.Open();
                    bool exists;
                    MySqlCommand cmd = new MySqlCommand($"SHOW DATABASES LIKE '{NameBD}'", con);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        exists = reader.Read();
                    }
                    if (exists)
                    {
                        Import import = new Import();
                        import.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("БД не существует");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
