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
        OracleConnection con;
        string database;
        public Window1(string ds)
        {
            InitializeComponent();
            this.database = ds;
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            con = new OracleConnection(database);
            con.Open();
            AdminHome w = new AdminHome(database);
            w.Show();
            this.Hide();
            
        }

        private void btnPegawai_Click(object sender, RoutedEventArgs e)
        {
            con = new OracleConnection(database);
            con.Open();
            PegawaiHome w = new PegawaiHome(database);
            w.Show();
            this.Hide();
        }
    }
}
