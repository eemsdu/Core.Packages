using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Dynamic;


public class Filter
{
    public string Field { get; set; } //hangi alan üzerinde çalışıyorum 
    public string? Value  { get; set; } //bunun değeri ne 

    public string Operator { get;set; }
    public string? Logic { get; set; } //şu şartı sağlayan ama başka bir şartı sağlamayan logici geçebiliriz 
    public IEnumerable<Filter> Filters { get; set; }   //benim birden fazla filtrem söz konusu olablir bir filtreye başka bir filtre eklemiş oluyorum burası ile

    public Filter()
    {
        Field = string.Empty;  //alanımı  boş bir şekilde başlatıyorum 
        Operator = string.Empty; //operatörümü boş bir şekilde başlatıyorum 
    }
    public Filter(string field,string @operator) //c# keywordlerinde operator diyte bir kelime mevcut o yüzden değişken ismini bunu vermeyiz vermek istiyorsak @ ile verebiliriz yalnızca 
    {
        Field = field;
        Operator = @operator;
    }
}
