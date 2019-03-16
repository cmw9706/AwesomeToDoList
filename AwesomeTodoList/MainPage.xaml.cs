using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeTodoList.ViewModels;
using Xamarin.Forms;

namespace AwesomeTodoList
{
    public partial class MainPage : ContentPage
    {
        public ScreenMode TodoListScreenMode { get; set; }

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            switch (TodoListScreenMode) 
            {
                case (ScreenMode.List):
                    var xMove = -1 * (this.Width * .40);
                    var yMove = -1 * (this.Height * .66666);

                    floatingActionButton.TranslateTo(xMove, yMove, 350, Easing.CubicIn);
                    gradientBackground.TranslateTo(0, yMove, 350, Easing.CubicIn);

                    TodoListScreenMode = ScreenMode.AddView;
                    break;
                case (ScreenMode.AddView):
                    floatingActionButton.TranslateTo(0, 0, 350, Easing.CubicOut);
                    gradientBackground.TranslateTo(0, 0, 350, Easing.CubicOut);

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
