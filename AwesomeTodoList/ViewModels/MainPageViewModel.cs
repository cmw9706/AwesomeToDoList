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
                    Task = "It was a bright cold day in April, and the clocks were striking thirteen."
                },
                new TodoItem
                {
                    Id = 2,
                    Task = "Someone must have slandered Josef K., for one morning, without having done anything truly wrong, he was arrested."
                },
                new TodoItem
                {
                    Id = 3,
                    Task = "All this happened, more or less."
                },
            };

        }
    }
}
