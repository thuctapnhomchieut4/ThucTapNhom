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
    public partial class frmThemSinhVien : Form
    {
        public static SqlConnection con;
        public frmThemSinhVien()
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
            String sqlSELECT = "SELECT * FROM DMSV";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            txtMaLop.Enabled = false;
        }
        public bool kiemtratontai()
        {
            bool KT = false;
            string maso = txtMaSV.Text;
            SqlDataAdapter da_kiemtra = new SqlDataAdapter("Select * from DMSV where MaSV='" + maso + "'", con);
            DataTable dt_kiemtra = new DataTable();
            da_kiemtra.Fill(dt_kiemtra);

            if (dt_kiemtra.Rows.Count > 0)
            {
                KT = true;
            }
            da_kiemtra.Dispose();
            return KT;
        }
        private void groupbox_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string chuoi;
            chuoi = txtMaSV.Text;
            if (kiemtratontai())
            {
                MessageBox.Show("Mã sv đã tồn tại. Vui lòng nhập lại !");
            }
            else
            {
                if (txtMaSV.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập mã sv");
                }
                //else if (chuoi.Length != 4)
                //{
                //    MessageBox.Show("Bạn phải nhập đúng 4 ký tự");
                //}
                else
                {
                    string theDate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
                    string them = "insert into DMSV values ('"+txtMaSV.Text+"','"+txtTenSV.Text+"','"+txtGioiTinh.Text+"','"+theDate+"','"+txtNoiSinh.Text+"','"+txtMaLop.Text+"') select MaSV,MaLop from DMSV where MaLop = '"+txtMaLop.Text+"'";
                    SqlCommand comThem = new SqlCommand(them, con);
                    comThem.ExecuteNonQuery();
                    getdata();
                    MessageBox.Show("Thêm mới thành công ");
                    this.Close();
                    frmSinhVien tg = new frmSinhVien();
                    tg.ShowDialog();
                }
            }
        }

        private void frmThemSinhVien_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
            loadcombobox();
        }
        public void loadcombobox()
        {
            string sql = "select MaLop, TenLop from DMLop";
            SqlCommand com = new SqlCommand(sql,con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds,"DMLop");
            comboBox1.DataSource = ds.Tables[0];
            //comboBox1.DisplayMember = "TenLop";
            comboBox1.DisplayMember = "MaLop";
            comboBox1.ValueMember = "MaLop";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaLop.Text = comboBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
