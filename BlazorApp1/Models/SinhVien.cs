using FluentNHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
    public class SinhVien
    {
        [Key]
        public virtual Guid GuiID { get; set; }

        public virtual int STT  { get; set; }

        [Required(ErrorMessage = "Họ và tên không được để trống.")]
        public virtual string  FullName { get; set; }
                      
        public virtual int  Gender { get; set; }
                      
        public virtual string  MathScore { get; set; }
                      
        public virtual string  LiteratureScore { get; set; }
                      
        public virtual string  EnglishScore { get; set; }

        public virtual int SoThuTu { get; set; }

        public virtual double AvgScore
        {
            get
            {
                bool check = MathScore != null && LiteratureScore != null && EnglishScore != null && CheckNumber(MathScore) && CheckNumber(LiteratureScore) && CheckNumber(EnglishScore);
                if (check)
                    return Math.Round((Convert.ToDouble(MathScore) + Convert.ToDouble(LiteratureScore) + Convert.ToDouble(EnglishScore))/3,2);
                return 0;
            }
        }

        public virtual string HocLuc
        {
            get
            {
                if (AvgScore >= 8) return "Giỏi";
                else if (6.5 <= AvgScore && AvgScore < 8) return "Khá";
                else if (5 <= AvgScore && AvgScore < 6.5) return "Trung bình";
                return "Yếu";
            }
        }

        /// <summary>
        /// Kiểm tra xem chuỗi nhập vào có phải là số không?
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public virtual bool CheckNumber(string text)
        {
            return double.TryParse(text, out double number);
        }

        public SinhVien()
        {
            Gender = 9999;
            FullName = "";
            MathScore = "";
            LiteratureScore = "";
            EnglishScore = "";
        }
    }
}
