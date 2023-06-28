using BaiTap1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap1
{
    public class ManageStudent
    {
        public void AddStudent()
        {
            SinhVien newStudent = new SinhVien();
            Console.Write("Nhap ho va ten: ");
            newStudent.FullName = Console.ReadLine();
            Console.Write("Nhap gioi tinh: ");
            newStudent.Gender = Console.ReadLine();
            Console.Write("Diem toan: ");
            newStudent.MathScore = Console.ReadLine();
            Console.Write("Diem van: ");
            newStudent.LiteratureScore = Console.ReadLine();
            Console.Write("Diem anh: ");
            newStudent.EnglishScore = Console.ReadLine();
            NHibernateHelper.AddStudent(newStudent);
            //students.Add(newStudent);   
        }

        public void UpdateStudent()
        {
            List<SinhVien> students = NHibernateHelper.GetAllStudents();
            if (students != null && students.Count > 0)
            {
                Console.Write("Nhap id sinh vien muon sua: ");
                var id = Console.ReadLine();
                if (id != null)
                {
                    var student = students.Find(x => x.ID == Convert.ToInt32(id));
                    if (student != null)
                    {
                        Console.Write("Nhap ho ten: ");
                        student.FullName = Console.ReadLine();
                        Console.Write("Nhap gioi tinh: ");
                        student.Gender = Console.ReadLine();
                        Console.Write("Diem toan: ");
                        student.MathScore = Console.ReadLine();
                        Console.Write("Diem van: ");
                        student.LiteratureScore = Console.ReadLine();
                        Console.Write("Diem anh: ");
                        student.EnglishScore = Console.ReadLine();
                        NHibernateHelper.UpdateStudent(student);
                    }
                    else Console.WriteLine($"Khong tim thay nhan vien co ID: {id}");
                }
            }
        }

        public void DeleteStudent()
        {
            List<SinhVien> students = NHibernateHelper.GetAllStudents();
            if (students != null && students.Count > 0)
            {
                Console.Write("Nhap id sinh vien muon xoa: ");
                var id = Console.ReadLine();
                if (id != null)
                {
                    var student = students.Find(x => x.ID == Convert.ToInt32(id));
                    if (student != null)
                        NHibernateHelper.DeleteStudent(student);
                    else Console.WriteLine($"Khong tim thay nhan vien co ID: {id}");
                }
            }
        }

        public void SearchStudent()
        {
            List<SinhVien> students = NHibernateHelper.GetAllStudents();
            if (students != null && students.Count > 0)
            {
                Console.Write("Nhap ten sinh vien muon tim: ");
                string name = Console.ReadLine();
                var listsv =students.FindAll(x => x.FullName.Contains(name));
                if (listsv.Any())
                {
                    Console.WriteLine("ID\tHoTen\t\tGioiTinh\tToan\tVan\tAnh\tDiem TB\t\tHoc Luc\t");
                    listsv.ForEach(sv => Console.WriteLine($"{sv.ID}\t {sv.FullName}\t\t {sv.Gender}\t  {sv.MathScore}\t {sv.LiteratureScore}\t {sv.EnglishScore}\t {sv.AvgScore}\t {sv.HocLuc}\t"));
                }
                else Console.WriteLine($"Khong tim thay sinh vien co ten la {name}");
            }
        }

        public void SortStudentByGPA()
        {
            List<SinhVien> students = NHibernateHelper.GetAllStudents();
            if (students != null && students.Count > 0)
            {
                students.Sort(delegate (SinhVien sv1, SinhVien sv2) {
                    return sv2.AvgScore.CompareTo(sv1.AvgScore);
                });

                DisplayStudentBySort(students);
            }
        }
        public void SortStudentByFullName()
        {
            List<SinhVien> students = NHibernateHelper.GetAllStudents();
            if (students != null && students.Count > 0)
            {
                students.Sort(delegate (SinhVien sv1, SinhVien sv2) {
                    return sv1.FullName.CompareTo(sv2.FullName);
                });
                DisplayStudentBySort(students);
            }
        }

        public void SortStudentByID()
        {
            List<SinhVien> students = NHibernateHelper.GetAllStudents();
            if (students != null && students.Count > 0)
            {
                students.Sort(delegate (SinhVien sv1, SinhVien sv2) {
                    return sv2.ID.CompareTo(sv1.ID);
                });
                DisplayStudentBySort(students);
            }
        }
        public void DisplayStudent()
        {
            List<SinhVien> students = NHibernateHelper.GetAllStudents();
            Console.WriteLine("\n---------DANH SACH SINH VIEN-----------");
            //Console.WriteLine("ID\tHoTen\t\tGioiTinh\tToan\tVan\tAnh\tDiem TB\t\tHoc Luc\t");
            Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, -10} {4, -10} {5, -8} {6, -8} {7, -10}",
                  "ID", "FullName", "Gender", "MathScore", "LiteratureScore", "EnglishScore", "AvgScore", "HocLuc");
            // hien thi danh sach sinh vien
            if (students != null && students.Count > 0)
            {
                foreach (SinhVien sv in students)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, -10} {4, -15} {5, -12} {6, -8} {7, -10}",
                                     sv.ID, sv.FullName, sv.Gender, sv.MathScore, sv.LiteratureScore, sv.EnglishScore, sv.AvgScore,
                                     sv.HocLuc);
                    //Console.WriteLine($"{sv.ID}\t {sv.FullName}\t\t {sv.Gender}\t  {sv.MathScore}\t {sv.LiteratureScore}\t {sv.EnglishScore}\t {sv.AvgScore}\t {sv.HocLuc}\t");
                }
            }
            Console.WriteLine();
        }

        public void DisplayStudentBySort(List<SinhVien> students)
        {
            Console.WriteLine("\n---------DANH SACH SINH VIEN SAU KHI SAP XEP-----------");
            Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, -10} {4, -10} {5, -8} {6, -8} {7, -10}",
                  "ID", "FullName", "Gender", "MathScore", "LiteratureScore", "EnglishScore", "AvgScore", "HocLuc");
            // hien thi danh sach sinh vien
            if (students != null && students.Count > 0)
            {
                foreach (SinhVien sv in students)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, -10} {4, -15} {5, -12} {6, -8} {7, -10}",
                                     sv.ID, sv.FullName, sv.Gender, sv.MathScore, sv.LiteratureScore, sv.EnglishScore, sv.AvgScore,
                                     sv.HocLuc);
                }
            }
            Console.WriteLine();
        }

    }
}
