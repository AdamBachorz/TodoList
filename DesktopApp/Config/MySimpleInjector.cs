using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataAccess.Daos;
using Model.DataAccess.Daos.Interfaces;
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

            // Services


            _container.Register<MainView>();
        }

        public MainView MainViewInstance => _container.GetInstance<MainView>();
    }
}
