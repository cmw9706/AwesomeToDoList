using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeTodoList.SubViews;
using AwesomeTodoList.ViewModels;

using Xamarin.Forms;

namespace AwesomeTodoList
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel { get; set; }

        public ScreenMode TodoListScreenMode { get; set; }

        public AddItemView AddView { get; set; }

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();

            ViewModel = (MainPageViewModel)BindingContext;

        }

        void AddedSubView_TaskAdded(object sender, EventArgs e)
        {
            var task = addedSubView.AddedTask.Text;

            ViewModel.AddItem(task);

            Handle_Clicked(this, new EventArgs());
        }


        void Handle_Clicked(object sender, System.EventArgs e)
        {
            switch (TodoListScreenMode) 
            {
                case (ScreenMode.List):
                    var xMove = -1 * (this.Width * .40);
                    var yMove = -1 * (this.Height * .99);

                    floatingActionButton.TranslateTo(xMove, (yMove * .80), 350, Easing.CubicIn);
                    floatingActionButton.RotateTo(45, 350);
                    gradientBackground.TranslateTo(0, yMove, 350, Easing.CubicIn);
                    list.TranslateTo(0, yMove, 350 ,Easing.CubicIn);

                    addView.TranslateTo(0, yMove, 350, Easing.CubicIn);
                    addedSubView.TaskAdded += AddedSubView_TaskAdded;

                    TodoListScreenMode = ScreenMode.AddView;
                    break;
                case (ScreenMode.AddView):
                    addedSubView.AddedTask.Text = string.Empty;

                    floatingActionButton.TranslateTo(0, 0, 350, Easing.CubicOut);
                    floatingActionButton.RotateTo(0, 350);
                    gradientBackground.TranslateTo(0, 0, 350, Easing.CubicOut);
                    list.TranslateTo(0, 0, 350 ,Easing.CubicOut);

                    addedSubView.TaskAdded -= AddedSubView_TaskAdded;

                    addView.TranslateTo(0, 0, 350, Easing.CubicOut);

                    TodoListScreenMode = ScreenMode.List;
                    break;
            }
        }
    }
    public enum ScreenMode
    {
        List,
        AddView
    }
}
