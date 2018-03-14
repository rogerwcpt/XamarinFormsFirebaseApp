# XamarinFormsFirebaseApp
Testing Firebase Database via Xamarin Forms

Using nuget package [Firebase.Xamarin](https://www.nuget.org/packages/Firebase.Xamarin/), perform a POST and GET of objects.

##### Add Data

```C#
            Account user = new Account();
            user.uid = String.Empty;
            user.name = "user " + _list.Length;
            user.email = user.name + "@email.com";

            var firebase = new FirebaseClient(FirebaseURL);
            var item = await firebase.Child("users").PostAsync<Account>(user);
```

##### Fetch Data

```C#
          var firebase = new FirebaseClient(FirebaseURL);

            var result = await firebase
                .Child("users")
                .OnceAsync<Account>();

            _list = result.ToArray();

            AccountsListView.ItemsSource = _list;
```
