using Core.Persistance.Dynamic;
using Core.Persistance.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Repositories;

public interface IAsyncRepository<TEntity, TEntityId>:IQuery<TEntity> where TEntity : Entity<TEntityId>
    //burada gelen entitynin tentiy tipinde olmasını ve entitynin ise tentityıd tipinde olması gerektiğini söylüyorum entityden inherit edilecek ve id tipi ne ise o tip de guid ise guid int ise int olacağını söylüyorum diğer hallerde hata fırlatsın diş

{
    //ilk olarak hangi entity ile çalışacağımı veriyorum  brandı verdim çalışcağım id nin veri tipini de veriyorum 
    Task<TEntity?> GetAsync(
        Expression<Func<TEntity, bool>> predicate, //lamda ile where koşulu yazmamızı sağlar işte mesela id si parametreden gelen ids ye eşit olanları getir diyebiliriz ya da unic olan bir alan ile de şartlı bir işlem gerçekleştirmemiz sağlar 
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, //join desteği getirildi , get operasyonunu sadece tek tabloya bağımlı olmasının önüne geçmiş olduk burada join yaparak  joine göre data getirmek isteyebilirim querybale ile verilerimizi query edebilecek ortamı hazırlamış oluyoruz,bu query tentity için çalışacak yani ilgili domaine göre çalışma yapılacak null geçiyorum çünkü illa join yapmak istemeyebilirim istersem joinliyorum aynın işlemi predicate için yapmıyorum 
        bool withDeleted = false,  //db de silinenleri sorguda getireyim mi getirmeyim mi bazen silinenleri de okumak isteyebilirim burada böyle bir durum söz konusu olursa  true yapmam yeterli olucak 
        bool enableTracking = true, // takip mekanizması  default true ama ben burayıda yine isteye göre false yapabilirim 
        CancellationToken cancellationToken = default); //iptal etme işlemi için gerekli olan değer defaultu veriyoruz );
    Task<Paginate<TEntity>> GetListAsync(  //entity için bir liste dönecek 
         Expression<Func<TEntity, bool>>? predicate = null, 
         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, //azalana göre listelenebilir 
         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, //join yapılarak başka bir tablodan da veri alabiliriz buraya 
         int index=0, //ilk sayfa
         int size=10, //10 adet veri defaultta gelsin 
         bool withDeleted=false,
         bool enabledTracking=true, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(   //aradığımız değer var mı yok mu var ise true yok ise false dönsün demiş oluyoruz 
        Expression<Func<TEntity, bool>>? predicate = null, //predicate geçiyoruz bunu demez isek data var mı yokmu diye bakar ama özel olorak tc numrası var mı yok mu yada daha farklı bir örnek vermek istiyorsak bunu kullanmalıyız o kouşda var mı yok mu 
        bool withDeleted=false,
        bool enabledTracking=true,
        CancellationToken cancellationToken = default);
    Task<TEntity> AddAsync(TEntity entity); //bana entity ver onu ekliyim 
    Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entity);
    Task<TEntity> UpdateAsync(TEntity entity);

    Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entity);
    Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false); //permanent kalıcı demek ben bunu softdelete mi yapayım yani db de kalıcı olarak uçurayım mı yoksa uçurmayıp silindi diye işaretleyeyim mi defaultta false yapıcaz burayı 
    Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entity,bool permanent=false);

    Task<Paginate<TEntity>> GetListByDynamicAsync(
        DynamicQuery dynamic,
        Expression<Func<TEntity,bool>>? predicate =null,
          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
           int index = 0, //ilk sayfa
         int size = 10, //10 adet veri defaultta gelsin 
         bool withDeleted = false,
         bool enabledTracking = true, CancellationToken cancellationToken = default);
     //burası dinamik bir listeleme yapısı sunar bize örnek vermek gerekirse bir araba kiralama sisteminde sol tarafda arabanın cinsi fiyatı markası yılı vs gibi bilgilerle filtreleme  diyebileceğimiz bir listeleme yapısı sunar bizlere bu listeleme de kullanıcı sol tarafdan hangisini doldurur ise ona göre dinamik bir şekilde sorgulama yaparak bizlere sonucu döndürsün 
}
