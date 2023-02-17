using InspectorGadget.Tmx.Plugin.ViewModels;
using Tecnomatix.Engineering.Ui.WPF;

namespace InspectProgram.Tmx.Plugin.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : TxWindow
    {
        public MainWindow(VMMain viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public VMMain ViewModel => DataContext as VMMain;
    }
}
