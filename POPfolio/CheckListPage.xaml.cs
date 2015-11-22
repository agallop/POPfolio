using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Forms;

namespace POPfolio
{
    /// <summary>
    /// Interaction logic for CheckListPage.xaml
    /// </summary>
    public partial class CheckListPage : Page
    {
        private String [] basicInformation;
        private String photo;
        public CheckListPage()
        {
            InitializeComponent();
            basicInformation = new String[3];
        }

        private void basicInformationButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BasicInformationPage(basicInformation));
            if (basicInformation[0] != "")
            {
                basicInformationButton.Background = new SolidColorBrush(Colors.Cyan);
                basicInformationButton.Foreground = new SolidColorBrush(Colors.Red);
            }
            checkCanGenerate();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                photo = dlg.FileName;
                photoButton.Background = new SolidColorBrush(Colors.Cyan);
                photoButton.Foreground = new SolidColorBrush(Colors.Red);
            }
            checkCanGenerate();
        }

        private void checkCanGenerate()
        {
            generateButton.IsEnabled = basicInformation[0] != "" && photo != null;
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            String folder = dialog.SelectedPath;

            outputFile(folder);
        }

        private void outputFile(String folder)
        {
            String indexFile = folder + "\\index.html";
            StreamWriter writer = new StreamWriter(indexFile);

            //head
            writer.Write("<html>\n<head>\n\t<title>\n\t\t");
            writer.Write(basicInformation[0]);
            writer.Write("\n\t</title>\n</head>\n");

            //body
            writer.Write("<body>\n\t<p>");
            writer.Write(basicInformation[0]);
            writer.Write("</p>\n\t<p>");
            writer.Write(basicInformation[1]);
            writer.Write("</p>\n\t<p>");
            writer.Write(basicInformation[2]);
            writer.Write("</p>\n\t");
            writer.Write("<img src=\"");
            writer.Write(photo);
            writer.Write("\" />\n<body>\n");

            writer.Write("</html>");

            writer.Close();
            System.Diagnostics.Process.Start(indexFile);

        }
    }
}
