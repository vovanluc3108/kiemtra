using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using kiemtrathuwinform.Entity;
using kiemtrathuwinform.BussinessLogicLayer;

namespace kiemtrathuwinform
{
    public partial class CapnhatourForm : Form
    {
        LoaiTourBL loaiBL = new LoaiTourBL();
        TourBL tourBL = new TourBL();
        CommonBL comBL = new CommonBL();

        public CapnhatourForm()
        {
            InitializeComponent();
        }

        public void Getcombobox()
        {
            DataTable dtLoai = loaiBL.GetAllLoaiTour();
            this.cbcLoai.DataSource = dtLoai;
            this.cbcLoai.DisplayMember = "tenloai";
            this.cbcLoai.ValueMember = "maloai";
        }

        public void LoadImage()
        {
            try
            {
                pictureBox1.BackgroundImage = Image.FromFile("\\image" + txtHinh.Text);
            }
            catch (System.IO.FileNotFoundException)
            {

                pictureBox1.BackgroundImage = null;
            }
        }

        private void CapnhatourForm_Load(object sender, EventArgs e)
        {
            try
            {
                Getcombobox();
            BindingSource bs = tourBL.GetAllTour();
            this.dataGridView1.DataSource = bs;
            this.bindingNavigator1.BindingSource = bs;
            this.txtMa.DataBindings.Add("Text", bs, "matour");
            this.txtTen.DataBindings.Add("Text", bs, "tentour");
            this.txtHinh.DataBindings.Add("Text", bs, "hinh");
            this.dateTimePicker1.DataBindings.Add("Value", bs, "ngaykhoihanh", true, DataSourceUpdateMode.OnValidation, null, "dd/MM/yyyy");
            this.cbcLoai.DataBindings.Add("SelectedValue", bs, "maloai");
            this.dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private Tour GetTour()
        {
            Tour tour = new Tour();
            tour.MaLoai = this.txtMa.Text;
            tour.TenTour = this.txtTen.Text;
            tour.Hinh = this.txtHinh.Text;
            tour.NgayKhoiHanh = this.dateTimePicker1.Value;
            tour.MaLoai = this.cbcLoai.SelectedValue.ToString();
            return tour;
        }
        

       private void LoadGridView(Tour tour)
        {
            this.dataGridView1.CurrentRow.Cells[0].Value = tour.MaTour;
            this.dataGridView1.CurrentRow.Cells[1].Value = tour.TenTour;
            this.dataGridView1.CurrentRow.Cells[2].Value = tour.Hinh;
            this.dataGridView1.CurrentRow.Cells[3].Value = tour.NgayKhoiHanh;
            this.dataGridView1.CurrentRow.Cells[4].Value = tour.MaLoai;
            this.dataGridView1.Refresh();

        }

       
       

        private void btnThem_Click(object sender, EventArgs e)
        {
            Tour tour = this.GetTour();
            int i = tourBL.Insert(tour);
            if (i>0)
            {
                this.LoadGridView(tour);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DialogResult n = openFileDialog1.ShowDialog();
            if (n == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                string file = comBL.upload(openFileDialog1.FileName);
                txtHinh.Text = file;
            }
        }
    }
}
