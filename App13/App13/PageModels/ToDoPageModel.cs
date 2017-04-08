using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App13.PageModels
{
    [ImplementPropertyChanged]
    public class ToDoPageModel : FreshMvvm.FreshBasePageModel
    {
        public ObservableCollection<ToDoItem> ToDoItems { get; } = new ObservableCollection<ToDoItem>();
        private string path;

        public ToDoPageModel(IDataBasePath dbPath)
        {
            System.Collections.Generic.List<ToDoItem> lst = null;
            path = dbPath.GetPath();

            using (var db = new ToDoContext(path))
            {
                var dbTask = db.Database.EnsureCreatedAsync();
                dbTask.Wait();
                lst = db.ToDoItems.ToList();
                if (lst.Count < 1)
                {
                    ToDoItem todo = new ToDoItem() { Completed = false, Description = "Test To Do Item" };
                    db.ToDoItems.Add(todo);
                    db.SaveChanges();
                }

                lst = db.ToDoItems.ToList();
                foreach (var item in lst)
                {
                    ToDoItems.Add(item);
                }
            }

        }

        public ToDoItem SelectedItem { get; set; }

        public Command SaveItems
        {
            get
            {
                return new Command
                (() =>
                   {
                       using (var db = new ToDoContext(path))
                       {
                           foreach (ToDoItem item in ToDoItems)
                           {
                               db.Update(item);
                           }
                           db.SaveChanges();
                       }
                   }
                );
            }
        }

        public string NewToDoDescription { get; set; }

        public Command AddItem
        {
            get
            {
                return new Command(() =>
                {
                    using (var db = new ToDoContext(path))
                    {
                        ToDoItem todo = new ToDoItem() { Description = NewToDoDescription };
                        db.ToDoItems.Add(todo);
                        db.SaveChanges();
                        ToDoItems.Clear();
                        foreach(var item in db.ToDoItems.ToList())
                        {
                            ToDoItems.Add(item);
                        }
                    }
                });
            }
        }
    }
}
