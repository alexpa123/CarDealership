use CarDealershipDB
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'SelectFeaturedVehicles')
drop procedure SelectFeaturedVehicles
go

create procedure SelectFeaturedVehicles as
begin
	select [Image],Make,Model,Price,[Year]
	from Car
	join Make on Make.MakeId = Car.MakeId
	join Model on Model.ModelId = Car.ModelId
	where Featured = 1
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'SelectNewVehicles')
drop procedure SelectNewVehicles
go

create procedure SelectNewVehicles as
begin
	select [Image],Make,Model,BodyStyle,Transmission,ExteriorColor.Color as ExteriorColor,InteriorColor.Color as InteriorColor, Mileage, VIN, Price, MSRP, [Year]
	from Car
	join Make on Make.MakeId = Car.MakeId
	join Model on Model.ModelId = Car.ModelId
	join BodyStyle on BodyStyle.BodyStyleId = Car.BodyStyleId
	join Transmission on Transmission.TransmissionId = Car.TransmissionId
	join ExteriorColor on ExteriorColor.ExteriorColorId = Car.ExteriorColorId
	join InteriorColor on InteriorColor.InteriorColorId = Car.InteriorColorId
	where Car.[Year] = 2018
end
go


if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'SelectUsedVehicles')
drop procedure SelectUsedVehicles
go

create procedure SelectUsedVehicles as
begin
	select [Image],Make,Model,BodyStyle,Transmission,ExteriorColor.Color as ExteriorColor,InteriorColor.Color as InteriorColor, Mileage, VIN, Price, MSRP, [Year]
	from Car
	join Make on Make.MakeId = Car.MakeId
	join Model on Model.ModelId = Car.ModelId
	join BodyStyle on BodyStyle.BodyStyleId = Car.BodyStyleId
	join Transmission on Transmission.TransmissionId = Car.TransmissionId
	join ExteriorColor on ExteriorColor.ExteriorColorId = Car.ExteriorColorId
	join InteriorColor on InteriorColor.InteriorColorId = Car.InteriorColorId
	where Car.[Year] < 2018
end
go


if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'SelectSpecials')
drop procedure SelectSpecials
go

create procedure SelectSpecials as
begin
	select * from Special
end
go


--if exists(select * from INFORMATION_SCHEMA.ROUTINES
--where ROUTINE_NAME = 'NewVehicleSearch')
--drop procedure NewVehicleSearch
--go

--create procedure NewVehicleSearch(
--	@stringMakeModelOrYear as varchar(20) = null,
--	@minPrice as decimal = null,
--	@maxPrice as decimal = null,
--	@minYear as int = null,
--	@maxYear as int = null
--) as
--if @stringMakeModelOrYear = null
--	set @stringMakeModelOrYear = '';
--if @minPrice = null
--	--set @minPrice = 0;
--if @maxPrice = null
--	set @maxPrice = 50000
--if @minYear = null
--	set @minYear = 2000
--if @maxYear = null
--	set @maxYear = 2999

--begin
--	select Car.[CarId], [Image],Make,Model,BodyStyle,Transmission,ExteriorColor.Color as ExteriorColor,InteriorColor.Color as InteriorColor, Mileage, VIN, Price, MSRP, [Year], [Description]
--	from Car
--	join Make on Make.MakeId = Car.MakeId
--	join Model on Model.ModelId = Car.ModelId
--	join BodyStyle on BodyStyle.BodyStyleId = Car.BodyStyleId
--	join Transmission on Transmission.TransmissionId = Car.TransmissionId
--	join ExteriorColor on ExteriorColor.ExteriorColorId = Car.ExteriorColorId
--	join InteriorColor on InteriorColor.InteriorColorId = Car.InteriorColorId
--	where Price >= @minPrice and Price <= @maxPrice 
--	--and [Year] >= @minYear and [Year] <= @maxYear or
--	--Model.Model like '%'+ @stringMakeModelOrYear +'%' or Make like '%'+ @stringMakeModelOrYear + '%'
--end
--go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'GetCarById')
drop procedure GetCarById
go

create procedure GetCarById(
	@carId int
) as
begin
	select CarId,[Image],Make,Model,BodyStyle,Transmission,ExteriorColor.Color as ExteriorColor,InteriorColor.Color as InteriorColor, Mileage, VIN, Price, MSRP, [Year], [Description]
	from Car
	join Make on Make.MakeId = Car.MakeId
	join Model on Model.ModelId = Car.ModelId
	join BodyStyle on BodyStyle.BodyStyleId = Car.BodyStyleId
	join Transmission on Transmission.TransmissionId = Car.TransmissionId
	join ExteriorColor on ExteriorColor.ExteriorColorId = Car.ExteriorColorId
	join InteriorColor on InteriorColor.InteriorColorId = Car.InteriorColorId
	where Car.CarId = @carId
end
go




if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'NewVehicleSearch')
drop procedure NewVehicleSearch
go

create procedure NewVehicleSearch(
	@stringMakeModelOrYear as varchar(20) = null,
	@minPrice as decimal = 0,
	@maxPrice as decimal = 0,
	@minYear as int = 0,
	@maxYear as int = 0
) as
if @stringMakeModelOrYear = null
set @stringMakeModelOrYear = ''

if  @minPrice = 0
set @minPrice = 0

if @maxPrice = 0
set @maxPrice = 100000

if @minYear = 0
set @minYear = 1990

if @maxYear = 0
set @maxYear = 2999
	begin
	select Car.[CarId], [Image],Make,Model,BodyStyle,Transmission,ExteriorColor.Color as ExteriorColor,InteriorColor.Color as InteriorColor, Mileage, VIN, Price, MSRP, [Year], [Description]
	from Car
	join Make on Make.MakeId = Car.MakeId
	join Model on Model.ModelId = Car.ModelId
	join BodyStyle on BodyStyle.BodyStyleId = Car.BodyStyleId
	join Transmission on Transmission.TransmissionId = Car.TransmissionId
	join ExteriorColor on ExteriorColor.ExteriorColorId = Car.ExteriorColorId
	join InteriorColor on InteriorColor.InteriorColorId = Car.InteriorColorId
	join [Type] on [Type].TypeId = Car.TypeId
	where (Model.Model like '%'+ @stringMakeModelOrYear +'%' or Make.Make like '%'+ @stringMakeModelOrYear +'%' or [Year] like '%'+ @stringMakeModelOrYear + '%')
	and ([Type] = 'New' and Price >= @minPrice and Price <= @maxPrice and [Year] <= @maxYear and [Year] >= @minYear)
	end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'UsedVehicleSearch')
drop procedure UsedVehicleSearch
go

create procedure UsedVehicleSearch(
	@stringMakeModelOrYear as varchar(20) = null,
	@minPrice as decimal = 0,
	@maxPrice as decimal = 0,
	@minYear as int = 0,
	@maxYear as int = 0
) as
if @stringMakeModelOrYear = null
set @stringMakeModelOrYear = ''

if  @minPrice = 0
set @minPrice = 0

if @maxPrice = 0
set @maxPrice = 100000

if @minYear = 0
set @minYear = 1990

if @maxYear = 0
set @maxYear = 2999
	begin
	select Car.[CarId], [Image],Make,Model,BodyStyle,Transmission,ExteriorColor.Color as ExteriorColor,InteriorColor.Color as InteriorColor, Mileage, VIN, Price, MSRP, [Year], [Description]
	from Car
	join Make on Make.MakeId = Car.MakeId
	join Model on Model.ModelId = Car.ModelId
	join BodyStyle on BodyStyle.BodyStyleId = Car.BodyStyleId
	join Transmission on Transmission.TransmissionId = Car.TransmissionId
	join ExteriorColor on ExteriorColor.ExteriorColorId = Car.ExteriorColorId
	join InteriorColor on InteriorColor.InteriorColorId = Car.InteriorColorId
	join [Type] on [Type].TypeId = Car.TypeId
	where (Model.Model like '%'+ @stringMakeModelOrYear +'%' or Make.Make like '%'+ @stringMakeModelOrYear +'%' or [Year] like '%'+ @stringMakeModelOrYear + '%')
	and ([Type] = 'Used' and Price >= @minPrice and Price <= @maxPrice and [Year] <= @maxYear and [Year] >= @minYear)
	end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'SelectAllUnsoldVehicles')
drop procedure SelectAllUnsoldVehicles
go

create procedure SelectAllUnsoldVehicles(
	@stringMakeModelOrYear as varchar(20) = null,
	@minPrice as decimal = 0,
	@maxPrice as decimal = 0,
	@minYear as int = 0,
	@maxYear as int = 0
) as
if @stringMakeModelOrYear = null
set @stringMakeModelOrYear = ''

if  @minPrice = 0
set @minPrice = 0

if @maxPrice = 0
set @maxPrice = 100000

if @minYear = 0
set @minYear = 1990

if @maxYear = 0
set @maxYear = 2999
	begin
	select Car.[CarId], [Image],Make,Model,BodyStyle,Transmission,ExteriorColor.Color as ExteriorColor,InteriorColor.Color as InteriorColor, Mileage, VIN, Price, MSRP, [Year], [Description]
	from Car
	join Make on Make.MakeId = Car.MakeId
	join Model on Model.ModelId = Car.ModelId
	join BodyStyle on BodyStyle.BodyStyleId = Car.BodyStyleId
	join Transmission on Transmission.TransmissionId = Car.TransmissionId
	join ExteriorColor on ExteriorColor.ExteriorColorId = Car.ExteriorColorId
	join InteriorColor on InteriorColor.InteriorColorId = Car.InteriorColorId
	join [Type] on [Type].TypeId = Car.TypeId
	where (Model.Model like '%'+ @stringMakeModelOrYear +'%' or Make.Make like '%'+ @stringMakeModelOrYear +'%' or [Year] like '%'+ @stringMakeModelOrYear + '%')
	and (Sold = 0 and Price >= @minPrice and Price <= @maxPrice and [Year] <= @maxYear and [Year] >= @minYear)
	end
go


if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'AdminVehicleSearch')
drop procedure AdminVehicleSearch
go

create procedure AdminVehicleSearch(
	@stringMakeModelOrYear as varchar(20) = null,
	@minPrice as decimal = 0,
	@maxPrice as decimal = 0,
	@minYear as int = 0,
	@maxYear as int = 0
) as
if @stringMakeModelOrYear = null
set @stringMakeModelOrYear = ''

if  @minPrice = 0
set @minPrice = 0

if @maxPrice = 0
set @maxPrice = 100000

if @minYear = 0
set @minYear = 1990

if @maxYear = 0
set @maxYear = 2999
	begin
	select Car.[CarId], [Image],Make,Model,BodyStyle,Transmission,ExteriorColor.Color as ExteriorColor,InteriorColor.Color as InteriorColor, Mileage, VIN, Price, MSRP, [Year], [Description]
	from Car
	join Make on Make.MakeId = Car.MakeId
	join Model on Model.ModelId = Car.ModelId
	join BodyStyle on BodyStyle.BodyStyleId = Car.BodyStyleId
	join Transmission on Transmission.TransmissionId = Car.TransmissionId
	join ExteriorColor on ExteriorColor.ExteriorColorId = Car.ExteriorColorId
	join InteriorColor on InteriorColor.InteriorColorId = Car.InteriorColorId
	join [Type] on [Type].TypeId = Car.TypeId
	where (Model.Model like '%'+ @stringMakeModelOrYear +'%' or Make.Make like '%'+ @stringMakeModelOrYear +'%' or [Year] like '%'+ @stringMakeModelOrYear + '%')
	and (Price >= @minPrice and Price <= @maxPrice and [Year] <= @maxYear and [Year] >= @minYear)
	end
go


if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'AddContact')
drop procedure AddContact
go

create procedure AddContact(
	@Name varchar(30),
	@Email varchar(30),
	@Phone varchar(12),
	@Message varchar(1000),
	@Vin varchar(30) = null
) as
	declare @ContactId int
	begin
		insert into Contact([Name],[Email],Phone,[Message],VIN)
		values(@Name,@Email,@Phone,@Message,@Vin)
		select @ContactId = scope_identity();
	end
go


if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'UpdateSale')
drop procedure UpdateSale
go

create procedure UpdateSale(
	@userName varchar(30),
	@carId int,
	@purchaseType varchar(30),
	@purchasePrice decimal,
	@name varchar(30) = null,
	@phone varchar(30) = null,
	@email varchar(30) = null,
	@street1 varchar(30) = null,
	@street2 varchar(30) = null,
	@city varchar(30) = null,
	@state varchar(30) = null,
	@zipcode varchar(30) = null
) as
	declare @Date date
	begin
		set @Date = GETDATE()
		insert into Sale([UserName],[CarId],[PurchaseType],[PurchasePrice],[Name],[Phone],
						[Email],[Street1],[Street2],[City],[State],[Zipcode],[Date])
		values(@userName,@carId,@purchaseType,@purchasePrice,@name,@phone,@email,@street1,@street2,@city,@state,@zipcode,@Date)

	end
go



if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'AddVehicle')
drop procedure AddVehicle
go

create procedure AddVehicle(
	@make varchar(30),
	@model varchar(30),
	@type varchar(30),
	@bodyStyle varchar(30),
	@year int,
	@transmission varchar(30),
	@exteriorColor varchar(30),
	@interiorColor varchar(30),
	@mileage int,
	@vin varchar(30),
	@msrp decimal,
	@price decimal,
	@description varchar(30) = null,
	@featured bit = 0,
	@sold bit = 0,
	@specialId int = null,
	@image varchar(50) = null
) as
	declare @makeId int
	declare @modelId int
	declare @bodyStyleId int
	declare @transmissionId int
	declare @typeId int
	declare @exteriorColorId int
	declare @interiorColorId int

	set @makeId = (select MakeId from Make where Make.Make = @make)
	set @modelId = (select ModelId from Model where Model.Model = @model)
	set @bodyStyleId = (select BodyStyleId from BodyStyle where Bodystyle.BodyStyle = @bodyStyle)
	set @typeId = (select TypeId from [Type] where [Type].[Type] = @type)
	set @transmissionId = (select TransmissionId from Transmission where Transmission = @transmission)
	set @exteriorColorId = (select ExteriorColorId from ExteriorColor where ExteriorColor.Color = @exteriorColor)
	set @interiorColorId = (select InteriorColorId from InteriorColor where InteriorColor.Color = @interiorColor)
begin	
insert into Car(MakeId,ModelId,SpecialId,BodyStyleId,TransmissionId,Price,MSRP,TypeId,ExteriorColorId,InteriorColorId,VIN,
				Mileage,[Description],[Image],Sold,Featured,[Year])
		 values(@makeId,@modelId,@specialId,@bodyStyleId,@transmissionId,@price,@msrp,@typeId,@exteriorColorId,@interiorColorId,
				@vin,@mileage,@description,@image,@sold,@featured,@year)
end
go


if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'EditVehicle')
drop procedure EditVehicle
go

create procedure EditVehicle(
	@carId int,
	@make varchar(30) = null,
	@model varchar(30) = null,
	@type varchar(30) = null,
	@bodyStyle varchar(30) = null,
	@year int,
	@transmission varchar(30) = null,
	@exteriorColor varchar(30) = null,
	@interiorColor varchar(30) = null,
	@mileage int,
	@vin varchar(30),
	@msrp decimal,
	@price decimal,
	@description varchar(30) = null,
	@featured bit = 0,
	@sold bit = 0,
	@specialId int = null,
	@image varchar(50) = null
) as
	declare @makeId int
	declare @modelId int
	declare @bodyStyleId int
	declare @transmissionId int
	declare @typeId int
	declare @exteriorColorId int
	declare @interiorColorId int

	set @makeId = (select MakeId from Make where Make.Make = @make)
	set @modelId = (select ModelId from Model where Model.Model = @model)
	set @bodyStyleId = (select BodyStyleId from BodyStyle where Bodystyle.BodyStyle = @bodyStyle)
	set @typeId = (select TypeId from [Type] where [Type].[Type] = @type)
	set @transmissionId = (select TransmissionId from Transmission where Transmission = @transmission)
	set @exteriorColorId = (select ExteriorColorId from ExteriorColor where ExteriorColor.Color = @exteriorColor)
	set @interiorColorId = (select InteriorColorId from InteriorColor where InteriorColor.Color = @interiorColor)
begin	
update Car set
	Car.MakeId = @makeId,
	Car.ModelId = @modelId,
	Car.SpecialId = @specialId,
	Car.BodyStyleId = @bodyStyleId,
	Car.TransmissionId = @transmissionId,
	Car.Price = @price,
	Car.MSRP = @msrp,
	Car.[TypeId] = @typeId,
	Car.ExteriorColorId = @exteriorColorId,
	Car.InteriorColorId = @interiorColorId,
	Car.VIN = @vin,
	Car.Mileage = @mileage,
	Car.[Description] = @description,
	Car.[Image] = @image,
	Car.Sold = @sold,
	Car.Featured = @featured,
	Car.[Year] = @year
	where Car.CarId = @carId
end
go