using AntDesign.TableModels;
using AntDesign;
using System.ComponentModel;
using System.Text.Json;
using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using BlazorApp1.DI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Forms;
using System.Reflection;

namespace BlazorApp1.Pages
{
    public partial class ListStudent
    {
        [Inject] IStudentService StudentService { get; set; }
        SinhVien student = new SinhVien();

        #region Field

        List<SinhVien> listStudent;
        IEnumerable<SinhVien> selectedRows;
        ITable table;
        int _pageIndex = 1;
        int _pageSize = 3;
        int _total = 0;
        bool _visible = false;
        string _titleModel = "";
        int _statusModal;
        bool _visibleDialog = false;
        string _modalText = "Bạn có muốn xoá sinh viên này không?";
        Guid _idStudent;
        private Form<SinhVien> form;

        #endregion

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            listStudent = await StudentService.GetStudentsByPageAsyn(_pageIndex, _pageSize);
            int i = (_pageIndex - 1) * _pageSize + 1;
            listStudent.ForEach(c => { c.STT = i; i++; });
            _total = StudentService.TotalRecord();
        }

        public async Task OnChange(QueryModel<SinhVien> queryModel)
        {
            _pageIndex = queryModel.PageIndex;
            _pageSize = queryModel.PageSize;
            await LoadData();
            Console.WriteLine(JsonSerializer.Serialize(queryModel));
        }

        //public Task<List<SinhVien>> GetForecastAsync(int pageIndex, int pageSize)
        //{
        //    return Task.FromResult(Enumerable.Range((pageIndex - 1) * pageSize + 1, pageSize).Select(index =>
        //    {
        //        return new SinhVien
        //        {
        //            ID = index,
        //        };
        //    }).ToList());
        //}

        public void RemoveSelection(int id)
        {
            var selected = selectedRows.Where(x => x.STT != id);
            selectedRows = selected;
        }

        private async Task Delete(Guid id)
        {
            var student = listStudent.Find(x => x.GuiID == id);
            if (student != null)
            {
                bool result = await StudentService.DeleteStudentAsyn(student);
                if (result)
                {
                    await LoadData();
                    //await _message.Success("Xoá sinh viên thành công");
                }
            }

            _visibleDialog = false;
        }

        private void UpdateStudent(Guid id)
        {
            var studentByID = listStudent.Find(x => x.GuiID == id);
            if (studentByID != null)
            {
                student = studentByID;
                _visible = true;
                _statusModal = 1; //Modal update
                _titleModel = "Cập nhật sinh viên";
            }
        }

        string GetGenderLabel(int gender)
        {
            if (gender == 0) return "Nam";
            else if (gender == 1) return "Nữ";
            else return "Khác";
        }

       

        private async Task HandleOk(MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(student.FullName))
            {
                if (_statusModal==0)
                {
                    var result =  await StudentService.AddStudentAsyn(student);
                    if (result)
                    {
                        await LoadData();
                    }
                }
                else
                {
                    var result = await StudentService.UpdateStudentAsyn(student);
                    if (result)
                        listStudent = await StudentService.GetStudentsByPageAsyn(_pageIndex, _pageSize);
                }
            _visible = false;
            }
            else _visible = true;
            student = new SinhVien();
        }

        private void HandleCancel(MouseEventArgs e)
        {
            _visible = false;
            form.Reset(); //reset lại form
            student = new SinhVien();
        }

        private void AddStudent()
        {
            _visible = true; 
            _titleModel = "Thêm mới sinh viên";
            _statusModal = 0; //Modal create
            student.Gender = 0; //Mặc định giới tính là nam khi thêm mới
            student.GuiID = Guid.NewGuid();
        }

    }
}
