using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace BlueScreen
{
    /// <summary>
    /// bs.xaml 的交互逻辑
    /// </summary>
    public partial class bs : Window
    {
        ImageSource? qr;
        string? prog, code, link;
        public bs()
        {
            InitializeComponent();
            qr = MainWindow.res;
            QRImage.Source = qr;
            prog = MainWindow.Prog;
            code = MainWindow.ErCode;
            link = MainWindow.Links;
            Progress.Text = $"{prog}% 完成";
            Error.Text = code;
            Link.Text = link;
        }

        /// <summary>
        /// 没用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void a_Changed(object sender, EventArgs e)
        {
            //雪豹闭嘴
        }

        private void CommandBinding_Increase_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
