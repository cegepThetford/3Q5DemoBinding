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

namespace Demo6
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeHoraire _employe;
        public MainWindow()
        {
            InitializeComponent();
            _employe = new EmployeHoraire("Adam Bernard", 10.00m);
            grille.DataContext = _employe;
        }
        public EmployeHoraire Employe
        {
            get { return _employe; }
            set
            {
                _employe = value;
            }
        }
        private void AjouterHeures(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string chaine = b.Content.ToString().Split()[1];
            int nbHeures = int.Parse(chaine);
            _employe.ajouterHeures(nbHeures);
        }
        private void btnRafraichir_Click(object sender, RoutedEventArgs e)
        {
            // Version 1
            tbNom.Text = _employe.Nom;
            tbTauxHoraire.Text = _employe.TauxHoraire.ToString();
            tbNbHeures.Text = _employe.NbHeures.ToString();
        }
    }
}
