using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Paging;


public class Paginate<T> 
{
    public Paginate()
    {
            Items=Array.Empty<T>(); 
    }
    //sayfalama ile ilgili bir extencion yazmak istiyorum 
    public int Size { get; set; }
    public int Index { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public IList<T> Items { get; set; }
    public bool HasPrevious => Index > 0; //burada önce ki sayfamı onu setlemeyelim hesaplama ile ortaya çıksınm dioyruz 
    public bool HasNext => Index+1<Pages;  //sonraki sayfa var mı 
}
