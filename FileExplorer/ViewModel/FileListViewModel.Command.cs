using FileExplorer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;

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
    }
}
