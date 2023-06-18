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
using System.Xml.Linq;

namespace ZzzWF
{
    public partial class CreateForm : Form
    {
        private string chuoikn = @"Data Source=DESKTOP-PBAV582\SQLEXPRESS;Initial Catalog=Zzz;Integrated Security=True";
        bus b = new bus();
        dal a = new dal();
        
        public CreateForm()
        {
            InitializeComponent();
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //string name = tbName.Text;
            //string city = cbCity.SelectedItem.ToString();
            //string phone = tbPhone.Text;

            //try
            //{
            //    Customer kh = new Customer();
            //    kh.Name = tbName.Text;
            //    kh.City = cbCity.SelectedItem.ToString();
            //    kh.Phone = tbPhone.Text;

            //    using (SqlConnection cnn = new SqlConnection(chuoikn))
            //    {
            //        cnn.Open();
            //        string insertQuery = "INSERT INTO CUSTOMERS (Name, City, Phone) VALUES (@Name, @City, @Phone)";
            //        using (SqlCommand cmd = new SqlCommand(insertQuery, cnn))
            //        {
            //            cmd.Parameters.AddWithValue("@Name", kh.Name);
            //            cmd.Parameters.AddWithValue("@City", kh.City);
            //            cmd.Parameters.AddWithValue("@Phone", kh.Phone);
            //        }

            //    }
            //        MessageBox.Show("Thêm nhân viên thành công!!!");
            //}
            try
            {
                using (SqlConnection connection = new SqlConnection(chuoikn))
                {
                    connection.Open();

                    // Retrieve data from input controls
                    string name = tbName.Text;
                    string city = cbCity.SelectedItem.ToString();
                    string phone = tbPhone.Text;

                    // Prepare the insert query
                    string insertQuery = "INSERT INTO CUSTOMERS (Name, City, Phone) VALUES (@Name, @City, @Phone)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Set parameter values
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@City", city);
                        command.Parameters.AddWithValue("@Phone", phone);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data added successfully!");
                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show("Lỗi !!!" + x);
            }
        }

        //private void Save(string name, string city, string phone)
        //{
        //    using (SqlConnection connection = new SqlConnection(chuoikn))
        //    {
        //        string query = "INSERT INTO CUSTOMERS (Name, City, Phone) VALUES (@name, @city, @phone)";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.Parameters.AddWithValue("@Name", name);
        //        command.Parameters.AddWithValue("@City", city);
        //        command.Parameters.AddWithValue("@Phone", phone);

        //        connection.Open();
        //        command.ExecuteNonQuery();
        //    }
        //}
    }
}
