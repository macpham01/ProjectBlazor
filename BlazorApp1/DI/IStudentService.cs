using BlazorApp1.Models;

namespace BlazorApp1.DI
{
    public interface IStudentService
    {
        public Task<List<SinhVien>> GetStudentsByPageAsyn(int pageNumber, int pageSize);

        public Task<bool> AddStudentAsyn(SinhVien sinhVien);

        public Task<bool> UpdateStudentAsyn(SinhVien sinhVien);

        public Task<bool> DeleteStudentAsyn(SinhVien sinhVien);

        public Task<SinhVien> DisplayAStudentAsyn(SinhVien sinhVien);

        public int TotalRecord();

    }
}
