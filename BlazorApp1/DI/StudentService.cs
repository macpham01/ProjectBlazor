using BlazorApp1.Data;
using BlazorApp1.Models;
using NHibernate.Linq;
using System.Drawing.Printing;

namespace BlazorApp1.DI
{
    public class StudentService : IStudentService
    {
        public async Task<bool> AddStudentAsyn(SinhVien sinhVien)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(sinhVien);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<bool> DeleteStudentAsyn(SinhVien sinhVien)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(sinhVien);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.WriteLine(e);
                        return false;
                    }

                }
            }
        }

        public async Task<List<SinhVien>> GetStudentsByPageAsyn(int pageNumber, int pageSize)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                return await session.Query<SinhVien>()
                   .Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize)
                   .ToListAsync();
            }
        }

        public async Task<bool> UpdateStudentAsyn(SinhVien sinhVien)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(sinhVien);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.WriteLine(e);
                        return false;
                    }

                }
            }
        }

        public async Task<SinhVien> DisplayAStudent(int id)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                return session.Query<SinhVien>().FirstOrDefault(x=>x.STT==id);
            }
        }

        public Task<SinhVien> DisplayAStudentAsyn(SinhVien sinhVien)
        {
            throw new NotImplementedException();
        }

        public int TotalRecord()
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                return session.Query<SinhVien>().ToList().Count;
            }
        }
    }
}
