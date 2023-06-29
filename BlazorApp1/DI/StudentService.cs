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

        public async Task<List<SinhVien>> GetStudentsByPageAsyn(int pageNumber, int pageSize, string fullName,int gender, string mathScore, string literatureScore, string englishScore)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                if (gender==9999) return await session.Query<SinhVien>()
                       .Where(x=>x.FullName.Contains(fullName) && (x.Gender == 0 || x.Gender == 1 || x.Gender==2) && x.MathScore.Contains(mathScore)&&x.LiteratureScore.Contains(literatureScore)&&x.EnglishScore.Contains(englishScore))
                       .Skip((pageNumber - 1) * pageSize)
                       .Take(pageSize)
                       .ToListAsync();
                else
                    return await session.Query<SinhVien>()
                       .Where(x=>x.FullName.Contains(fullName)&&x.Gender==gender&&x.MathScore.Contains(mathScore)&&x.LiteratureScore.Contains(literatureScore)&&x.EnglishScore.Contains(englishScore))
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

        public async Task<SinhVien> DisplayAStudent(Guid id)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                return session.Query<SinhVien>().FirstOrDefault(x=>x.GuiID==id);
            }
        }

        public Task<SinhVien> DisplayAStudentAsyn(SinhVien sinhVien)
        {
            throw new NotImplementedException();
        }

        public int TotalRecord(string fullName,int gender, string mathScore, string literatureScore, string englishScore)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                if (gender == 9999) return session.Query<SinhVien>()
                        .Where(x => x.FullName.Contains(fullName) && (x.Gender == 0 || x.Gender == 1 || x.Gender == 2) && x.MathScore.Contains(mathScore) && x.LiteratureScore.Contains(literatureScore) && x.EnglishScore.Contains(englishScore))
                        .ToList().Count;
                else
                    return session.Query<SinhVien>()
                        .Where(x => x.FullName.Contains(fullName)&& x.Gender==gender && x.MathScore.Contains(mathScore) && x.LiteratureScore.Contains(literatureScore) && x.EnglishScore.Contains(englishScore))
                        .ToList().Count;
            }
        }

        public List<SinhVien> GetAllStudent()
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                return session.Query<SinhVien>().ToList();
            }
        }
    }
}
