/*using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Interfaz
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private ObservableCollection<string> messages;
        public Window1()
        {
            InitializeComponent();
            messages = new ObservableCollection<string>();
            MessagesListView.ItemsSource = messages;
        }
        //new
        public void AddMessage(string message)
        {
            messages.Add(message);
        }
        //
        private void Enviar_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTexBox.Text;
            if(!string.IsNullOrEmpty(message)) {
                messages.Add(message);
                MessageTexBox.Text = string.Empty;

            }
        }
    }
}*/
using System.Collections.ObjectModel;
using System.Windows;

namespace Interfaz
{
    public partial class Window1 : Window
    {
        public ObservableCollection<string> Messages { get; set; }

        public Window1()
        {
            InitializeComponent();
            Messages = new ObservableCollection<string>();
            MessagesListView.ItemsSource = Messages;
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }

        private void Enviar_Click(object sender, RoutedEventArgs e)
        {
            // Código para enviar mensajes desde Window1 si es necesario
        }
    }
}

