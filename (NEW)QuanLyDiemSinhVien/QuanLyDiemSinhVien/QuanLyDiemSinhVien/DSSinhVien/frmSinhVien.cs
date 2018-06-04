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
    public partial class frmSinhVien : Form
    {
        public static SqlConnection con;
        public frmSinhVien()
        {
            InitializeComponent();
        }
        private void connect()
        {
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
            dataGridView5.DataSource = dt; // đổ dữ liệu vào dG
            txtMaSV.Enabled = false;
        }
        private void groupbox_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView5.CurrentRow.Index;
            txtMaSV.Text = dataGridView5.Rows[index].Cells[0].Value.ToString();
            txtTenSV.Text = dataGridView5.Rows[index].Cells[1].Value.ToString();
            txtGioiTinh.Text = dataGridView5.Rows[index].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView5.Rows[index].Cells[3].Value.ToString();
            txtNoiSinh.Text = dataGridView5.Rows[index].Cells[4].Value.ToString();
            txtMaLop.Text = dataGridView5.Rows[index].Cells[5].Value.ToString();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmThemSinhVien tsv = new frmThemSinhVien();
            tsv.Show();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            string sua = "update DMSV set TenSV =N'"+txtTenSV.Text+"',GioiTinh =N'"+txtGioiTinh.Text+"',NgaySinh='"+theDate+"',NoiSinh=N'"+txtNoiSinh.Text+"' where MaSV ='"+txtMaSV.Text+"'";
            SqlCommand comSua = new SqlCommand(sua, con);
            comSua.ExecuteNonQuery();
            getdata();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string xoa = "delete a from ThongKe a inner join DMSV b on a.MaSV = b.MaSV where b.MaSV = '"+txtMaSV.Text+"' delete c from DMDiem c inner join DMSV b on c.MaSV=b.MaSV where b.MaSV = '"+txtMaSV.Text+"' delete from DMSV where MaSV = '"+txtMaSV.Text+"' ";
                SqlCommand comXoa = new SqlCommand(xoa, con);
                comXoa.ExecuteNonQuery();
                getdata();
            }
            else if (dialogResult == DialogResult.No)
            {
                getdata();
            }
        }
    }
}
