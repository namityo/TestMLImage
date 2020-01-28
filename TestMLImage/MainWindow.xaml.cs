using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace TestMLImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string fileName = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonSelectImage_Click(object sender, RoutedEventArgs e)
        {
            // ダイアログのインスタンスを生成
            var dialog = new OpenFileDialog();

            // ファイルの種類を設定
            dialog.Filter = "画像ファイル (*.jpg;*.jpeg;*.JPG;*.JPEG)|*.jpg;*.jpeg";

            // ダイアログを表示する
            if (dialog.ShowDialog() == true)
            {
                fileName = dialog.FileName;

                image.Source = FileToBitmapImage(dialog.FileName);
            }
        }

        private void buttonAnalyzeImage_Click(object sender, RoutedEventArgs e)
        {
            // TODO 解析処理
            textBlock.Text = "";
        }

        /// <summary>
        /// ファイルをBitmapImageに変換する
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static BitmapImage FileToBitmapImage(string filePath)
        {
            BitmapImage bi = null;

            try
            {
                using (FileStream fs = File.OpenRead(filePath))
                {
                    bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = fs;
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.EndInit();
                }
            }
            catch (Exception)
            {
                bi = null;
            }

            return bi;
        }
    }
}
