using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Oracle.DataAccess.Client;
using System.Data;
namespace Project_PCS
{
    /// <summary>
    /// Interaction logic for MasterBarang.xaml
    /// </summary>
    public partial class MasterBarang : Window
    {
        class cbSupKat
        {
            public string kode { get; set; }
            public string nama { get; set; }

            public cbSupKat(string kode, string nama)
            {
                this.kode = kode;
                this.nama = nama;
            }
        }
        List<cbSupKat> lisKat = new List<cbSupKat>();
        List<cbSupKat> lisSup = new List<cbSupKat>();
        OracleConnection con;
        DataSet ds;
        public MasterBarang()
        {
            InitializeComponent();
            con = App.conn;
            LoadBarang();
            LoadKategori();
            LoadSupplier();
        }
        private void LoadBarang()
        {
            using (OracleDataAdapter adap = new OracleDataAdapter($"SELECT * from barang order by 1 desc", con))
            {
                ds = new DataSet();
                adap.Fill(ds);
                viewer.ItemsSource = ds.Tables[0].DefaultView;
            }
        }
        private void LoadKategori()
        {
            using (OracleDataAdapter adap = new OracleDataAdapter($"SELECT * from kategori", con))
            {
                DataTable dt = new DataTable();
                adap.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    string id =item["id_kategori"].ToString();
                    string nama =item["nama_kategori"].ToString();
                    lisKat.Add(new cbSupKat(id, nama));
                }

                cbKategori.ItemsSource = lisKat;
                cbKategori.DisplayMemberPath = "nama";
                cbKategori.SelectedValuePath = "kode";
            }
        }
        private void Btn_Insert_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            try
            {
                int harga_eceran = Convert.ToInt32(tbHargaEceran.Text);
                int harga_grosir = Convert.ToInt32(tbHargaGrosir.Text);
                int min_jum_barang = Convert.ToInt32(tbMinJum.Text);
                int jum_barang = Convert.ToInt32(tbJumBarang.Text);
                int jum_min_grosir = Convert.ToInt32(tbJumMinGrosir.Text);
                try
                {
                    string nama = tb_nama.Text;
                    string status = Convert.ToInt32(cbxStatus.IsChecked).ToString();
                    string query = $"INSERT into barang values('','{nama}',{harga_eceran},{harga_grosir},{min_jum_barang},{jum_barang},'{cbSupplier.SelectedValue}','{cbKategori.SelectedValue}',{jum_min_grosir},'{status}')";
                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.ExecuteNonQuery();
                    LoadBarang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                    MessageBox.Show(ex.Message);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Harga Eceran,Harga Grosir,Min Jum Barang, Jum Barang, Jum Min Grosir harus angka");
            }
            con.Close();
        }
        private void LoadSupplier()
        {
            using (OracleDataAdapter adap = new OracleDataAdapter($"SELECT * from supplier", con))
            {
                DataTable dt=new DataTable();
                adap.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    string kode = item["id_supplier"].ToString();
                    string nama = item["nama_supplier"].ToString();
                    lisSup.Add(new cbSupKat(kode, nama));
                }
                cbSupplier.ItemsSource = lisSup;
                cbSupplier.DisplayMemberPath = "nama";
                cbSupplier.SelectedValuePath = "kode";
            }

        }

        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            try
            {
                int harga_eceran = Convert.ToInt32(tbHargaEceran.Text);
                int harga_grosir = Convert.ToInt32(tbHargaGrosir.Text);
                int min_jum_barang = Convert.ToInt32(tbMinJum.Text);
                int jum_barang = Convert.ToInt32(tbJumBarang.Text);
                int jum_min_grosir = Convert.ToInt32(tbJumMinGrosir.Text);
                try
                {
                    string nama = tb_nama.Text;
                    string status = Convert.ToInt32(cbxStatus.IsChecked).ToString();
                    string query = $"UPDATE barang set nama_barang='{nama}',harga_eceran={harga_eceran},harga_grosir={harga_grosir},min_jum_barang={min_jum_barang},jum_barang={jum_barang},id_supplier='{cbSupplier.SelectedValue}',id_kategori='{cbKategori.SelectedValue}',jum_min_grosir={jum_min_grosir},status='{status}')";
                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.ExecuteNonQuery();
                    LoadBarang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Harga Eceran,Harga Grosir,Min Jum Barang, Jum Barang, Jum Min Grosir harus angka");
            }
            con.Close();
        }
        string id_barang;
        private void Viewer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewer.SelectedIndex != -1)
            {
                id_barang = ds.Tables[0].Rows[viewer.SelectedIndex]["id_barang"].ToString();
                tb_nama.Text = ds.Tables[0].Rows[viewer.SelectedIndex]["nama_barang"].ToString();
                tbHargaEceran.Text= ds.Tables[0].Rows[viewer.SelectedIndex]["harga_eceran"].ToString();
                tbHargaGrosir.Text = ds.Tables[0].Rows[viewer.SelectedIndex]["harga_grosir"].ToString();
                tbMinJum.Text = ds.Tables[0].Rows[viewer.SelectedIndex]["min_jum_barang"].ToString();
                tbJumBarang.Text = ds.Tables[0].Rows[viewer.SelectedIndex]["jum_barang"].ToString();
                cbKategori.SelectedValue= ds.Tables[0].Rows[viewer.SelectedIndex]["id_kategori"].ToString();
                cbSupplier.SelectedValue= ds.Tables[0].Rows[viewer.SelectedIndex]["id_supplier"].ToString();
                tbJumMinGrosir.Text= ds.Tables[0].Rows[viewer.SelectedIndex]["jum_min_grosir"].ToString();
                cbxStatus.IsChecked = Convert.ToBoolean(Convert.ToInt32(ds.Tables[0].Rows[viewer.SelectedIndex]["status"].ToString()));
            }
        }
    }
}
