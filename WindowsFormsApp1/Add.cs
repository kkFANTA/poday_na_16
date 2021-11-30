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
    public partial class Add : Form
    {
        public Service serv;
        static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=abd_12;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public Add(Service form)
        {
            InitializeComponent();
            serv = form;
            //Table<Servicee> servicee = context.GetTable<Servicee>();
            //dataGridView1.DataSource = servicee.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Servicee servv = new Servicee
            {
                Title = textBox5.Text,
                Cost = Convert.ToDecimal(textBox1.Text),
                DurationInSeconds = Convert.ToInt32(textBox2.Text),
                Description = Convert.ToString(textBox3.Text),
                Discount = Convert.ToInt32(textBox4.Text),
                MainImagePath = Convert.ToString(comboBox1.SelectedValue),
            };
            context.GetTable<Servicee>().InsertOnSubmit(servv);
            context.SubmitChanges();
            Table<Servicee> service = context.GetTable<Servicee>();
            serv.dataGridView1.DataSource = service.ToList();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "abd_12DataSet.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this.abd_12DataSet.Service);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Service f6 = new Service();
            f6.Show();
            Close();
        }
    }
}
