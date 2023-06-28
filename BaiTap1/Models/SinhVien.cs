using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap1.Models
{
    public class SinhVien
    {
        public virtual int ID  { get; set; }
                      
        public virtual string  FullName { get; set; }
                      
        public virtual string  Gender { get; set; }
                      
        public virtual string  MathScore { get; set; }
                      
        public virtual string  LiteratureScore { get; set; }
                      
        public virtual string  EnglishScore { get; set; }

        public virtual double AvgScore
        {
            get
            {
                bool check = MathScore != null && LiteratureScore != null && EnglishScore != null && CheckNumber(MathScore) && CheckNumber(LiteratureScore) && CheckNumber(EnglishScore);
                if (check)
                    return (Convert.ToDouble(MathScore) + Convert.ToDouble(LiteratureScore) + Convert.ToDouble(EnglishScore)) / 3;
                return 0;
            }
        }

        public virtual string HocLuc
        {
            get
            {
                if (AvgScore >= 8) return "Gioi";
                else if (6.5 <= AvgScore && AvgScore < 8) return "Kha";
                else if (5 <= AvgScore && AvgScore < 6.5) return "Trung binh";
                return "Yeu";
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
    }
}
