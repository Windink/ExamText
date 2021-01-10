using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using ExamSystem.WebApi;
using ExamSystem.WebApi.entities;
using ExamSystem.WebApi.Server;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.IO;
using ExamSystem.WebApi.entities.Examinees;
using System.Threading.Tasks;

namespace ExamSystem.Pages
{
    /// <summary>
    /// CreatePage.xaml 的交互逻辑
    /// </summary>
    public partial class CreateUserPage : Page
    {
        private UserServer userRequest;
        private ExamineeServer examineeServer;
        private Token token;
        
        private string NewId;
        private string imagePath;
        public CreateUserPage(Token token)
        {
            InitializeComponent();
            userRequest = new UserServer(token.login_Token);
            examineeServer = new ExamineeServer(token.login_Token);
            this.token = token;
            InitializeUser();
        }

        /// <summary>
        /// 初始显示数据
        /// </summary>
        public async void InitializeUser()
        {
            JToken result = await userRequest.GetRequest(Uris.BaseUrl + Uris.User + "GetRoles");
            //JToken result =await userRequest.GetRequest(Uris.BaseUrl + Uris.User + "Get", new entity<long>() { id = long.Parse(token.login_Id) });
            //userName.Text = result["username"].ToString();
            //name.Text = result["name"].ToString();
            //surname.Text = result["surname"].ToString();
            //emailAddress.Text = result["emailAddress"].ToString();
            //password.Password = result["password"].ToString();
            foreach (var item in result["items"])
            {
                //MessageBox.Show(item["name"].ToString());
                CheckBox checkBox = new CheckBox();
                checkBox.Content = item["name"].ToString();
                roleNames.Children.Add(checkBox);
            }
        }

        /// <summary>
        /// 创建事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(password.Password != againpassword.Password)
            {
                MessageBox.Show("两次输入密码不一致");
            }
            List<string> roles = new List<string>();
            foreach(CheckBox item in roleNames.Children)
            {
                if(item .IsChecked==true)
                {
                    roles.Add (item.Content.ToString()); 
                }
            }
           
            UserRule user = new UserRule()
            {
                emailAddress = emailAddress.Text,
                userName = userName.Text,
                name = name.Text,
                password = password.Password,
                surname = surname.Text,
                roleNames = roles.ToArray() 
            };

            var result = await userRequest.CreateRequest(Uris.BaseUrl + Uris.User + "Create", user);

            if ((bool)result["success"])
            {
                NewId = result["result"]["id"].ToString();

                var re = await UploadImage();

                if (re!=null&&!(bool)re["success"])
                { MessageBox.Show(re["error"]["message"].ToString()); }
                else
                {
                    GoBack();
                }      
            }
            else
            {
               MessageBox.Show(result["error"]["message"].ToString()); 
            }

        }

        private async Task<JToken> UploadImage()
        { 
            if(imagePath==null)
            {
                return null;
            }
            Bitmap bitmap = new Bitmap(imagePath);
            string picture = ImagetoBase64(bitmap);

            ExamineeRule examineeDto = new ExamineeRule()
            {
                picture = picture,
                userID = NewId
             };
            var result = await examineeServer.CreateRequest(Uris.BaseUrl + Uris.Examinee + "Create", examineeDto);

            return result;
        }



    

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reverse_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
     
        }

        public void GoBack()
        {
            Frame frame = new Frame();
            frame.Content = new Users(token);
            this.Content = frame;

        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "jpg图片|*.jpg|png图片|*.png|jpeg图片|*.jpeg|bmp图片|*.bmp";
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imagePath = ofd.FileName;
                image.Source = new BitmapImage(new Uri(imagePath));

            }
        }

        /// <summary>
        /// 将文件转base64
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private string ImagetoBase64(Bitmap image)
        {
            using(MemoryStream me = new MemoryStream())
            {
                image.Save(me,image.RawFormat);
                byte[] imageBytes = me.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

    }
}
