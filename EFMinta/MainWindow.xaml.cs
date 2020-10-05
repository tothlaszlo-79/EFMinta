using System;
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
using DataAccessLayer.Controller;
using DataAccessLayer.AdditionalModels;


namespace EFMinta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            betoltSingleTable();
            betoltOsszetettAdat();
        }

        private void betoltSingleTable()
        {
            SingleTableController singleTab = new SingleTableController();
            dg1.ItemsSource = singleTab.GetAll();

        }

        private void betoltOsszetettAdat()
        {
            TableWithForigenKeyController controller = new TableWithForigenKeyController();
            dg2.ItemsSource = controller.GetAll_linked();
        }
    }
}
