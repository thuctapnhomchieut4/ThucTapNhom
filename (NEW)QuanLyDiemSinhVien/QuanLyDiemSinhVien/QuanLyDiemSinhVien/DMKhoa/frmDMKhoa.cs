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
    public partial class frmDMKhoa : Form
    {
        public static SqlConnection con; // Đối tượng cho việc kết nối với SQ
        public frmDMKhoa()
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
            String sqlSELECT = "SELECT * FROM DMKhoa";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView1.DataSource = dt; // đổ dữ liệu vào dG
            txtMaKhoa.Enabled = false;
        }
        private void frmDMKhoa_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            txtMaKhoa.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtTenKhoa.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtDiaChiKhoa.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmThemDMKhoa a = new frmThemDMKhoa();
            a.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string sua = "update DMKhoa set TenKhoa = N'" + txtTenKhoa.Text + "', DiaChiKhoa = '" + txtDiaChiKhoa.Text + "' where MaKhoa = '" + txtMaKhoa.Text + "'";
            SqlCommand comSua = new SqlCommand(sua, con);
            comSua.ExecuteNonQuery();
            getdata();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa k?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string xoa = "delete from DMKhoa where MaKhoa = '" + txtMaKhoa.Text + "'";
                SqlCommand comXoa = new SqlCommand(xoa, con);
                comXoa.ExecuteNonQuery();
                getdata();
            }
            else if (dialogResult == DialogResult.No)
            {
                getdata();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
