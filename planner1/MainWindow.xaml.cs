﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Text.RegularExpressions;

namespace planner1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InfoTextBox_DragOver(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
                e.Effects = System.Windows.DragDropEffects.Copy;
            else
                e.Effects = System.Windows.DragDropEffects.None;
            e.Handled = true;
        }

        private void InfoTextBox_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
            //    e.Effects = System.Windows.DragDropEffects.Copy;
            //else
            //    e.Effects = System.Windows.DragDropEffects.None;
            //e.Handled = true;
            string url = e.Data.GetData(DataFormats.StringFormat).ToString();
            if (url.Contains("\n")) url = url.Substring(0, url.IndexOf("\n"));
            WebClient x = new WebClient();
            string source = x.DownloadString("https://learn.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.stackpanel?view=winrt-22621");
            string title = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>",
            RegexOptions.IgnoreCase).Groups["Title"].Value;
            FileNameLabel.Content = title;
        }

        private void InfoTextBox_Drop(object sender, System.Windows.DragEventArgs e)
        {
            string url = e.Data.GetData(DataFormats.StringFormat).ToString();
            Trace.WriteLine("Current 1: " + url);
        }

        //private void FileDropStackPanel_Drop(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
        //    {
        //        Trace.WriteLine("Current Date and time is : " + e);
        //        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

        //        string names = System.IO.Path.GetFileName(files[0]);

        //        FileNameLabel.Content = names;
        //    }
        //}
    }
}
