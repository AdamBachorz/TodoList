using System;
using System.Collections.Generic;
using Model.DataAccess.Daos;
using Model.DataAccess.Daos.Interfaces;
using Model.DataAccess.Entity;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Model.Test.DataAccess.Test
{
    [TestFixture]
    public class ToDoItemDaoTest
    {
        private IToDoItemDao _toDoItemDao;

        [SetUp]
        public void Setup()
        {
            _toDoItemDao = new ToDoItemDao();
        }

        [Test]
        public void GetAll_NoExceptions()
        {
            IList<ToDoItem> toDoItems = null;
            Assert.DoesNotThrow(() => toDoItems = _toDoItemDao.GetAll());
            Assert.NotNull(toDoItems);
        }
    }
}
