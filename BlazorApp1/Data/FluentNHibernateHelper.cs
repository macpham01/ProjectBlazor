using BlazorApp1.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ISession = NHibernate.ISession;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace BlazorApp1.Data
{
    public class FluentNHibernateHelper
    {
        private static ISessionFactory sessionFactory;
        public static ISession OpenSession()
        {
            if (sessionFactory == null)
            {
                Configuration configuration = new Configuration();
                configuration.Configure("hibernate.cfg.xml");

                var mapper = new ModelMapper();
                mapper.AddMapping<SinhVienMap>();

                var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                configuration.AddDeserializedMapping(mapping, "NHibernateExample");

                sessionFactory = configuration.BuildSessionFactory();
            }

            return sessionFactory.OpenSession();
        }
    }
}
