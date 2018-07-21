use CarDealershipDB
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'MakeDropdown')
drop procedure MakeDropdown
go

create procedure MakeDropdown as
begin
	select * from Make
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'ModelDropdown')
drop procedure ModelDropdown
go

create procedure ModelDropdown as
begin
	select * from Model
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'TypeDropdown')
drop procedure TypeDropdown
go

create procedure TypeDropdown as
begin
	select * from [Type]
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'BodyStyleDropDown')
drop procedure BodyStyleDropDown
go

create procedure BodyStyleDropDown as
begin
	select * from BodyStyle
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'ExteriorColorDropDown')
drop procedure ExteriorColorDropDown
go

create procedure ExteriorColorDropDown as
begin
	select * from ExteriorColor
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'InteriorColorDropDown')
drop procedure InteriorColorDropDown
go

create procedure InteriorColorDropDown as
begin
	select * from InteriorColor
end
go



if exists(select * from INFORMATION_SCHEMA.ROUTINES
where ROUTINE_NAME = 'TransmissionDropDown')
drop procedure TransmissionDropDown
go

create procedure TransmissionDropDown as
begin
	select * from Transmission
end
go