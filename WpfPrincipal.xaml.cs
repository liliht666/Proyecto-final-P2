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

namespace AzharaP2C
{
    /// <summary>
    /// Lógica de interacción para WpfPrincipal.xaml
    /// </summary>
    public partial class WpfPrincipal : Window
    {
        public WpfPrincipal()
        {
            InitializeComponent();
        }

        private void btnProd_Click_1(object sender, RoutedEventArgs e)
        {
            WpfDataBinding winDataBinding = new WpfDataBinding();
            winDataBinding.Show();
            this.Close();
        }
    }
}
