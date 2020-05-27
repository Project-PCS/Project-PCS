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
namespace Project_PCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static OracleConnection con;
        public static string data, user, pass;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            data = tb_datasource.Text;
            user = tb_username.Text;
            pass = tb_pass.Text;

            con = new OracleConnection($"Data Source={data};User Id={user}; Password={pass}");
            try
            {
              
                App.conn = con;
                con.Open();
                con.Close();
                Window1 w = new Window1($"Data Source={data};User Id={user}; Password={pass}");
                w.Show();
                this.Hide();

            }
            catch (Exception)
            {
                MessageBox.Show("Gagal Login");
            }
        }
    }
}
