using ExamSystem.WebApi;
using ExamSystem.WebApi.entities.TestPapers;
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
    /// CreatePages.xaml 的交互逻辑
    /// </summary>
    public partial class CreatePages : Page
    {
        private Token token;
        public CreatePages(Token token)
        {
            InitializeComponent();
            this.token = token;
            QuestionBank.testPaperRule = new TestPaperRule();
            questionFram.Content = new PreViewPage();
        }

        private void CreateChoice_Click(object sender, RoutedEventArgs e)
        {
            questionFram.Content = new ChoicePage(token);
        }

        private void CreateCompletion_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CreateASQuestion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Build_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Revesr_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
