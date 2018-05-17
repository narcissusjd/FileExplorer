using FileExplorer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Telerik.Windows.Controls;

namespace FileExplorer.ViewModel
{
    partial class FileListViewModel
    {

        public void Report(FileListItem item)
        {
            try
            {
                if (item.Info is DirectoryInfo)
                {
                    item.IconSource = new BitmapImage(new Uri("/Images/Icons/GenericFolderIcon.ico", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    System.Drawing.Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(item.Info.FullName);
                    item.IconSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(icon.Handle, new Int32Rect(0, 0, icon.Width, icon.Height), BitmapSizeOptions.FromEmptyOptions());
                }
            }
            catch
            { }
            Items.Add(item);
        }

        public ICommand SelectionChangedCommand { get; set; }

        private void OnSelectionChangedCommandExecuted(object obj)
        {

        }

        public ICommand MouseDoubleClickCommand { get; set; }

        private void OnMouseDoubleClickCommandExecuted(object obj)
        {
            var sender = (obj as MouseButtonEventArgs).OriginalSource;
            if(sender is RadListBoxItem)
            {
                FileListItem item = (sender as RadListBox).DataContext as FileListItem;
                (obj as MouseButtonEventArgs).Handled = true;
            }
            
        }
    }
}
