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
    /// Interaction logic for Master_Supplier.xaml
    /// </summary>
    public partial class Master_Supplier : UserControl
    {
        //class supplier
        //{
        //    public string kode { get; set; }
        //    public string nama { get; set; }

        //    public supplier(string kode, string nama)
        //    {
        //        this.kode = kode;
        //        this.nama = nama;
        //    }
        //}
        //List<supplier> listsup = new List<supplier>();
        OracleConnection con;
        DataSet ds;
        string id_supplier;
        Window w1;
        public Master_Supplier(Window w1)
        {
            InitializeComponent();
            this.w1 = w1;
            //listsup.Add(new supplier("Supplier_Kongsinyiasi","Supplier Kongsinyiasi"));
            //listsup.Add(new supplier("Supplier","Supplier"));

            //cbSupplier.ItemsSource = listsup;
            //cbSupplier.DisplayMemberPath = "nama";
            //cbSupplier.SelectedValuePath = "kode";

            con = App.conn;
            loadSupplier();
            
        }
        private void loadSupplier()
        {
            using (OracleDataAdapter adap = new OracleDataAdapter($"SELECT * from supplier order by 1 asc", con))
            {
                ds = new DataSet();
                adap.Fill(ds);
                viewer.ItemsSource = ds.Tables[0].DefaultView;
            }
        }
       
        private string autogen()
        {
            string query = $"SELECT 'SUP'|| lpad(max(substr(id_supplier,-3,3))+1,3,0) from supplier";
            OracleCommand cmd = new OracleCommand(query, con);
            string id = cmd.ExecuteScalar().ToString();
            return id;
        }

        private void Insert()
        {
            con.Open();
            string id = autogen();
            string nama = tbnama.Text;
            string alamat = tbalamat.Text;
            long no = Convert.ToInt64(tb_notelepon.Text);
            string status= (Convert.ToInt32(cbxStatus.IsChecked)).ToString();
            string query = $"INSERT into supplier values('{id}','{nama}','{alamat}',{no},'{status}')";
            OracleCommand cmd = new OracleCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                long no = Convert.ToInt64(tb_notelepon.Text);
                if (no.ToString().Length != 13)
                {
                    MessageBox.Show("No Hp harus 13 digit");
                }
                else
                {
                    try
                    {
                        Insert();
                        loadSupplier();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Insert Gagal");
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Hp harus angka");
            }
        }
        private void Update()
        {
            con.Open();
            string nama = tbnama.Text;
            string alamat = tbalamat.Text;
            long no = Convert.ToInt64(tb_notelepon.Text);
            string status = (Convert.ToInt32(cbxStatus.IsChecked)).ToString();
            string query = $"UPDATE supplier set nama_supplier='{nama}',alamat_supplier='{alamat}',nomor_telp={no},status='{status}' where id_supplier='{id_supplier}'";
            MessageBox.Show(query);
            OracleCommand cmd = new OracleCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                long no = Convert.ToInt64(tb_notelepon.Text);
                if (no.ToString().Length != 13)
                {
                    MessageBox.Show("No Hp harus 13 digit");
                }
                else
                {
                    try
                    {
                        Update();
                        loadSupplier();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Update Gagal");
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Hp harus angka");
            }
        }

        private void Viewer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewer.SelectedIndex!=-1)
            {
                id_supplier = ds.Tables[0].Rows[viewer.SelectedIndex]["id_supplier"].ToString();
                tbnama.Text = ds.Tables[0].Rows[viewer.SelectedIndex]["nama_supplier"].ToString();
                tbalamat.Text = ds.Tables[0].Rows[viewer.SelectedIndex]["alamat_supplier"].ToString();
                tb_notelepon.Text = ds.Tables[0].Rows[viewer.SelectedIndex]["nomor_telp"].ToString();
                cbxStatus.IsChecked = Convert.ToBoolean(Convert.ToInt32(ds.Tables[0].Rows[viewer.SelectedIndex]["status"].ToString()));
            }
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            admin a = new admin();
            a.Show();
            w1.Hide();
        }
    }
}
