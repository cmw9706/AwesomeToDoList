using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AwesomeTodoList.Models;
using Xamarin.Forms;

namespace AwesomeTodoList.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TodoItem> _todoItems;
        public FileImageSource _fabImageSource;

        public ObservableCollection<TodoItem> TodoItems 
        { 
            get => _todoItems;
            set 
            { 
                _todoItems = value;
                NotifyPropertyChanged(nameof(TodoItems));
            }
        }

        public FileImageSource FabImageSource 
        {
            get => _fabImageSource;
            private set
            {
                _fabImageSource = value;
                NotifyPropertyChanged(nameof(FabImageSource));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public MainPageViewModel()
        {
            TodoItems = new ObservableCollection<TodoItem>
            {
                new TodoItem
                {
                    Id = 1,
                    Task = "Go milk the cow!"
                },
                new TodoItem
                {
                    Id = 2,
                    Task = "Cover yourself in bologna"
                },
                new TodoItem
                {
                    Id = 3,
                    Task = "Rethink your life choices"
                },
            };

        }

        public void AddItem(string task) 
        {
            var newList = TodoItems;
            newList.Add(new TodoItem { Id = TodoItems.Count + 1, Task = task });
            TodoItems = newList;
        }
    }
}
