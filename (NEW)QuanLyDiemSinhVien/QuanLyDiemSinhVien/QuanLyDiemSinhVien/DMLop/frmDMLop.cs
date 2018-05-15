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
    public partial class frmDMLop : Form
    {
        public static SqlConnection con;
        public frmDMLop()
        {
            InitializeComponent();
        }
        private void connect()
        {
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
            dataGridView3.DataSource = dt; // đổ dữ liệu vào dG
            txtMaLop.Enabled = false;
            txtMaKhoa.Enabled = false;
        }
        public DataTable truyvan(string sql, SqlConnection con)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            return dt;
        }
       
        private void Load_Treeview()
        {
            tvDMLop.Nodes.Clear();
            DataTable dt_Khoa = truyvan("select * from DMKhoa", con);
            if (dt_Khoa.Rows.Count > 0)
            {
                for (int i = 0; i < dt_Khoa.Rows.Count; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = dt_Khoa.Rows[i]["MaKhoa"].ToString();//lấy column tên tác giả từ table TACGIA
                    DataTable dt_Lop = truyvan("SELECT * FROM DMLop where MaKhoa = '" + dt_Khoa.Rows[i]["MaKhoa"].ToString() + "'", con);
                    if (dt_Lop.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt_Lop.Rows.Count; j++)
                        {
                            node.Nodes.Add(dt_Lop.Rows[j]["MaLop"].ToString());//lấy column tên sách từ table SACH }
                        }
                        tvDMLop.Nodes.Add(node);
                    }
                }
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode theNode = this.tvDMLop.SelectedNode;
            string sql = "select b.MaLop,b.TenLop,a.MaKhoa,b.DiaDiemHoc,b.ThoiGianHoc from DMKhoa a inner join DMlop b on a.MaKhoa = b.MaKhoa where a.MaKhoa = '" + theNode.Text + "' or b.MaLop = '" + theNode.Text + "'";
            SqlCommand com = new SqlCommand(sql, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView3.DataSource = dt;

            
        }

        private void frmDMLop_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
            Load_Treeview();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView3.CurrentRow.Index;
            txtMaLop.Text = dataGridView3.Rows[index].Cells[0].Value.ToString();
            txtTenLop.Text = dataGridView3.Rows[index].Cells[1].Value.ToString();
            txtMaKhoa.Text = dataGridView3.Rows[index].Cells[2].Value.ToString();
            txtDiaDiem.Text = dataGridView3.Rows[index].Cells[3].Value.ToString();
            txtThoiGianHoc.Text = dataGridView3.Rows[index].Cells[4].Value.ToString();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void tấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            getdata();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            frmThemDMLop tl = new frmThemDMLop();
            tl.Show();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            string sua = "update DMLop set TenLop = N'"+txtTenLop.Text+"', DiaDiemHoc=N'"+txtDiaDiem.Text+"',ThoiGianHoc='"+txtThoiGianHoc.Text+"'  where MaLop='"+txtMaLop.Text+"'";
            SqlCommand comSua = new SqlCommand(sua, con);
            comSua.ExecuteNonQuery();
            getdata();
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtDiaDiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtThoiGianHoc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtTenLop_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaKhoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaLop_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
