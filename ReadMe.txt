
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

