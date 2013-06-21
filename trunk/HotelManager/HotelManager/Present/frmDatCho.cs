using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HotelManager.Business;
using HotelManager.Data.Entity;

namespace HotelManager.Present
{
    public partial class frmDatCho : Form
    {
        float tiencoc = 0;
        public frmDatCho()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dtthoidiemden_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void txtloaiphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BusPhong.Timphongtheotenloaiphong(txtloaiphong.Text, dtthoidiemden.Value, dtthoidiemdi.Value);
            txtsoluongphongtrong.Text = (dataGridView1.RowCount - 1 ).ToString();
            txtcocchomotphong.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            int x = Int32.Parse(txtcocchomotphong.Text);
            x = x * 20 / 100;
            txtcocchomotphong.Text = x.ToString();


        }

        private void frmDatCho_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BusPhieuDatCho.Findtinhtrang(false);
            dataGridView2.DataSource = BusPhieuDatCho.GetTable();
        }

        private void bttimphong_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BusPhong.Timphongtheothoidiem(dtthoidiemden.Value, dtthoidiemdi.Value);
            btdatcho.Enabled = false;
        }

        private void grthongtindatcho_Enter(object sender, EventArgs e)
        {

        }

        private void lbdiachi_Click(object sender, EventArgs e)
        {

        }

        private void txtsoluongphongdatcho_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btdatcho_Click(object sender, EventArgs e)
        {
            if(txtsoluongphongdatcho.Text == "")
                MessageBox.Show("Can nhap so luong phong dat cho", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (Int32.Parse(txtsoluongphongdatcho.Text) > Int32.Parse(txtsoluongphongtrong.Text))
                    MessageBox.Show("So luong phong dat cho khong vuot qua so luong phong trong", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    txttongcoc.Text = (Int32.Parse(txtcocchomotphong.Text) * Int32.Parse(txtsoluongphongdatcho.Text)).ToString();
                    PhieuDatCho phieudatcho = BusPhieuDatCho.FindSDT(txtsodienthoai.Text);
                    tiencoc += (float.Parse(txtcocchomotphong.Text) * float.Parse(txtsoluongphongdatcho.Text));
                    for (int i = 0; i < Int32.Parse(txtsoluongphongdatcho.Text); i++)
                    {
                        Phong phong = BusPhong.FindTheoTenPhong(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        ChiTietPhieuDatCho chitietphieudatcho = new ChiTietPhieuDatCho();

                        chitietphieudatcho.MaPhieuDatCho = phieudatcho.MaPhieuDatCho;
                        chitietphieudatcho.DonGia = float.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        chitietphieudatcho.Coc = float.Parse(txtcocchomotphong.Text);
                        chitietphieudatcho.MaPhong = phong.MaPhong;
                       

                        BusChiTietPhieuDatCho.Add(chitietphieudatcho);

                        
                        

                    }
                    phieudatcho.TenNguoiDatCho = txtnguoidat.Text;
                    phieudatcho.DiaChi = txtdiachi.Text;
                    phieudatcho.SDT = txtsodienthoai.Text;
                    phieudatcho.ThoiDiemDat = dtthoidiemdat.Value;
                    phieudatcho.ThoiDiemDen = dtthoidiemden.Value;
                    phieudatcho.ThoiDiemDi = dtthoidiemdi.Value;
                    phieudatcho.TongCoc = tiencoc;
                    BusPhieuDatCho.UpdatePhieuDatCho(phieudatcho);
                    MessageBox.Show("Da dat thanh cong", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dataGridView2.DataSource = BusPhieuDatCho.GetTable();

                
            }
        }

        private void btluudatcho_Click(object sender, EventArgs e)
        {
            tiencoc = 0;
            PhieuDatCho phieudatcho = new PhieuDatCho();
            phieudatcho.TenNguoiDatCho = txtnguoidat.Text;
            phieudatcho.DiaChi = txtdiachi.Text;
            phieudatcho.SDT = txtsodienthoai.Text;
            phieudatcho.ThoiDiemDat = dtthoidiemdat.Value;
            phieudatcho.ThoiDiemDen = dtthoidiemden.Value;
            phieudatcho.ThoiDiemDi = dtthoidiemdi.Value;
            phieudatcho.TongCoc = 0;
            BusPhieuDatCho.Add(phieudatcho);
            dataGridView2.DataSource = BusPhieuDatCho.GetTable();
            btdatcho.Enabled = true;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtnguoidat.Text = dataGridView2.Rows[e.RowIndex].Cells["clkhachhang"].Value.ToString();
            txtsodienthoai.Text = dataGridView2.Rows[e.RowIndex].Cells["colSDT"].Value.ToString();
            txttongcoc.Text = dataGridView2.Rows[e.RowIndex].Cells["cltongcoc"].Value.ToString();
            dtthoidiemdat.Value = DateTime.Parse(dataGridView2.Rows[e.RowIndex].Cells["clthoidiemdat"].Value.ToString());
            dtthoidiemden.Value = DateTime.Parse(dataGridView2.Rows[e.RowIndex].Cells["clthoidiemden"].Value.ToString());
            dtthoidiemdi.Value = DateTime.Parse(dataGridView2.Rows[e.RowIndex].Cells["clthoidiemdi"].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PhieuDatCho phieudatcho =  BusPhieuDatCho.FindSDT(txtsodienthoai.Text);
            BusChiTietPhieuDatCho.XoaCTPDC(phieudatcho.MaPhieuDatCho);
            BusPhieuDatCho.Delete(phieudatcho.MaPhieuDatCho);
           
            dataGridView2.DataSource = BusPhieuDatCho.GetTable();
        }
    }
}