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
    public partial class AddClient : Form
    {
        public Service CS;
        static string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=abd_12;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public AddClient(Service form)
        {
            InitializeComponent();
            CS = form;
        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "abd_12DataSet2.v4". При необходимости она может быть перемещена или удалена.
            this.v4TableAdapter.Fill(this.abd_12DataSet2.v4);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "abd_12DataSet1.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.abd_12DataSet1.Client);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "abd_12DataSet.Service". При необходимости она может быть перемещена или удалена.
            this.serviceTableAdapter.Fill(this.abd_12DataSet.Service);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            clientService clientSer = new clientService
            {
                ClientID = Convert.ToInt32(comboBox1.SelectedValue),
                ServiceID = Convert.ToInt32(comboBox2.SelectedValue),
                StartTime = dateTimePicker1.Value,
                Comment = textBox1.Text
            };
            context.GetTable<clientService>().InsertOnSubmit(clientSer);
            context.SubmitChanges();
            Table<clientService> service = context.GetTable<clientService>();
            CS.dataGridView1.DataSource = service.ToList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiseUser f2 = new ServiseUser();
            f2.Show();
            Hide();
        }
    }
}
