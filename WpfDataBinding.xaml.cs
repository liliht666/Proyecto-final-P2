using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para WpfDataBinding.xaml
    /// </summary>
    public partial class WpfDataBinding : Window
    {
        public ObservableCollection<Producto> ListaProductos { get; set; }
        public Producto productoSel { get; set; }

        public WpfDataBinding()
        {
            InitializeComponent();

            ListaProductos = new ObservableCollection<Producto>
            {
                new Producto("Falda", "300", "L"),
                new Producto("Blusa", "150", "M"),
                new Producto("Medias de Red", "50","S")

            };


            DataContext = this; //explica en que contexto estamos

            lstBProductos.ItemsSource = ListaProductos;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string letterPattern = "^[A-Za-zñ]+$";
            string patronNumeros = @"^\d+$"; string nombre = txtNomProd.Text;
            string precio = txtNomPrecio.Text;
            string talla = cbTalla.Text;

            if (!string.IsNullOrEmpty(precio))
            { 
                if (!Regex.IsMatch(txtNomProd.Text, letterPattern))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato del Nombre es incorrecto";
                    txtNomProd.Clear();
                    txtNomProd.Focus();
                    return;
                }
                if (!Regex.IsMatch(txtNomPrecio.Text, patronNumeros))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato del precio es incorrecto";
                    txtNomPrecio.Clear();
                    txtNomPrecio.Focus();
                    return;
                }
                if (!Regex.IsMatch(txtNomProd.Text, letterPattern))
                {
                    lblMensaje.Foreground = Brushes.Red;
                    lblMensaje.Content = "El formato de la talla es incorrecto";
                    cbTalla.Focus();
                    return;
                }
               else
                {
                    ListaProductos.Add(new Producto(nombre, precio, talla));
                    txtNomPrecio.Clear();
                    txtNomProd.Clear();
                }

               
            }
            else
            {
                MessageBox.Show("Error en el ingreso de datos!!");
            }
        }
        private void lstBProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productoSel != null)
            {
                txtNomProd.Text = productoSel.Nombre;
                txtNomPrecio.Text = productoSel.Precio.ToString();
                cbTalla.Text = productoSel.Talla;
            }

        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            ListaProductos.Remove(productoSel);
            txtNomPrecio.Clear();
            txtNomProd.Clear();

        }


    }
}

