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

namespace QuanLyDiemSinhVien
{
    public partial class frmThemDMKhoa : Form
    {
        public static SqlConnection con;
        public frmThemDMKhoa()
        {
            InitializeComponent();
        }
        private void connect()
        {
            //String cn = @"server ='DESKTOP-J51JA3J\SQLEXPRESS' ;database ='Project_QuanlythuvienMTA' ;Integrated Security = true";//;Integrated Security = false
            String cn = @"server ='DUC-PC\SQLEXPRESS' ;database ='Project_QuanlySinhVien' ;Integrated Security = true";//;Integrated Security = false
            con = new SqlConnection(cn);
            con.Open();
        }
        public void getdata()
        {
            String sqlSELECT = "SELECT * FROM DMKhoa";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
        }
        public bool kiemtratontai()
        {
            bool KT = false;
            string maso = txtMaKhoa.Text;
            SqlDataAdapter da_kiemtra = new SqlDataAdapter("Select * from DMKhoa where MaKhoa='" + maso + "'", con);
            DataTable dt_kiemtra = new DataTable();
            da_kiemtra.Fill(dt_kiemtra);

            if (dt_kiemtra.Rows.Count > 0)
            {
                KT = true;
            }
            da_kiemtra.Dispose();
            return KT;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string chuoi;
            chuoi = txtMaKhoa.Text;
            if (kiemtratontai())
            {
                MessageBox.Show("Mã khoa đã tồn tại. Vui lòng nhập lại !");
            }
            else
            {
                if (txtMaKhoa.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập mã khoa");
                }
                //else if (chuoi.Length != 4)
                //{
                //    MessageBox.Show("Bạn phải nhập đúng 4 ký tự");
                //}
                else
                {
                    string them = "insert into DMKhoa values ('"+txtMaKhoa.Text+"','"+txtTenKhoa.Text+"','"+txtDiaChiKhoa.Text+"')";
                    SqlCommand comThem = new SqlCommand(them, con);
                    comThem.ExecuteNonQuery();
                    getdata();
                    MessageBox.Show("Thêm mới thành công ");
                    this.Close();
                    frmDMKhoa tg = new frmDMKhoa();
                    tg.ShowDialog();
                }
            }
        }

        private void frmThemDMKhoa_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
