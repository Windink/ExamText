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
using ExamSystem.WebApi;
using ExamSystem.WebApi.entities;
using ExamSystem.WebApi.Server;
using Newtonsoft.Json.Linq;
using ExamSystem.CustomControl;

namespace ExamSystem.Pages.ExamPage
{
    /// <summary>
    /// ExamPreview.xaml 的交互逻辑
    /// </summary>
    public partial class ExamPreview : Page
    {
        private readonly TestpaperServer testpaperServer;
        private readonly ChocieQuestionServer questionServer;
        private readonly CompletionServer completionServer;
        private readonly SAQuestionServer aQuestionServer;
        private readonly Token token;
        private int index = 0;

        public ExamPreview(Token token, JToken testpaper)
        {
            InitializeComponent();
            this.token = token;
            this.testpaperServer = new TestpaperServer(token.login_Token);
            this.questionServer = new ChocieQuestionServer(token.login_Token);
            this.completionServer = new CompletionServer(token.login_Token);
            this.aQuestionServer = new SAQuestionServer(token.login_Token);
            Initialize(testpaper);
        }

        private  void Initialize(JToken testpaper)
        {
            string[] choices = testpaper["examQuestionIDs"].ToString().Split(',');
            string[] completions = testpaper["examCompletionIDs"].ToString().Split(',');
            string[] shortAnswers = testpaper["examShortAnswerQuestionIDs"].ToString().Split(',');
            CreateChoice(choices);
            CreateCompletion(completions);
            CreateSAQuesiotn(shortAnswers);
        }

        private async void CreateChoice(string[] choices)
        {
            foreach(string choice in choices)
            {
                try
                { 
                    var result = await questionServer.GetRequest(Uris.BaseUrl + Uris.ChoiceQuestion + "Get",new entity<long>() 
                    { 
                        id = long.Parse(choice)
                    });
                    ChoiceControl choiceControl = new ChoiceControl(index, result);
                    Choices.Children.Add(choiceControl);
                    index++;
                }
                catch (Exception e)
                {
                    continue;
                }
            }
        }

        private async void CreateCompletion(string[] completions)
        {
            foreach (string completion in completions)
            {
                try
                {
                    var result = await completionServer.GetRequest(Uris.BaseUrl + Uris.Completion + "Get", new entity<long>()
                    {
                        id = long.Parse(completion)
                    });
                    CompletionControl completionControl = new CompletionControl(index, result["question"].ToString());
                    Completions.Children.Add(completionControl);
                    index++;  
                }
                catch(Exception e)
                {
                    continue;
                }
            }
        }

        private async void CreateSAQuesiotn(string[] shortAnswers)
        {
            foreach (string shortAnswer in shortAnswers)
            {
                try
                {
                    var result = await aQuestionServer.GetRequest(Uris.BaseUrl + Uris.SAQuestion + "Get", new entity<long>()
                    {
                        id = long.Parse(shortAnswer)
                    });
                    SAQuestionControl sAQuestionControl = new SAQuestionControl(index, result["question"].ToString());
                    SQuestions.Children.Add(sAQuestionControl);
                    index++;
                }
                catch (Exception e)
                {
                    continue;
                }
            }


        }

        private void Reverse_Click(object sender, RoutedEventArgs e)
        {
            Frame frame = new Frame();
            frame.Content = new ExamPaper(token);
            this.Content = frame;
        }
    }
}
