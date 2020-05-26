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
using System.Text.RegularExpressions;
using Oracle.DataAccess.Client;
using System.Data;

namespace Project_PCS
{
    /// <summary>
    /// Interaction logic for TransaksiJual.xaml
    /// </summary>
    public partial class TransaksiJual : Window
    {
        string database, qry, idcust, nonota;
        long total, kembali;
        int idxtabel, poin, poinAwal;
        OracleConnection con;
        DataTable dt = new DataTable();
        OracleDataReader dr;
        OracleDataAdapter da;
        
        void PoinHarga()
        {
            total = 0;
            poin = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                total += Convert.ToInt64(dt.Rows[i][4].ToString());
            }
            labTotal.Content = total.ToString();
            poin = Convert.ToInt32(total) / 10000;
            labPoin.Content = poin.ToString();
        }

        bool cekDataGrid(string idbarang)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (idbarang == dt.Rows[i][0].ToString())
                {
                    return false;
                }
            }
            return true;
        }

        public TransaksiJual(string ds)
        {
            InitializeComponent();
            database = ds;
            con = new OracleConnection(database);

            labIDCust.Content = "-";
            labNamaCust.Content = "-";
            labNoNota.Content = "-";
            labPoin.Content = "0";
            labKembali.Content = "0";
            labIDBrg.Content = "-";
            labNamaBrg.Content = "-";
            labTotal.Content = "0";

            dt.Columns.Add("ID Barang", typeof(string));
            dt.Columns.Add("Nama Barang", typeof(string));
            dt.Columns.Add("Jumlah", typeof(Int64));
            dt.Columns.Add("Harga", typeof(Int64));
            dt.Columns.Add("Subtotal", typeof(Int64));

            cCust.IsEnabled = true;
            cBarang.IsEnabled = false;
            cBayar.IsEnabled = false;
            
            dgJual.ItemsSource = dt.DefaultView;
            dgJual.IsReadOnly = true;
            tbCariCust.Focus();
        }
        
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            PegawaiHome ph = new PegawaiHome(database);
            this.Close();
            ph.Show();
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            cBarang.IsEnabled = true;
            cBayar.IsEnabled = true;
            cCust.IsEnabled = false;

            if (tbCariCust.Text == "")
            {
                idcust = "";
            }
            else
            {
                idcust = labIDCust.Content.ToString();
            }

            try
            {
                con.Open();
                qry = "select NewNotaJual from dual";
                OracleCommand cmd = new OracleCommand(qry, con);
                labNoNota.Content = cmd.ExecuteScalar();
                nonota = labNoNota.Content.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
            tbCariCust.Text = "";
            tbCariBrg.Focus();
        }

        private void TbBayar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex("[^0-9]");
            e.Handled = reg.IsMatch(e.Text);
        }

        private void TbJumlah_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    con.Open();
                    qry = $"select * from barang where id_barang = '{labIDBrg.Content}' and rownum = 1";
                    OracleCommand cmd = new OracleCommand(qry, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.GetInt64(6) < Convert.ToInt32(tbJumlah.Text))
                    {
                        MessageBox.Show("Stok tidak cukup!");
                        tbJumlah.Text = "";
                        con.Close();
                    }
                    else
                    {
                        DataRow drow = dt.NewRow();
                        drow[0] = dr.GetString(0);
                        drow[1] = dr.GetString(1);
                        drow[2] = tbJumlah.Text;
                        
                        if (Convert.ToInt32(tbJumlah.Text) < dr.GetInt64(9))
                        {
                            drow[3] = dr.GetInt64(2);
                        }
                        else
                        {
                            drow[3] = dr.GetInt64(3);
                        }
                        drow[4] = Convert.ToInt64(drow[3].ToString()) * Convert.ToInt64(drow[2].ToString());
                        dr.Close();
                        dt.Rows.Add(drow);

                        //qry = $"select * from promo where id_barang = {drow[0]} and to_char(tanggal_promo, 'dd-MMM-yy') > {DateTime.Now.Date.ToString("dd-MMM-yy")} ";
                        //cmd = new OracleCommand(qry, con);



                        con.Close();
                        labIDBrg.Content = "-";
                        labNamaBrg.Content = "-";
                        tbCariBrg.Text = "";
                        tbJumlah.Text = "";
                        PoinHarga();
                        tbCariBrg.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    con.Close();
                }
            }
        }

        private void TbCariBrg_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                tbJumlah.Focus();
            }
        }

        private void TbCariCust_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnEnter.Focus();
            }
            else {
                if (tbCariCust.Text != "")
                {
                    try
                    {
                        con.Open();
                        labIDCust.Content = "";
                        labNamaCust.Content = "";
                        qry = $"select id_customer, nama_customer, poin from customer where upper(nama_customer) like '%{tbCariCust.Text.ToUpper()}%' or upper(id_customer) like '%{tbCariCust.Text.ToUpper()}%' and rownum = 1";
                        OracleCommand cmd = new OracleCommand(qry, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        labIDCust.Content = dr.GetString(0);
                        labNamaCust.Content = dr.GetString(1);
                        poinAwal = dr.GetInt32(2);
                        dr.Close();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        labIDCust.Content = "-";
                        labNamaCust.Content = "-";
                    }
                }
                else
                {
                    labIDCust.Content = "-";
                    labNamaCust.Content = "-";
                }
            }
        }

        private void DgJual_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            idxtabel = dgJual.Items.IndexOf(dgJual.CurrentItem);
        }

        private void TbBayar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                kembali = Convert.ToInt64(tbBayar.Text) - total;
                labKembali.Content = kembali.ToString();
                btnSelesai.Focus();
            }
        }

        private void BtnSelesai_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            OracleTransaction trans = con.BeginTransaction();

            try
            {
                qry = "insert into notajual_hdr values(:no_nota, :tglnota, :poin, :idcust, :idpegawai)";
                string tgl = DateTime.Now.Date.ToShortDateString();
                OracleCommand cmd = new OracleCommand(qry, con);

                cmd.Parameters.Add("no_nota", OracleDbType.Varchar2).Value = nonota;
                cmd.Parameters.Add("tglnota", OracleDbType.Date).Value = DateTime.Parse(tgl);
                cmd.Parameters.Add("poin", OracleDbType.Int32).Value = poin;
                cmd.Parameters.Add("idcust", OracleDbType.Varchar2).Value = idcust;
                cmd.Parameters.Add("idpegawai", OracleDbType.Varchar2).Value = "PEG01";
                cmd.ExecuteNonQuery();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    qry = "insert into notajual_body values (:no_nota, :idbarang, :qty, :harga)";
                    cmd = new OracleCommand(qry, con);
                    cmd.Parameters.Add("no_nota", OracleDbType.Varchar2).Value = labNoNota.Content;
                    cmd.Parameters.Add("idbarang", OracleDbType.Varchar2).Value = dt.Rows[i][0].ToString();
                    cmd.Parameters.Add("qty", OracleDbType.Int32).Value = Convert.ToInt32(dt.Rows[i][2].ToString());
                    cmd.Parameters.Add("harga", OracleDbType.Long).Value = Convert.ToInt64(dt.Rows[i][3].ToString());
                    cmd.ExecuteNonQuery();
                }

                poin += poinAwal;
                qry = $"update customer set poin={poin} where id_customer='{idcust}'";
                MessageBox.Show("Transaksi penjualan berhasil");

                trans.Commit();
                dt.Rows.Clear();
                dt = new DataTable();
                con.Close();

                PoinHarga();
                idcust = "";
                kembali = 0;
                labNoNota.Content = "-";
                labKembali.Content = "0";
                tbBayar.Text = "";
                labIDCust.Content = "-";
                labNamaCust.Content = "-";

                cCust.IsEnabled = true;
                cBarang.IsEnabled = false;
                cBayar.IsEnabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trans.Rollback();
                con.Close();
            }
        }

        private void BtnHapus_Click(object sender, RoutedEventArgs e)
        {
            if (idxtabel >= 0)
            {
                dt.Rows.RemoveAt(idxtabel);
                PoinHarga();
            }
        }

        private void TbCariBrg_KeyUp(object sender, KeyEventArgs e)
        {
            if (tbCariBrg.Text != "")
            {
                try
                {
                    con.Open();
                    qry = $"select * from barang where upper(nama_barang) like '%{tbCariBrg.Text.ToUpper()}%'or upper(id_barang) like '%{tbCariBrg.Text.ToUpper()}%' and rownum = 1";
                    OracleCommand cmd = new OracleCommand(qry, con);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    labIDBrg.Content = dr.GetString(0);
                    labNamaBrg.Content = dr.GetString(1);
                    dr.Close();
                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                    labIDBrg.Content = "-";
                    labNamaBrg.Content = "-";
                }

                if (e.Key == Key.Return)
                {
                    tbJumlah.Focus();
                }
            }
            else
            {
                labIDBrg.Content = "-";
                labNamaBrg.Content = "-";
            }
        }

        private void TbCariCust_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            
        }
        
        private void TbJumlah_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex("[^0-9]");
            e.Handled = reg.IsMatch(e.Text);
        }
    }
}
