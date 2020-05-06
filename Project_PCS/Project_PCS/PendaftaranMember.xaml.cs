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

namespace Project_PCS
{
    /// <summary>
    /// Interaction logic for PendaftaranMember.xaml
    /// </summary>
    public partial class PendaftaranMember : Window
    {
        OracleConnection con;
        string database;
        public PendaftaranMember(string ds)
        {
            InitializeComponent();
            this.database = ds;
        }
        
        private void btnDaftar_Click(object sender, RoutedEventArgs e)
        {
            con = new OracleConnection(database);
            
            string jk = "";
            if (rbLaki.IsChecked==true)
            {
                jk = "L";
            }
            else if (rbPerempuan.IsChecked == true)
            {
                jk = "P";
            }
            MessageBoxResult result = MessageBox.Show("Nama: "+tbNama.Text+"\n"+"Alamat: "+tbAlamat.Text+"\n"+"Jenis Kelamin: "+jk+"\n"+"Apakah data sudah benar?", "Konfirmasi", MessageBoxButton.YesNo);
            if(result==MessageBoxResult.Yes)
            {
                con.Open();
                string query = $"INSERT INTO CUSTOMER VALUES('{tbKode.Text}','{tbNama.Text}','{jk}','{tbAlamat.Text}',{0},'{1}')";
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Customer berhasil didaftarkan");
            }
        }

        private void tbNama_SelectionChanged(object sender, RoutedEventArgs e)
        {
            con = new OracleConnection(database);
            if (tbNama.Text != "")
            {
                con.Open();
                string query = "SELECT COUNT(ID_CUSTOMER) FROM CUSTOMER";
                OracleCommand cmd = new OracleCommand(query, con);
                int jumcust = Convert.ToInt32(cmd.ExecuteScalar());
                jumcust = jumcust + 1;
                string id = "CUS";
                if (jumcust < 10)
                {
                    id = id + "00" + jumcust;
                }
                else if (jumcust < 100)
                {
                    id = id + "0" + jumcust;
                }
                else
                {
                    id = id + jumcust;
                }
                tbKode.Text = id;
                con.Close();
            }
        }
    }
}
