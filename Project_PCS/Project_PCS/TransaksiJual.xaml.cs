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

                        //cek promo
                        qry = $"select id_promo, nama_promo || id_barang, potongan_harga from promo where id_barang = '{dt.Rows[dt.Rows.Count-1][0]}' and to_date(sysdate, 'dd-MM-yy') > to_date(tanggal_promo, 'dd-MM-yy') and to_date(sysdate, 'dd-MM-yy') < to_date(akhir_promo, 'dd-MM-yy') and rownum=1";
                        cmd = new OracleCommand(qry, con);
                        dr = cmd.ExecuteReader();

                        while(dr.Read())
                        {
                            long potonganharga;
                            drow = dt.NewRow();
                            drow[0] = dr.GetString(0);
                            drow[1] = dr.GetString(1);
                            drow[2] = dt.Rows[dt.Rows.Count-1][2].ToString();

                            if (dr.GetString(1).Contains("DISKON"))
                            {
                                potonganharga = (Convert.ToInt64(dt.Rows[dt.Rows.Count-1][3].ToString()) * dr.GetInt64(2))/100;
                                MessageBox.Show("harga asli: " + dt.Rows[dt.Rows.Count - 1][3].ToString() + "\n potongan: " + dr.GetInt64(2));
                                MessageBox.Show("hasil: " + potonganharga);
                            }
                            else
                            {
                                potonganharga = dr.GetInt64(2);
                            }
                            drow[3] = potonganharga * -1;
                            drow[4] = Convert.ToInt64(drow[3].ToString()) * Convert.ToInt64(drow[2].ToString());
                            dt.Rows.Add(drow);
                        }
                        dr.Close();

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
                    MessageBox.Show("Input tidak valid!");
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
                
                long hargabaru;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    hargabaru = 0;
                    if (dt.Rows[i][0].ToString().Substring(0, 1) == "D")
                    {
                        hargabaru = Convert.ToInt64(dt.Rows[i - 1][3].ToString()) + Convert.ToInt64(dt.Rows[i][3].ToString());
                        dt.Rows[i - 1][3] = hargabaru;
                        dt.Rows[i-1][4] = Convert.ToInt64(dt.Rows[i-1][3].ToString()) * Convert.ToInt64(dt.Rows[i-1][2].ToString());
                        dt.Rows.RemoveAt(i);
                    }
                }
                btnSelesai.Focus();
            }
        }

        private void BtnSelesai_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("btnselesai masuk");
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
                    MessageBox.Show("qry string");
                    cmd = new OracleCommand(qry, con);
                    MessageBox.Show("new cmd");
                    cmd.Parameters.Add("no_nota", OracleDbType.Varchar2).Value = nonota;
                    MessageBox.Show("param nonota added");
                    cmd.Parameters.Add("idbarang", OracleDbType.Varchar2).Value = dt.Rows[i][0].ToString();
                    MessageBox.Show("param idbrg added");
                    cmd.Parameters.Add("qty", OracleDbType.Int32).Value = dt.Rows[i][2];
                    MessageBox.Show("param qty added");
                    cmd.Parameters.Add("harga", OracleDbType.Long).Value = dt.Rows[i][3];
                    MessageBox.Show("param harga added");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("done execute " + i);
                }
                
                poin += poinAwal;
                qry = $"update customer set poin={poin} where id_customer='{idcust}'";
                cmd = new OracleCommand(qry, con);
                cmd.ExecuteNonQuery();

                trans.Commit();
                con.Close();
                MessageBox.Show("Transaksi penjualan berhasil");
                dt.Rows.Clear();
                dt = new DataTable();

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
            if (idxtabel >= 0 && dt.Rows[idxtabel][0].ToString().Substring(0,1) == "B")
            {
                if (idxtabel < dt.Rows.Count - 1 && dt.Rows[idxtabel+1][0].ToString().Substring(0,1) == "D")
                {
                    dt.Rows.RemoveAt(idxtabel + 1);
                }
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
