using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using SoftwareCatalog.Core;

namespace SoftwareCatalog.UI.WPF
{
    /// <summary>
    /// Interaction logic for DialogAddSoft.xaml
    /// </summary>
    public partial class DialogAddSoft : Window
    {
        public SoftInfo SoftInfo { get; set; }

        public string Path
        {
            get { return TextBoxPath.Text; }
            set { TextBoxPath.Text = value; }
        }

        public DialogAddSoft()
        {
            InitializeComponent();
        }

        private void ButtonDone_Click(object sender, RoutedEventArgs e)
        {
            SoftInfo = new SoftInfo
            {
                Name = TextBoxName.Text,
                Path = TextBoxPath.Text,
                LastUpdateDate = DateTime.Now
            };
            Close();
        }

        private void ButtonSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                Filter = ".exe|*.exe",
                Title = "Select Appliction"
            };
            dialog.FileOk += (o, args) =>
            {
                TextBoxPath.Text = dialog.FileName;
            };
            dialog.ShowDialog();
        }
    }
}
