using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public static class Constants
    {
        public const string AppName = "ToDo List - Adam Bachorz";
        public const string DefaultDateFormat = "dd/MM/yyyy hh:mm:ss";

        public static class Sizes
        {
            public static Size DefaultAddImageSize = new Size(50, 50);
            public static Size DefaultBellSize = new Size(25, 25);
            public static Size DefaultNavigationImageSize = new Size(25, 25);
        }

        public static class Interface
        {
            public static class Main
            {
                public const string AddNewTask = "Add new task";
                public const string PickDate = "Pick 'To Do List' for another day";
            }

            public static class Errors
            {
                public const string NoTaskFromPast = "Cannot set reminder for task from past";
            }

            public static class DatePicker
            {
                public const string Confirm = "Confirm";
                public const string Cancel = "Cancel";
            }

            public static class TaskContextMenu
            {
                public const string ToRemind = "Check/Uncheck reminder";
                public const string Edit = "Edit";
                public const string Delete = "Delete";
            }

            public static class UpcomingTasks
            {
                public const string MainLabel = "Upcoming important tasks for current week";
            }
        }

    }
}
