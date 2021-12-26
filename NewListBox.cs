using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows;
using System.Collections;

namespace HelpEvent
{
    public class NewListBox : ListBox
    {
        public NewListBox()
        {
            this.SelectionChanged += NewListBox_SelectionChanged;
        }

        void NewListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedItemsList.Clear();
            foreach (var item in this.SelectedItems) 
            { this.SelectedItemsList.Add(item); }
        }
        #region SelectedItemsList

        public IList SelectedItemsList
        {
            get { return (IList)GetValue(SelectedItemsListProperty); }
            set { SetValue(SelectedItemsListProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemsListProperty =
                DependencyProperty.Register("SelectedItemsList", typeof(IList), typeof(NewListBox), new PropertyMetadata(null));

        #endregion
    }
}
