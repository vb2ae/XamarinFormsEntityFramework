using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App13
{
    [ImplementPropertyChanged]
    public class ToDoItem 
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}
