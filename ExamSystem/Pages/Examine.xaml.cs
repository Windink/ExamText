using ExamSystem.CustomControl;
using ExamSystem.WebApi;
using ExamSystem.WebApi.entities;
using ExamSystem.WebApi.Server;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
using ExamSystem.WebApi.entities.TestAnswers;

namespace ExamSystem.Pages
{
    /// <summary>
    /// Examine.xaml 的交互逻辑
    /// </summary>
    public partial class Examine : Page
    {
        private readonly TestpaperServer testpaperServer;
        private readonly ChocieQuestionServer questionServer;
        private readonly CompletionServer completionServer;
        private readonly SAQuestionServer aQuestionServer;
        private readonly JToken testpaper;
        private readonly Token token;
        private int index = 0;

        public Examine(Token token, JToken testpaper)
        {
            InitializeComponent();
            this.token = token;
            this.testpaper = testpaper;
            this.testpaperServer = new TestpaperServer(token.login_Token);
            this.questionServer = new ChocieQuestionServer(token.login_Token);
            this.completionServer = new CompletionServer(token.login_Token);
            this.aQuestionServer = new SAQuestionServer(token.login_Token);
            Initialize(testpaper);
        }


        private void Initialize(JToken testpaper)
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
            foreach (string choice in choices)
            {
                try
                {
                    var result = await questionServer.GetRequest(Uris.BaseUrl + Uris.ChoiceQuestion + "Get", new entity<long>()
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
                catch (Exception e)
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
            frame.Content = new ExamineeExamPape(token);
            this.Content = frame;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> choices = GetChoice();
            List<string> completions = GetCompletion();
            List<string> saquestions = GetSQAnswer();

            TestAnswerRule testAnswerRule = new TestAnswerRule()
            {
                ShortAnswers = string.Join(",",saquestions.ToArray()),
                ChoiceAnswers = string.Join(",",choices.ToArray()),
                CompletionAnswers =string.Join(",",completions.ToArray()),
                ExamTestPaperId = int.Parse(testpaper["id"].ToString()),
                UserId = long.Parse(token.login_Id)
            };

            var result =await testpaperServer.CreateRequest(Uris.BaseUrl+Uris.TestAnswer+"Create",testAnswerRule);

            GoBack();
        }

        private List<string> GetChoice()
        {
            List<string> choices = new List<string>();
            foreach (var item in Choices.Children)
            {
                if(item is Label)
                { continue; }
                ChoiceControl choiceControl = item as ChoiceControl;
                choices.Add(choiceControl.GetChoiceinformation().ToString());
            }

            return choices;
        }

        private List<string> GetCompletion()
        {
            List<string> completons = new List<string>();
            foreach (var item in Completions.Children)
            {
                if (item is Label)
                { continue; }
                CompletionControl completion = item as CompletionControl;
                completons.Add(completion.GetAnswer());
            }

            return completons;
        }

        private List<string> GetSQAnswer()
        {
            List<string> squestions = new List<string>();
            foreach (var item in SQuestions.Children)
            {
                if (item is Label)
                { continue; }
                SAQuestionControl sAQuestion = item as SAQuestionControl;
                squestions.Add(sAQuestion.GetAnswer());
            }

            return squestions;
        }

        private void GoBack()
        {
            Frame frame = new Frame();
            frame.Content = new ExamineeExamPape(token);
            this.Content = frame;
        }
    }
}
