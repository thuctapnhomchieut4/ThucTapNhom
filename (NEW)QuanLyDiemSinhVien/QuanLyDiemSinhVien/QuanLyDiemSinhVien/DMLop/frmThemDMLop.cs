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
    public partial class frmThemDMLop : Form
    {
        public static SqlConnection con;
        public frmThemDMLop()
        {
            InitializeComponent();
        }
        private void connect()
        {
            //String cn = @"server ='DESKTOP-J51JA3J\SQLEXPRESS' ;database ='Project_QuanlythuvienMTA' ;Integrated Security = true";//;Integrated Security = false
            String cn = @"server ='DESKTOP-J51JA3J\SQLEXPRESS' ;database ='Project_QuanlySinhVien' ;Integrated Security = true";//;Integrated Security = false
            con = new SqlConnection(cn);
            con.Open();
        }
        public void getdata()
        {
            String sqlSELECT = "SELECT * FROM DMLop";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            //txtMaKhoa.Enabled = false;
        }
        public bool kiemtratontai()
        {
            bool KT = false;
            string maso = txtMaLop.Text;
            SqlDataAdapter da_kiemtra = new SqlDataAdapter("Select * from DMLop where MaLop='" + maso + "'", con);
            DataTable dt_kiemtra = new DataTable();
            da_kiemtra.Fill(dt_kiemtra);

            if (dt_kiemtra.Rows.Count > 0)
            {
                KT = true;
            }
            da_kiemtra.Dispose();
            return KT;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string chuoi;
            chuoi = txtMaLop.Text;
            if (kiemtratontai())
            {
                MessageBox.Show("Mã lớp đã tồn tại. Vui lòng nhập lại !");
            }
            else
            {
                if (txtMaLop.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập mã lớp");
                }
                //else if (chuoi.Length != 4)
                //{
                //    MessageBox.Show("Bạn phải nhập đúng 4 ký tự");
                //}
                else
                {
                    string them = "insert into DMLop values ('"+txtMaLop.Text+"','"+txtTenLop.Text+"','"+comboBox1.Text+"','"+txtDiaDiem.Text+"','"+txtThoiGianHoc.Text+"')";
                    SqlCommand comThem = new SqlCommand(them, con);
                    comThem.ExecuteNonQuery();
                    getdata();
                    MessageBox.Show("Thêm mới thành công ");
                    this.Close();
                    frmDMLop tg = new frmDMLop();
                    tg.ShowDialog();
                }
            }
        }
        public void loadcomboBox1()
        {
            string sql = "select MaKhoa, TenKhoa from DMKhoa";
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "DMKhoa");
            comboBox1.DataSource = ds.Tables[0];
            //comboBoxMaMH.DisplayMember = "TenLop";
            comboBox1.DisplayMember = "MaKhoa";
            comboBox1.ValueMember = "MaKhoa";
        }
        private void frmThemDMLop_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
            loadcomboBox1();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
