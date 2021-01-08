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
    /// CompletionControl.xaml 的交互逻辑
    /// </summary>
    public partial class CompletionControl : UserControl
    {
        //分别为上划线（Overline)，中划线(StrikeThrough)，基线(Baseline)，下划线(Underline)。

        private string Question;
        private List<TextBox> textBoxs;

        public CompletionControl(int index,string Question)
        {
            InitializeComponent();
            textBoxs = new List<TextBox>();
            questionindex.Content = index.ToString();
            this.Question = Question;
            Initialize(Question);
        }
        /// <summary>
        /// 初始化题目
        /// </summary>
        /// <param name="infor"></param>
        public void Initialize(string infor)
        {
            int num = infor.IndexOf("??");
            if (num == -1)
            {
                CreateLabel(infor);
                return;
            }
            else
            {
                CreateLabel(infor.Substring(0, num));
                CreateTextBlock();
                infor = infor.Substring(num + 2, infor.Length - num - 2);
                Initialize(infor);
            }

        }

        /// <summary>
        /// 返回答案
        /// </summary>
        /// <returns></returns>
        public string GetAnswer()
        {
            return textBoxs.ToString();
        }

        private void CreateLabel(string infor)
        {
            Label label = new Label();
            label.Content = infor;
            label.FontSize = 15;
            label.VerticalAlignment = VerticalAlignment.Center;
            Completions.Children.Add(label);
        }

        private void CreateTextBlock()
        {
            TextBox textBox = new TextBox();
            textBox.VerticalAlignment = VerticalAlignment.Center;
            textBox.Text = "";
            textBox.Width = 30;
            textBox.FontSize = 15;
            textBox.BorderThickness = new Thickness(0, 0, 0, 1);
            Completions.Children.Add(textBox);
            textBoxs.Add(textBox);
        }
    }
}
