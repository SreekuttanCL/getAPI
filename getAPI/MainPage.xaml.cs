using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using getAPI.Models;
using SQLite;

namespace getAPI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private const string url = "https://jsonplaceholder.typicode.com/posts";
        private HttpClient _Client = new HttpClient();

        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            //Sends a GET request to the specified Uri and returns the response body as a string in an asynchronous operation 
            var content = await _Client.GetStringAsync(url);
            //Deserializes or converts JSON String into a collection of Post 
            List<Posts> posts = JsonConvert.DeserializeObject<List<Posts>>(content);
            //Assigning the ObservableCollection to MyListView in the XAML of this file 
            Post_List.ItemsSource = posts;
            base.OnAppearing();
        }

        private void Fav_ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SavePosts());
        }

        private void Posts_ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                var PostSelected = e.SelectedItem as Posts;
                Posts post = new Posts()
                {
                    userId = PostSelected.userId,
                    id = PostSelected.id,
                    title = PostSelected.title,
                    body = PostSelected.body
                };

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
                {
                    conn.CreateTable<Posts>();
                    int itemsInserted = conn.Insert(post);

                    if (itemsInserted > 0)
                        DisplayAlert("Done", "Post saved", "Ok");
                    else
                        DisplayAlert("Error", "Post not saved", "Ok");
                }
            }
        }
    }
}
