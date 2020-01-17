using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public static class Constants
    {
        public const string DefaultDateFormat = "dd/MM/yyyy hh:mm:ss";

        public static class Interface
        {
            public static class Main
            {
                public const string AddNewTask = "Add new task";
                public const string PickDate = "Pick 'To Do List' for another day";
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
                public const string MainLabel = "Upcoming tasks for current week";
            }
        }

        public static class Symbols
        {
            public static string LeftArrow = "⏪";
            public static string RightArrow = "⏩";
            public static string Bell = "🔔";
        }
    }
}
