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
    public partial class frmDMDiem : Form
    {
        public static SqlConnection con;
        public frmDMDiem()
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
            String sqlSELECT = "SELECT * FROM DMDiem";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView4.DataSource = dt; // đổ dữ liệu vào dG
            txtMaSV.Enabled = false;
            txtMaMH.Enabled = false;
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmThemDMDiem diem = new frmThemDMDiem();
            diem.Show();
        }

        private void frmDMDiem_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
            Load_Treeview();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView4.CurrentRow.Index;
            txtMaSV.Text = dataGridView4.Rows[index].Cells[0].Value.ToString();
            txtMaMH.Text = dataGridView4.Rows[index].Cells[1].Value.ToString();
            txtLanThi.Text = dataGridView4.Rows[index].Cells[2].Value.ToString();
            txtDiemSo.Text = dataGridView4.Rows[index].Cells[3].Value.ToString();
            txtDiemChu.Text = dataGridView4.Rows[index].Cells[4].Value.ToString();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string sua = "update DMDiem set LanThi = '"+txtLanThi.Text+"', DiemSo = '"+txtDiemSo.Text+"', DiemChu ='"+txtDiemChu.Text+"' where MaSV = '"+txtMaSV.Text+ "' and MaMH = '" + txtMaMH.Text + "' and LanThi ='" + txtLanThi.Text + "'";
            SqlCommand comSua = new SqlCommand(sua, con);
            comSua.ExecuteNonQuery();
            getdata();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa k?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string xoa = "delete from DMDiem where MaSV = '" + txtMaSV.Text + "' and MaMH = '"+txtMaMH.Text+"' and LanThi ='"+txtLanThi.Text+"' and DiemSo ='"+txtDiemSo.Text+"'";
                SqlCommand comXoa = new SqlCommand(xoa, con);
                comXoa.ExecuteNonQuery();
                getdata();
            }
            else if (dialogResult == DialogResult.No)
            {
                getdata();
            }
        }
        public DataTable truyvan(string sql, SqlConnection con)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dt);
            return dt;
        }
        private void điểm9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM DMDiem where DiemSo >=9";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView4.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void tấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getdata();
        }

        private void điểm9ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM DMDiem where DiemSo >=8 and DiemSo <9";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView4.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void điểm85ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM DMDiem where DiemSo >=7 and DiemSo <8";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView4.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void điểm8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM DMDiem where DiemSo >=4 and DiemSo <7";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView4.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void điểm7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM DMDiem where  DiemSo <4";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView4.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void quaMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM DMDiem where  DiemSo >=4";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView4.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void trượtMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM DMDiem where  DiemSo <4";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView4.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void tấtCảToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getdata();
        }
        private void Load_Treeview()
        {           
            tvDMDiem.Nodes.Clear();
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
                        tvDMDiem.Nodes.Add(node);
                    }
                }
            }
        }
        private void tvDMDiem_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode theNode = this.tvDMDiem.SelectedNode;
            string sql = "select a.MaSV,a.MaMH,a.LanThi,a.DiemSo,a.DiemChu from DMDiem a inner join DMMonHoc b on a.MaMH = b.MaMH inner join DMLop c on b.MaLop = c.MaLop inner join DMKhoa d on c.MaKhoa = d.MaKhoa where d.MaKhoa = '"+theNode.Text+"' or c.MaLop = '"+theNode.Text+"' order by DiemSo desc";
            SqlCommand com = new SqlCommand(sql, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView4.DataSource = dt;
        }

        private void từCaoThấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "select * from DMDiem order by DiemSo desc";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView4.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void từThấpCaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "select * from DMDiem order by DiemSo asc";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView4.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "select a.MaSV,a.MaMH,a.LanThi,a.DiemSo,a.DiemChu from DMDiem a inner join DMSV b on a.MaSV = b.MaSV where a.MaSV = '"+txtTimKiemDiem.Text+"' or a.MaMH ='"+ txtTimKiemDiem.Text + "' or a.LanThi ='"+ txtTimKiemDiem.Text + "' or b.TenSV like '%"+ txtTimKiemDiem.Text + "%'";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView4.DataSource = dt; // đổ dữ liệu vào dG
        }

       
        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
