using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AwesomeTodoList.SubViews
{
    public partial class AddItemView : ContentView
    {
        public Entry AddedTask { get; set; }

        public EventHandler TaskAdded { get; set; }

        public AddItemView()
        {
            InitializeComponent();

            //AddButton = addButton;
            AddedTask = addedTask;
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            TaskAdded.Invoke(this, new EventArgs());
        }
    }
}
