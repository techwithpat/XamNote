using System;
using Microsoft.Extensions.DependencyInjection;
using XamNote.Data;
using XamNote.ViewModels;
using XamNote.Views;

namespace XamNote
{
    public static class Locator
    {
        private static IServiceProvider serviceProvider;

        public static void Initialize()
        {
            var services = new ServiceCollection();
            services.AddSingleton<INoteRepository, SqliteNoteRepository>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<NoteViewModel>();
            services.AddTransient<HomeView>();
            services.AddTransient<NoteView>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
