using HalloWinUI.Data;
using HalloWinUI.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HalloWinUI.ViewModels.Pages
{
    public class MainMaisonsViewModel : BaseViewModel
    {
        private readonly IHalloweenDataProvider _dataProvider;
        private MaisonViewModel? _maisonSelectionnee;

        public MaisonViewModel MaisonSelectionnee
        {
            get => _maisonSelectionnee;
            set
            {
                if (_maisonSelectionnee != value)
                {
                    _maisonSelectionnee = value;
                    // binding TwoWay ==> RaisePropertyChanged()
                }
            }
        }

        public ObservableCollection<MaisonViewModel> Maisons { get; }

        public string NouvelleMaison { get; set; }

        public MainMaisonsViewModel(IHalloweenDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Maisons = new ObservableCollection<MaisonViewModel>();
        }

        public void ChargerMaisons()
        {
            Maisons.Clear();
            List<Maison> maisons = _dataProvider.GetMaisons();

            if (maisons != null)
            {
                foreach (Maison maison in maisons)
                {
                    Maisons.Add(new MaisonViewModel(maison));
                }
            }
        }

        public void SupprimerMaison()
        {
            if (MaisonSelectionnee != null)
            {
                Maisons.Remove(MaisonSelectionnee); 
            }
        }

        public void AjouterMaison(string name)
        {
            // TODO: T'y étais presque, c'est NouvelleMaison que tu dois ajouter.
            //          Avec le binding avec le xaml et RaisePropertyChanged dans la prop NouvelleMaison.
            //          Pas besoin du param. name.
            Maisons.Add(new MaisonViewModel(maison));
        }
    }
}
