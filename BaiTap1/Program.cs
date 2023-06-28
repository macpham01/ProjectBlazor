using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManageStudent manageStudent = new ManageStudent();
            while (true)
            {
                try
                {
                    manageStudent.DisplayStudent();
                    int menu;
                    Console.WriteLine();
                    Console.WriteLine("---------MENU----------");
                    Console.WriteLine("1. Them sinh vien.\n\n" +
                        "2. Cap nhat thong tin sinh vien theo ID.\n\n" +
                        "3. Xoa sinh vien theo ID.\n\n" +
                        "4. Tim kiem sinh vien theo ten.\n\n" +
                        "5. Sap xep sinh vien theo diem trung binh (GPA).\n\n" +
                        "6. Sap xep sinh vien theo ten.\n\n" +
                        "7. Sap xep sinh vien theo ID.\n");
                    Console.Write("Nhap lua chon cua ban: ");
                    menu = Convert.ToInt32(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            manageStudent.AddStudent();
                            break;
                        case 2:
                            manageStudent.UpdateStudent();
                            break;
                        case 3:
                            manageStudent.DeleteStudent();
                            break;
                        case 4:
                            manageStudent.SearchStudent();
                            break;
                        case 5:
                            manageStudent.SortStudentByGPA();
                            break;
                        case 6:
                            manageStudent.SortStudentByFullName();
                            break;
                        case 7:
                            manageStudent.SortStudentByID();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Da co loi trong qua trinh xu ly");
                }
            
            }
        }
    }
}
