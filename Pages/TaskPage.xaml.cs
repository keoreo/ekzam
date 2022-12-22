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
    /// Логика взаимодействия для TaskPage.xaml
    /// </summary>
    public partial class TaskPage : Page
    {
        public TaskPage()
        {
            InitializeComponent();
            var currentTask = ConnectOdb.conObj.Task.ToList();
            DGrid.ItemsSource = currentTask;
        }

      

        private void Add_click(object sender, RoutedEventArgs e)
        {
            Manager.MyFrame.Navigate(new AddPage(null));
        }
        private void Delete_click(object sender, RoutedEventArgs e)
        {
            var TaskForRemoving = DGrid.SelectedItems.Cast<AppData.Task>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следущие {TaskForRemoving.Count()} элементов?", "Внимание",
               MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Ekzam_gusEntities.GetContext().Task.RemoveRange(TaskForRemoving);
                    Ekzam_gusEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGrid.ItemsSource = Ekzam_gusEntities.GetContext().Task.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void Edit_click(object sender, RoutedEventArgs e)
        {
            Manager.MyFrame.Navigate(new AddPage((sender as Button).DataContext as AppData.Task));
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Ekzam_gusEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid.ItemsSource = Ekzam_gusEntities.GetContext().Task.ToList();
            }
        }
    }
}
