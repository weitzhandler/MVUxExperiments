using Microsoft.UI.Xaml.Controls;
using MVUx.Data;
using MVUx.Presentation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MVUx;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();

        var dataStore = new DataStore();
        var bindableVM = new MainViewModel.BindableMainViewModel(dataStore);

        this.DataContext = bindableVM;
    }
}
