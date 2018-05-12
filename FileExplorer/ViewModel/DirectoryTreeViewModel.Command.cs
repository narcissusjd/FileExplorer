using FileExplorer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using Telerik.Windows;
using Telerik.Windows.Controls;

namespace FileExplorer.ViewModel
{
    partial class DirectoryTreeViewModel : ViewModelBase
    {

        public ICommand ExpandedCommand { get; set; }

        private void OnExpandedCommandExecuted(object obj)
        {
            var expandedItem = (obj as RadRoutedEventArgs).OriginalSource as RadTreeViewItem;
            ExplorerItem item = expandedItem.Tag as ExplorerItem;
            foreach(ExplorerItem  child in item.Children)
            {
                child.Children = GetChildren(child.Info as DirectoryInfo);
            }
        }

        public ICommand SelectionChangedCommand { get; set; }

        private void OnSelectionChangedCommandExecuted(object obj)
        {
            var view = (obj as SelectionChangedEventArgs).OriginalSource as RadTreeView;

            ExplorerItem item = view.SelectedItem as ExplorerItem;
            this.SelectedDirectory = item.Info as DirectoryInfo;
        }
    }
}
