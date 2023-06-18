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
    public partial class Form1 : Form
    {

        
        bus b = new bus();
        //Khai báo đối tượng BackgroundWorker
        private BackgroundWorker backgroundWorker;
        public Form1()
        {
            // Khởi tạo BackgroundWorker
            backgroundWorker = new BackgroundWorker();
            // Cho phép báo cáo tiến trình
            backgroundWorker.WorkerReportsProgress = true;

            // Đăng ký các sự kiện
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

            InitializeComponent();
            loaddgvKhachHang();
        }
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //todo
        }
        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // todo
        }
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // todo
        }


        public Form1(DataTable data)
        {
            dgvKHACHHANG.DataSource = data;
            InitializeComponent();
        }

        void loaddgvKhachHang()
        {
            dgvKHACHHANG.DataSource = b.getData();
            dgvKHACHHANG.Columns[0].HeaderText = "Mã khách hàng";
            dgvKHACHHANG.Columns[1].HeaderText = "Tên khách hàng";
            dgvKHACHHANG.Columns[2].HeaderText = "Địa chỉ";
            dgvKHACHHANG.Columns[3].HeaderText = "Số điện thoại";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loaddgvKhachHang();
        }

        private void SetData(int id, string name, string city, string phone)
        {
            this.tbID.Text =id.ToString();
            this.tbName.Text = name;
            this.cbCity.SelectedItem = city;
            this.tbPhone.Text = phone;

        }

        

        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateForm c = new CreateForm();
            
            c.ShowDialog();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EditForm edit = new EditForm(int.Parse(tbID.Text),tbName.Text, cbCity.Text,tbPhone.Text);
            //đăng ký phương thức updatedgv làm một event handler cho sự kiện OnDataUpdated của EditForm 
            edit.OnDataUpdate += updatedgv;


            edit.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string ma = tbID.Text;
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xoá nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                if (b.XoaKH(ma))
                {
                    MessageBox.Show("Xoá thành công!!!");
                    loaddgvKhachHang();
                }
            }
        }

        private void dgvKHACHHANG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            tbID.Text = dgvKHACHHANG[0, i].Value.ToString();
            tbName.Text = dgvKHACHHANG[1, i].Value.ToString();
            cbCity.Text = dgvKHACHHANG[2, i].Value.ToString();
            tbPhone.Text = dgvKHACHHANG[3, i].Value.ToString();
        }

        private void updatedgv()
        {
            loaddgvKhachHang();
        }
        
    }
}
