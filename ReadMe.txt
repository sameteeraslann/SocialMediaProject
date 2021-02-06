
1- TwitterProject ad�nda BlankSolution a��l�r

2- TwitterProject.Domain ad�nda Class Library(.Core) Projesi a��l�r.
	2.1 Enums klas�r� a��l�r.
		2.1.1 Bu klas�r alt�na Status.cs a��l�r.
	 
	2.2 Entities klasr� a��l�r. 
		2.2.1 Interface klas�r� a��l�r ve bu klas�r alt�na IBaseEntity.cs interface'si a��l�r.

		2.2.2. Concrete klas�r� a��l�r. Bu klas�r�de projemizde ihtiya� duyulan s�n�flar olu�turulur.
			2.2.2.1 Child s�n�flara kal�t�m vermek ama�l� BaseEntity.cs a��l�r, abstract olarak i�aretlenir, IBaseEntity'den implement al�n�r ve IBaseEntity'de yazd���m�z propertyler burada g�vde kazan�r.

            2.2.2.2 AppRole.cs a��l�r.
            Not: Kullan�c� ile ilgili i�lemlerde Asp .Net Core Identity s�n�f�ndan yararlanaca��m. Bu ba�lamda AppUserRole ve AppUser s�n�flar�nda Identity s�n�fdan kal�t�m alacaklar. Bunu i�in Microsoft.Extensions.Identity.Store paketini y�kleyece�iz.

            2.2.2.3 AppUser.cs a��l�r.
			2.2.2.4 Follow.cs a��l�r.
			2.2.2.5 Mention.cs a��l�r.
			2.2.2.6 Like.cs a��l�r.
			2.2.2.7 Share.cs a��l�r.
			2.2.2.8 Tweet.cs a��l�r.

	2.3 Repositories klas�r� a��l�r. Projede temel anlamda CRUD operasyonlar�n� y�r�tece�im methodlar� asenkron programing'e uygun �ekilde olu�turaca��m.
		2.3.1 BaseRepo kls�r� a��l�r i�ine IRepository interfaces eklenir.
		Not: Microsoft.EntityFremeworkCore(5.0.2) Nuget Package Manager'den y�klenir.
		Not: GenericRepository Pattern, DIP kullanaca��m�z i�in her Concrete s�n�f i�in Repository a�aca��z.
		2.3.2 EntityTypeRepo klas�r� a��l�r.
			2.3.2.1 IAppUserRepository a��l�r.
			2.3.2.2 IFollowRepository a��l�r.
			2.3.2.3 ILikeRepository a��l�r.
			2.3.2.4 IMentionRepository a��l�r.
			2.3.2.5 IShareRepository a��l�r.
			2.3.2.6 ITweetRepository a��l�r.

	2.4 UnitOfWork klas�r� a��l�r.
		2.4.1 IUnitOfWork.cs aray�z� a��l�r.  Bu aray�zde Unit Of Work desenine dahil etmek istedi�imiz Repository'leri ekliyoruz.


3-TwitterProject.Infrastructure ad�nda Class Library(.Core) Projesi a��l�r.

	Not: Microsoft.EntityFremeworkCore(5.0.2) Nuget Package Manager'den y�klenir.
	Not: Referanslara TwitterProject.Domain katman� eklenir.

	3.2 Mapping Klas�r� A��l�r.

		3.2.1 Abstract klas�r� eklenir.
			3.1.1.1 BaseMap.cs eklenir ve abstract olarak i�aretlenir.

		3.2.2 Concrete klas�r� eklenir.
			3.2.2.1 AppRoleMap.cs a��l�r.
			3.2.2.2 AppUserMap.cs a��l�r.
			3.2.2.3 FollowMap.cs a��l�r.
			3.2.2.4 LikeMap.cs a��l�r.
			3.2.2.5 MentionMap.cs a��l�r.
			3.2.2.6 ShareMap.cs a��l�r.
			3.2.2.7 TweetMap.cs a��l�r.
	
	3.3 Context klas�r� a��l�r.
		3.3.1 ApplicationDbContext.cs a��l�r. CodeFirst ile aya�a kald�raca��m�z projen�n tablolar�n� DbSet edece�iz ve Mapping i�erisinde yapm�� oldu�umuz Map'leme i�lemlerini override edece�iz.

		NOT: Microsoft.AspNetCore.Identity.EntityFrameWork.Core (5.0.2) Nuget Package Manager'den y�klenir.


	3.4 Repositories Kla�s�r a��l�r. Burada Domain k�sm�nda olu�turdu�umuz Generic Repository'lere g�vde kazand�raca��z.
		Not: GenericRepository ile ilgili daha fazla bilgi i�in bknz https://samettteraslan.gitbook.io/desing-patterns/

		3.4.1 AppUserRepository a��ld�.
		3.4.2 FollowRepository a��ld�.
		3.4.3 LikeRepository a��ld�.
		3.4.4 MentionRepository a��ld�.
		3.4.5 ShareRepository a��ld�.
		3.4.6 TweetRepository a��ld�.

	3.5 UnitOfWork Klas�r� a��l�r.
		3.5.1 UnitOfWork.cs eklenir. Burada TwitterProject.Domain katman�nda olu�turdu�umuz UnitOfWork methodlar�n� g�vdelendirece�iz.
		Not: UnitOfWork ile ilgili daha fazla bilgi i�in bknz https://samettteraslan.gitbook.io/desing-patterns/


4-TwitterProject.Application Katman� a��l�r.
		NOT: Microsoft.AspNet.Core.Http.Features (5.0.2) Nuget Package Manager'den y�klenir.

	4.1 Models klas�r� eklenir.
		4.1.2 DTOs klas�r� eklenir.
			4.1.2.1 AddMentionDTO a��ld�.
			4.1.2.2 AddTweetDTO a��ld�.
			4.1.2.3 EditProfileDTO a��ld�.
			4.1.2.4 FollowDTO a��ld�.
			4.1.2.5 LikeDTO a��ld�.
			4.1.2.6 LoginDTO a��ld�.
			4.1.2.7 ProfileSummaryDTO a��ld�.
			4.1.2.8 RegisterDTO a��ld�.

	4.2 AutoMapper yapmak i�in Mapper klas�r� a��l�r ve alt�na Mapping.cs ad�nda s�n�f eklendir.

		NOT: AutoMapper Nuget Package Manager'den y�klenir.
		NOT: AutoMapper Microsoft.DependencyInjection 8.1.1 Nuget Package Manager'den y�klenir.


				// AutoMapper Link Ekle//

	4.3 Services klas�r� a��l�r.
		



