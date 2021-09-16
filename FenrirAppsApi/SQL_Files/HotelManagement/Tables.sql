Use HotelManagement

Begin Try	Drop Table dbo.t_Employees				End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_Permissions			End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_Employee_Permissions	End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_Constants				End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_Guests					End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_Rooms					End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_Payments				End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_Bookings				End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_Countries				End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_States					End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_Cities					End Try		Begin Catch	End Catch

IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'HotelManagement' And Table_Name = 't_Employees'))
	Create Table t_Employees (EmployeeID Int, UserName Varchar(50), FirstName Varchar(50), MidName Varchar(50), LastName1 Varchar(50), LastName2 Varchar(50), Locked Bit, LockCount Int, LockedDateTime DateTime, RequiresReset Bit,
		Password Varchar(50), EmployeeTypeID Int, StartDateTime DateTime, LastLoginDateTime DateTime, Terminated Bit, TerminatedDateTime DateTime,
		CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)

IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'HotelManagement' And Table_Name = 't_Permissions'))
	Create Table t_Permissions (PermissionID Int, ParentID Int, Code Int, Name Varchar(50), Description Varchar(500), Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)
	
IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'HotelManagement' And Table_Name = 't_Employee_Permissions'))
	Create Table t_Employee_Permissions (EmployeeID Int, PermissionID Int, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)

IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'HotelManagement' And Table_Name = 't_Constants'))
	Create Table t_Constants (ConstantID Int, ParentID Int, Name Varchar(50), Description Varchar(500), Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)

IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'HotelManagement' And Table_Name = 't_Guests'))
	Create Table t_Guests (GuestID Int, FirstName Varchar(50), MidName Varchar(50), LastName1 Varchar(50), LastName2 Varchar(50), GuestTypeID Int, DLNo Varchar(20), BlackListed Bit, BlackListedDate DateTime, 
		StreetAddress Varchar(50), CountryID Int, StateID Int, CityID Int, PostalCode Varchar(50), Email Varchar(50), PhoneNumber Varchar(20), Comment Varchar(1000),
		CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)

IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'HotelManagement' And Table_Name = 't_Rooms'))
	Create Table t_Rooms (RoomID Int, RoomNo Int, RoomTypeID Int, RoomRate Money, RoomStatusID Int, MaxCapacity Int, Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)

IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'HotelManagement' And Table_Name = 't_Payments'))
	Create Table t_Payments (PaymentID Int, GuestID Int, Amount Money, CardTypeID Int, SafetyDeposit Money, Comment Varchar(1000), CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)

IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'HotelManagement' And Table_Name = 't_Bookings'))
	Create Table t_Bookings (BookingID Int, GuestID Int, PaymentID Int, CheckInDate DateTime, CheckOutDate DateTime, BookTypeID Int, BookRate Money, Comment Varchar(1000), Canceled Bit, CanceledDate DateTime, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)

IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'HotelManagement' And Table_Name = 't_Countries'))
	Create Table t_Countries (CountryID Int, Name Varchar(50), Abbrev Varchar(3), Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)

IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'HotelManagement' And Table_Name = 't_States'))
	Create Table t_States (CountryID Int, StateID Int, Name Varchar(50), Abbrev Varchar(3), Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)

IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'HotelManagement' And Table_Name = 't_Cities'))
	Create Table t_Cities (CountryID Int, StateID Int, CityID Int, Name Varchar(50), Abbrev Varchar(3), Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)

Select * From dbo.t_Employees
Select * From dbo.t_Permissions
Select * From dbo.t_Employee_Permissions
Select * From dbo.t_Constants
Select * From dbo.t_Guests
Select * From dbo.t_Rooms
Select * From dbo.t_Payments
Select * From dbo.t_Bookings
Select * From dbo.t_Countries
Select * From dbo.t_States
Select * From dbo.t_Cities

--Constants
--0, null, ConstantGroupings


--1, 0, EmployeeType

--3, 0, GuestTypes

--5, 0, RoomTypes
--31, 1, Single,
--32, 1, Double

--7, 0, RoomStatuses
--41, 2, Available
--42, 2, Booked,
--43, 2, ToBeCleaned

--9, 0, BookType,
--51, 3, InAdvance - Card,
--52, 3, AtTime - Card,
--53, 3, AtTime - Cash,
--54, 3, Future With Deposit
