use CarDealershipDB
go

set identity_insert [Type] on;
insert into Type (TypeId, [Type]) values (1, 'New');
insert into Type (TypeId, [Type]) values(2, 'Used');
set identity_insert [Type] off;

set identity_insert BodyStyle on;
insert into BodyStyle (BodyStyleId, BodyStyle) values (1, 'Hatchback');
insert into BodyStyle (BodyStyleId, BodyStyle) values (2, 'Sedan');
insert into BodyStyle (BodyStyleId, BodyStyle) values (3, 'SUV');
insert into BodyStyle (BodyStyleId, BodyStyle) values (4, 'Crossover');
insert into BodyStyle (BodyStyleId, BodyStyle) values (5, 'Coupe');
insert into BodyStyle (BodyStyleId, BodyStyle) values (6, 'Convertible');
insert into BodyStyle (BodyStyleId, BodyStyle) values (7, 'Van');
set identity_insert BodyStyle off;

set identity_insert ExteriorColor on;
insert into ExteriorColor (ExteriorColorId, Color) values (1, 'Blue');
insert into ExteriorColor (ExteriorColorId, Color) values (2, 'Red');
insert into ExteriorColor (ExteriorColorId, Color) values (3, 'Orange');
insert into ExteriorColor (ExteriorColorId, Color) values (4, 'Yellow');
insert into ExteriorColor (ExteriorColorId, Color) values (5, 'Green');
insert into ExteriorColor (ExteriorColorId, Color) values (6, 'Brown');
set identity_insert ExteriorColor off;

set identity_insert InteriorColor on;
insert into InteriorColor (InteriorColorId, Color) values (1, 'Blue');
insert into InteriorColor (InteriorColorId, Color) values (2, 'Red');
insert into InteriorColor (InteriorColorId, Color) values (3, 'Orange');
insert into InteriorColor (InteriorColorId, Color) values (4, 'Yellow');
insert into InteriorColor (InteriorColorId, Color) values (5, 'Green');
insert into InteriorColor (InteriorColorId, Color) values (6, 'Brown');
set identity_insert InteriorColor off;

set identity_insert Special on;
insert into Special (SpecialId, Title, [Description]) values (1, 'Timi', 'Allsebrook');
insert into Special (SpecialId, Title, [Description]) values (2, 'Bent', 'Stadding');
insert into Special (SpecialId, Title, [Description]) values (3, 'Libbi', 'Mayes');
insert into Special (SpecialId, Title, [Description]) values (4, 'Alissa', 'Kurton');
set identity_insert Special off;

set identity_insert [Role] on;
insert into [Role] (RoleId, Title) values (1, 'Admin');
insert into [Role] (RoleId, Title) values (2, 'Sales');
set identity_insert [Role] off;


insert into [User] (UserName, RoleId, FirstName, LastName, Email, PhoneNumber, [Password]) values ('alexpa123', 1, 'Allyn', 'Maffei', 'amaffei0@hc360.com', '599-934-7672', 'eJ1CX0RVvd');
insert into [User] (UserName, RoleId, FirstName, LastName, Email, PhoneNumber, [Password]) values ('testuser123', 1, 'Goldina', 'Templar', 'gtemplar1@mat.com', '659-624-1880', 'qvejcfG');
insert into [User] (UserName, RoleId, FirstName, LastName, Email, PhoneNumber, [Password]) values ('Mike123', 2, 'Kirk', 'Maginn', 'kmaginn2@fc2.com', '385-171-3104', '3HkM7LId');
insert into [User] (UserName, RoleId, FirstName, LastName, Email, PhoneNumber, [Password]) values ('Alan123', 2, 'Dollie', 'Melding', 'dmelding3@time.com', '229-907-6833', 'wUoJZEWVziQ');


insert into RoleUser (RoleId, UserName) values (1, 'alexpa123');
insert into RoleUser (RoleId, UserName) values (1, 'testuser123');
insert into RoleUser (RoleId, UserName) values (2, 'Mike123');
insert into RoleUser (RoleId, UserName) values (2, 'Alan123');

set identity_insert Make on;
insert into Make (MakeId, Make) values (1, 'Toyota');
insert into Make (MakeId, Make) values (2, 'Honda');
insert into Make (MakeId, Make) values (3, 'Hyundai');
insert into Make (MakeId, Make) values (4, 'Ford');
insert into Make (MakeId, Make) values (5, 'Chevrolet');
set identity_insert Make off;

set identity_insert Model on;
insert into Model (ModelId, MakeId, Model) values (1, 1, 'Corolla');
insert into Model (ModelId, MakeId, Model) values (2, 2, 'Civic');
insert into Model (ModelId, MakeId, Model) values (3, 3, 'Sonata');
insert into Model (ModelId, MakeId, Model) values (4, 4, 'F-150');
insert into Model (ModelId, MakeId, Model) values (5, 5, 'Equinox');
insert into Model (ModelId, MakeId, Model) values (6, 1, 'Tundra');
insert into Model (ModelId, MakeId, Model) values (7, 2, 'Accord');
insert into Model (ModelId, MakeId, Model) values (8, 3, 'Elantra');
insert into Model (ModelId, MakeId, Model) values (9, 4, 'Focus');
insert into Model (ModelId, MakeId, Model) values (10, 5, 'Traverse');
set identity_insert Model off;


insert into UserMake (UserName, MakeId, DateAdded) values ('alexpa123', 1, '5/19/2016');
insert into UserMake (UserName, MakeId, DateAdded) values ('alexpa123', 2, '4/4/2018');
insert into UserMake (UserName, MakeId, DateAdded) values ('alexpa123', 3, '7/8/2016');
insert into UserMake (UserName, MakeId, DateAdded) values ('alexpa123', 4, '3/1/2017');
insert into UserMake (UserName, MakeId, DateAdded) values ('Mike123', 5, '12/22/2012');



insert into UserMakeModel (UserName, ModelId, MakeId, DateAdded) values ('alexpa123', 1, 1, '1/11/2018');
insert into UserMakeModel (UserName, ModelId, MakeId, DateAdded) values ('alexpa123', 2, 2, '1/6/2018');
insert into UserMakeModel (UserName, ModelId, MakeId, DateAdded) values ('alexpa123', 3, 3, '6/30/2018');
insert into UserMakeModel (UserName, ModelId, MakeId, DateAdded) values ('alexpa123', 4, 4, '9/9/2017');
insert into UserMakeModel (UserName, ModelId, MakeId, DateAdded) values ('alexpa123', 5, 5, '5/31/2018');



set identity_insert Transmission on;
insert into Transmission (TransmissionId, Transmission) values (1, 'Automatic');
insert into Transmission (TransmissionId, Transmission) values (2, 'Manual');
insert into Transmission (TransmissionId, Transmission) values (3, 'Automated Manual');
insert into Transmission (TransmissionId, Transmission) values (4, 'Continuously Variable Transmission');
insert into Transmission (TransmissionId, Transmission) values (5, 'Tiptronic');
set identity_insert Transmission off;


set identity_insert Car on;
insert into Car (CarId, MakeId, ModelId, SpecialId, BodyStyleId, TransmissionId, Price, MSRP, TypeId, ExteriorColorId, InteriorColorId, VIN, Mileage, [Description], [Image], Sold,Featured, [Year]) values (1, 1, 1, 2, 1, 1, 38117, 29645, 2, 1, 5, 'WBADX7C50CE938551', 93887, 'great car', 'TemporTurpis.jpeg', 1,0,2015);
insert into Car (CarId, MakeId, ModelId, SpecialId, BodyStyleId, TransmissionId, Price, MSRP, TypeId, ExteriorColorId, InteriorColorId, VIN, Mileage, [Description], [Image], Sold,Featured, [Year]) values (2, 2, 2, 4, 6, 1, 29633, 964, 2, 6, 3, 'WBSBR934X1E615069', 3491, 'great car', 'IdLuctus.tiff', 0,1,2018);
insert into Car (CarId, MakeId, ModelId, SpecialId, BodyStyleId, TransmissionId, Price, MSRP, TypeId, ExteriorColorId, InteriorColorId, VIN, Mileage, [Description], [Image], Sold,Featured, [Year]) values (3, 3, 3, 3, 4, 5, 30871, 31990, 2, 4, 1, '2G61V5S82E9931489', 86735, 'great car', 'Adipiscing.png', 0,1,2018);
insert into Car (CarId, MakeId, ModelId, SpecialId, BodyStyleId, TransmissionId, Price, MSRP, TypeId, ExteriorColorId, InteriorColorId, VIN, Mileage, [Description], [Image], Sold,Featured, [Year]) values (4, 4, 4, 3, 7, 2, 20572, 4163, 2, 1, 2, '5J6TF2H51EL788195', 96287, 'great car', 'Rutrortis.tiff', 0,1,2018);
insert into Car (CarId, MakeId, ModelId, SpecialId, BodyStyleId, TransmissionId, Price, MSRP, TypeId, ExteriorColorId, InteriorColorId, VIN, Mileage, [Description], [Image], Sold,Featured, [Year]) values (5, 5, 5, 3, 7, 2, 15829, 19669, 2, 5, 4, '19UUA9E51EA827161', 78767, 'great car', 'OdioJusto.gif', 0,1,2018);
insert into Car (CarId, MakeId, ModelId, SpecialId, BodyStyleId, TransmissionId, Price, MSRP, TypeId, ExteriorColorId, InteriorColorId, VIN, Mileage, [Description], [Image], Sold,Featured, [Year]) values (6, 1, 6, 3, 4, 5, 6014, 7566, 1, 6, 6, 'WAUKFBFL0EN207418', 78520, 'great car', 'Mollis.png', 0,1,2018);
insert into Car (CarId, MakeId, ModelId, SpecialId, BodyStyleId, TransmissionId, Price, MSRP, TypeId, ExteriorColorId, InteriorColorId, VIN, Mileage, [Description], [Image], Sold,Featured, [Year]) values (7, 2, 7, 1, 2, 3, 85, 20445, 2, 5, 2, '1G4GD5GGXAF732004', 111425, 'Fantastic car', 'MontesNascdil', 1,0,2016);
insert into Car (CarId, MakeId, ModelId, SpecialId, BodyStyleId, TransmissionId, Price, MSRP, TypeId, ExteriorColorId, InteriorColorId, VIN, Mileage, [Description], [Image], Sold,Featured, [Year]) values (8, 3, 8, 1, 2, 2, 1997, 3741, 2, 4, 3, '2HNYD28299H862984', 48239, 'Fantastic car', 'InFelisEu.tiff', 0,0,2014);
insert into Car (CarId, MakeId, ModelId, SpecialId, BodyStyleId, TransmissionId, Price, MSRP, TypeId, ExteriorColorId, InteriorColorId, VIN, Mileage, [Description], [Image], Sold,Featured, [Year]) values (9, 4, 9, 3, 3, 3, 24325, 10886, 2, 3, 5, 'WA1EY94L68D581400', 20563, 'Fantastic car', 'Libero.jpeg', 0,0,2012);
insert into Car (CarId, MakeId, ModelId, SpecialId, BodyStyleId, TransmissionId, Price, MSRP, TypeId, ExteriorColorId, InteriorColorId, VIN, Mileage, [Description], [Image], Sold,Featured, [Year]) values (10, 5, 10, 3, 2, 1, 21821, 14200, 2, 1, 6, 'WAUVC58E73A576111', 74396, 'Fantastic car', 'Suspendisenti.tiff', 0,0,2010);
set identity_insert Car off;

select * from Car


set identity_insert Customer on;
insert into Customer (CustomerId, FirstName, LastName, Phone, Email, Street1, Street2, City, Zipcode, [State]) values (1, 'Claudia', 'Ortmann', '702-670-9346', 'cortmann0@163.com', '81754 Grover Junction', '91 Westridge Place', 'Henderson', '0004-0360', 'NV');
insert into Customer (CustomerId, FirstName, LastName, Phone, Email, Street1, Street2, City, Zipcode, [State]) values (2, 'Bowie', 'Seifert', '614-770-2147', 'bseifert1@skype.com', '1 Pine View Lane', '17 Lukken Crossing', 'Columbus', '0591-2468', 'OH');
insert into Customer (CustomerId, FirstName, LastName, Phone, Email, Street1, Street2, City, Zipcode, [State]) values (3, 'Ronda', 'Drinan', '520-787-5234', 'rdrinan2@netvibes.com', '7792 Vidon Crossing', '76 Prairie Rose Road', 'Tucson', '36987-3279', 'AZ');
insert into Customer (CustomerId, FirstName, LastName, Phone, Email, Street1, Street2, City, Zipcode, [State]) values (4, 'Willie', 'Rawstron', '559-391-2043', 'wrawstron3@ftc.gov', '076 Emmet Avenue', '3 Shelley Alley', 'Fresno', '61919-464', 'CA');
insert into Customer (CustomerId, FirstName, LastName, Phone, Email, Street1, Street2, City, Zipcode, [State]) values (5, 'Flori', 'Westwood', '915-127-1358', 'fwestwood4@posterous.com', '77 Elgar Plaza', '58 Debra Street', 'El Paso', '63323-064', 'TX');
insert into Customer (CustomerId, FirstName, LastName, Phone, Email, Street1, Street2, City, Zipcode, [State]) values (6, 'Kendra', 'Tapley', '540-349-1931', 'ktapley5@dmoz.org', '6 Carey Alley', '820 Prentice Avenue', 'Roanoke', '49035-571', 'VA');
insert into Customer (CustomerId, FirstName, LastName, Phone, Email, Street1, Street2, City, Zipcode, [State]) values (7, 'Kim', 'Lyle', '763-350-5367', 'klyle6@google.ru', '79628 Calypso Avenue', '2652 Oak Valley Drive', 'Minneapolis', '0904-6181', 'MN');
insert into Customer (CustomerId, FirstName, LastName, Phone, Email, Street1, Street2, City, Zipcode, [State]) values (8, 'Evie', 'Daleman', '863-526-6339', 'edaleman7@walmart.com', '04812 Delladonna Crossing', '82104 Elmside Trail', 'Lakeland', '42507-417', 'FL');
insert into Customer (CustomerId, FirstName, LastName, Phone, Email, Street1, Street2, City, Zipcode, [State]) values (9, 'Bradford', 'Rolling', '225-940-4754', 'brolling8@paginegialle.it', '24932 Scofield Terrace', '207 Florence Junction', 'Baton Rouge', '49035-098', 'LA');
insert into Customer (CustomerId, FirstName, LastName, Phone, Email, Street1, Street2, City, Zipcode, [State]) values (10, 'Banky', 'Hardaker', '702-894-1909', 'bhardaker9@va.gov', '11326 Nova Way', '36 Di Loreto Way', 'Las Vegas', '65162-219', 'NV');
set identity_insert Customer off;

set identity_insert Contact on;
insert into Contact(ContactId,[Name],Email,Phone,[Message],VIN)
values(1, 'alex','ajpachec@gmail.com','333-333-3333','super long message', 'vinnumber');
set identity_insert Contact off;
