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
    /// Interaction logic for Penukaran_Poin.xaml
    /// </summary>
    public partial class Penukaran_Poin : Window
    {
        OracleConnection con;
        string database;
        private OracleDataAdapter da;
        DataSet db = new DataSet();
        DataTable dt = new DataTable();
        string id;
        int totalpoin = 0;
        int poin = 0;
        public Penukaran_Poin(string ds)
        {
            InitializeComponent();
            this.database = ds;
            dt.Columns.Add("Id Nota", typeof(string));
            dt.Columns.Add("Id Barang Menarik", typeof(string));
            dt.Columns.Add("Id Barang", typeof(string));
            dt.Columns.Add("Poin", typeof(Int32));
            dgList.ItemsSource = dt.DefaultView;
            LoadNumber();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PegawaiHome ph = new PegawaiHome(database);
            this.Close();
            ph.Show();
        }

        private void btnCari_Click(object sender, RoutedEventArgs e)
        {
            if(tbId.Text!="")
            {
                LoadDataSet();
                con = new OracleConnection(database);
                con.Open();
                string query = "SELECT poin from customer where id_customer='" + tbId.Text + "'";
                OracleCommand cmd = new OracleCommand(query, con);
                poin = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                lbPoin.Content = poin;
            }
            else
            {
                MessageBox.Show("Masukkan Id Customer");
            }
        }

        private void LoadDataSet()
        {
            con = new OracleConnection(database);
            con.Open();
            string query = "SELECT bm.id_barang_menarik as \"Id Barang\", b.nama_barang as \"Nama Barang\", bm.jml_poin as \"Jumlah Poin\", bm.status_berlaku as \"Status Berlaku\" from barang b, barang_menarik bm where b.id_barang = bm.id_barang";
            OracleCommand cmd = new OracleCommand(query, con);
            cmd.ExecuteReader();
            OracleDataAdapter oda = new OracleDataAdapter(cmd);
            db = new DataSet();
            oda.Fill(db);
            dgBarang.ItemsSource = db.Tables[0].DefaultView;
            con.Close();
        }

        private void dgBarang_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dgBarang.SelectedIndex!=-1)
            {
                DataRow dr = db.Tables[0].Rows[dgBarang.SelectedIndex];
                tbIdBarang.Text = dr["Id Barang"].ToString();
                btnTambah.IsEnabled = true;
            }
        }

        private void LoadNumber()
        {
            con = new OracleConnection(database);
            con.Open();
            string query = "SELECT COUNT(ID_TUKAR_POIN) FROM TUKARPOIN_HDR";
            OracleCommand cmd = new OracleCommand(query, con);
            int jumsup = Convert.ToInt32(cmd.ExecuteScalar());
            jumsup = jumsup + 1;
            id = "TP";
            if (jumsup < 10)
            {
                id = id + "00" + jumsup;
            }
            else if (jumsup < 100)
            {
                id = id + "0" + jumsup;
            }
            else
            {
                id = id + jumsup;
            }
            con.Close();
        }

        private void Poin()
        {
            totalpoin = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                totalpoin += Convert.ToInt32(dt.Rows[i][3].ToString());
            }
            poinreq.Content = totalpoin;
        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            con = new OracleConnection(database);

            con.Open();
            string query = "SELECT jml_poin from barang_menarik where id_barang_menarik = '" + tbIdBarang.Text + "'";
            OracleCommand cmd = new OracleCommand(query, con);
            int temp = Convert.ToInt32(cmd.ExecuteScalar());
            totalpoin = totalpoin + temp;

            query = "SELECT id_barang from barang_menarik where id_barang_menarik = '" + tbIdBarang.Text + "'";
            cmd = new OracleCommand(query, con);
            string barang = cmd.ExecuteScalar().ToString();
            con.Close();

            if (totalpoin <= poin)
            {
                DataRow dr = dt.NewRow();
                dr[0] = id;
                dr[1] = tbIdBarang.Text;
                dr[2] = barang;
                dr[3] = temp;
                dt.Rows.Add(dr);
                Poin();
                btnTukar.IsEnabled = true;
            }
            else
            {
                totalpoin = totalpoin - temp;
                MessageBox.Show("Poin anda tidak cukup");
            }
        }

        private void Reset()
        {
            LoadDataSet();
            LoadNumber();
        }

        private void UpdateBarang()
        {
            con = new OracleConnection(database);
            con.Open();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int tempjum = 0;
                string query = "SELECT jum_barang from barang where id_barang ='" + dt.Rows[i][2].ToString() + "'";
                OracleCommand cmd = new OracleCommand(query, con);
                tempjum = Convert.ToInt32(cmd.ExecuteScalar());
                tempjum = tempjum - 1;

                query = $"update barang set jum_barang = {tempjum} where id_barang ='{dt.Rows[i][2].ToString()}'";
                cmd = new OracleCommand(query, con);

                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        private void updatePoin()
        {
            int temp = Convert.ToInt32(lbPoin.Content);
            int kurangi = Convert.ToInt32(poinreq.Content);
            int sisa = temp - kurangi;
            con = new OracleConnection(database);
            con.Open();
            string query = $"UPDATE customer set poin={sisa} where id_customer='{tbId.Text}'";
            OracleCommand cmd = new OracleCommand(query, con);
            cmd.ExecuteNonQuery();

            query = "SELECT poin from customer where id_customer='" + tbId.Text + "'";
            cmd = new OracleCommand(query, con);
            lbPoin.Content = cmd.ExecuteScalar().ToString();
            con.Close();
        }

        private void btnTukar_Click(object sender, RoutedEventArgs e)
        {
            string skrng = DateTime.Now.ToString("yyyy-MM-dd");
            string tgl = "TO_DATE('" + skrng + "','YYYY-MM-DD')";
            con = new OracleConnection(database);
            con.Open();
            using (OracleTransaction trans = con.BeginTransaction())
            {
                try
                {
                    string query = $"INSERT INTO tukarpoin_hdr VALUES('{id}','{tbId.Text}',{tgl})";
                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        query = $"INSERT INTO tukarpoin_body VALUES('{dt.Rows[i][0].ToString()}','{dt.Rows[i][1].ToString()}')";
                        cmd = new OracleCommand(query, con);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    con.Close();
                    MessageBox.Show("Penukaran Berhasil");
                    UpdateBarang();
                    updatePoin();
                    dt.Rows.Clear();
                    Reset();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    con.Close();
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show("Transaksi Gagal");
                }
            }
        }

        int idx;
        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {
            dt.Rows.RemoveAt(idx);
            btnHapus.IsEnabled = false;
            Poin();
        }

        private void dgList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            idx = dgList.Items.IndexOf(dgList.CurrentItem);
            btnHapus.IsEnabled = true;
        }
    }
}
