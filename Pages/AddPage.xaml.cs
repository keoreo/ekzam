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

namespace ekzam.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        private AppData.Task _currentTask = new AppData.Task();
        public AddPage(AppData.Task selectedorder)
        {
            InitializeComponent();
            if (selectedorder != null)
                _currentTask = selectedorder;
            DataContext = _currentTask;
            ConnectOdb.conObj = new Ekzam_gusEntities();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
