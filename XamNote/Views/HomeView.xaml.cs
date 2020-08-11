using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamNote.ViewModels;

namespace XamNote.Views
{
    public partial class HomeView : ContentPage
    {
        public HomeView(HomeViewModel homeViewModel)
        {
            InitializeComponent();

            homeViewModel.Navigation = Navigation;
            BindingContext = homeViewModel;

            ResetCollectionViewSelection();
        }

        private void ResetCollectionViewSelection()
        {
            NoteCollectionView.SelectionChanged += (s, e)
                => NoteCollectionView.SelectedItem = null;
        }
    }
}
