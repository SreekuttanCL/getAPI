using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using getAPI.Models;

namespace getAPI
{
    public partial class SavePosts : ContentPage
    {
        public SavePosts()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //! added using SQLite; 
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                //! added using XamarinNotesApp.Models; 
                conn.CreateTable<Posts>();
                List<Posts> notes = conn.Table<Posts>().ToList();
                postsListView.ItemsSource = notes;
            }
        }
        private void NotesListView_ItemSelected(object sender, EventArgs e) { }
    }
}
