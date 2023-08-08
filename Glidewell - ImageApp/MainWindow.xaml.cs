using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ImageProcessingApp
{
    public partial class MainWindow : Window
    {
        private BitmapImage loadedImage;
        private BitmapImage depthMapImage;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenImage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                loadedImage = new BitmapImage(new Uri(openFileDialog.FileName));
                ImageViewer.Source = loadedImage;
            }
        }

        private void OpenDepthMap_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                depthMapImage = new BitmapImage(new Uri(openFileDialog.FileName));
                DepthMapViewer.Source = depthMapImage;
            }
        }

        private void Reconstruct3D_Click(object sender, RoutedEventArgs e)
        {
            if (loadedImage != null && depthMapImage != null)
            {
                // Reconstruct 3D effect logic
                // Apply the depth map to the loadedImage to create the 3D effect
                // You need to implement this part based on your specific algorithm
            }
            else
            {
                MessageBox.Show("Open an image and a depth map before reconstructing 3D.");
            }
        }

        private void Grayscale_Click(object sender, RoutedEventArgs e)
        {
            if (loadedImage != null)
            {
                // Convert the loadedImage to grayscale
                BitmapSource grayscaleImage = ConvertToGrayscale(loadedImage);
                ImageViewer.Source = grayscaleImage;
            }
        }

        private BitmapSource ConvertToGrayscale(BitmapSource source)
        {
            FormatConvertedBitmap grayscaleBitmap = new FormatConvertedBitmap(source, PixelFormats.Gray8, null, 0);
            return grayscaleBitmap;
        }

        private void NewWidthTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NewWidthTextBox.Text == "New Width")
            {
                NewWidthTextBox.Text = string.Empty;
                NewWidthTextBox.Foreground = Brushes.Black;
            }
        }

        private void NewWidthTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewWidthTextBox.Text))
            {
                NewWidthTextBox.Text = "New Width";
                NewWidthTextBox.Foreground = Brushes.Gray;
            }
        }

        private void NewHeightTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NewHeightTextBox.Text == "New Height")
            {
                NewHeightTextBox.Text = string.Empty;
                NewHeightTextBox.Foreground = Brushes.Black;
            }
        }

        private void NewHeightTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewHeightTextBox.Text))
            {
                NewHeightTextBox.Text = "New Height";
                NewHeightTextBox.Foreground = Brushes.Gray;
            }
        }

        private void Resize_Click(object sender, RoutedEventArgs e)
        {
            if (loadedImage != null)
            {
                int newWidth = int.Parse(NewWidthTextBox.Text);
                int newHeight = int.Parse(NewHeightTextBox.Text);

                // Create a TransformedBitmap to resize the loadedImage
                TransformedBitmap resizedBitmap = new TransformedBitmap();
                resizedBitmap.BeginInit();
                resizedBitmap.Source = loadedImage;
                resizedBitmap.Transform = new ScaleTransform(newWidth / loadedImage.Width, newHeight / loadedImage.Height);
                resizedBitmap.EndInit();

                // Display the resized image
                ImageViewer.Source = resizedBitmap;
            }
            else
            {
                MessageBox.Show("Open an image before resizing.");
            }
        }

        private void SaveImage_Click(object sender, RoutedEventArgs e)
        {
            // Implement the Save Image logic here
        }
    }
}
