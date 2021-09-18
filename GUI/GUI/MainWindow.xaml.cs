using System;
using System.Collections.Concurrent;
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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using LiveCharts.Configurations;
using System.Threading;
using System.Diagnostics;

namespace GUI
{

    public partial class MainWindow : Window
    {

        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "InitIntArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InitIntArray();
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "InitFloatArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InitFloatArray();
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "InitIntList", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InitIntList();
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "InitFloatList", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InitFloatList();

        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "AppendIntArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AppendIntArray(int item);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "AppendFloatArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AppendFloatArray(float item);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "AppendIntList", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AppendIntList(int item);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "AppendFloatList", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AppendFloatList(float item);

        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "RandomIntArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr RandomIntArray(int length, StringBuilder output);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "RandomFloatArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr RandomFloatArray(int length, StringBuilder output);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "RandomIntList", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr RandomIntList(int length, StringBuilder output);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "RandomFloatList", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr RandomFloatList(int length, StringBuilder output);

        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "SortIntArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SortIntArray(int method, int type);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "SortFloatArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SortFloatArray(int method, int type);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "SortIntList", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SortIntList(int method, int type);
        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "SortFloatList", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SortFloatList(int method, int type);

        [DllImport("D:/CProj/lab4/cmake-build-debug/lab4.dll", EntryPoint = "DisplayArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DisplayArray(int arr_number, StringBuilder output);

        Thread bubbleThread;
        private System.Timers.Timer timer;
        public MainWindow()
        {
            InitializeComponent();
            InitIntArray();
            InitFloatArray();
            InitIntList();
            InitFloatList();

            randomColSize = 0;
            canAccess = true;
            bubbleThread = new Thread(BubbleSortThread);

            timeAxis0 = new BlockingCollection<int>();
            last0 = 0;
            line0.Values = new ChartValues<int>();
            
            timer = new System.Timers.Timer(50);
            timer.Elapsed += OnTimedEvent;
            timer.Interval = 50;
            timer.Start();
        }

        private int last0;

        private void OnTimedEvent(object obj, EventArgs args)
        {
            if (!line0.Values.Contains(last0))
            {
                line0.Values.Add(last0);
            }
        }

        private bool canAccess;

        private int randomColSize;

        private void InitButton_Click(object sender, RoutedEventArgs e)
        {
            if (canAccess)
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
                TextLayoutUpdate();
            }
        }

        private void TextLayoutUpdate()
        {
            var textBox = text.Text.Split("\n".ToCharArray());
            if (textBox.Length > 11)
            {
                for(int i = 0; i < textBox.Length - 11; i++)
                {
                    textBox[i] = "";
                }
                text.Text = "";
                for (int i = 0; i < textBox.Length - 1; i++)
                {
                    if(textBox[i] != "") text.Text += textBox[i] + "\n";
                }
            }
        }

        private void LengthScrollbar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Display_Click(object sender, RoutedEventArgs e)
        {
            if (canAccess)
            {
                StringBuilder sb = new StringBuilder(10000);
                if (text.Text.Length > 200)
                {
                    text.Text = "";
                }
                if ((bool)arrBut.IsChecked)
                {
                    if ((bool)intBut.IsChecked)
                    {
                        DisplayArray(0, sb);
                    }
                    if ((bool)floatBut.IsChecked)
                    {
                        DisplayArray(1, sb);
                    }
                }
                if ((bool)listBut.IsChecked)
                {
                    if ((bool)intBut.IsChecked)
                    {
                        DisplayArray(2, sb);
                    }
                    if ((bool)floatBut.IsChecked)
                    {
                        DisplayArray(3, sb);
                    }
                }
                text.Text += sb.ToString() + "\n";
                TextLayoutUpdate();
            }
        }

        private void Append_Click(object sender, RoutedEventArgs e)
        {
            if (canAccess)
            {
                if ((bool)arrBut.IsChecked)
                {
                    if ((bool)intBut.IsChecked)
                    {
                        int item;
                        if (int.TryParse(itemText.Text, out item))
                        {
                            AppendIntArray(item);
                            text.Text += "Item appended!\n";
                        }
                        else
                        {
                            MessageBox.Show("Please! Enter correct number!");
                        }
                    }
                    if ((bool)floatBut.IsChecked)
                    {
                        float item1;
                        if (float.TryParse(itemText.Text, out item1))
                        {
                            AppendFloatArray(item1);
                            text.Text += "Item appended!\n";
                        }
                        else
                        {
                            MessageBox.Show("Please! Enter correct number!");
                        }
                    }
                }
                if ((bool)listBut.IsChecked)
                {
                    if ((bool)intBut.IsChecked)
                    {
                        int item;
                        if (int.TryParse(itemText.Text, out item))
                        {
                            AppendIntList(item);
                            text.Text += "Item appended!\n";
                        }
                        else
                        {
                            MessageBox.Show("Please! Enter correct number!");
                        }
                    }
                    if ((bool)floatBut.IsChecked)
                    {
                        float item1;
                        if (float.TryParse(itemText.Text, out item1))
                        {
                            AppendFloatList(item1);
                            text.Text += "Item appended!\n";
                        }
                        else
                        {
                            MessageBox.Show("Please! Enter correct number!");
                        }
                    }
                }
                TextLayoutUpdate();
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            randomColSize = (int)slider.Value;
            lengthCounter.Content = randomColSize.ToString();
        }

        private void RandFloatList_Click(object sender, RoutedEventArgs e)
        {
            if (canAccess)
            {
                StringBuilder sb = new StringBuilder(10000);
                if ((bool)arrBut.IsChecked)
                {
                    if ((bool)intBut.IsChecked)
                    {
                        RandomIntArray(randomColSize, sb);
                    }
                    if ((bool)floatBut.IsChecked)
                    {
                        RandomFloatArray(randomColSize, sb);
                    }
                }
                if ((bool)listBut.IsChecked)
                {
                    if ((bool)intBut.IsChecked)
                    {
                        RandomIntList(randomColSize, sb);
                    }
                    if ((bool)floatBut.IsChecked)
                    {
                        RandomFloatList(randomColSize, sb);
                    }
                }
                text.Text += sb.ToString() + "\n";
                TextLayoutUpdate();
            }
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            if (canAccess)
            {
                if ((bool)arrBut.IsChecked)
                {
                    if ((bool)intBut.IsChecked)
                    {
                        if ((bool)bubble.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortIntArray(0, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortIntArray(0, 1);
                            }
                        }
                        else if ((bool)insertion.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortIntArray(1, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortIntArray(1, 1);
                            }
                        }
                        else if ((bool)heap.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortIntArray(2, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortIntArray(2, 1);
                            }
                        }
                        else if ((bool)quick.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortIntArray(3, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortIntArray(3, 1);
                            }
                        }
                    }
                    if ((bool)floatBut.IsChecked)
                    {
                        if ((bool)bubble.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortFloatArray(0, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortFloatArray(0, 1);
                            }
                        }
                        else if ((bool)insertion.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortFloatArray(1, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortFloatArray(1, 1);
                            }
                        }
                        else if ((bool)heap.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortFloatArray(2, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortFloatArray(2, 1);
                            }
                        }
                        else if ((bool)quick.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortFloatArray(3, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortFloatArray(3, 1);
                            }
                        }
                    }
                }
                if ((bool)listBut.IsChecked)
                {
                    if ((bool)intBut.IsChecked)
                    {
                        if ((bool)bubble.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortIntList(0, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortIntList(0, 1);
                            }
                        }
                        else if ((bool)insertion.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortIntList(1, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortIntList(1, 1);
                            }
                        }
                        else if ((bool)heap.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortIntList(2, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortIntList(2, 1);
                            }
                        }
                        else if ((bool)quick.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortIntList(3, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortIntList(3, 1);
                            }
                        }
                    }
                    if ((bool)floatBut.IsChecked)
                    {
                        if ((bool)bubble.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortFloatList(0, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortFloatList(0, 1);
                            }
                        }
                        else if ((bool)insertion.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortFloatList(1, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortFloatList(1, 1);
                            }
                        }
                        else if ((bool)heap.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortFloatList(2, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortFloatList(2, 1);
                            }
                        }
                        else if ((bool)quick.IsChecked)
                        {
                            if ((bool)more.IsChecked)
                            {
                                SortFloatList(3, 0);
                            }
                            else if ((bool)less.IsChecked)
                            {
                                SortFloatList(3, 1);
                            }
                        }
                    }
                }
            }
        }

        BlockingCollection<int> timeAxis0 = new BlockingCollection<int>();

        private void BubbleSortThread()
        {
            StringBuilder sb = new StringBuilder(1000);
            for (int i = 1; i < 1000; i++)
            {
                RandomIntArray(i, sb);

                Stopwatch watch = new Stopwatch();
                watch.Start();
                SortIntArray(0, 0);
                watch.Stop();
                last0 = (int) watch.ElapsedMilliseconds;
                timeAxis0.Add((int)watch.ElapsedMilliseconds);
            }
            canAccess = true;
            bubbleThread.Abort();
        }

        private void BuildGraph_Click(object sender, RoutedEventArgs e)
        {
            if (canAccess)
            {
                timeAxis0 = new BlockingCollection<int>();
                canAccess = false;
                if ((bool)arrBut.IsChecked)
                {
                    if ((bool)intBut.IsChecked)
                    {
                        //List<int> timeAxis1 = new List<int>();
                        //List<int> timeAxis2 = new List<int>();
                        //List<int> timeAxis3 = new List<int>();

                        if(!bubbleThread.IsAlive) bubbleThread.Start();
                        //timer.Start();
                    }
                    if ((bool)floatBut.IsChecked)
                    {

                    }
                }
                if ((bool)listBut.IsChecked)
                {
                    if ((bool)intBut.IsChecked)
                    {

                    }
                    if ((bool)floatBut.IsChecked)
                    {

                    }
                }
            }
        }
    }
}
