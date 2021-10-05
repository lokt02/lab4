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
        Thread insertionThread;
        // Thread heapThread;
        Thread quickThread;

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
            insertionThread = new Thread(InsertionSortThread);
            // heapThread = new Thread(HeapSortThread);
            quickThread = new Thread(QuickSortThread);
        }

        private BlockingCollection<double> timeAxis0;
        private BlockingCollection<double> timeAxis1;
        private BlockingCollection<double> timeAxis2;
        private BlockingCollection<double> timeAxis3;

        private int last0;
        private int last1;
        private int last2;
        private int last3;

        private void OnTimedEvent(object obj, EventArgs args)
        {
            if (line0.Values.Count < timeAxis0.Count)
            {
                for (int i = line0.Values.Count; i < timeAxis0.Count; i++)
                {
                    line0.Values.Add(timeAxis0.ToArray()[i]);
                }
            }
            if (line1.Values.Count < timeAxis1.Count)
            {
                for (int i = line1.Values.Count; i < timeAxis1.Count; i++)
                {
                    line1.Values.Add(timeAxis1.ToArray()[i]);
                }
            }
            if (line2.Values.Count < timeAxis2.Count)
            {
                for (int i = line2.Values.Count; i < timeAxis2.Count; i++)
                {
                    line2.Values.Add(timeAxis2.ToArray()[i]);
                }
            }
            if (line3.Values.Count < timeAxis3.Count)
            {
                for (int i = line3.Values.Count; i < timeAxis3.Count; i++)
                {
                    line3.Values.Add(timeAxis3.ToArray()[i]);
                }
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
                        else if (/*(bool)heap.IsChecked*/ false)
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
                        else if (/*(bool)heap.IsChecked*/ false)
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
                        else if (/*(bool)heap.IsChecked*/ false)
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
                        else if (/*(bool)heap.IsChecked*/ false)
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

        private void BubbleSortThread()
        {
            Dispatcher.Invoke(() =>
            {
                line0.Values = new ChartValues<int>();
            });
            StringBuilder sb = new StringBuilder(1000);
            int i = 400;
            int delta = 1;
            while (i < 1500)
            {
                RandomIntArray(i, sb);

                Stopwatch watch = new Stopwatch();
                watch.Start();
                SortIntArray(0, 0);
                watch.Stop();
                Dispatcher.Invoke(() =>
                {
                    line0.Values.Add((int)watch.ElapsedMilliseconds);
                });
                i += delta;
                if (i % 50 == 0)
                {
                    delta += 5;
                }
            }
            insertionThread.Start();
            timeChart.Update();
        }
        private void InsertionSortThread()
        {
            Dispatcher.Invoke(() =>
            {
                line1.Values = new ChartValues<int>();
            });
            StringBuilder sb = new StringBuilder(1000);
            int i = 400;
            int delta = 1;
            while (i < 1500)
            {
                RandomIntArray(i, sb);

                Stopwatch watch = new Stopwatch();
                watch.Start();
                SortIntArray(1, 0);
                watch.Stop();
                Dispatcher.Invoke(() =>
                {
                    line1.Values.Add((int)watch.ElapsedMilliseconds);
                });
                i += delta;
                if (i % 50 == 0)
                {
                    delta += 5;
                }
            }
            // heapThread.Start();
            quickThread.Start();
            timeChart.Update();
        }
        private void HeapSortThread()
        {
            Dispatcher.Invoke(() =>
            {
                line2.Values = new ChartValues<int>();
            });
            StringBuilder sb = new StringBuilder(1000);
            int i = 400;
            int delta = 1;
            while (i < 1500)
            {
                RandomIntArray(i, sb);

                Stopwatch watch = new Stopwatch();
                watch.Start();
                SortIntArray(2, 0);
                watch.Stop();
                Dispatcher.Invoke(() =>
                {
                    line2.Values.Add((int)watch.ElapsedMilliseconds);
                });
                i += delta;
                if (i % 50 == 0)
                {
                    delta += 5;
                }
            }
            quickThread.Start();
            timeChart.Update();
            canAccess = true;
        }
        private void QuickSortThread()
        {
            Dispatcher.Invoke(() =>
            {
                line3.Values = new ChartValues<int>();
            });
            StringBuilder sb = new StringBuilder(1000);
            int i = 400;
            int delta = 1;
            while (i < 1500)
            {
                RandomIntArray(i, sb);

                Stopwatch watch = new Stopwatch();
                watch.Start();
                SortIntArray(3, 0);
                watch.Stop();
                Dispatcher.Invoke(() =>
                {
                    line3.Values.Add((int)watch.ElapsedMilliseconds);
                });
                i += delta;
                if (i % 50 == 0)
                {
                    delta += 5;
                }
            }
            timeChart.Update();
            canAccess = true;
        }

        private void BuildGraph_Click(object sender, RoutedEventArgs e)
        {
            if (canAccess)
            {
                canAccess = false;
                bubbleThread.Start();
            }
        }
    }
}
