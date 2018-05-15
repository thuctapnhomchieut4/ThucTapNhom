using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVien
{
    public partial class Login : Form
    {
        public static bool isThanhCong = false;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tenDN = txtUserName.Text;
            string pass = txtPassword.Text;
            if (tenDN == "admin" && pass == "admin")
            {
                isThanhCong = true;
                frmMain frmMain = new frmMain();
                frmMain.ShowDialog();
                this.Close();
            }
            else
            {
                isThanhCong = false;
                MessageBox.Show("Sai id hoặc mật khẩu");
                this.Close();
                Dispose(); //giải phóng bộ nhớ
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
