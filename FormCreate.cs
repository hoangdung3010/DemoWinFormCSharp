using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZzzWF
{
    public partial class FormCreate : Form
    {
        private string connectionString;

        //Tạo  delegate
        public delegate void DataUpdateDelegate();
        //Tạo event dựa trên delegate đã tạo
        public event DataUpdateDelegate OnDataUpdate;
        public FormCreate(string connectionString)
        {
            InitializeComponent();
            this.connectionString = connectionString;
        }

        public FormCreate()
        {
        }

        private void FormCreate_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string city = cbCity.SelectedItem.ToString();
            string phone = tbPhone.Text;

            SaveCustomerToDatabase(name, city, phone);
           

            this.Close();
        }

        private void SaveCustomerToDatabase(string name, string city, string phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO CUSTOMERS (Name, City, Phone) VALUES (@Name, @City, @Phone)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@Phone", phone);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
