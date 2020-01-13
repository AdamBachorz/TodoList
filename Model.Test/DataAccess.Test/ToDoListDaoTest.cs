using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.DataAccess.Daos;
using Model.DataAccess.Daos.Interfaces;
using Model.DataAccess.Entity;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Model.Test.DataAccess.Test
{
    [TestFixture]
    public class ToDoListDaoTest
    {
        private IToDoListDao _toDoListDao;

        [SetUp]
        public void Setup()
        {
            _toDoListDao = new ToDoListDao();
        }

        [Test]
        public void GetAll_NoExceptions()
        {
            IList<ToDoList> toDoLists = null;
            Assert.DoesNotThrow(() => toDoLists = _toDoListDao.GetAll());
        }
    }
}
