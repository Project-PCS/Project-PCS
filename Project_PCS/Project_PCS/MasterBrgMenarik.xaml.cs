using System;
using System.Collections.Generic;
using System.Data;
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
using System.Text.RegularExpressions;

namespace Project_PCS
{
    /// <summary>
    /// Interaction logic for MasterBrgMenarik.xaml
    /// </summary>
    public partial class MasterBrgMenarik : Window
    {
        OracleConnection con;
        OracleDataReader dr;
        OracleDataAdapter da;
        string qry;
        int rowidx;
        DataTable dt = new DataTable();

        void loadDataGrid()
        {
            dt.Rows.Clear();
            qry = "select id_barang_menarik as \"ID Brg Menarik\", nama_barang as \"Nama Barang\", jml_barang as \"Jml Barang\", jml_poin as \"Jml Poin\", case status_berlaku when 1 then 'Berlaku' when 0 then 'Tidak Berlaku' end as \"Status\" from barang_menarik bm, barang b where bm.id_barang = b.id_barang order by 1";
            OracleCommand cmd = new OracleCommand(qry, con);
            cmd.ExecuteReader();
            da = new OracleDataAdapter(cmd);
            da.Fill(dt);
            dgBrgMenarik.ItemsSource = dt.DefaultView;
        }

        public MasterBrgMenarik()
        {
            InitializeComponent();
            dgBrgMenarik.IsReadOnly = true;
            btnUbah.IsEnabled = false;
            con = App.conn;

            try
            {
                con.Open();
                loadDataGrid();
                OracleCommand cmd = new OracleCommand("select NewBarangMenarik from dual", con);
                labIDBrgMenarik.Content = cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnKembali_Click(object sender, RoutedEventArgs e)
        {
            admin a = new admin();
            a.Show();
            this.Hide();
        }

        private void BtnTambah_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                qry = "insert into barang_menarik values(:id, :idbrg, :jml, :poin, :status)";
                OracleCommand cmd = new OracleCommand(qry, con);
                cmd.Parameters.Add("id", OracleDbType.Varchar2).Value = labIDBrgMenarik.Content;
                cmd.Parameters.Add("idbrg", OracleDbType.Varchar2).Value = labIDBrg.Content;
                cmd.Parameters.Add("jml", OracleDbType.Int32).Value = tbJmlBarang.Text;
                cmd.Parameters.Add("poin", OracleDbType.Int32).Value = tbJmlPoin.Text;
                if (cbBerlaku.IsChecked == true)
                {
                    cmd.Parameters.Add("status", OracleDbType.Int16).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("status", OracleDbType.Int16).Value = 0;
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Menambahkan");

                loadDataGrid();
                qry = "select NewBarangMenarik from dual";
                cmd = new OracleCommand(qry, con);
                labIDBrgMenarik.Content = cmd.ExecuteScalar();
                labIDBrg.Content = "-";
                labNamaBrg.Content = "-";
                labHarga.Content = "0";
                tbJmlBarang.Text = "";
                tbJmlPoin.Text = "";
                tbCari.Text = "";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        private void TbJmlPoin_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex("[^0-9]");
            e.Handled = reg.IsMatch(e.Text);
        }

        private void TbJmlBarang_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex("[^0-9]");
            e.Handled = reg.IsMatch(e.Text);
        }
        
        private void TbCari_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbCari.Text != "")
            {
                qry = $"select k.nama_kategori, b.id_barang, b.nama_barang, b.harga_eceran from kategori k, barang b where upper(id_barang) like '%{tbCari.Text.ToUpper()}%' or upper(nama_barang) like '%{tbCari.Text.ToUpper()}%' and k.id_kategori = b.id_kategori and rownum = 1";

                try
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand(qry, con);
                    dr = cmd.ExecuteReader();

                    dr.Read();
                    labKategori.Content = dr.GetString(0);
                    labIDBrg.Content = dr.GetString(1);
                    labNamaBrg.Content = dr.GetString(2);
                    labHarga.Content = dr.GetInt64(3);
                    dr.Close();

                    con.Close();
                }
                catch (Exception ex)
                {
                    labIDBrg.Content = "-";
                    labNamaBrg.Content = "-";
                    labHarga.Content = "0";
                    labKategori.Content = "-";
                    con.Close();
                }
            }
            else
            {
                labKategori.Content = "";
                labIDBrg.Content = "";
                labNamaBrg.Content = "";
                labHarga.Content = "";
            }
        }

        private void DgBrgMenarik_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            rowidx = dgBrgMenarik.Items.IndexOf(dgBrgMenarik.CurrentItem);

            if (rowidx >= 0)
            {
                tbCari.IsEnabled = false;
                btnTambah.IsEnabled = false;
                btnUbah.IsEnabled = true;
                try
                {
                    con.Open();
                    qry = $"select k.nama_kategori, b.id_barang, b.harga_eceran from barang b, kategori k where nama_barang = '{dt.Rows[rowidx][1]}' and k.id_kategori = b.id_kategori";
                    OracleCommand cmd = new OracleCommand(qry, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    labKategori.Content = dr.GetString(0);
                    labIDBrg.Content = dr.GetString(1);
                    labHarga.Content = dr.GetInt64(2);
                    dr.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    con.Close();
                }

                labIDBrgMenarik.Content = dt.Rows[rowidx][0];
                tbCari.Text = "";
                labNamaBrg.Content = dt.Rows[rowidx][1].ToString();
                tbJmlBarang.Text = dt.Rows[rowidx][2].ToString();
                tbJmlPoin.Text = dt.Rows[rowidx][3].ToString();

                if (dt.Rows[rowidx][4].ToString() == "Berlaku")
                {
                    cbBerlaku.IsChecked = true;
                }
                else
                {
                    cbBerlaku.IsChecked = false;
                }
            }
            else
            {
                tbCari.IsEnabled = true;
                btnTambah.IsEnabled = true;
                btnUbah.IsEnabled = false;
            }
        }
        
        private void BtnUbah_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int status;
                con.Open();

                if (cbBerlaku.IsChecked == true)
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }

                qry = $"update barang_menarik set jml_barang = {tbJmlBarang.Text}, jml_poin = {tbJmlPoin.Text}, status_berlaku = {status} where id_barang_menarik = '{labIDBrgMenarik.Content}'";
                OracleCommand cmd = new OracleCommand(qry, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Mengubah");

                loadDataGrid();
                qry = "select NewBarangMenarik from dual";
                cmd = new OracleCommand(qry, con);
                labIDBrgMenarik.Content = cmd.ExecuteScalar();
                labIDBrg.Content = "-";
                labKategori.Content = "-";
                labNamaBrg.Content = "-";
                labHarga.Content = "0";
                tbJmlBarang.Text = "";
                tbJmlPoin.Text = "";
                tbCari.Text = "";
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }
    }
}
