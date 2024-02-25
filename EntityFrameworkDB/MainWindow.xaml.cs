using EntityFrameworkDB.DAO;
using EntityFrameworkDB.MODEL;
using System;
using System.Collections;
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

namespace EntityFrameworkDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MODEL.PELISContext m_db = new MODEL.PELISContext();
        private IDAO manager;
        public MainWindow()
        {
            
            InitializeComponent();
            DAOFactory factory = new DAOFactory();
            manager = factory.GetDAO(m_db);
            lvFilms.ItemsSource = manager.GetFilms();
            lvFilms.SelectedIndex = 0;
            
            lvActors.ItemsSource = manager.GetActors("*");
            cbActors.ItemsSource = manager.GetActors("*");
            cbLetter.ItemsSource = GenerateLetters();
            cbLetter.SelectedIndex = 0;
        }

        private List<Char> GenerateLetters()
        {
            List<Char> letters = new List<Char>();
            letters.Add('*');
            for (char c = 'A'; c <= 'Z'; c++)
            {
                letters.Add(c);
            }
            return letters;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            manager.SaveActor(txtFirstName, txtLastName);
        }


        private void btnFilterActors_Click(object sender, RoutedEventArgs e)
        {
            lvActors.ItemsSource = manager.GetActors(cbLetter.Text.ToString());
        }

        private void btnFilterFilms_Click(object sender, RoutedEventArgs e)
        {
            string actorId = cbActors.Text.Split(" ")[0];
            lvFilms.ItemsSource = manager.GetFilms(Convert.ToInt32(actorId));
        }

        private void btnAll_Click(object sender, RoutedEventArgs e)
        {
            lvFilms.ItemsSource = manager.GetFilms();
            lvActors.ItemsSource = manager.GetActors("*");
            cbActors.ItemsSource = manager.GetActors("*");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                Actor actor = btn.DataContext as Actor;
                if (actor != null)
                {
                    WNDUpdate WNDUpdate = new WNDUpdate(manager, actor);
                    WNDUpdate.ShowDialog();
                    lvActors.ItemsSource = manager.GetActors("*");
                    cbActors.ItemsSource = manager.GetActors("*");
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if(btn != null)
            {
                Actor actor = btn.DataContext as Actor;
                if(actor != null)
                {
                    if (MessageBox.Show("You will delete all the relations of this actor with its films, are you sure?", "Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        manager.DeleteActorMovies(actor.ActorId);
                        manager.DeleteActor(actor);
                        lvActors.ItemsSource = manager.GetActors("*");
                        cbActors.ItemsSource = manager.GetActors("*");
                    }
                }
            }
        }
    }
}
