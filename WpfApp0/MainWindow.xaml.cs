using System.Windows;
using WpfApp0.StartUpHelpers;
using WpfLibrary;

namespace WpfApp0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDataAccess _dataAccess;
        private readonly IAbstractFactory<ChildForm> factory;

        public MainWindow(IDataAccess dataAccess, IAbstractFactory<ChildForm> factory)
        {
            InitializeComponent();
            _dataAccess = dataAccess;
            this.factory = factory;
        }

        private void getData_Click(object sender, RoutedEventArgs e)
        {
            data.Text = _dataAccess.GetData();
        }

        private void openChildForm_Click(object sender, RoutedEventArgs e)
        {
            factory.Create().Show();
        }
    }
}
