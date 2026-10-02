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
    public partial class Import : Form
    {
        string csvPath = "";
        string table = "";
        string ConStr = @"host=localhost;uid=root;pwd=root;Database=pr34_smirnov;";
        public Import()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    csvPath = openFileDialog.FileName;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (csvPath == "")
            {
                MessageBox.Show("Выберите файл для импорта");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Выберите таблицу для импорта");
            }
            else
            {
                try
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        table = "OrderPickupPoint";
                    }
                    else
                    {
                        table = "Order";
                        using (MySqlConnection con = new MySqlConnection(ConStr))
                        {
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM OrderPickupPoint", con);
                            int count = Convert.ToInt32(cmd.ExecuteScalar());

                            if (count == 0)
                            {
                                MessageBox.Show(
                                    "Ошибка импорта заказов!\n\n" +
                                    "В базе данных нет ни одного пункта выдачи.\n" +
                                    "Сначала импортируйте или создайте данные для таблицы 'OrderPickupPoint',\n" +
                                    "так как каждый заказ должен быть привязан к существующему пункту.",
                                    "Требуется предварительное действие",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                                return;
                            }
                        }
                    }
                    string[] lines = File.ReadAllLines(csvPath, System.Text.Encoding.GetEncoding("Windows-1251"));

                    using (MySqlConnection con = new MySqlConnection(ConStr))
                    {
                        con.Open();
                        int count = 0;
                        for (int i = 1; i < lines.Length; i++)
                        {
                            if (lines[i].Trim() == "") continue;
                            count++;
                            string[] v = lines[i].Split(';');

                            string sql = $"INSERT INTO `{table}` VALUES (" + string.Join(",", Array.ConvertAll(v, x => "'" + x.Trim() + "'")) + ")";

                            new MySqlCommand(sql, con).ExecuteNonQuery();
                        }
                        MessageBox.Show("Добавлено записей: " + count);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
