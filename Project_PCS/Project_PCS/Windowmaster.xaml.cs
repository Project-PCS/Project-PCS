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
    /// Interaction logic for Windowmaster.xaml
    /// </summary>
    public partial class Windowmaster : Window
    {
        public Windowmaster()
        {
            InitializeComponent();
            Master_Supplier sup = new Master_Supplier(this);
            canvas.Children.Add(sup);
        }
    }
}
