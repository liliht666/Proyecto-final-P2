using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AzharaP2C
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string rutaArchivoLogin = "D:\\signup\\registroUsers.txt";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtCorreo.Clear();
            pwdContraseña.Clear();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            string correo = txtCorreo.Text;
            string contra = pwdContraseña.Password;
            if (correo == "" || contra == "")
            {
                lblMensaje.Foreground = Brushes.Red;
                lblMensaje.Content = "¡Debe llenar TODOS los campos!";
            }
            else
            {
                try
                {
                    if (!File.Exists(rutaArchivoLogin))
                    {
                        lblMensaje.Foreground = Brushes.Red;
                        lblMensaje.Content = "La ruta o el archivo no existen";
                        return;
                    }
                    else
                    {
                        var contenidoArch = File.ReadAllLines(rutaArchivoLogin);
                        foreach (var linea in contenidoArch)
                        {
                            var partes = linea.Split(',');

                            //if para encontrar administrador
                            if (correo.Equals(partes[0]) && contra.Equals(partes[1]))
                            {
                                WpfDataBinding winAd = new WpfDataBinding();
                                winAd.Show();
                                this.Close();
                            }
                            else
                            {
                                lblMensaje.Foreground = Brushes.Red;
                                lblMensaje.Content = "Usuario no registrado... Posble impostor!";
                            }
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                //string datos = txtCorreo.Text + "\n" + pwdContraseña.Password + "\n";
                //lblMensaje.Foreground = Brushes.Black;
                //lblMensaje.Content = datos;
            }
        }

        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {
            WinSignUp signUp = new WinSignUp();
            signUp.Show();
            this.Close();
        }
    }
}
