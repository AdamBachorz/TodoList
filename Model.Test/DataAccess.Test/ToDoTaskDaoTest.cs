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
    public class ToDoTaskDaoTest
    {
        private IToDoTaskDao _toDoTaskDao;

        [SetUp]
        public void Setup()
        {
            _toDoTaskDao = new ToDoTaskDao();
        }

        [Test]
        public void GetAll_NoExceptions()
        {
            IList<ToDoTask> toDoTasks = null;
            Assert.DoesNotThrow(() => toDoTasks = _toDoTaskDao.GetAll());
            Assert.NotNull(toDoTasks);
        }
    }
}
