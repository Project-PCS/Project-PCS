﻿using System;
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

namespace Project_PCS
{
    /// <summary>
    /// Interaction logic for admin.xaml
    /// </summary>
    public partial class admin : Window
    {
        public admin()
        {
            InitializeComponent();
            cbPilihan.Items.Add("Master Barang");
            cbPilihan.Items.Add("Master Kategori");
            cbPilihan.Items.Add("Master Supplier");
            cbPilihan.Items.Add("Master Promo");
            cbPilihan.Items.Add("Master Customer");
            cbPilihan.Items.Add("Master Karyawan");
            cbPilihan.Items.Add("Master Barang Menarik");
            cbPilihan.Items.Add("Laporan");
            cbPilihan.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(cbPilihan.SelectedItem == "Master Promo")
            {
                promo p = new promo();
                p.Show();
                this.Close();
            }
            else if(cbPilihan.SelectedItem == "Master Customer")
            {
                cust c = new cust();
                c.Show();
                this.Close();
            }
            else if(cbPilihan.SelectedItem == "Master Karyawan")
            {
                peg p = new peg();
                p.Show();
                this.Close();
            }
            else if (cbPilihan.SelectedItem == "Master Kategori")
            {
                WindowMaster2 mkat = new WindowMaster2();
                mkat.Show();
                this.Close();
            }
            else if (cbPilihan.SelectedItem == "Master Supplier")
            {
                Windowmaster msup = new Windowmaster();
                msup.Show();
                this.Close();
            }
            else if (cbPilihan.SelectedItem == "Master Barang")
            {
                MasterBarang mbar = new MasterBarang(this);
                mbar.Show();
                this.Close();
            }
            else if (cbPilihan.SelectedValue.ToString() == "Master Barang Menarik")
            {
                MasterBrgMenarik mbm = new MasterBrgMenarik();
                mbm.Show();
                this.Close();
            }
            else if (cbPilihan.SelectedValue.ToString() == "Laporan")
            {
                MasterReport mreport = new MasterReport();
                mreport.Show();
                this.Close();
            }

        }

        private void mainmenu_Click(object sender, RoutedEventArgs e)
        {
            Window1 mw = new Window1();
            mw.Show();
            this.Close();
        }
    }
}
