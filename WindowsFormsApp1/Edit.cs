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
    public partial class Edit : Form
    {
        public Service serv;
        static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=abd_12;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public Edit(Service form)
        {
            InitializeComponent();
            serv = form;
            Servicee it = context.GetTable<Servicee>().FirstOrDefault(x => x.id == Convert.ToInt32(serv.dataGridView1.CurrentRow.Cells[0].Value));
            textBox5.Text = it.Title;
            textBox1.Text = Convert.ToString(it.Cost);
            textBox2.Text= Convert.ToString(it.DurationInSeconds);
            textBox3.Text = Convert.ToString(it.Description);
            textBox4.Text = Convert.ToString(it.Discount);
            comboBox1.SelectedValue = Convert.ToString(it.MainImagePath);
            context.SubmitChanges();
            //Table<Servicee> service = context.GetTable<Servicee>();
            //dataGridView1.DataSource = service.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Servicee it = context.GetTable<Servicee>().FirstOrDefault(x => x.id == Convert.ToInt32(serv.dataGridView1.CurrentRow.Cells[0].Value));
            it.Title = textBox5.Text;
            it.Cost = Convert.ToDecimal(textBox1.Text);
            it.DurationInSeconds = Convert.ToInt32(textBox2.Text);
            it.Description = Convert.ToString(textBox3.Text);
            it.Discount = Convert.ToInt32(textBox4.Text);
            it.MainImagePath = Convert.ToString(comboBox1.SelectedValue);
            context.SubmitChanges();
            Table<Servicee> service = context.GetTable<Servicee>();
            serv.dataGridView1.DataSource = service.ToList();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Service f6 = new Service();
            f6.Show();
            Close();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "abd_12DataSet.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this.abd_12DataSet.Service);

        }
    }
}
