using FileExplorer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;

namespace FileExplorer.ViewModel
{
    partial class DirectoryTreeViewModel : ViewModelBase
    {
        DirectoryInfo selectedDirectory;
        ObservableCollection<ExplorerItem> items;

        public DirectoryInfo SelectedDirectory { get => selectedDirectory; set { selectedDirectory = value; this.OnPropertyChanged("SelectDirectory"); } }

        public ObservableCollection<ExplorerItem> Items { get => items; set => items = value; }

        public DirectoryTreeViewModel()
        {
            items = new ObservableCollection<ExplorerItem>();
            this.ExpandedCommand = new DelegateCommand(OnExpandedCommandExecuted);
            this.SelectionChangedCommand = new DelegateCommand(OnSelectionChangedCommandExecuted);

            BitmapImage driveImg= new BitmapImage(new Uri("Images/Icons/Drive.ico", UriKind.RelativeOrAbsolute));
            //BitmapImage driveImg = new BitmapImage(new Uri("Images/Icons/Drive.ico", UriKind.RelativeOrAbsolute));
            ExplorerItem root = new ExplorerItem();
            root.Header = "My Computer";
            root.IconSource = new BitmapImage(new Uri("Images/Icons/iMac Unibody 27.ico", UriKind.RelativeOrAbsolute));
            foreach(DriveInfo drive in DriveInfo.GetDrives())
            {
                ExplorerItem item = new ExplorerItem();
                item.Header = drive.Name;
                item.Path = drive.Name;
                item.FullPath = drive.RootDirectory.FullName;
                item.Info = drive.RootDirectory;
                item.IconSource = driveImg;
                item.Children = GetChildren(drive.RootDirectory);
                root.Children.Add(item);
            }
            items.Add(root);
        }

        public ObservableCollection<ExplorerItem> GetChildren(DirectoryInfo parent)
        {
            ObservableCollection<ExplorerItem> children = new ObservableCollection<ExplorerItem>();
            try
            {
                var directories = parent.EnumerateDirectories().GetEnumerator();
                while(directories.MoveNext())
                {
                    DirectoryInfo di = directories.Current;
                    ExplorerItem child = new ExplorerItem();
                    child.Header = di.Name;
                    child.Info = di;
                    child.Path = di.Name;
                    child.FullPath = di.FullName;
                    children.Add(child);
                }
            }
            catch
            { }
            return children;
        }
    }
}
