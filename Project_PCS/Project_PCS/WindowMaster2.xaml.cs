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

namespace Project_PCS
{
    /// <summary>
    /// Interaction logic for WindowMaster2.xaml
    /// </summary>
    public partial class WindowMaster2 : Window
    {
        public WindowMaster2()
        {
            InitializeComponent();
            Master_Kategori kat = new Master_Kategori(this);
            canvas.Children.Add(kat);
        }
    }
}
