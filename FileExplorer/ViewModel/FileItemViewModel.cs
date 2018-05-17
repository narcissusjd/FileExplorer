using FileExplorer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Telerik.Windows.Controls;

namespace FileExplorer.ViewModel
{
    class FileItemViewModel
    {
        public FileItemViewModel()
        {
            this.MouseDoubleClickCommand = new DelegateCommand(OnMouseDoubleClickCommandExecuted);
        }

        public ICommand MouseDoubleClickCommand { get; set; }
        private void OnMouseDoubleClickCommandExecuted(object obj)
        {
            var sender = (obj as MouseButtonEventArgs).OriginalSource;
            if (sender is RadListBoxItem)
            {
                FileListItem item = (sender as RadListBox).DataContext as FileListItem;
                (obj as MouseButtonEventArgs).Handled = true;
            }
        }
    }
}
