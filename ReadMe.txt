
1- TwitterProject ad�nda BlankSolution a��l�r

2- TwitterProject.Domain ad�nda Class Library(.Core) Projesi a��l�r.
	2.1 Enums klas�r� a��l�r.
		2.1.1 Bu klas�r alt�na Status.cs a��l�r.

		 public enum Status { Active = 1, Modified = 2, Passive = 3 }
	
	2.2 Entities klasr� a��l�r. 
		2.2.1 Interface klas�r� a��l�r ve bu klas�r alt�na IBaseEntity.cs interface'si a��l�r.

		DateTime CreateDate { get; set; }
        DateTime? ModifiedDate { get; set; } => nullable ge�ildi.
        DateTime? DeleteDate { get; set; }   => nullable ge�ildi.
        Status Status { get; set; }

		2.2.2. Concrete klas�r� a��l�r. Bu klas�r�de projemizde ihtiya� duyulan s�n�flar olu�turulur.
			2.2.2.1 Child s�n�flara kal�t�m vermek ama�l� BaseEntity.cs a��l�r, abstract olarak i�aretlenir, IBaseEntity'den implement al�n�r ve IBaseEntity'de yazd���m�z propertyler burada g�vde kazan�r.

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

            2.2.2.2 AppRole.cs a��l�r.
            Not: Kullan�c� ile ilgili i�lemlerde Asp .Net Core Identity s�n�f�ndan yararlanaca��m. Bu ba�lamda AppUserRole ve AppUser s�n�flar�nda Identity s�n�fdan kal�t�m alacaklar. Bunu i�in Microsoft.Extensions.Identity.Store paketini y�kleyece�iz.

                    public class AppRole: IdentityRole<int>,IBaseEntity
                    {
                        private DateTime _createDate = DateTime.Now;
                        public DateTime CreateDate { get => _createDate; set => value = _createDate; }
                
                        public DateTime? ModifiedDate { get; set; }
                        public DateTime? DeleteDate { get; set; }
                
                        private Status _status = Status.Active;
                        public Status Status { get => _status; set => value = _status; }
                    }
            2.2.2.3 AppUser.cs a��l�r.

