using BaiTap1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Mapping.ByCode;
using NHibernate.Cfg;

namespace BaiTap1
{
    public class NHibernateHelper
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
        public static List<SinhVien> GetAllStudents()
        {
            using (var session = OpenSession())
            {
                return session.Query<SinhVien>().ToList();
            }
        }

        public static void AddStudent(SinhVien student)
        {
            using (var session = OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(student);
                    transaction.Commit();
                }
            }
        }

        public static void UpdateStudent(SinhVien student)
        {
            using (var session = OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Update(student);
                    transaction.Commit();
                }
            }
        }

        public static void DeleteStudent(SinhVien student)
        {
            using (var session = OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(student);
                    transaction.Commit();
                }
            }
        }
    }
}