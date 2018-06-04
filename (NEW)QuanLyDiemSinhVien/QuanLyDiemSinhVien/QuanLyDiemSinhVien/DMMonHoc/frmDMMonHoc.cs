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
    public partial class frmDMMonHoc : Form
    {
        public static SqlConnection con;
        public frmDMMonHoc()
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
            String sqlSELECT = "SELECT * FROM DMMonHoc";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView2.DataSource = dt; // đổ dữ liệu vào dG
            txtMaMonHoc.Enabled = false;
            txtMaLop.Enabled = false;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmDMMonHoc_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView2.CurrentRow.Index;
            txtMaMonHoc.Text = dataGridView2.Rows[index].Cells[0].Value.ToString();
            txtTenMonHoc.Text = dataGridView2.Rows[index].Cells[1].Value.ToString();
            txtSoTinChi.Text = dataGridView2.Rows[index].Cells[2].Value.ToString();
            txtMaLop.Text = dataGridView2.Rows[index].Cells[3].Value.ToString();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmThemDMMonHoc a = new frmThemDMMonHoc();
            a.ShowDialog();
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string sua = "update DMMonHoc set TenMH = N'" + txtTenMonHoc.Text + "', SoTiet = '" + txtSoTinChi.Text + "' where MaMH = '" + txtMaMonHoc.Text + "'";
            SqlCommand comSua = new SqlCommand(sua, con);
            comSua.ExecuteNonQuery();
            getdata();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa k?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string xoa = "delete from DMMonHoc where MaMH = '" + txtMaMonHoc.Text + "'";
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
