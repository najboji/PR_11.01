using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr34
{
    public partial class Authorization : Form
    {
        string Role = "";
        string FIO = "";
        string ConStr = @"host=localhost;uid=root;pwd=root;database=pr34_smirnov";
        int count = 2;
        bool captcha = false;
        bool TrueCaptha = true;
        Random rnd = new Random();
        Image[] ArrayOfImages = {
    Properties.Resources._1,
    Properties.Resources._2,
    Properties.Resources._3,
    Properties.Resources._4 };
        public Authorization()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            Configuration currentConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string h = currentConfig.AppSettings.Settings["host"].Value;
            string u = currentConfig.AppSettings.Settings["uid"].Value;
            string p = currentConfig.AppSettings.Settings["pwd"].Value;

            string connectionString = $"host={h};uid={u};pwd={p};";
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                con.Open();

                MessageBox.Show($"СУБД доступна по адресу {h}");

                con.Close();
            }
            catch (Exception)
            {
                DialogResult res = MessageBox.Show($"Ошибка подключения\nНастроить подключение?", "ОШИБКА", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (res != DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    Settings settings = new Settings();
                    settings.ShowDialog();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Логин является обязательным для заполнения", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Пароль является обязательным для заполнения", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string login = textBox1.Text;
                    string password = textBox2.Text;
                    using (MySqlConnection con = new MySqlConnection(ConStr))
                    {
                        con.Open();
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM User WHERE UserLogin = '" + @login + "';", con))
                        {
                            cmd.Parameters.AddWithValue("@login", login);
                            cmd.CommandType = CommandType.Text;
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (captcha)
                                {
                                    if (pictureBox1.Image == ArrayOfImages[0])
                                    {
                                        if (textBox3.Text == "s7a12")
                                        {
                                            TrueCaptha = true;
                                        }
                                    }
                                    else if (pictureBox1.Image == ArrayOfImages[1])
                                    {
                                        if (textBox3.Text == "49bjc")
                                        {
                                            TrueCaptha = true;
                                        }
                                    }
                                    else if (pictureBox1.Image == ArrayOfImages[2])
                                    {
                                        if (textBox3.Text == "ep8u3")
                                        {
                                            TrueCaptha = true;
                                        }
                                    }
                                    else
                                    {
                                        if (textBox3.Text == "ro5z6")
                                        {
                                            TrueCaptha = true;
                                        }
                                    }
                                    textBox3.Clear();
                                }
                                if (reader.Read())
                                {
                                    string dbPassword = reader["UserPassword"].ToString();
                                    FIO = reader["UserSurname"].ToString() + " " + reader["UserName"].ToString() + " " + reader["UserPatronymic"].ToString();
                                    Role = reader["UserRole"].ToString();
                                    if (password == dbPassword && TrueCaptha)
                                    {
                                        count = 2;
                                        textBox1.Clear();
                                        textBox2.Clear();
                                        pictureBox1.Visible = false;
                                        textBox3.Visible = false;
                                        button3.Visible = false;
                                        if (Role == "1")
                                        {
                                            Client client = new Client(FIO);
                                            client.ShowDialog();
                                        }
                                        else if (Role == "2")
                                        {
                                            Manager manager = new Manager(FIO);
                                            manager.ShowDialog();
                                        }
                                        else 
                                        {
                                            Admin admin = new Admin(FIO);
                                            admin.ShowDialog();
                                        }
                                    }
                                    else if (!TrueCaptha)
                                    {
                                        MessageBox.Show("Введена неверная каптча", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        int random = rnd.Next(0, ArrayOfImages.Length);
                                        pictureBox1.Image = ArrayOfImages[random];
                                        --count;
                                        if (count == 1)
                                        {
                                            CreateImage();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Система заблокирована на 10 секунд");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Неверный пароль", "Ошибка входа",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        --count;
                                        if (count == 1)
                                        {
                                            CreateImage();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Система заблокирована на 10 секунд");
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Неверный логин", "Ошибка входа",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    --count;
                                    if (count == 1)
                                    {
                                        CreateImage();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Система заблокирована на 10 секунд");
                                    }
                                }

                            }
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString());
            }
        }
        void CreateImage()
        {
            button3.Visible = true;
            textBox3.Visible = true;
            pictureBox1.Visible = true;
            captcha = true;
            TrueCaptha = false;
            int random = rnd.Next(0, ArrayOfImages.Length);
            pictureBox1.Image = ArrayOfImages[random];
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (count < 1)
            {
                Sleep();
            }
        }
        void Sleep()
        {
            Thread.Sleep(10000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            int random = rnd.Next(0, ArrayOfImages.Length);
            pictureBox1.Image = ArrayOfImages[random];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Guest guest = new Guest();
            guest.ShowDialog();
        }
    }
}
