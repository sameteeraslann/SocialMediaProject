
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
			2.3.2.1 IAppUserRepository açýld.
			2.3.2.2 IFollowRepository
			2.3.2.3 ILikeRepository
			2.3.2.4 IMentionRepository
			2.3.2.5 IShareRepository
			2.3.2.6 ITweetRepository

	2.4 UnitOfWork klasörü açýlýr.
		2.4.1 IUnitOfWork.cs arayüzü açýlýr.  Bu arayüzde Unit Of Work desenine dahil etmek istediðimiz Repository'leri ekliyoruz.


3-TwitterProject.Infrastructure adýnda Class Library(.Core) Projesi açýlýr.
