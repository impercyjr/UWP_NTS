using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using  T1809E_UWP_DAPI.Models;
using System.Net.Http.Headers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace T1809E_UWP_DAPI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int _choosedGender = 2;
        private String _birthDay;
        public MainPage()
        {
            this.InitializeComponent();
            //getApiAsync();
        }

        //public async void getApiAsync()
        //{
        // // HttpClient client = new HttpClient();
        //  //string respone = await client.GetStringAsync("https://api.coindesk.com/v1/bpi/currentprice.json");
        //   //var obj = JsonConvert.DeserializeObject<Bitcoin>(respone);
        //    //Debug.WriteLine(respone);
        //}

        //public async HttpResponseMessage Register(Uri uri, Member item)
        //{
        //  var json = JsonConvert.SerializeObject(item);
        //  var content = new StringContent(json);
        //  content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //  HttpClient _client = new HttpClient();
        //  return await _client.PostAsync(uri, content);
        //}

        private void Gender_Choose(object sender, RoutedEventArgs e)
        {
          var chooseRadioButton = (RadioButton)sender;
          if (chooseRadioButton == null) return;
          switch (chooseRadioButton.Tag)
          {
            case "Male":
              _choosedGender = 1;
              break;
            case "Female":
              _choosedGender = 0;
              break;
            case "Other":
              _choosedGender = 2;
              break;
          }
        }

        private void Birthday_OnDateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
          if (sender.Date.HasValue)
          {
            _birthDay = sender.Date.Value.Date.ToString("yyyy-MM-dd");
          }
        }

        private void Submit_OnClick(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("https://2-dot-backup-server-002.appspot.com/_api/v2/members");
            var member = new Member();
            member.firstName = firstName.Text;
            member.lastName = lastName.Text;
            member.address = address.Text;
            member.password = password.Password;
            member.phone = phone.Text;
            member.gender = _choosedGender;
            member.birthday = _birthDay;
            member.email = email.Text;
            member.avatar = avatar.Text;
            //var resp = Register(uri, member);
            Debug.WriteLine(member.ToString());
        }
    }
}
