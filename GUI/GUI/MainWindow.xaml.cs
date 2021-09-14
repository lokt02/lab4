﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace GUI
{

    public partial class MainWindow : Window
    {

        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "LabFunc")]
        public static extern IntPtr LabFunc();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnTextBoxInit(object sender, EventArgs e)
        {

            textBox.Text = Marshal.PtrToStringAnsi(LabFunc());
            // textBox.Text = LabFunc().ToString();
        }
    }
}
