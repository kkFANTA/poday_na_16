using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class ServiseUser : Form
    {
        static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=abd_12;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public ServiseUser()
        {
            InitializeComponent();
            Table<Servicee> service = context.GetTable<Servicee>();
            dataGridView1.DataSource = service.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Authorization f6 = new Authorization();
            f6.Show();
            Close();
        }

        private void ServiseUser_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "abd_12DataSet2.v4". При необходимости она может быть перемещена или удалена.
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var f = context.GetTable<Servicee>().Where(x => x.Title.Contains(textBox1.Text)|| x.Description.Contains(textBox1.Text));
            dataGridView1.DataSource = f.ToList();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "0-5%")
            {
                var f = context.GetTable<Servicee>().Where(x => x.Discount >= 0 && x.Discount <= 0.05);
                dataGridView1.DataSource = f.ToList();
            }
            if (comboBox1.Text == "5%-15%")
            {
                var f = context.GetTable<Servicee>().Where(x => x.Discount >= 0.05 && x.Discount <= 0.15);
                dataGridView1.DataSource = f.ToList();
            }
            if (comboBox1.Text == "15%-30%")
            {
                var f = context.GetTable<Servicee>().Where(x => x.Discount >= 0.15 && x.Discount <= 0.3);
                dataGridView1.DataSource = f.ToList();
            }
            if (comboBox1.Text == "30%-70%")
            {
                var f = context.GetTable<Servicee>().Where(x => x.Discount >= 0.3 && x.Discount <= 0.7);
                dataGridView1.DataSource = f.ToList();
            }
            if (comboBox1.Text == "70%-100%")
            {
                var f = context.GetTable<Servicee>().Where(x => x.Discount >= 0.7 && x.Discount <= 1);
                dataGridView1.DataSource = f.ToList();
            }
            if (comboBox1.Text == "Все")
            {
                var f = context.GetTable<Servicee>().Where(x => x.Discount >= 0 && x.Discount <= 1);
                dataGridView1.DataSource = f.ToList();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox2.Text == "Service")
            {
                Table<Servicee> service = context.GetTable<Servicee>();
                dataGridView1.DataSource = service.ToList();
            }
            if (comboBox2.Text == "ClientService")
            {
              dataGridView1.DataSource = sql.ToList();
            }
        }
     string sql = "SELECT * FROM dbo.v4";

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (comboBox2.Text == "ClientService")
            //{
            //    AddClient f7 = new AddClient();
            //    f7.Show();
            //    Hide();
            //}
        }
    }
}
