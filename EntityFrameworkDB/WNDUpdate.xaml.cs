using EntityFrameworkDB.DAO;
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

namespace EntityFrameworkDB
{
    /// <summary>
    /// Lógica de interacción para WNDUpdate.xaml
    /// </summary>
    public partial class WNDUpdate : Window
    {
        IDAO manager;
        MODEL.Actor actor;
        public WNDUpdate(IDAO manager, MODEL.Actor actor)
        {
            InitializeComponent();
            this.manager = manager;
            this.actor = actor;
            tbFirstName.Text = actor.FirstName;
            tbLastName.Text = actor.LastName;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            actor.FirstName = tbFirstName.Text;
            actor.LastName = tbLastName.Text;
            actor.LastUpdate = DateTime.Now;
            manager.UpdateActor(actor);
            this.Close();
        }
    }
}
