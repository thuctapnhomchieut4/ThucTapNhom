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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void đầuSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMKhoa dmk = new frmDMKhoa();
            dmk.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void thôngTinTácGiảToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDMMonHoc a = new frmDMMonHoc();
            a.Show();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMLop lop = new frmDMLop();
            lop.Show();
        }

        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMDiem diem = new frmDMDiem();
            diem.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinMượnTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSinhVien sv = new frmSinhVien();
            sv.Show();
        }
    }
}
