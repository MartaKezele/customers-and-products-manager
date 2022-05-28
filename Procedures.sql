use AdventureWorksOBP
go

-- country

create proc RetrieveCountryByID
	@IDDrzava int
as
begin
	select * from Drzava where IDDrzava = @IDDrzava
end
go

create proc RetrieveAllCountries
as
begin
	select * from Drzava
end
go

create proc RetrieveCountryByCityID
	@IDGrad int
as
begin
	select * from Drzava where IDDrzava = (select DrzavaID from Grad where IDGrad = @IDGrad)
end
go

-- city

create proc RetrieveCityByID
	@IDGrad int
as
begin
	select * from Grad where IDGrad = @IDGrad
end
go

create proc RetrieveCitiesByCountryID
	@IDDrzava int
as
begin
	select * from Grad where DrzavaID = @IDDrzava order by Naziv
end
go

-- customer

create proc CreateCustomer
	@Ime nvarchar(50),
	@Prezime nvarchar(50),
	@Email nvarchar(50),
	@Telefon nvarchar(25),
	@IDGrad int
as
begin
	if not exists(select * from Kupac where Ime = @Ime and Prezime = @Prezime and Email = @Email and Telefon = @Telefon and GradID = @IDGrad)
	insert into Kupac(Ime, Prezime, Email, Telefon, GradID)
	values(@Ime, @Prezime, @Email, @Telefon, @IDGrad)
end
go

create proc RetrieveCustomerByID
	@IDKupac int
as
begin
	select * 
	from Kupac
	where IDKupac = @IDKupac
end
go

create proc RetrieveCustomerByReceiptID
	@IDRacun int
as
begin
	select * from Kupac where IDKupac in (select KupacID from Racun where IDRacun = @IDRacun)
end
go

create proc RetrieveAllCustomers
as
begin
	select *
	from Kupac
end
go

create proc RetrieveCustomersByCityID
	@IDGrad int
as
begin
	select *
	from Kupac
	where GradID = @IDGrad
	order by IDKupac
end
go

create proc UpdateCustomerByID
	@IDKupac int,
	@Ime nvarchar(50),
	@Prezime nvarchar(50),
	@Email nvarchar(50),
	@Telefon nvarchar(25),
	@IDGrad int
as
begin
	if not exists(select * from Kupac where Ime = @Ime and Prezime = @Prezime and Email = @Email and Telefon = @Telefon and GradID = @IDGrad)
	begin
		update Kupac
		set
			Ime = @Ime,
			Prezime = @Prezime,
			Email = @Email,
			Telefon = @Telefon,
			GradID = @IDGrad
		where IDKupac=@IDKupac
	end
end
go

create proc DeleteCustomerByID
	@IDKupac int
as
begin
	delete from Stavka where RacunID in (select IDRacun from Racun where KupacID = @IDKupac)
	delete from Racun where KupacID = @IDKupac
	delete from Kupac where IDKupac = @IDKupac
end
go


-- recepit

create proc RetrieveReceiptByID
	@IDRacun int
as
begin
	select * from Racun where IDRacun = @IDRacun
end
go

create proc RetrieveReceiptsByCustomerID
	@IDKupac int
as
begin
	select * from Racun where KupacID = @IDKupac
end
go

create proc DeleteReceiptByID
	@IDRacun int
as
begin
	delete from Stavka where RacunID = @IDRacun
	delete from Racun where IDRacun = @IDRacun
end
go



-- commercialist

create proc RetrieveCommercialistByID
	@IDKomercijalist int
as
begin
	select * from Komercijalist where IDKomercijalist = @IDKomercijalist
end
go

-- credit card

create proc RetrieveCreditCardByID
	@IDKreditnaKartica int
as
begin
	select * from KreditnaKartica where IDKreditnaKartica = @IDKreditnaKartica
end
go

--items

create proc RetrieveItemByID
	@IDStavka int
as
begin
	select * from Stavka where IDStavka = @IDStavka
end
go

create proc RetrieveItemsByReceiptID
	@IDRacun int
as
begin
	select * from Stavka where RacunID = @IDRacun
end
go

create proc DeleteItemByID
	@IDStavka int
as
begin
	delete from Stavka where IDStavka = @IDStavka
end
go


-- product

create proc CreateProductWithSubcategory
	@Naziv nvarchar(50),
	@BrojProizvoda nvarchar(25),
	@Boja nvarchar(15),
	@MinimalnaKolicinaNaSkladistu smallint,
	@CijenaBezPDV money,
	@PotkategorijaID int
as
begin
	if not exists(select * from Proizvod where 
	Naziv = @Naziv and 
	BrojProizvoda = @BrojProizvoda and 
	Boja = @Boja and 
	MinimalnaKolicinaNaSkladistu = @MinimalnaKolicinaNaSkladistu and 
	CijenaBezPDV = @CijenaBezPDV and 
	PotkategorijaID = @PotkategorijaID)
		begin
			insert into Proizvod(Naziv, BrojProizvoda, Boja, MinimalnaKolicinaNaSkladistu, CijenaBezPDV, PotkategorijaID)
			values(@Naziv, @BrojProizvoda, @Boja, @MinimalnaKolicinaNaSkladistu, @CijenaBezPDV, @PotkategorijaID)
		end
end
go

create proc CreateProductWithoutSubcategory
	@Naziv nvarchar(50),
	@BrojProizvoda nvarchar(25),
	@Boja nvarchar(15),
	@MinimalnaKolicinaNaSkladistu smallint,
	@CijenaBezPDV money
as
begin
	if not exists(select * from Proizvod where 
	Naziv = @Naziv and 
	BrojProizvoda = @BrojProizvoda and 
	Boja = @Boja and 
	MinimalnaKolicinaNaSkladistu = @MinimalnaKolicinaNaSkladistu and 
	CijenaBezPDV = @CijenaBezPDV)
		begin
			insert into Proizvod(Naziv, BrojProizvoda, Boja, MinimalnaKolicinaNaSkladistu, CijenaBezPDV)
			values(@Naziv, @BrojProizvoda, @Boja, @MinimalnaKolicinaNaSkladistu, @CijenaBezPDV)
		end
end
go

create proc RetrieveProductByID
	@IDProizvod int
as
begin
	select * from Proizvod where IDProizvod = @IDProizvod
end
go

create proc RetrieveAllProducts
as
begin
	select * from Proizvod
end
go

create proc UpdateProductByID
	@IDProizvod int,
	@Naziv nvarchar(50),
	@BrojProizvoda nvarchar(25),
	@Boja nvarchar(15),
	@MinimalnaKolicinaNaSkladistu smallint,
	@CijenaBezPDV money,
	@PotkategorijaID int
as
begin
	if not exists(select * from Proizvod where 
	Naziv = @Naziv and 
	BrojProizvoda = @BrojProizvoda and 
	Boja = @Boja and 
	MinimalnaKolicinaNaSkladistu = @MinimalnaKolicinaNaSkladistu and 
	CijenaBezPDV = @CijenaBezPDV and 
	PotkategorijaID = @PotkategorijaID)
	begin
		update Proizvod
		set 
			Naziv = @Naziv, 
			BrojProizvoda = @BrojProizvoda, 
			Boja = @Boja, 
			MinimalnaKolicinaNaSkladistu = @MinimalnaKolicinaNaSkladistu, 
			CijenaBezPDV = @CijenaBezPDV, 
			PotkategorijaID = @PotkategorijaID
		where IDProizvod = @IDProizvod
	end
end
go

create proc DeleteProductByID
	@IDProizvod int
as
begin
	delete from Stavka where ProizvodID = @IDProizvod
	delete from Proizvod where IDProizvod = @IDProizvod
end
go

-- subcategory

create proc CreateSubcategory
	@Naziv nvarchar(50),
	@IDKategorija int
as
begin
	if not exists(select * from Potkategorija where Naziv = @Naziv and KategorijaID = @IDKategorija)
	begin
		insert into Potkategorija(Naziv, KategorijaID)
		values(@Naziv, @IDKategorija)
	end
end
go

create proc RetrieveSubcategoryByID
	@IDPotkategorija int
as
begin
	select * from Potkategorija where IDPotkategorija = @IDPotkategorija
end
go

create proc RetrieveAllSubcategories
as
begin
	select * from Potkategorija
end
go

create proc RetrieveSubcategoriesByCategoryID
	@IDKategorija int
as
begin
	select * from Potkategorija where KategorijaID = @IDKategorija
end
go

create proc UpdateSubcategoryByID
	@IDPotkategorija int,
	@Naziv nvarchar(50),
	@IDKategorija int
as
begin
	if not exists(select * from Potkategorija where Naziv = @Naziv and KategorijaID = @IDKategorija)
	begin
		update Potkategorija
		set Naziv = @Naziv, KategorijaID = @IDKategorija
		where IDPotkategorija = @IDPotkategorija
	end
end
go

create proc DeleteSubcategoryByID
	@IDPotkategorija int
as
begin
	update Proizvod
	set PotkategorijaID = null
	where PotkategorijaID = @IDPotkategorija
	delete from Potkategorija where IDPotkategorija = @IDPotkategorija
end
go


-- category

create proc CreateCategory
	@Naziv nvarchar(50)
as
begin
	if not exists(select * from Kategorija where Naziv = @Naziv)
	begin		
		insert into Kategorija(Naziv)
		values(@Naziv)
	end
end
go

create proc RetrieveCategoryByID
	@IDKategorija int
as
begin
	select * from Kategorija where IDKategorija = @IDKategorija
end
go

create proc RetrieveCategoryBySubcategoryID
	@IDPotkategorija int
as
begin
	select *  from Kategorija where IDKategorija = (select KategorijaID from Potkategorija where IDPotkategorija = @IDPotkategorija)	
end
go

create proc RetrieveAllCategories
as
begin
	select * from Kategorija
end
go

create proc UpdateCategoryByID
	@IDKategorija int,
	@Naziv nvarchar(50)
as
begin
	if not exists(select * from Kategorija where Naziv = @Naziv)
	begin
		update Kategorija
		set
		Naziv = @Naziv
		where IDKategorija = @IDKategorija
	end
end
go

create proc DeleteCategoryByID
	@IDKategorija int
as
begin	
	update Proizvod
	set PotkategorijaID = null
	where PotkategorijaID in (select IDPotkategorija from Potkategorija where KategorijaID = @IDKategorija)
	
	delete from Potkategorija where KategorijaID = @IDKategorija
	delete from Kategorija where IDKategorija = @IDKategorija
end
go