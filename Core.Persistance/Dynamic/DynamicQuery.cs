using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Dynamic;

public class DynamicQuery
{
    public IEnumerable<Sort>? Sort { get; set;} //bizim sort değerimiz yani sıralama değerimiz 
    public Filter? Filter { get; set;} //filter değerimizi veriyoruz burada sıralama çoğul olacak şekilde verilirken filter değerimiz ise tekil olarak verilmiş durumda bu hususta filterın genel yapısı filter üstüne filter eklenecek bir şekilde olduğu için bu şekilde bir sistem düşünülmüştür.
    public DynamicQuery()
    {
       
    }
    public DynamicQuery(IEnumerable<Sort>? sort, Filter? filter)
    {
        Filter = filter;
        Sort = sort;    
    }


}
