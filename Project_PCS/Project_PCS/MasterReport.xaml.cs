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
using System.Text.RegularExpressions;
using Oracle.DataAccess.Client;

namespace Project_PCS
{
    /// <summary>
    /// Interaction logic for MasterReport.xaml
    /// </summary>
    public partial class MasterReport : Window
    {
        List<string> listjenis = new List<string>();
        List<string> listbulan = new List<string>();
        long tahun; int bulan;
        public string strParam;

        public MasterReport()
        {
            InitializeComponent();

            listjenis.Add("Penjualan Barang");
            listjenis.Add("Pembelian Barang");
            listjenis.Add("Penukaran Poin");
            cbJenis.ItemsSource = listjenis;

            listbulan.Add("Januari");
            listbulan.Add("Februari");
            listbulan.Add("Maret");
            listbulan.Add("April");
            listbulan.Add("Mei");
            listbulan.Add("Juni");
            listbulan.Add("Juli");
            listbulan.Add("Agustus");
            listbulan.Add("September");
            listbulan.Add("Oktober");
            listbulan.Add("November");
            listbulan.Add("Desember");
            cbBulan.ItemsSource = listbulan;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            bulan = cbBulan.SelectedIndex + 1;
            if (bulan < 10)
            {
                strParam = "0" + bulan.ToString();
            }
            else
            {
                strParam = bulan.ToString();
            }

            try
            {
                tahun = Convert.ToInt64(tbTahun.Text);
                strParam += "-" + tahun;

                if (cbJenis.SelectedIndex == 0)
                {
                    ReportJual rjual = new ReportJual();
                    rjual.SetDatabaseLogon(MainWindow.user, MainWindow.pass, MainWindow.data, "");
                    rjual.SetParameterValue("bulan", cbBulan.SelectedValue.ToString().ToUpper());
                    rjual.SetParameterValue("tahun", tahun);
                    rjual.SetParameterValue("BlnTh", strParam);
                    CRViewer.ViewerCore.ReportSource = rjual;
                }
                else if (cbJenis.SelectedIndex == 1)
                {
                    ReportBeli rbeli = new ReportBeli();
                    rbeli.SetDatabaseLogon(MainWindow.user, MainWindow.pass, MainWindow.data, "");
                    rbeli.SetParameterValue("bulan", cbBulan.SelectedValue.ToString().ToUpper());
                    rbeli.SetParameterValue("tahun", tahun);
                    rbeli.SetParameterValue("BlnTh", strParam);
                    CRViewer.ViewerCore.ReportSource = rbeli;
                }
                else if (cbJenis.SelectedIndex == 2)
                {
                    ReportTukar rtukar = new ReportTukar();
                    rtukar.SetDatabaseLogon(MainWindow.user, MainWindow.pass, MainWindow.data, "");
                    rtukar.SetParameterValue("bulan", cbBulan.SelectedValue.ToString().ToUpper());
                    rtukar.SetParameterValue("tahun", tahun);
                    rtukar.SetParameterValue("BlnTh", strParam);
                    CRViewer.ViewerCore.ReportSource = rtukar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input Tahun Tidak Valid!");
            }
            cbBulan.SelectedIndex = -1;
            tbTahun.Text = "";
        }

        private void TbTahun_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex("[^0-9]");
            e.Handled = reg.IsMatch(e.Text);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            admin a = new admin();
            a.Show();
            this.Close();
        }
    }
}
