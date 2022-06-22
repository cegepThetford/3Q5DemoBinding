using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo6
{
    public class EmployeHoraire : INotifyPropertyChanged
    {
        private string _nom;
        private decimal _tauxHoraire;
        private decimal _nbHeures;

        public event PropertyChangedEventHandler PropertyChanged;

        public EmployeHoraire(string nom, decimal taux)
        {
            _nom = nom;
            _tauxHoraire = taux;
            _nbHeures = 0.0m;
        }

        public void ajouterHeures(decimal nbH)
        {
            //_nbHeures += nbH;
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs("NbHeures"));
            NbHeures += nbH;
        }

        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                this.notifier("Nom");
            }
        }
        public decimal TauxHoraire
        {
            get { return _tauxHoraire; }
            set
            {
                _tauxHoraire = value;
                this.notifier("TauxHoraire");

            }
        }
        public decimal NbHeures
        {
            get { return _nbHeures; }
            set
            {
                _nbHeures = value;
                this.notifier("NbHeures");
            }
        }
        private void notifier(string propriete)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propriete));
        }
        public decimal calculerSalaireBrut()
        {
            decimal salaire = _tauxHoraire * _nbHeures;
            if (_nbHeures > 75.0m)
                salaire += 0.5m * _tauxHoraire * (_nbHeures - 75.0m);
            return salaire;
        }

        public override int GetHashCode()
        {
            return Nom.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is EmployeHoraire))
                return false;
            EmployeHoraire empl = (EmployeHoraire)obj;
            return empl.Nom.Equals(_nom);
        }
    }

}
