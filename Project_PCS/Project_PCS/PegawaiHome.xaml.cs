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
    /// Interaction logic for PegawaiHome.xaml
    /// </summary>
    public partial class PegawaiHome : Window
    {
        string database;
        string pegawai;
        public PegawaiHome(string ds, string user)
        {
            InitializeComponent();
            this.database = ds;
            this.pegawai = user;
        }

        private void btnPembelian_Click(object sender, RoutedEventArgs e)
        {
            TransaksiPembelian tp = new TransaksiPembelian(database, pegawai);
            this.Close();
            tp.Show();
        }

        private void btnPendaftaran_Click(object sender, RoutedEventArgs e)
        {
            PendaftaranMember pm = new PendaftaranMember(database, pegawai);
            this.Close();
            pm.Show();
        }

        private void BtnPenjualan_Click(object sender, RoutedEventArgs e)
        {
            TransaksiJual tj = new TransaksiJual(database, pegawai);
            this.Close();
            tj.Show();
        }

        private void btnPenukaran_Click(object sender, RoutedEventArgs e)
        {
            Penukaran_Poin pp = new Penukaran_Poin(database, pegawai);
            this.Close();
            pp.Show();
        }

        private void mainmenu_Click(object sender, RoutedEventArgs e)
        {
            Window1 mw = new Window1();
            mw.Show();
            this.Close();
        }
    }
}
