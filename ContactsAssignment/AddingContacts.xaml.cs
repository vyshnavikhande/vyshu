using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsAssignment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddingContacts : ContentPage
    {
      
        public AddingContacts()
        {
            InitializeComponent();
            //capture.Clicked += async (sender, args) =>
            //{

            //    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            //    {
            //        DisplayAlert("No Camera", ":( No camera available.", "OK");
            //        return;
            //    }

            //    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            //    {
            //        Directory = "Test",
            //        SaveToAlbum = true,
            //        CompressionQuality = 75,
            //        CustomPhotoSize = 50,
            //        PhotoSize = PhotoSize.MaxWidthHeight,
            //        MaxWidthHeight = 2000,
            //        DefaultCamera = CameraDevice.Front
            //    });

            //    if (file == null)
            //        return;

            //    DisplayAlert("File Location", file.Path, "OK");

            //    MyImage.Source = ImageSource.FromStream(() =>
            //    {
            //        var stream = file.GetStream();
            //        file.Dispose();
            //        return stream;
            //    });
            //};
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsTakePhotoSupported && !CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Message", "Photo Capture and Pick Not supported", "OK");
                return;
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Images",
                    Name = DateTime.Now + "_test.jpg"
                });
                if (file == null)
                    return;
                await DisplayAlert("File Path", file.Path, "OK");

                MyImage.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }

            //    if (!Plugin.Media.CrossMedia.Current.IsCameraAvailable || !Plugin.Media.CrossMedia.Current.IsTakePhotoSupported)
            //    {
            //        await DisplayAlert("Camera not supported", "Camera not supported", "OK");
            //        capture.IsEnabled = false;
            //        return;
            //    }

            //    // verifies that the user has permission to access the camera
            //    var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            //    if (cameraStatus != PermissionStatus.Granted)
            //    {
            //        var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera });
            //        cameraStatus = results[Permission.Camera];
            //        if (cameraStatus != PermissionStatus.Granted)
            //        {
            //            await DisplayAlert("Permissions Denied", "Unable to take photos.", "OK");
            //            capture.IsEnabled = false;
            //            return;
            //        }
            //    }

            //    // Assures user intends to take a photo
            //    await DisplayAlert("Take picture confirmation", "Would you like to take a picture?", "Yes");

            //    // Accesses Media Plugin's TakePhotoAsync method to take a the photo
            //    var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
            //    {
            //        Directory = "Sample",
            //        Name = "test.jpg",
            //    });

            //    // Displays the image if their is image information
            //    if (photo != null)
            //    {
            //        MyImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            //        MyImage.Aspect = Aspect.AspectFill;
            //    }
            //}

        }

    }
}