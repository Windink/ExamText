using ExamSystem.WebApi;
using ExamSystem.WebApi.entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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



namespace ExamSystem.Pages
{
    /// <summary>
    /// Users.xaml 的交互逻辑
    /// </summary>
    public partial class Users : Page
    {
        private UserWebRequest userRequest;
        private List<JToken> users;

        public Users(Token token)
        {
            InitializeComponent();
            userRequest = new UserWebRequest(token.login_Token);
            _ = initializeView();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public async Task initializeView()
        {
            List<JToken> users = await userRequest.GetAllRequest(uri.BaseUrl + uri.User + "GetAll");
            foreach(var item in users)
            {
                var it = new { ID = item["id"],Name = item["name"], CreatTime = item["creationTime"] };
                listView.Items.Add(it);
            }

        }
    }
}
