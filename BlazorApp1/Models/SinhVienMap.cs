using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Models
{
    public class SinhVienMap : ClassMapping<SinhVien>
    {
        public SinhVienMap()
        {
            Table("SinhVien");
            Id(x => x.GuiID, map =>
            {
                map.Column("GuiID");
            });
            Property(x => x.STT, map => map.Generated(PropertyGeneration.Always));
            Property(x => x.FullName);
            Property(x => x.Gender);
            Property(x => x.MathScore);
            Property(x => x.LiteratureScore);
            Property(x => x.EnglishScore);
        }
    }
}
