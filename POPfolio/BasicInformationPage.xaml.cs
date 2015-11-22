using System;
using System.Collections;
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

namespace POPfolio
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class BasicInformationPage : Page
    {
        private String[] list;
        public BasicInformationPage()
        {
            InitializeComponent();
        }
        public BasicInformationPage(String [] newList)
        {
            InitializeComponent();
            list = newList;
            nameEntry.Text = list[0];
            emailEntry.Text = list[1];
            phoneEntry.Text = list[2];
        }
        

        private void Button_Click(object sender, RoutedEventArgs e) {
            list[0] = nameEntry.Text;
            list[1] = emailEntry.Text;
            list[2] = phoneEntry.Text;
            this.NavigationService.GoBack();
        }
    }
}
