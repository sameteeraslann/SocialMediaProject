
1- TwitterProject adýnda BlankSolution açýlýr

2- TwitterProject.Domain adýnda Class Library(.Core) Projesi açýlýr.
	2.1 Enums klasörü açýlýr.
		2.1.1 Bu klasör altýna Status.cs açýlýr.

		 public enum Status { Active = 1, Modified = 2, Passive = 3 }
	
	2.2 Entities klasrü açýlýr. 
		2.2.1 Interface klasörü açýlýr ve bu klasör altýna IBaseEntity.cs interface'si açýlýr.

		DateTime CreateDate { get; set; }
        DateTime? ModifiedDate { get; set; } => nullable geçildi.
        DateTime? DeleteDate { get; set; }   => nullable geçildi.
        Status Status { get; set; }

		2.2.2. Concrete klasörü açýlýr. Bu klasörüde projemizde ihtiyaç duyulan sýnýflar oluþturulur.
			2.2.2.1 Child sýnýflara kalýtým vermek amaçlý BaseEntity.cs açýlýr, abstract olarak iþaretlenir, IBaseEntity'den implement alýnýr ve IBaseEntity'de yazdýðýmýz propertyler burada gövde kazanýr.

		    	public abstract class BaseEntity<T> : IBaseEntity
                {
                 public T Id { get; set; }

                 private DateTime _createDate = DateTime.Now;
                 public DateTime CreateDate { get => _createDate; set => value = _createDate; }

                 public DateTime? ModifiedDate { get; set; }
                 public DateTime? DeleteDate { get; set; }

                 private Status _status = Status.Active;
                 public Status Status { get => _status; set => value = _status; }
                }

            2.2.2.2 AppRole.cs açýlýr.
            Not: Kullanýcý ile ilgili iþlemlerde Asp .Net Core Identity sýnýfýndan yararlanacaðým. Bu baðlamda AppUserRole ve AppUser sýnýflarýnda Identity sýnýfdan kalýtým alacaklar. Bunu için Microsoft.Extensions.Identity.Store paketini yükleyeceðiz.

                    public class AppRole: IdentityRole<int>,IBaseEntity
                    {
                        private DateTime _createDate = DateTime.Now;
                        public DateTime CreateDate { get => _createDate; set => value = _createDate; }
                
                        public DateTime? ModifiedDate { get; set; }
                        public DateTime? DeleteDate { get; set; }
                
                        private Status _status = Status.Active;
                        public Status Status { get => _status; set => value = _status; }
                    }
            2.2.2.3 AppUser.cs açýlýr.

