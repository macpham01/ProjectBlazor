using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap1.Models
{
    public class SinhVienMap : ClassMapping<SinhVien>
    {
        public SinhVienMap()
        {
            Table("SinhVien");
            Id(x => x.ID, map => map.Generator(Generators.Identity));
            Property(x => x.FullName);
            Property(x => x.Gender);
            Property(x => x.MathScore);
            Property(x => x.LiteratureScore);
            Property(x => x.EnglishScore);
        }
    }
}
