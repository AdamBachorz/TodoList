using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataAccess.Daos;
using Model.DataAccess.Daos.Interfaces;
using Model.Services;
using Model.Services.Interfaces;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace DesktopApp.Config
{
    public class MySimpleInjector
    {
        private Container _container;

        public MySimpleInjector()
        {
            _container = new Container();
        }

        public void Register()
        {
            // DAOs
            _container.Register<IToDoListDao, ToDoListDao>();
            _container.Register<IToDoTaskDao, ToDoTaskDao>();

            // Services
            _container.Register<IToDoListService, ToDoListService>();

            _container.Register<MainForm>();
        }

        public MainForm MainViewInstance => _container.GetInstance<MainForm>();
    }
}
