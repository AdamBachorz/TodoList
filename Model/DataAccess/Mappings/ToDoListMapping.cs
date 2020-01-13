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
    public class ToDoListMapping : ClassMapping<ToDoList>
    {
        public ToDoListMapping()
        {
            Table("TO_DO_LIST");
            Id(x => x.Id, m => { m.Column("ID"); m.Generator(Generators.Native); });
            Property(x => x.Date, m => m.Column("DATE"));

            Bag(x => x.ToDoItems,
                c =>
                {
                    c.Table("TO_DO_ITEM");
                    c.Lazy(CollectionLazy.NoLazy);
                    c.Inverse(true);
                    c.Key(k =>
                    {
                        k.Column("TO_DO_ITEM_ID");
                    });

                },

               m => m.OneToMany(a => a.Class(typeof(ToDoItem)))
                );
        }
    }
}