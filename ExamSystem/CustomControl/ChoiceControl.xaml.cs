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

namespace ExamSystem.CustomControl
{
    /// <summary>
    /// ChoiceQuestionControl.xaml 的交互逻辑
    /// </summary>
    public partial class ChoiceControl : UserControl
    {
        private string ChoiceChar;
        private string ChoiceString;
        private CheckBox IsCheckBox;
        private Label[] answerContrls ;
        private string[] answers;
        private enum AnswerTONum
        {
            A = 0,
            B = 1,
            C = 2,
            D = 3
        }

        public ChoiceControl(int index,JToken choicequestion)
        {
            InitializeComponent();
            QuestionIndex.Content = index;
            answerContrls = new Label[4] { Aanswer, Banswer, Canswer, Danswer };
            answers = new string[4] {choicequestion["trueAnswer"].ToString(), 
                choicequestion["ortherAnswerOne"].ToString(),
                choicequestion["ortherAnswerTwo"].ToString(), 
                choicequestion["ortherAnswerThree"].ToString() };

            AnswerTONum d = (AnswerTONum)Enum.Parse(typeof(AnswerTONum),choicequestion["trueAnswerIndex"].ToString());
            
            int flag = (int)d;
            Initialize(flag);
        }

        private void Initialize(int flag)
        {
            int tab = 1;
            answerContrls[flag].Content = answers[0];
             for(int i=0; i < 4;i++)
            {
                if (i == flag) { continue; }
                else
                {
                    answerContrls[i].Content = answers[tab++];
                }
            }
        }


        /// <summary>
        /// 返回答案
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,string> GetChoiceinformation()
        {
            if(ChoiceChar.Equals(""))
            {
                return new Dictionary<string, string>() { { "error", QuestionIndex.ToString() } };
            }
            return new Dictionary<string, string>(){ { ChoiceChar,ChoiceString } };
        }

        private void Check_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if(IsCheckBox != null)
            { IsCheckBox.IsChecked = false; }
            IsCheckBox = checkBox;
            ChoiceChar = checkBox.Content.ToString();
            StackPanel s = checkBox.Parent as StackPanel;
            Label label = s.Children[1] as Label;
            ChoiceString = label.Content.ToString();
        }
    }
}
