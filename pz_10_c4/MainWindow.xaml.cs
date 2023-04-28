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

namespace pz_10_c4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Notes> notese;
        List<Notes> notDoneNotese;
        List<Notes> doneNotese;
        public MainWindow()
        {
            InitializeComponent();
            notese = new List<Notes>()
            {
            new Notes("Сходить в кафе",Status.Выполнено),
            new Notes("Купить новый телефон",Status.Выполнено),
            new Notes("Выпить с друзьями",Status.Нужно_выполнить)
            };
            Update();
        }

        private void Online_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Online.SelectedItem == null) return;
            var a = notese.FindIndex(u => u == Online.SelectedItem);
            notese[a].status = Status.Выполнено;
            Update();
        }
        public void Update()
        {
            notDoneNotese = notese.Where(u => u.status == Status.Нужно_выполнить).ToList();
            doneNotese = notese.Where(u => u.status == Status.Выполнено).ToList();
            Online.ItemsSource = notDoneNotese;
            Offline.ItemsSource = doneNotese;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (TextNotes.Text == "" || TextNotes.Text == null) return;
            notese.Add(new Notes(TextNotes.Text, Status.Нужно_выполнить));
            Update();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Offline.SelectedItems == null) return;
            foreach (var note in Offline.SelectedItems)
            {
                notese.Remove((Notes)note);
            }
            Update();
        }
    }
}
