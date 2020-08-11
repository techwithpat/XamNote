using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XamNote.Data;
using XamNote.Models;
using XamNote.Views;

namespace XamNote.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<Note> notes;
        private readonly INoteRepository noteRepository;

        public HomeViewModel(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;

            SubscribeToSaveOccuredMessage();

            InitializeAddNoteCommand();

            LoadNotes();
        }

        private void SubscribeToSaveOccuredMessage()
        {
            MessagingCenter.Subscribe<NoteViewModel>(this, "saveoccured", n => LoadNotes());
        }

        private void InitializeAddNoteCommand()
            => AddNoteCommand = new Command(async () => NavigateToNoteView(new Note()));

        private async void LoadNotes()
        {
            try
            {
                var notes = await noteRepository.GetNotes()
                ?? Enumerable.Empty<Note>();

                Notes = new ObservableCollection<Note>(notes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }           
        }

        private async void NavigateToNoteView(Note value)
        {
            var noteView = Locator.Resolve<NoteView>();
            var noteViewModel = noteView.BindingContext as NoteViewModel;
            noteViewModel.Note = value;

            await Navigation.PushAsync(noteView);
        }

        public ObservableCollection<Note> Notes
        {
            get => notes;
            set
            {
                notes = value;
                OnPropertyChanged();
            }
        }

        public Note SelectedNote
        {
            get => null;
            set
            {
                if (value == null) return;
                NavigateToNoteView(value);
            }
        }
              

        public ICommand AddNoteCommand { get; private set; }
    }
}
