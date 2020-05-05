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
        }
    }
}
