﻿using System;
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
        DataSet dbk = new DataSet();

        private class Supplier
        {
            public string Kode { get; set; }
            public string Nama { get; set; }
        }

        private void LoadSup()
        {
            con = new OracleConnection(database);
            con.Open();
            using(OracleCommand cmd = new OracleCommand("select * from supplier", con))
            {
                using(OracleDataReader reader = cmd.ExecuteReader())
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

        public TransaksiPembelian(string ds)
        {
            InitializeComponent();
            this.database = ds;
            Reset();
            LoadNomor();
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
            btnBeli.IsEnabled = false;
        }

        private void btnBeli_Click(object sender, RoutedEventArgs e)
        {
            string tgl = "TO_DATE('" + lblTgl.Content + "','YYYY-MM-DD')";
            con = new OracleConnection(database);
            con.Open();
            using (OracleTransaction trans = con.BeginTransaction())
            {
                try
                {
                    OracleCommand cmd = new OracleCommand("insert into notasupplier_hdr values(:no_nota, :id_supplier, " +
                        ":tanggal_pembayaran, :batas_pembayaran, :status)",con);
                    cmd.Parameters.Add(":no_nota",tbNomor.Text);
                    cmd.Parameters.Add(":id_supplier", cbSupplier.SelectedValue.ToString());
                    cmd.Parameters.Add(":tanggal_pembayaran", null);
                    cmd.Parameters.Add(":batas_bayar", tgl);
                    cmd.Parameters.Add(":status", 0);
                    cmd.ExecuteNonQuery();

                    da.Update(dbk.Tables[0]);
                    trans.Commit();
                    con.Close();
                    MessageBox.Show("Transaksi Berhasil");
                    Reset();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    con.Close();
                    MessageBox.Show("Transaksi Gagal");
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
            LoadDataSetKeranjang();
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
                DataRow dr = dbk.Tables[0].NewRow();
                dr[0] = id;
                dr[1] = tbIdBarang.Text;
                dr[2] = jum;
                dr[3] = harga;
                dbk.Tables[0].Rows.Add(dr);

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

        private void LoadDataSetKeranjang()
        {
            da = new OracleDataAdapter ("select * from notasupplier_body where 1 = 2", con);
            //membuat syntax insert update delete otomatis
            OracleCommandBuilder builder = new OracleCommandBuilder(da);
            dbk = new DataSet();
            da.Fill(dbk);
            dgKeranjang.ItemsSource = dbk.Tables[0].DefaultView;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PegawaiHome ph = new PegawaiHome(database);
            this.Close();
            ph.Show();
        }
    }
}
