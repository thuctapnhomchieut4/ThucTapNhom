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
    public partial class frmThemDMDiem : Form
    {
        public static SqlConnection con;
        public frmThemDMDiem()
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
            String sqlSELECT = "SELECT * FROM DMDiem";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
        }      

        private void btnThem_Click(object sender, EventArgs e)
        {                           
                string them = "insert into DMDiem values ('"+comboBoxMaSV.Text+"','"+comboBoxMaMH.Text+"','"+txtLanThi.Text+"','"+txtDiemSo.Text+"','"+txtDiemChu.Text+"') ";
                SqlCommand comThem = new SqlCommand(them, con);
                comThem.ExecuteNonQuery();
                getdata();
                MessageBox.Show("Thêm mới thành công ");
                this.Close();
                frmDMDiem tg = new frmDMDiem();
                tg.ShowDialog();         
        }
        public void loadcomboboxMaSV()
        {
            string sql = "select MaSV, TenSV from DMSV";
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "DMSV");
            comboBoxMaSV.DataSource = ds.Tables[0];
            //comboBoxMaMH.DisplayMember = "TenLop";
            comboBoxMaSV.DisplayMember = "MaSV";
            comboBoxMaSV.ValueMember = "MaSV";
        }
        public void loadcomboboxMaMH()
        {
            string sql = "select MaMH, TenMH from DMMonHoc";
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds, "DMMonHoc");
            comboBoxMaMH.DataSource = ds.Tables[0];
            //comboBoxMaMH.DisplayMember = "TenLop";
            comboBoxMaMH.DisplayMember = "MaMH";
            comboBoxMaMH.ValueMember = "MaMH";
        }
        private void frmThemDMDiem_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
            loadcomboboxMaSV();
            loadcomboboxMaMH();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxMaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBoxMaMH_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
