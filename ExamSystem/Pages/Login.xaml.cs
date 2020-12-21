﻿using Abp.WebApi.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamSystem
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Page
    {

        private readonly AbpWebApiClient _abpWebApiClient;
        private string baseUrl = "http://localhost:21021";
        

        public Login()
        {
            InitializeComponent();
            _abpWebApiClient = new AbpWebApiClient();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {


           var result = await Authenticate();
           GetExamineesCount(result.Values.First());

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Register();
        }

        public async Task<Dictionary<string, string>> Authenticate()
        {
           
            var url =baseUrl + "/api/TokenAuth/Authenticate";
            var input = new
            {

                UsernameOrEmailAddress = "admin",
                Password = "123qwe"
            };
            var result = await _abpWebApiClient.PostAsync<Dictionary<string,string>>(url, input);

            Cookie cookie = new Cookie(result.Keys.First(), result.Values.First());

            _abpWebApiClient.Cookies.Add(cookie);
            //MessageBox.Show(cookie.Name);
            return result;
        }

        


        public async void GetExamineesCount(string token)
        {  var uri = baseUrl + "/api/services/app/Examinee/GetExamineesCount";
            //_abpWebApiClient.RequestHeaders.Add(new Abp.NameValue("Authorization","Bearer " +_abpWebApiClient.Cookies.First() ));
           using(var httpclient = new HttpClient())
            {
                httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var re = await httpclient.GetAsync(uri);

                var result = await re.Content.ReadAsStringAsync();
                var obj = JToken.Parse(result);
                MessageBox.Show(obj["result"].ToString());
            }
            
          

           // var result = await _abpWebApiClient.PostAsync<string>(uri);

     
        }



        #region 测试
        //public async Task CookieBasedAuth()
        //{
        //    Uri uri = new Uri(baseUrl + loginUrl);
        //    var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None, UseCookies = true };
        //    using(var client = new HttpClient(handler))
        //    {
        //        client.BaseAddress = uri;
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));

        //        var content = new FormUrlEncodedContent(new Dictionary<string, string>()
        //        {
        //            {"TenancyName", "Default"},
        //            {"UsernameOrEmailAddress", user},
        //            {"Password", pwd }
        //        });

        //        var result = await client.PostAsync(uri, content);

        //        HttpStatusCode state = result.StatusCode;
        //        MessageBox.Show(state.ToString());

        //        string loginResult = await result.Content.ReadAsStringAsync();

        //        MessageBox.Show(loginResult);
        //        var getCookies = handler.CookieContainer.GetCookies(uri);

        //        foreach(Cookie cookie in getCookies)
        //        {
        //            _abpWebApiClient.Cookies.Add(cookie);

        //        }

        //    }
        //}

        //public async Task<string> GetAbpToken()
        //{
        //    Uri uri = new Uri(baseUrl);
        //    var tokenResult = await _abpWebApiClient.PostAsync<string>(baseUrl + abpTokenUrl, new
        //    {
        //        TenancyName = "Default",
        //        UsernameOrEmailAddress = user,
        //        Password = pwd
        //    });
        //    //Application.SetCookie(uri, tokenResult);
        //    MessageBox.Show(tokenResult);
        //    return tokenResult;
        //}
        #endregion
    }
}
