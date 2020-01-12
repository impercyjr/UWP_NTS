using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using T1809E_UWP_DAPI.Utils;
using T1809E_UWP_DAPI.Services;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using T1809E_UWP_DAPI.Models;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T1809E_UWP_DAPI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class Login : Page
    {
        private AuthenticationService _server = new AuthenticationService();
        public static string Token;

        private Validator validator = new Validator();


        public Login()
        {
            this.InitializeComponent();
        }

        private async void LoginHanlde(object sender, RoutedEventArgs e)
        {

            if (validator.IsEmail(email.Text))
            {
                emailAlert.Text = "";
                if (validator.IsNotNullAndNotEmpty(password.Password))
                {
                    passwordAlert.Text = "";
                    //Next
                }
                else
                {
                    passwordAlert.Text = "Please enter password";
                }
            }
            else
            {
                emailAlert.Text = "Inlavid email, please enter valid email format.";
            }
            var email1 = email.Text;
            var password1 = password.Password;
            Token = await this._server.LoginTask(email1, password1);
            this.Frame.Navigate(typeof(Pages.Login));

            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation =
            Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            savePicker.SuggestedFileName = "New Document";
            var file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
               FileHandleService.WriteToFile(file,Token);
            }


            //////var result = await FileHandleService.ReadFile("hello.txt");
            //////Debug.WriteLine(result);   

        }
        
    }
}

        

    



