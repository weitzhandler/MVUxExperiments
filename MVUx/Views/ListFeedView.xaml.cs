// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml.Controls;
using MVUx.Data;
using MVUx.Presentation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MVUx.Views;

public sealed partial class ListFeedView : UserControl
{
    public ListFeedView()
    {
        this.InitializeComponent();

        var dataStore = new DataStore();
        var bindableVM = new MainViewModel.BindableMainViewModel(dataStore);

        this.DataContext = bindableVM;
    }
}
