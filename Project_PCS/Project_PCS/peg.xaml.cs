using Oracle.DataAccess.Client;
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
    /// Interaction logic for peg.xaml
    /// </summary>
    public partial class peg : Window
    {
        OracleConnection con;
        DataSet db = new DataSet();

        public peg()
        {
            InitializeComponent();
            con = MainWindow.con;
            show();
            tblPeg.IsReadOnly = true;
            tblPeg.CanUserAddRows = false;
            tbID.IsReadOnly = true;
        }
        public void show()
        {
            try
            {
                buka();
                string query = "SELECT * from pegawai";
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.ExecuteReader();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                db = new DataSet();
                adapter.Fill(db);
                tblPeg.ItemsSource = db.Tables[0].DefaultView;

                
            }
            catch (Exception ex)
            {
                
                //Console.WriteLine(ex.StackTrace);
                //MessageBox.Show("EROR");
                MessageBox.Show("Gagal karena " + ex.Message);
            }

            tbID.Text = "";
            tbNama1.Text = "";
            tbAlamat.Text = "";
            tbnotelp.Text = "";
        }

        private void tblpeg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //btnup.IsEnabled = true;
            if (tblPeg.SelectedIndex != -1)
            {
                DataRow dr = db.Tables[0].Rows[tblPeg.SelectedIndex];
                tbID.Text = dr["ID_PEGAWAI"].ToString();
                tbNama1.Text = dr["NAMA_PEGAWAI"].ToString();
                string jk = dr["JK"].ToString();
                if (jk == "W")
                {
                    Wanita.IsChecked = true;
                }
                else
                {
                    Pria.IsChecked = true;
                }
                tbAlamat.Text = dr["ALAMAT"].ToString();
                tbnotelp.Text = dr["NO_TELP"].ToString();
                if (dr["STATUS"].ToString()=="1")
                {
                    cbaktif.IsChecked = true;
                }
                else
                {
                    cbaktif.IsChecked = false;
                }
                string shift = dr["SHIFT"].ToString();
                if (shift == "Pagi")
                {
                    rbPagi.IsChecked = true;
                }
                else if (shift == "Siang")
                {
                    rbSiang.IsChecked = true;
                }
                else if (shift == "Malam")
                {
                    rbMalam.IsChecked = true;
                }
            }
        }
        public void buka()
        {
            if (con.State == System.Data.ConnectionState.Closed) con.Open();

        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
          
            buka();
            string id = tbID.Text;
            string nama = tbNama1.Text;
            string shift = ""; int stat = 0;
            string alamat = tbAlamat.Text;
            string notelp = tbnotelp.Text;
            string jk = "";
            if (Pria.IsChecked == true)
            {
                jk = "P";
            }
            if (Wanita.IsChecked == true)
            {
                jk = "W";
            }
            if (cbaktif.IsChecked == true)
            {
                stat = 1;
            }
            if (rbPagi.IsChecked == true)
            {
                shift = "Pagi";
            }
            else if (rbSiang.IsChecked == true)
            {
                shift = "Siang";
            }
            else if (rbMalam.IsChecked == true)
            {
                shift = "Malam";
            }
            //autogen();
            try
            {
                MessageBoxResult result = MessageBox.Show("Nama: " + nama + "\n" + "JK: " + jk + "\n" + "No telp : " + notelp + "\n" + "Alamat: " + alamat  +"\n" + "Shift: " + shift+  "\n" + "Status: " + stat + "\n" + "Apakah data sudah benar?", "Konfirmasi", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    string q = $"insert into pegawai (ID_PEGAWAI,NAMA_PEGAWAI,JK,NO_TELP,ALAMAT,SHIFT,STATUS" +
                                    $") values" +
                                $"('{id_peg}','{nama}','{jk}','{notelp}','{alamat}','{shift}',{stat})";
                    OracleCommand cmd = new OracleCommand(q, con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.StackTrace);
                //MessageBox.Show("EROR");
                MessageBox.Show("Gagal karena " + ex.Message);

            }
            
            show();


        }

        string id_peg;
  

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buka();
                string id = tbID.Text;
                string nama = tbNama1.Text;
                string shift = ""; int stat = 0;
                string alamat = tbAlamat.Text;
                string notelp = tbnotelp.Text;
                string jk = "";
                if (Pria.IsChecked == true)
                {
                    jk = "P";
                }
                if (Wanita.IsChecked == true)
                {
                    jk = "W";
                }
                if (cbaktif.IsChecked == true)
                {
                    stat = 1;
                }
                if (rbPagi.IsChecked == true)
                {
                    shift = "Pagi";
                }
                else if (rbSiang.IsChecked == true)
                {
                    shift = "Siang";
                }
                else if (rbMalam.IsChecked == true)
                {
                    shift = "Malam";
                }
                string update = $"UPDATE PEGAWAI SET NAMA_PEGAWAI = '{nama}'" +
                $", SHIFT ='{shift}', JK ='{jk}', ALAMAT ='{alamat}', no_telp ='{notelp}', status ={stat} where ID_PEGAWAI = '{id}'";

                OracleCommand cmd = new OracleCommand(update, con);
                cmd.ExecuteNonQuery();
                
                show();
                MessageBox.Show("Berhasil Update");
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            //show();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            admin a = new admin();
            a.Show();
        }
    }
}
