using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace pr34
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Configuration currentConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            currentConfig.AppSettings.Settings["host"].Value = textBox1.Text;
            currentConfig.AppSettings.Settings["uid"].Value = textBox2.Text;
            currentConfig.AppSettings.Settings["pwd"].Value = textBox3.Text;

            currentConfig.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show($"Новая строка подключения сохранена\nhost={textBox1.Text};uid={textBox2.Text};pwd={textBox3.Text};", "Сохранить", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Application.Restart();
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            Configuration currentConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            textBox1.Text = currentConfig.AppSettings.Settings["host"].Value;
            textBox2.Text = currentConfig.AppSettings.Settings["uid"].Value;
            textBox3.Text = currentConfig.AppSettings.Settings["pwd"].Value;
        }
    }
}
