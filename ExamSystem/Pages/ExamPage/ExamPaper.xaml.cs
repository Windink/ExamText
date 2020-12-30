using ExamSystem.WebApi;
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

namespace ExamSystem.Pages.ExamPage
{
    /// <summary>
    /// ExamPaper.xaml 的交互逻辑
    /// </summary>
    public partial class ExamPaper : Page
    {
        private Token token;
        public ExamPaper(Token token)
        {
            InitializeComponent();
            this.token = token;
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Updata_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CreatePage_Click(object sender, RoutedEventArgs e)
        {
            Frame frame = new Frame();
            frame.Content = new CreatePages(token);
            this.Content = frame;
        }
    }
}
