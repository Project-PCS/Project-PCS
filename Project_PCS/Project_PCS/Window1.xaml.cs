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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        OracleConnection conn;
        string database;
        public Window1(string ds)
        {
            InitializeComponent();
            conn = MainWindow.con;
            this.database = ds;
        }
        public Window1()
        {
            InitializeComponent();
            conn = MainWindow.con;
        }

        private void admin_Click(object sender, RoutedEventArgs e)
        {
        }

        private void pegawai_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (peg.IsChecked==true)
            {
                PegawaiHome pg = new PegawaiHome(database);
                pg.Show();
                this.Close();
            }
            else if (adm.IsChecked == true)
            {
                if(tb_username.Text=="admin" && tb_pass.Password == "nimda")
                {

                    admin a = new admin();
                    a.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password salah");
                }
            }
            else
            {
                MessageBox.Show("Pilih login sebagai apa");
            }
        }
    }
}
