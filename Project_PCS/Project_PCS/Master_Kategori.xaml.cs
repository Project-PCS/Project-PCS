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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Oracle.DataAccess.Client;
using System.Data;
namespace Project_PCS
{
    /// <summary>
    /// Interaction logic for Master_Kategori.xaml
    /// </summary>
    public partial class Master_Kategori : UserControl
    {
        OracleConnection con;
        DataSet ds;
        string id_kategori;
        Window w1;
        public Master_Kategori(Window w1)
        {
            InitializeComponent();
            this.w1 = w1;
            con = App.conn;
            loadKategori("");
        }
        private void loadKategori(string param)
        {
            if (param == "")
            {
                using (OracleDataAdapter adap = new OracleDataAdapter($"SELECT * from kategori order by 1 asc", con))
                {
                    ds = new DataSet();
                    adap.Fill(ds);
                    viewer.ItemsSource = ds.Tables[0].DefaultView;
                }
            }
            else
            {
                param = param.ToLower();
                using (OracleDataAdapter adap = new OracleDataAdapter($"SELECT * from kategori where lower(nama_kategori) like'%{param}%' order by 1 desc", con))
                {
                    ds = new DataSet();
                    adap.Fill(ds);
                    viewer.ItemsSource = ds.Tables[0].DefaultView;
                }
            }
            
        }
        private string autogen()
        {
            string query_autogen = $"SELECT 'KAT'|| lpad(max(substr(id_kategori,-2,2))+1,2,0) from kategori";
            OracleCommand cmd = new OracleCommand(query_autogen, con);
            string idKategori = cmd.ExecuteScalar().ToString();
            return idKategori;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            try
            {
                string id_kategori = autogen();
                MessageBox.Show(id_kategori);
                string nama = tbnama.Text;
                string status = (Convert.ToInt32((bool)cbxStatus.IsChecked)).ToString();
                string insert = $"INSERT into kategori values('{id_kategori}','{nama}','{status}')";
                OracleCommand cmd = new OracleCommand(insert, con);
                cmd.ExecuteNonQuery();
                con.Close();
                loadKategori("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                con.Close();
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            try
            {
                string nama = tbnama.Text;
                string status = (Convert.ToInt32((bool)cbxStatus.IsChecked)).ToString();
                string update = $"UPDATE kategori set nama_kategori='{nama}',status='{status}' where id_kategori='{id_kategori}'";
                OracleCommand cmd = new OracleCommand(update, con);
                cmd.ExecuteNonQuery();
                con.Close();
                loadKategori("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                con.Close();
            }
        }

        private void Viewer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewer.SelectedIndex!=-1)
            {
                id_kategori = ds.Tables[0].Rows[viewer.SelectedIndex]["id_kategori"].ToString();
                tbnama.Text = ds.Tables[0].Rows[viewer.SelectedIndex]["nama_kategori"].ToString();
                cbxStatus.IsChecked = Convert.ToBoolean(Convert.ToInt32(ds.Tables[0].Rows[viewer.SelectedIndex]["status"].ToString()));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            admin a = new admin();
            a.Show();
            w1.Hide();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            loadKategori(tbSearch.Text);
        }
    }
}
