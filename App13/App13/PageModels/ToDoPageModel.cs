using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App13.PageModels
{
    public class ToDoPageModel:FreshMvvm.FreshBasePageModel 
    {
        public ToDoPageModel(IDataBasePath dbPath)
        {
            System.Collections.Generic.List<ToDoItem> lst = null;
            string path = dbPath.GetPath();

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
            }

        }
    }
}
