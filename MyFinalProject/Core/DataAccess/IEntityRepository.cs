using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // **Core katmanı başka katmanları referans almaz alırsa bağımlı olur
    //generic constraint(generic kısk)
    //class : referans tip gelebilir
    //IEntity : IEntity olabilr veya Ientity implemente edebilen nesne olabilir
    //new() : new'lenebilir olmalı [IEntity new lenemdiği için böyle yaptık(interface olduğu(soyut) olduğu için)]
    public interface IEntityRepository<T> where T:class,IEntity,new() // bana tipini söyler
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//filter = null fitre vermeyebilirsiniz
        //delege tipi, bişey verebilmemizi sağlayan metotlar(Linq) 
        T Get(Expression<Func<T, bool>> filter);
        //Expression == List<T> GetAllByCategory(int categoryId); şöyle filtreler yazabilmemizi sağlar
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
        //Alt yapı ekibi Sadece Core katmanı ile ilgilenir

    }
}
