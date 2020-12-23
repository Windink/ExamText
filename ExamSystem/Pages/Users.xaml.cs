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

namespace ExamSystem.Pages
{
    /// <summary>
    /// Users.xaml 的交互逻辑
    /// </summary>
    public partial class Users : Page
    {
        public class uss
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string CreatTime { get; set; }
        }
        public Users()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
               
                var item = new uss { ID = i.ToString(), Name = "ss", CreatTime = DateTime.Now.ToString() };
               // DataContext = item;

                listView.Items.Add(item);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
