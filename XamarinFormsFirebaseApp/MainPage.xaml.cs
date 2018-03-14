using System;
using System.Collections.Generic;
using Firebase.Xamarin.Database;
using Xamarin.Forms;
using XamarinFormsFirebaseApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinFormsFirebaseApp
{
    public partial class MainPage : ContentPage
    {
        private const string FirebaseURL = "https://xamarin-firebase-app.firebaseio.com/";
        private FirebaseObject<Account>[] _list;

        public MainPage()
        {
            InitializeComponent();

            AddNewButton.Clicked += AddNew_Clicked;
        }

		protected override async void OnAppearing()
		{
            base.OnAppearing();

            await PopulateList();
        }

        private async Task PopulateList()
        {
            var firebase = new FirebaseClient(FirebaseURL);

            var result = await firebase
                .Child("users")
                .OnceAsync<Account>();

            _list = result.ToArray();

            AccountsListView.ItemsSource = _list;
        }

        async void AddNew_Clicked(object sender, EventArgs e)
        {
            Account user = new Account();
            user.uid = String.Empty;
            user.name = "user " + _list.Length;
            user.email = user.name + "@email.com";

            var firebase = new FirebaseClient(FirebaseURL);
            var item = await firebase.Child("users").PostAsync<Account>(user);

            PopulateList();
        }

	}
}
