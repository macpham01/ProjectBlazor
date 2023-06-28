using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaiTap1
{
    public class Student
    {
        public int ID { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public string MathScore { get; set; }

        public string LiteratureScore { get; set; }

        public string EnglishScore { get; set; }

        public double AvgScore
        {
            get
            {
                if (MathScore != null && LiteratureScore != null && EnglishScore != null && CheckNumber())
                    return (Convert.ToDouble(MathScore) + Convert.ToDouble(LiteratureScore) + Convert.ToDouble(EnglishScore)) / 3;
                return 0;
            }
        }

        public string HocLuc
        {
            get
            {
                if (AvgScore >= 8) return "Gioi";
                else if (6.5 <= AvgScore && AvgScore < 8) return "Kha";
                else if (5 <= AvgScore && AvgScore < 6.5) return "Trung binh";
                return "Yeu";
            }
        }

        public bool CheckNumber()
        {
            return double.TryParse(MathScore, out double number) && double.TryParse(LiteratureScore, out number) && double.TryParse(EnglishScore, out number);
        }
    }
}
