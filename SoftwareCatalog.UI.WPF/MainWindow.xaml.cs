using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SoftwareCatalog.Core;
using SoftwareCatalog.DAL;

namespace SoftwareCatalog.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string StoragePath = "storage.json";

        private readonly SoftInfoStorage _storage;
        private readonly SoftInfoSerializer _serializer = new SoftInfoSerializer();

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                _storage = new SoftInfoSerializer().Load(StoragePath);
            }
            catch (Exception ex)
            {
                _storage = new SoftInfoStorage();
            }
            foreach (var softInfo in _storage)
            {
                ViewSoftInfo(softInfo);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            StartAddDialog();
        }

        private void ViewSoftInfo(SoftInfo softInfo)
        {
            var itemDetails = new MenuItem
            {
                Header = "Details"
            };
            itemDetails.Click += (sender, args) =>
            {
                new DialogDetails(softInfo).ShowDialog();
            };

            ListBoxSoft.Items.Add(new CheckBox
            {
                Content = softInfo,
                ContextMenu = new ContextMenu
                {
                    ItemsSource = new[] { itemDetails}
                },
                Width = ListBoxSoft.Width
            });
        }

        private void AddSoftInfo(SoftInfo softInfo)
        {
            _storage.Add(softInfo);
            ViewSoftInfo(softInfo);
        }

        private async void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            await _serializer.SaveAsync(_storage, StoragePath);
            MessageBox.Show("Data saved!");
        }

        private async void ListBoxSoft_Drop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }
            var data = e.Data.GetData(DataFormats.FileDrop) as IEnumerable<string>;
            var files = new Queue<string>(data ?? Enumerable.Empty<string>());
            StartAddDialog(files);
        }

        private void StartAddDialog(Queue<string> files)
        {
            if (files.Count == 0)
            {
                return;
            }
            var file = files.Dequeue();
            var dialog = new DialogAddSoft
            {
                Owner = this,
                Path = file
            };
            dialog.Closed += (sender, args) =>
            {
                if (dialog.SoftInfo != null)
                {
                    AddSoftInfo(dialog.SoftInfo);
                }
                StartAddDialog(files);
            };
            dialog.ShowDialog();
        }

        private DialogAddSoft StartAddDialog()
        {
            var dialog = new DialogAddSoft
            {
                Owner = this
            };
            dialog.Closed += (sender, args) =>
            {
                AddSoftInfo(dialog.SoftInfo);
            };
            dialog.ShowDialog();
            return dialog;
        }
    }
}
