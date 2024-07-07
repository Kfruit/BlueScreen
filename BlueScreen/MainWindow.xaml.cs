using QRCoder;
using System.Drawing;
using System.IO;
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

namespace BlueScreen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("此项目仅供娱乐。", "重要消息：食用须知", MessageBoxButton.OK, MessageBoxImage.Information);
            MessageBox.Show("当“蓝屏模拟器”启动时，按下Ctrl+Q退出界面", "重要消息：热键", MessageBoxButton.OK, MessageBoxImage.Information);
            QRCodeGenerator? sqrGenerator = new QRCodeGenerator();
            QRCodeData? sqrCodeData = sqrGenerator.CreateQrCode(qrcode.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode? sqrCode = new QRCode(sqrCodeData);
            Bitmap? sb = new Bitmap(sqrCode.GetGraphic(20, "#6CA5EF","#FFFFFF",true));
            MemoryStream? sms = new MemoryStream();
            sb.Save(sms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = sms.GetBuffer();  //byte[]   bytes=   ms.ToArray(); 这两句都可以
            sms.Close();
            //Convert it to BitmapImage
            BitmapImage? simage = new BitmapImage();
            simage.BeginInit();
            simage.StreamSource = new MemoryStream(bytes);
            simage.EndInit();
            QRresult.Source = simage;
            res = simage;
            //就是删
            sqrGenerator = null;
            sqrCodeData = null;
            sqrCode = null;
            sb = null;
            simage = null;
            Prog = prog.Text;
            Links = qrcode.Text;
            ErCode = endcode.Text;
        }

        private void qrcode_KeyDown(object sender, KeyEventArgs e)
        {

        }
        public static ImageSource? res;
        public static string? ErCode,Links,Prog;
        private void qrcode_KeyUp(object sender, KeyEventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrcode.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap b = new Bitmap(qrCode.GetGraphic(20, "#2A8ADC", "#FFFFFF", true));
            MemoryStream ms = new MemoryStream();
            b.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = ms.GetBuffer();  //byte[]   bytes=   ms.ToArray(); 这两句都可以
            ms.Close();
            //Convert it to BitmapImage
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(bytes);
            image.EndInit();
            QRresult.Source = image;
            res = image;
            Links = qrcode.Text;
        }

        private void endcode_KeyUp(object sender, KeyEventArgs e)
        {
            ErCode = endcode.Text;
        }

        private void prog_KeyUp(object sender, KeyEventArgs e)
        {
            Prog = prog.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("“蓝屏模拟器”启动时，按下Ctrl+Q退出界面","重要消息：热键",MessageBoxButton.OK,MessageBoxImage.Information);
            bs BS = new();
            BS.Show();
        }
    }
}