using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsAssignment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsDetailPage : ContentPage
    {
        NewContact _contact;
        public ContactsDetailPage(NewContact contact)
        {
            if(contact == null)
            {
                throw new ArgumentNullException();
            }

            _contact = contact;
            BindingContext = contact;

            InitializeComponent();
        }

        private void SendSMS_Clicked(object sender, EventArgs e)
        {
            var x = callbutton.Parent;
            var x1 = x.FindByName("number") as Label;
            var x2 = x1.Text;
            var smsMessenger = CrossMessaging.Current.SmsMessenger;
            if(smsMessenger.CanSendSms)
            {
                smsMessenger.SendSms(x2, "Welcome to xamairn forms");
            }
        }

        private void PhoneCall_Clicked(object sender, EventArgs e)
        {
            var x = callbutton.Parent;
            var x1 = x.FindByName("number") as Label;
            var x2 = x1.Text;
            var phoneCallTalk = CrossMessaging.Current.PhoneDialer;
            if(phoneCallTalk.CanMakePhoneCall)
            {
                phoneCallTalk.MakePhoneCall(x2);
            }
        }

        private void SendEmail_Clicked(object sender, EventArgs e)
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                emailMessenger.SendEmail("@gmail.com", "Xamamrin");
            }
        }

        private void DeleteContact_Clicked(object sender, EventArgs e)
        {
            
        }

        private void FavouriteContact_Clicked(object sender, EventArgs e)
        {
            ContactsListViewModel.Favourite.Add(_contact);
        }
    }
}