using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Paging;

public static class IQueryablePaginateExtensions
{
    //burada queryable üzerinden bir sayfalama yapıyoruz veri tabanı tüm data gelmesin sadece arzu ettiğim sayfa gelsin queryable de sorgunun geldiği noktada veri tabanına sorgu gönderilir 
    public static async Task<Paginate<T>> ToPaginateAsync<T>
        (
        this IQueryable<T> source,
        int index,
        int size,
        CancellationToken cancellationToken = default)


    {
        int count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
        List<T> items = await source.Skip(index * size).Take(size).ToListAsync(cancellationToken).ConfigureAwait(false);
        //index çarpı index = 0 size eşittir 10 ise ilk 10 datayı al demiş olduk burada 
        Paginate<T> list = new()
        {
            Index = index,
            Count = count,
            Items = items,
            Size = size,
            Pages = (int)Math.Ceiling(count / (double)size)  //sayfa sayısı hesaplandı toplam sayı bölü size bölündü 

        };
        return list;

    }
    public static  Paginate<T> ToPaginate<T>(this IQueryable<T> source, int index, int size)

    {
        int count = source.Count();
        List<T> items = source.Skip(index * size).Take(size).ToList();
        //index çarpı index = 0 size eşittir 10 ise ilk 10 datayı al demiş olduk burada 
        Paginate<T> list = new()
        {
            Index = index,
            Count = count,
            Items = items,
            Size = size,
            Pages = (int)Math.Ceiling(count / (double)size)  //sayfa sayısı hesaplandı toplam sayı bölü size bölündü 

        };
        return list;

    }

}
