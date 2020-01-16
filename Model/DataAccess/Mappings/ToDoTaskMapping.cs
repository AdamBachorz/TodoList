using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.DataAccess.Entity;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Model.DataAccess.Mappings
{
    public class ToDoTaskMapping : ClassMapping<ToDoTask>
    {
        public ToDoTaskMapping()
        {
            Table("TO_DO_TASK");
            Id(x => x.Id, m => { m.Column("ID"); m.Generator(Generators.Native); });
            Property(x => x.Text, m => m.Column("TEXT"));
            Property(x => x.Checked, m => m.Column("CHECKED"));
            Property(x => x.ToRemind, m => m.Column("TO_REMIND"));

            ManyToOne(x => x.ToDoList, map =>
            {
                map.Column("TO_DO_LIST_ID");
            });
        }
    }
}