﻿using Oracle.DataAccess.Client;
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

namespace Project_PCS
{
    /// <summary>
    /// Interaction logic for cust.xaml
    /// </summary>
    public partial class cust : Window
    {
        OracleConnection con;
        DataSet db = new DataSet();
        public cust()
        {
            InitializeComponent();
            con = MainWindow.con;
            show();
            tblCust.IsReadOnly = true;
            tblCust.CanUserAddRows = false;
        }
        public void show()
        {
            try
            {
                buka();
                string query = "SELECT ID_CUSTOMER as \"ID\", NAMA_CUSTOMER as \"NAMA\",JK as \"JENIS KELAMIN\"," +
                            $"ALAMAT_CUSTOMER as \"ALAMAT\",NO_TELP as \"NO TELP\",POIN as \"POIN\",STATUS as \"STATUS\" from customer";
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.ExecuteReader();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                db = new DataSet();
                adapter.Fill(db);
                tblCust.ItemsSource = db.Tables[0].DefaultView;
                
            }
            catch (Exception ex)
            {
                
                //Console.WriteLine(ex.StackTrace);
                //MessageBox.Show("EROR");
                MessageBox.Show("Gagal karena " + ex.Message);
            }
        }

        private void tblCust_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //btnup.IsEnabled = true;
            if (tblCust.SelectedIndex != -1)
            {
                DataRow dr = db.Tables[0].Rows[tblCust.SelectedIndex];
                tbID.Text = dr["ID"].ToString();
                tbNama1.Text = dr["NAMA"].ToString();
                tbAlamat.Text = dr["ALAMAT"].ToString();
                tbPoin.Text = dr["POIN"].ToString();
                tbnotelp.Text = dr["NO TELP"].ToString();
                string stat = dr["STATUS"].ToString();
                if (stat == "0")
                {
                    cbaktif.IsChecked = false;
                }
                else
                {
                    cbaktif.IsChecked = true;
                }

                string jenis = dr["JENIS KELAMIN"].ToString();

                if (jenis == "L")
                {
                    rbL.IsChecked = true;
                }
                else if (jenis == "P")
                {
                    rbP.IsChecked = true;
                }
            }
        }
        public void buka()
        {
            if (con.State == System.Data.ConnectionState.Closed) con.Open();

        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buka();
                string id = tbID.Text;
                string jenis = "";
                if (rbL.IsChecked == true)
                {
                    jenis = "L";
                }
                else if (rbP.IsChecked == true)
                {
                    jenis = "P";
                }
                string nama = tbNama1.Text;
                string alamat = tbAlamat.Text;
                int poin = Convert.ToInt32(tbPoin.Text);
                string stat = "0";
                string notelp = tbnotelp.Text;
                if (cbaktif.IsChecked == true)
                {
                    stat = "1";
                }
                //autogen();
                MessageBoxResult result = MessageBox.Show("Nama: " + nama + "\n" + "JK: " + jenis + "\n" + "Alamat : " + alamat + "\n" + "No telp: " + notelp + "\n" + "Poin: " + poin + "\n" + "Status: " + stat + "\n" + "Apakah data sudah benar?", "Konfirmasi", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    string q = $"insert into customer (ID_CUSTOMER,NAMA_CUSTOMER,JK," +
                            $"ALAMAT_CUSTOMER,NO_TELP,POIN,STATUS) values" +
                        $"('CUS','{nama}','{jenis}','{alamat}','{notelp}',{poin},'{stat}')";
                    OracleCommand cmd = new OracleCommand(q, con);
                    cmd.ExecuteNonQuery();
                }
                
                
                show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        string id_cust;
        //public void autogen()
        //{
        //    //buka();
        //    string query = "SELECT LPAD(NVL(MAX(SUBSTR(id_pegawai, -2, 2)) + 1,1),2,'0') AS \"COUNT\" FROM customer";
        //    OracleCommand cmd = new OracleCommand(query, con);
        //    string ctr = cmd.ExecuteScalar().ToString();
        //    id_cust = "CUS" + ctr;
        //    //
        //}
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buka();
                string id = tbID.Text;
                string jenis = "";
                if (rbL.IsChecked == true)
                {
                    jenis = "L";
                }
                else if (rbP.IsChecked == true)
                {
                    jenis = "P";
                }
                string nama = tbNama1.Text;
                string alamat = tbAlamat.Text;
                int poin = Convert.ToInt32(tbPoin.Text);
                string stat = "0";
                string notelp = tbnotelp.Text;
                if (cbaktif.IsChecked == true)
                {
                    stat = "1";
                }
                string update = $"UPDATE customer SET NAMA_CUSTOMER = '{nama}'" +
                $", ALAMAT_CUSTOMER ='{alamat}' , JK = '{jenis}', POIN = {poin}, STATUS = '{stat}', no_telp ='{notelp}'  where id_customer = '{id}'";

                OracleCommand cmd = new OracleCommand(update, con);
                cmd.ExecuteNonQuery();


                
                MessageBox.Show("Berhasil Update");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message);
            }
            show();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            admin a = new admin();
            a.Show();
        }
    }
}
