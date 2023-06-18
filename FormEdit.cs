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
    public partial class FormEdit : Form
    {
        private Customer customer;
        private string connectionString;
        public FormEdit(Customer selectedCustomer, string connectionString)
        {
            InitializeComponent();
            this.customer = customer;
            this.connectionString = connectionString;
        }

        private void FormEdit_Load(object sender, EventArgs e)
        {
            tbName.Text = customer.Name;
            cbCity.SelectedItem = customer.City;
            tbPhone.Text = customer.Phone;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string city = cbCity.SelectedItem.ToString();
            string phone = tbPhone.Text;

            UpdateCustomerInDatabase(name, city, phone);

            this.Close();
        }

        private void UpdateCustomerInDatabase(string name, string city, string phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE CUSTOMERS SET Name = @Name, City = @City, Phone = @Phone WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Id", customer.Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
