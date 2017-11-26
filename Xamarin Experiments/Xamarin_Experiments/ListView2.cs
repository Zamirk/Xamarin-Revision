using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin_Experiments
{
    public class ListView2 : ContentPage
    {
        public ListView2()
        {
            //Layout
            StackLayout myStackLayout = new StackLayout();
            myStackLayout.Orientation = StackOrientation.Vertical;
            myStackLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            myStackLayout.VerticalOptions = LayoutOptions.FillAndExpand;

            //Entry
            EntryCell myEntryCell = new EntryCell();
            myEntryCell.Label = "Name";
            myEntryCell.Placeholder = "Enter Name";

            //Entry
            EntryCell myEntryCell2 = new EntryCell();
            myEntryCell2.Label = "Age";
            myEntryCell2.Placeholder = "Enter Age";

            //Entry
            EntryCell myEntryCell3 = new EntryCell();
            myEntryCell3.Label = "Email";
            myEntryCell3.Placeholder = "Enter Email";

            //Entry
            EntryCell myEntryCell4 = new EntryCell();
            myEntryCell4.Label = "Phone";
            myEntryCell4.Placeholder = "Enter Phone";

            //Picker
            //toolkit: PickerCel

            //Switch Cell
            SwitchCell mySwitchCell = new SwitchCell();
            mySwitchCell.Text = "My Switch";

            //Table
            TableView myTableView = new TableView();
            myTableView.HorizontalOptions = LayoutOptions.FillAndExpand;
            myTableView.VerticalOptions = LayoutOptions.FillAndExpand;
            myTableView.BackgroundColor = Color.White;

            TableSection myTableSection = new TableSection();
            myTableView.Root = new TableRoot();
            myTableView.Root.Add(myTableSection);

            //Adding Cells
            myTableSection.Add(myEntryCell);
            myTableSection.Add(myEntryCell2);
            myTableSection.Add(myEntryCell3);
            myTableSection.Add(myEntryCell4);
            myTableSection.Add(mySwitchCell);

            myStackLayout.Children.Add(myTableView);
            Content = myStackLayout;
        }
    }
}
