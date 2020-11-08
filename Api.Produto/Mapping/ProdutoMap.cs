using Api.Produto;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHIBERNATEORM.Mapping
{
    public class ProdutoMap : ClassMapping<Produto>
    {
        public ProdutoMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Increment);
                x.Type(NHibernateUtil.Int64);
                x.Column("Id");
            });

            Property(b => b.Nome, x =>
            {
                x.Length(520);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Table("Produto");

        }
    }
}
