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

namespace Project_PCS
{
    /// <summary>
    /// Interaction logic for TransaksiPembelian.xaml
    /// </summary>
    public partial class TransaksiPembelian : Window
    {
        OracleConnection con;
        string database;
        private OracleDataAdapter da;
        DataSet db = new DataSet();
        DataTable dt = new DataTable();

        private class Supplier
        {
            public string Kode { get; set; }
            public string Nama { get; set; }
        }

        public TransaksiPembelian(string ds)
        {
            InitializeComponent();
            this.database = ds;
            dt.Columns.Add("Id Nota", typeof(string));
            dt.Columns.Add("Id Barang", typeof(string));
            dt.Columns.Add("Banyak", typeof(Int64));
            dt.Columns.Add("Harga Beli", typeof(Int64));

            dgKeranjang.ItemsSource = dt.DefaultView;
            Reset();
            LoadNomor();
        }

        private void LoadSup()
        {
            con = new OracleConnection(database);
            con.Open();
            using (OracleCommand cmd = new OracleCommand("select * from supplier", con))
            {
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    List<Supplier> suplist = new List<Supplier>();
                    while (reader.Read())
                    {
                        suplist.Add(new Supplier()
                        {
                            Kode = reader.GetString(0),
                            Nama = reader.GetString(1)
                        });
                    }
                    cbSupplier.ItemsSource = suplist;
                    cbSupplier.DisplayMemberPath = "Nama";
                    cbSupplier.SelectedValuePath = "Kode";
                }
            }
            con.Close();
        }

        public void Reset()
        {
            string query = "SELECT NAMA_SUPPLIER FROM SUPPLIER";
            OracleCommand cmd = new OracleCommand(query, con);
            cbSupplier.SelectedIndex = -1;
            lblTgl.Content = "-";
            tbNomor.Text = "";
            LoadSup();
            LoadNomor();
            LoadDataSet();
            btnBeli.IsEnabled = false;
        }

        private void UpdateBarang()
        {
            con = new OracleConnection(database);
            con.Open();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int tempjum = 0;
                string query = "SELECT jum_barang from barang where id_barang ='" + dt.Rows[i][1].ToString() + "'";
                OracleCommand cmd = new OracleCommand(query, con);
                tempjum = Convert.ToInt32(cmd.ExecuteScalar());
                tempjum = tempjum + Convert.ToInt32(dt.Rows[i][2].ToString());

                query = "update barang set jum_barang = " + tempjum + "where id_barang ='" + dt.Rows[i][1].ToString() + "'";
                cmd = new OracleCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        private void btnBeli_Click(object sender, RoutedEventArgs e)
        {
            UpdateBarang();
            //MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd"));
            string tgl = "TO_DATE('" + lblTgl.Content + "','YYYY-MM-DD')";
            //MessageBox.Show(tgl);
            con = new OracleConnection(database);
            con.Open();
            using (OracleTransaction trans = con.BeginTransaction())
            {
                try
                {
                    string query = $"INSERT INTO notasupplier_hdr VALUES('{tbNomor.Text}','{cbSupplier.SelectedValue.ToString()}','{""}',{tgl},'{0}')";
                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        query = $"INSERT INTO notasupplier_body values('{dt.Rows[i][0].ToString()}','{dt.Rows[i][1].ToString()}',{Convert.ToInt32(dt.Rows[i][2].ToString())},{Convert.ToInt64(dt.Rows[i][3].ToString())})";
                        cmd = new OracleCommand(query, con);
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    con.Close();
                    MessageBox.Show("Transaksi Berhasil");
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

        private void LoadDataSet()
        {
            if(cbSupplier.SelectedIndex!=-1)
            {
                con = new OracleConnection(database);
                con.Open();
                string query = "SELECT * FROM BARANG WHERE ID_SUPPLIER='" + cbSupplier.SelectedValue.ToString() + "'";
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.ExecuteReader();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                db = new DataSet();
                adapter.Fill(db);
                dgDaftar.ItemsSource = db.Tables[0].DefaultView;
                con.Close();
            }
        }

        private void cbSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadDataSet();
            DateTime batas = DateTime.Now.AddDays(31);
            lblTgl.Content = batas.ToString("yyyy-MM-dd");
        }

        string id = "";
        private void LoadNomor()
        {
            con = new OracleConnection(database);
            con.Open();
            string query = "SELECT COUNT(NO_NOTA) FROM NOTASUPPLIER_HDR";
            OracleCommand cmd = new OracleCommand(query, con);
            int jumsup = Convert.ToInt32(cmd.ExecuteScalar());
            jumsup = jumsup + 1;
            id = "JSUP";
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
            tbNomor.Text = id;
            con.Close();
        }

        private void dgDaftar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dgDaftar.SelectedIndex!=-1)
            {
                DataRow dr = db.Tables[0].Rows[dgDaftar.SelectedIndex];
                tbIdBarang.Text = dr["id_barang"].ToString();
            }
        }

        private void tbbJum_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(tbbJum.Text!="")
            {
                btnTambah.IsEnabled = true;
            }
        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int jum = Convert.ToInt32(tbbJum.Text);
                con = new OracleConnection(database);
                con.Open();
                string query = "SELECT HARGA_BELI FROM BARANG WHERE ID_BARANG='" + tbIdBarang.Text + "'";
                OracleCommand cmd = new OracleCommand(query,con);
                int harga = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                DataRow dr = dt.NewRow();
                dr[0] = tbNomor.Text;
                dr[1] = tbIdBarang.Text;
                dr[2] = jum;
                dr[3] = harga;
                dt.Rows.Add(dr);

                tbIdBarang.Text = "";
                tbbJum.Text = "";
                btnTambah.IsEnabled = false;
                btnBeli.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Jumlah hanya dapat diisi dengan angka");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PegawaiHome ph = new PegawaiHome(database);
            this.Close();
            ph.Show();
        }

        int idx;
        private void dgKeranjang_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            idx = dgKeranjang.Items.IndexOf(dgKeranjang.CurrentItem);
            btnHapus.IsEnabled = true;
        }

        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {
            dt.Rows.RemoveAt(idx);
            btnHapus.IsEnabled = false;
        }
    }
}
