using ekzam.AppData;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ekzam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame MainFrame;
        public MainWindow()
        {
            InitializeComponent();
            ConnectOdb.conObj = new Ekzam_gusEntities();
            FrameObj.FrameMain = MyFrame;
        }
        private void Task_click(object sender, RoutedEventArgs e)
        {
           MyFrame.Content = new Pages.TaskPage();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
          MyFrame.Content = new MainWindow();
        }
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;

            }

            else
            {
                btnBack.Visibility = Visibility.Hidden;
            }

        }
    }
}
