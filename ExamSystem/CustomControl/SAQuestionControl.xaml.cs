﻿using System;
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
    /// SAQuestionControl.xaml 的交互逻辑
    /// </summary>
    public partial class SAQuestionControl : UserControl
    {
        public SAQuestionControl()
        {
            InitializeComponent();
        }


        public string GetAnswer()
        {
            return Answers.Text;
        }
    }
}