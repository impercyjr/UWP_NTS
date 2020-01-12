using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using T1809E_UWP_DAPI.Models;
using T1809E_UWP_DAPI.Utils;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using T1809E_UWP_DAPI.Services;
using T1809E_UWP_DAPI.Pages;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T1809E_UWP_DAPI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        private int _choosedGender = 2;
        private String _birthDay;
        private Validator validator = new Validator();
        public RegisterPage()
        {
            this.InitializeComponent();
            LoadRegisterPage();
        }
       

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

        public void IsPasswordConfirm(object sender, KeyRoutedEventArgs e)
        {
            if (!validator.IsPasswordMatch(Pwdpassword.Password, confirmPassword.Password))
            {
                pcfAlert.Text = "Password did not match.";
            } else
            {
                pcfAlert.Text = "";
            }
        }
        public void IsEmailValid(object sender, KeyRoutedEventArgs e)
        {
            if (!validator.IsEmail(Txtemail.Text))
            {
                emailAlert.Text = "Please enter valid email.";
            }
            else
            {
                emailAlert.Text = "";
            }
        }
        public void IsPhoneNumberValid(object sender, KeyRoutedEventArgs e)
        {
            if (!validator.IsPhoneNumber(Txtphone.Text))
            {
                phoneAlert.Text = "Enter Viet Nam's phone number (+84xxxxxxxxx).";
            }
            else
            {
                phoneAlert.Text = "";
            }
        }
        public bool IsNotNull(string str)
        {
            if (!validator.IsNotNullAndNotEmpty(str))
            {
                NotNullAlert.Text = "Please fill all field before submit";
                return false;
            }
            else
            {
                NotNullAlert.Text = "";
                return true;
            }
        }
        private void Birthday_OnDateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            if (sender.Date.HasValue)
            {
                _birthDay = sender.Date.Value.Date.ToString("yyyy-MM-dd");
            }
        }

        private void RegisterSubmit(object sender, RoutedEventArgs e)
        {   
            
            bool check = true;
            var member = new Member();
            member.firstName = TxtfirstName.Text;
            check = IsNotNull(TxtfirstName.Text);
            member.lastName = TxtlastName.Text;
            check = IsNotNull(TxtlastName.Text);
            member.address = Txtaddress.Text;
            check = IsNotNull(Txtaddress.Text);
            member.password = Pwdpassword.Password;
            check = IsNotNull(Pwdpassword.Password);
            member.phone = Txtphone.Text;
            member.gender = _choosedGender;
            member.birthday = _birthDay;
            check = IsNotNull(_birthDay);
            member.email = Txtemail.Text;
            member.avatar = Txtavatar.Text;
            if (check)
            {
                NotNullAlert.Text = "success";
                var memberJson = JsonConvert.SerializeObject(member);
                HttpContent contentToSend = new StringContent(memberJson, Encoding.UTF8,"application/Json");
                SubmitData(contentToSend);
            }
            else 
            {
                //DO some thing return an error
            }

        }

        private async void SubmitData(HttpContent contentToSend)
        {
            HttpClient httpClient = new HttpClient();
            var respone = await httpClient.
                PostAsync("https://2-dot-backup-server-002.appspot.com/_api/v2/members",contentToSend);
            var stringContent = await respone.Content.ReadAsStringAsync();
            var returnMember = JsonConvert.DeserializeObject<Member>(stringContent);
            Debug.WriteLine(returnMember.id);
        }
        private MemberService _memberService = new MemberService();
        private async void LoadRegisterPage()
        {
            Member member = await this._memberService.GetMemberInformation(Login.Token);


        }
    }
}
