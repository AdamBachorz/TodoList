﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccess.Entity
{
    public class ToDoItem : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime? RemindDate { get; set; }
        public virtual ToDoList ToDoList { get; set; }
    }
}
