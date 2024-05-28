/*using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Interfaz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Mostrar ventana secundaria
            Window1 window1 = new Window1();
            window1.Show();

            // Iniciar servidor de sockets de manera asíncrona
            await Task.Run(() => StartSocketServer());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void StartSocketServer()
        {
            // Configuración del punto de conexión
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");  // 127.0.0.1 => localhost
            int port = 8000;  // Puerto de conexión

            // Crea el Socket del Servidor
            using (Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                serverSocket.Bind(new IPEndPoint(ipAddress, port));

                // Poner el servidor en modo escucha
                serverSocket.Listen(10);

                Dispatcher.Invoke(() => MessageBox.Show("Servidor iniciado. Esperando conexiones..."));

                while (true)
                {
                    // Aceptar la conexión entrante
                    using (Socket clientSocket = serverSocket.Accept())
                    {
                        Dispatcher.Invoke(() => MessageBox.Show("Cliente conectado: " + clientSocket.RemoteEndPoint));

                        // Recibir mensaje del cliente
                        byte[] buffer = new byte[1024];
                        int receivedBytes = clientSocket.Receive(buffer);
                        string message = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
                        Dispatcher.Invoke(() => MessageBox.Show("Mensaje recibido: " + message));

                        // Enviar mensaje al cliente
                        string response = "Mensaje recibido correctamente!!!";
                        buffer = Encoding.UTF8.GetBytes(response);
                        clientSocket.Send(buffer);

                        // Cerrar la conexión con el cliente
                        clientSocket.Shutdown(SocketShutdown.Both);
                    }
                }
            }
        }
    }
}*/
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Interfaz
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Mostrar ventana secundaria
            Window1 window1 = new Window1();
            window1.Show();

            // Iniciar servidor de sockets de manera asíncrona
            await Task.Run(() => StartSocketServer(window1));
        }

        private void StartSocketServer(Window1 window1)
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8000;

            using (Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                serverSocket.Bind(new IPEndPoint(ipAddress, port));
                serverSocket.Listen(10);

                // Mostrar mensaje en la ventana secundaria
                window1.Dispatcher.Invoke(() => window1.AddMessage("Servidor iniciado. Esperando conexiones..."));

                while (true)
                {
                    using (Socket clientSocket = serverSocket.Accept())
                    {
                        window1.Dispatcher.Invoke(() => window1.AddMessage("Cliente conectado: " + clientSocket.RemoteEndPoint));

                        byte[] buffer = new byte[1024];
                        int receivedBytes = clientSocket.Receive(buffer);
                        string message = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
                        window1.Dispatcher.Invoke(() => window1.AddMessage("Mensaje recibido: " + message));

                        string response = "Mensaje recibido correctamente!!!";
                        buffer = Encoding.UTF8.GetBytes(response);
                        clientSocket.Send(buffer);

                        clientSocket.Shutdown(SocketShutdown.Both);
                    }
                }
            }
        }
    }
}
