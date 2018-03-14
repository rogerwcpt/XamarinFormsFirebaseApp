using System;
namespace XamarinFormsFirebaseApp.Models
{
    public class Account
    {
        public string uid { get; set; }
        public string name { get; set; }
        public string email { get; set; }

		public override string ToString()
		{
            return name;
		}
	}
}
