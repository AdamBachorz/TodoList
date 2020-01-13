using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Model.Core
{
    public sealed class NHibernateHelper
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly Configuration _configuration;

        public NHibernateHelper()
        {
            _configuration = BasicNHibernateConfiguration();
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        private Configuration BasicNHibernateConfiguration()
        {
            var configuration = new Configuration();

            configuration.SetProperty(NHibernate.Cfg.Environment.ProxyFactoryFactoryClass,
            typeof(NHibernate.Bytecode.StaticProxyFactoryFactory).AssemblyQualifiedName);

            configuration.SetProperty(
              NHibernate.Cfg.Environment.Dialect,
              typeof(NHibernate.Dialect.MsSql2012Dialect).AssemblyQualifiedName);

            configuration.SetProperty(
              NHibernate.Cfg.Environment.ConnectionString, ConnectionString());

            configuration.SetProperty(
              NHibernate.Cfg.Environment.FormatSql, "true");

            configuration.AddAssembly(Assembly.GetCallingAssembly());

            var basicMapping = BasicMapping();

            configuration.AddMapping(basicMapping);

            return configuration;
        }

        private HbmMapping BasicMapping()
        {
            var modelMapper = new ModelMapper();

            modelMapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());

            var mapping = modelMapper.CompileMappingForAllExplicitlyAddedEntities();

            return mapping;
        }

        public ISession OpenSession() => _sessionFactory.OpenSession();

        private string ConnectionString()
        {
            return "Server=localhost\\SQLEXPRESS; initial catalog=ToDoList; Integrated Security=True";
        }
    }
}
