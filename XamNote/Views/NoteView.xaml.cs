using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamNote.ViewModels;

namespace XamNote.Views
{
    public partial class NoteView : ContentPage
    {
        public NoteView(NoteViewModel noteViewModel)
        {
            InitializeComponent();

            noteViewModel.Navigation = Navigation;
            BindingContext = noteViewModel;
        }
    }
}
