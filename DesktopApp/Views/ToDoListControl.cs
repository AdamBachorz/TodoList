﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Model;
using Model.DataAccess.Entity;
using Model.DataAccess.Daos.Interfaces;
using Model.Services.Interfaces;
using DesktopApp.OtherForms;
using Model.Core;

namespace DesktopApp.Views
{
    public partial class ToDoListControl : UserControl
    {
        private readonly IToDoListService _toDoListService;
        private readonly IToDoListDao _toDoListDao;
        private readonly IToDoItemDao _toDoItemDao;
        private ToDoListModel _toDoListModel;

        public ToDoListControl(ToDoListModel toDoListModel, IToDoListService toDoListService, IToDoListDao toDoListDao, IToDoItemDao toDoItemDao)
        {
            InitializeComponent();

            _toDoListService = toDoListService;
            _toDoListModel = toDoListModel;
            _toDoListDao = toDoListDao;
            _toDoItemDao = toDoItemDao;
            
            SetListControl(_toDoListModel);          
        }
        
        private void buttonNewItem_Click(object sender, EventArgs e)
        {
            var listReference = _toDoListService.PickToDoListById(_toDoListModel.Id);
            var newItem = _toDoItemDao.Insert(ToDoItem.New(listReference));

            var newItemControl = new ToDoItemControl(new ToDoItemModel(newItem), _toDoListService, _toDoItemDao);
            
            flowLayoutPanel1.Controls.Add(newItemControl);
            newItemControl.EditItem();
        }
        
        private IEnumerable<ToDoItemControl> GenerateItemsControls(IList<ToDoItemModel> toDoItemModels)
        {
            foreach (var model in toDoItemModels)
            {
                yield return new ToDoItemControl(model, _toDoListService, _toDoItemDao);
            }
        }
        
        private void SetListControl(ToDoListModel toDoListModel)
        {
            // Remove old list items
            if (_toDoListModel?.ToDoItems?.Any() == true)
            {
                var toDoItemControls = flowLayoutPanel1.Controls.Cast<Control>()
                    .Where(control => control is ToDoItemControl);

                foreach (var itemControl in toDoItemControls)
                {
                    flowLayoutPanel1.Controls.Remove(itemControl);
                }
            }

            _toDoListModel = toDoListModel;
            labelTitleDate.Text = _toDoListModel.TitleDate;

            // Populate another list with items (if they exist)
            if (_toDoListModel?.ToDoItems?.Any() == true)
            {
                var itemControls = GenerateItemsControls(_toDoListModel.ToDoItems).ToArray();
                flowLayoutPanel1.Controls.AddRange(itemControls);
            }
        }
       
    }
}
