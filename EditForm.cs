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
using static ZzzWF.Form1;

namespace ZzzWF
{

    public partial class EditForm : Form
    {
        private string chuoikn = @"Data Source=DESKTOP-PBAV582\SQLEXPRESS;Initial Catalog=Zzz;Integrated Security=True";

        //Tạo  delegate
        public delegate void DataUpdateDelegate();
        //Tạo event dựa trên delegate đã tạo
        public event DataUpdateDelegate OnDataUpdate;
        //Với delegate và event này, bạn có thể sử dụng nó để thông báo cho Form1
        //khi dữ liệu đã được cập nhật thành công từ Form2, và sau đó cập nhật lại GridView trên Form1 để hiển thị dữ liệu mới.
        
        private bus b = new bus();

        private int id;
        private string name;
        private string city;
        private string phone;


        
        

        public EditForm(int id, string name,string city, string phone)
        {
            InitializeComponent();


            this.id = id;
            this.name = name;
            this.city = city;
            this.phone = phone;

            txtId.Text = id.ToString();
            tbName.Text = name;
            cbCity.SelectedItem = city;
            tbPhone.Text = phone;

            

            // Hiển thị thông tin bản ghi trên các điều khiển trong form
            //txtID.Text = id;
            //txtName.Text = name;
            //txtEmail.Text = email;
        }

        

        

        private void EditForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(chuoikn))
                {
                    connection.Open();

                    
                    string updatedName = tbName.Text;
                    string updatedCity = cbCity.SelectedItem.ToString();
                    string updatedPhone = tbPhone.Text;


                    string updateQuery = "UPDATE CUSTOMERS SET Name = @UpdatedName, City = @UpdatedCity, Phone = @UpdatedPhone WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {

                        command.Parameters.AddWithValue("@UpdatedName", updatedName);
                        command.Parameters.AddWithValue("@UpdatedCity", updatedCity);
                        command.Parameters.AddWithValue("@UpdatedPhone", updatedPhone);
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }

               
                
                MessageBox.Show("Cập nhật thành công!");
                //kích hoạt sự kiện OnDataUpdated để load lại data trong dgv
                OnDataUpdate?.Invoke();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }

    
}
