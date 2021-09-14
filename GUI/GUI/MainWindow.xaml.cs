using System;
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

        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "InitIntArray")]
        public static extern IntPtr InitIntArray();
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "InitFloatArray")]
        public static extern IntPtr InitFloatArray();
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "InitIntList")]
        public static extern IntPtr InitIntList();
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "InitFloatList")]
        public static extern IntPtr InitFloatList();

        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "AppendIntArray")]
        public static extern void AppendIntArray(int item);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "AppendFloatArray")]
        public static extern void AppendFloatArray(float item);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "AppendIntList")]
        public static extern void AppendIntList(int item);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "AppendFloatList")]
        public static extern void AppendFloatList(float item);

        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "RandomIntArray")]
        public static extern IntPtr RandomIntArray(int length);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "RandomFloatArray")]
        public static extern IntPtr RandomFloatArray(int length);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "RandomIntList")]
        public static extern IntPtr RandomIntList(int length);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "RandomFloatList")]
        public static extern IntPtr RandomFloatList(int length);

        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "SortIntArray")]
        public static extern void SortIntArray();
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "SortFloatArray")]
        public static extern void SortFloatArray();
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "SortIntList")]
        public static extern void SortIntList();
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "SortFloatList")]
        public static extern void SortFloatList();

        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "DisplayArray")]
        public static extern IntPtr DisplayArray(int arr_number);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)arrBut.IsChecked)
            {
                if ((bool)intBut.IsChecked)
                {
                    text.Text += Marshal.PtrToStringAnsi(InitIntArray());
                }
                if ((bool)floatBut.IsChecked)
                {
                    text.Text += Marshal.PtrToStringAnsi(InitFloatArray());
                }
            }
            if ((bool)listBut.IsChecked)
            {
                if ((bool)intBut.IsChecked)
                {
                    text.Text += Marshal.PtrToStringAnsi(InitIntList());
                }
                if ((bool)floatBut.IsChecked)
                {
                    text.Text += Marshal.PtrToStringAnsi(InitFloatList());
                }
            }
            text.Text += "\n";
        }

        private void LengthScrollbar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
