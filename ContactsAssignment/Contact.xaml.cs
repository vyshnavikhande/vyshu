using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsAssignment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contact : ContentPage
    {

        public Contact()
        {
            InitializeComponent();
        }

        private void Add_Contacts(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddingContacts());
        }

        async private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }
           var contact = e.SelectedItem as NewContact;
           await Navigation.PushAsync(new ContactsDetailPage(contact));
           listView.SelectedItem = null;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            serach.IsVisible = true;
        }
    }
}