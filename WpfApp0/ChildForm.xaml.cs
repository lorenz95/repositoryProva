using System.Windows;
using WpfLibrary;

namespace WpfApp0;

/// <summary>
/// Logica di interazione per ChildForm.xaml
/// </summary>
public partial class ChildForm : Window
{
    public IDataAccess _dataAccess { get; }

    public ChildForm(IDataAccess dataAccess)
    {
        InitializeComponent();
        _dataAccess = dataAccess;
        dataAccessInfo.Text = _dataAccess.GetData();
    }
}
