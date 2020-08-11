using System;
using Xamarin.Forms;

namespace XamNote.ViewModels
{
    public class ViewModelBase : BindableObject
    {
        public INavigation Navigation { get; set; }
    }
}
