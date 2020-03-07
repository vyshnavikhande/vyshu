using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsAssignment
{

    class ContactsListViewModel
    {
        public ICommand AddContactCommand => new Command(AddContact);
        public static ObservableCollection<NewContact> Employees { get; set; }
        public static ObservableCollection<NewContact> Favourite { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

        static ContactsListViewModel()
        {
            Favourite = new ObservableCollection<NewContact>()
            {
                new NewContact {ContactName = "Mary " , PhoneNumber = "9999999999" , EmailAddress = "mary@gmail.com" , ImageUrl = "person1.jpeg"}
                //new NewContact {ContactName = "John" , PhoneNumber = "9987687598" , EmailAddress = "john@gmail.com" , ImageUrl = "person2.jpeg"},
                //new NewContact {ContactName = "Sia " , PhoneNumber = "9477879076" , EmailAddress = "sia@gmail.com" , ImageUrl = "person3.jpg"},
                //new NewContact {ContactName = "Hary " , PhoneNumber = "9768579879" , EmailAddress = "hary@gmail.com" , ImageUrl = "person4.jpeg"},
                //new NewContact {ContactName = "George " , PhoneNumber = "9869876669" , EmailAddress = "george@gmail.com" , ImageUrl = "person5.jpg"},
                //new NewContact {ContactName = "Raj " , PhoneNumber = "97657323443" , EmailAddress = "raj@gmail.com" , ImageUrl = "person6.jpg"},

            };

            Employees = new ObservableCollection<NewContact>()
            {
                new NewContact {ContactName = "Mary " , PhoneNumber = "9999999999" , EmailAddress = "mary@gmail.com" , ImageUrl = "person1.jpeg"},
                new NewContact {ContactName = "John" , PhoneNumber = "9987687598" , EmailAddress = "john@gmail.com" , ImageUrl = "person2.jpeg"},
                new NewContact {ContactName = "Sia " , PhoneNumber = "9477879076" , EmailAddress = "sia@gmail.com" , ImageUrl = "person3.jpg"},
                new NewContact {ContactName = "Hary " , PhoneNumber = "9768579879" , EmailAddress = "hary@gmail.com" , ImageUrl = "person4.jpeg"},
                new NewContact {ContactName = "George " , PhoneNumber = "9869876669" , EmailAddress = "george@gmail.com" , ImageUrl = "person5.jpg"},
                new NewContact {ContactName = "Raj " , PhoneNumber = "97657323443" , EmailAddress = "raj@gmail.com" , ImageUrl = "person6.jpg"},

            };
        }
        public void AddContact()
        {
            var a = new NewContact { ContactName = Name, PhoneNumber = Number, EmailAddress = Email };
            Employees.Add(a);
        }

       
    }
}
