using ExamSystem.WebApi;
using ExamSystem.WebApi.Server;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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
    /// ExamineeExamPape.xaml 的交互逻辑
    /// </summary>
    public partial class ExamineeExamPape : Page
    {
        private readonly TestpaperServer testpaperServer;
        private Token token;
        private List<JToken> testpapers;



        public ExamineeExamPape(Token token)
        {
            InitializeComponent();
            this.token = token;
            testpaperServer = new TestpaperServer(token.login_Token);
            Initialize();
        }
        private async void Initialize()
        {
            listView.Items.Clear();
            // if (testpapers == null)
            //{ 
            this.testpapers = await testpaperServer.GetAllRequest(Uris.BaseUrl + Uris.TestPage + "GetAll");
            //d}
            foreach (var item in this.testpapers)
            {
                if (!(bool)item["isActive"])
                {
                    continue;
                }
                var it = new
                {
                    Name = item["examTestPaperName"],
                    ChoiceNameCount = item["examQuestionIDs"].ToString().Split(',').Length,
                    ComletionNameCount = item["examCompletionIDs"].ToString().Split(',').Length,
                    SAQNameCount = item["examShortAnswerQuestionIDs"].ToString().Split(',').Length,
                    ID = item["id"]
                };
                listView.Items.Add(it);
            }
            listView.Items.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Ascending));
        }



        private void Exam_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Frame frame = new Frame();
            foreach (var item in testpapers)
            { 
                if(item["id"].Equals(button.Tag))
            frame.Content = new Examine(token, item);
            }
            this.Content = frame;
        }
    }
}
