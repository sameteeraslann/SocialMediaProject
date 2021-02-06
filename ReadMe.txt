
1- TwitterProject adýnda BlankSolution açýlýr

2- TwitterProject.Domain adýnda Class Library(.Core) Projesi açýlýr.
	2.1 Enums klasörü açýlýr.
		2.1.1 Bu klasör altýna Status.cs açýlýr.
	 
	2.2 Entities klasrü açýlýr. 
		2.2.1 Interface klasörü açýlýr ve bu klasör altýna IBaseEntity.cs interface'si açýlýr.

		2.2.2. Concrete klasörü açýlýr. Bu klasörüde projemizde ihtiyaç duyulan sýnýflar oluþturulur.
			2.2.2.1 Child sýnýflara kalýtým vermek amaçlý BaseEntity.cs açýlýr, abstract olarak iþaretlenir, IBaseEntity'den implement alýnýr ve IBaseEntity'de yazdýðýmýz propertyler burada gövde kazanýr.

            2.2.2.2 AppRole.cs açýlýr.
            Not: Kullanýcý ile ilgili iþlemlerde Asp .Net Core Identity sýnýfýndan yararlanacaðým. Bu baðlamda AppUserRole ve AppUser sýnýflarýnda Identity sýnýfdan kalýtým alacaklar. Bunu için Microsoft.Extensions.Identity.Store paketini yükleyeceðiz.

            2.2.2.3 AppUser.cs açýlýr.
			2.2.2.4 Follow.cs açýlýr.
			2.2.2.5 Mention.cs açýlýr.
			2.2.2.6 Like.cs açýlýr.
			2.2.2.7 Share.cs açýlýr.
			2.2.2.8 Tweet.cs açýlýr.

	2.3 Repositories klasörü açýlýr. Projede temel anlamda CRUD operasyonlarýný yürüteceðim methodlarý asenkron programing'e uygun þekilde oluþturacaðým.
		2.3.1 BaseRepo klsörü açýlýr içine IRepository interfaces eklenir.
		Not: Microsoft.EntityFremeworkCore(5.0.2) Nuget Package Manager'den yüklenir.
		Not: GenericRepository Pattern, DIP kullanacaðýmýz için her Concrete sýnýf için Repository açacaðýz.
		2.3.2 EntityTypeRepo klasörü açýlýr.
			2.3.2.1 IAppUserRepository açýlýr.
			2.3.2.2 IFollowRepository açýlýr.
			2.3.2.3 ILikeRepository açýlýr.
			2.3.2.4 IMentionRepository açýlýr.
			2.3.2.5 IShareRepository açýlýr.
			2.3.2.6 ITweetRepository açýlýr.

	2.4 UnitOfWork klasörü açýlýr.
		2.4.1 IUnitOfWork.cs arayüzü açýlýr.  Bu arayüzde Unit Of Work desenine dahil etmek istediðimiz Repository'leri ekliyoruz.


3-TwitterProject.Infrastructure adýnda Class Library(.Core) Projesi açýlýr.

	Not: Microsoft.EntityFremeworkCore(5.0.2) Nuget Package Manager'den yüklenir.
	Not: Referanslara TwitterProject.Domain katmaný eklenir.

	3.2 Mapping Klasörü Açýlýr.

		3.2.1 Abstract klasörü eklenir.
			3.1.1.1 BaseMap.cs eklenir ve abstract olarak iþaretlenir.

		3.2.2 Concrete klasörü eklenir.
			3.2.2.1 AppRoleMap.cs açýlýr.
			3.2.2.2 AppUserMap.cs açýlýr.
			3.2.2.3 FollowMap.cs açýlýr.
			3.2.2.4 LikeMap.cs açýlýr.
			3.2.2.5 MentionMap.cs açýlýr.
			3.2.2.6 ShareMap.cs açýlýr.
			3.2.2.7 TweetMap.cs açýlýr.
	
	3.3 Context klasörü açýlýr.
		3.3.1 ApplicationDbContext.cs açýlýr. CodeFirst ile ayaða kaldýracaðýmýz projenýn tablolarýný DbSet edeceðiz ve Mapping içerisinde yapmýþ olduðumuz Map'leme iþlemlerini override edeceðiz.

		NOT: Microsoft.AspNetCore.Identity.EntityFrameWork.Core (5.0.2) Nuget Package Manager'den yüklenir.


	3.4 Repositories Klaösür açýlýr. Burada Domain kýsmýnda oluþturduðumuz Generic Repository'lere gövde kazandýracaðýz.
		Not: GenericRepository ile ilgili daha fazla bilgi için bknz https://samettteraslan.gitbook.io/desing-patterns/

		3.4.1 AppUserRepository açýldý.
		3.4.2 FollowRepository açýldý.
		3.4.3 LikeRepository açýldý.
		3.4.4 MentionRepository açýldý.
		3.4.5 ShareRepository açýldý.
		3.4.6 TweetRepository açýldý.

	3.5 UnitOfWork Klasörü açýlýr.
		3.5.1 UnitOfWork.cs eklenir. Burada TwitterProject.Domain katmanýnda oluþturduðumuz UnitOfWork methodlarýný gövdelendireceðiz.
		Not: UnitOfWork ile ilgili daha fazla bilgi için bknz https://samettteraslan.gitbook.io/desing-patterns/


4-TwitterProject.Application Katmaný açýlýr.
		NOT: Microsoft.AspNet.Core.Http.Features (5.0.2) Nuget Package Manager'den yüklenir.

	4.1 Models klasörü eklenir.
		4.1.2 DTOs klasörü eklenir.
			4.1.2.1 AddMentionDTO açýldý.
			4.1.2.2 AddTweetDTO açýldý.
			4.1.2.3 EditProfileDTO açýldý.
			4.1.2.4 FollowDTO açýldý.
			4.1.2.5 LikeDTO açýldý.
			4.1.2.6 LoginDTO açýldý.
			4.1.2.7 ProfileSummaryDTO açýldý.
			4.1.2.8 RegisterDTO açýldý.

	4.2 AutoMapper yapmak için Mapper klasörü açýlýr ve altýna Mapping.cs adýnda sýnýf eklendir.

		NOT: AutoMapper Nuget Package Manager'den yüklenir.
		NOT: AutoMapper Microsoft.DependencyInjection 8.1.1 Nuget Package Manager'den yüklenir.


				// AutoMapper Link Ekle//

	4.3 Services klasörü açýlýr.
		



