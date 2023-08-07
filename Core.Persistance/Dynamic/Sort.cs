using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Dynamic;

public class Sort //FİLTER VE SORT classları benim dynamic bir query oluşturmak için gerekli yardımcı classlarımdır dyanmic query içinde filter ve sortlar olan yapıdır...
{
    public string Field { get; set; } //hangi alan için olduğunu belirtiyoruz 
    public string Dir { get; set; } //asending mi yoksa desending mi 
    public Sort()
    {
        Field = string.Empty;
        Dir = string.Empty;     
    }
    public Sort(string  field,string dir)
    {
        Field=field;    
        Dir=dir;
    }
}

