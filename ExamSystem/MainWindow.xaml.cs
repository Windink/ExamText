using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.Util;


namespace ExamSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoCapture videoCapture = null;
        private Mat frame = null;
        private CascadeClassifier classfier;
        
        public MainWindow()
        {
            InitializeComponent();
            this.Content = new Login();
            classfier = new CascadeClassifier();
            imagebox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            imagebox1.Visible = true;
            videoCapture = new VideoCapture();

            imagebox1.SizeMode = PictureBoxSizeMode.StretchImage;
            
            //imagebox1.Size = new System.Drawing.Size(300, 200);
            if(videoCapture == null)
            {
                return;
            }
            videoCapture.ImageGrabbed += VideoCapture_ImageGrabbed;
            frame = new Mat();
          
            videoCapture.Start();
          
        }

        private void VideoCapture_ImageGrabbed(object sender, EventArgs e)
        {
            
            videoCapture.Retrieve(frame, 0);    //接收数据
            
            imagebox1.Image = frame;       //显示图像
           
            //frame.Dispose();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(videoCapture != null && videoCapture.IsOpened)
            {   
                videoCapture.Stop();
                videoCapture.Dispose();
            }
            imagebox1.Visible = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Content = new Register();
        }
    }
}
