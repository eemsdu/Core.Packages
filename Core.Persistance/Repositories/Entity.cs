using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Repositories;

public class Entity<TId>
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; } //nullable geçilebilir 
    public DateTime? DeletedDate { get; set; } //nullable geçielebilir 
    public Entity()
    {
        //parametresiz ctor 
        Id = default;  //hiç bir şey verilmezse ıd default olarak atılır
    }
    public Entity(TId id)
    {
        Id = id; 
    }

}
