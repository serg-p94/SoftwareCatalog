using System.Windows;
using SoftwareCatalog.Core;

namespace SoftwareCatalog.UI.WPF
{
    /// <summary>
    /// Interaction logic for DialogDetails.xaml
    /// </summary>
    public partial class DialogDetails : Window
    {
        private readonly SoftInfo _softInfo;
        public DialogDetails(SoftInfo softInfo)
        {
            InitializeComponent();

            _softInfo = softInfo;
            Title = softInfo.Name;
        }
    }
}
