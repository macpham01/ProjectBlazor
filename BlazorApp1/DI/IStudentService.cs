using BlazorApp1.Models;

namespace BlazorApp1.DI
{
    public interface IStudentService
    {
        public Task<List<SinhVien>> GetStudentsByPageAsyn(int pageNumber, int pageSize, string fullName,int gender, string mathScore, string literatureScore, string englishScore);

        public List<SinhVien> GetAllStudent();

        public Task<bool> AddStudentAsyn(SinhVien sinhVien);

        public Task<bool> UpdateStudentAsyn(SinhVien sinhVien);

        public Task<bool> DeleteStudentAsyn(SinhVien sinhVien);

        public Task<SinhVien> DisplayAStudentAsyn(SinhVien sinhVien);

        public int TotalRecord(string fullName,int gender, string mathScore, string literatureScore, string englishScore);

    }
}
