Insert Into t_Employees Values (101, 'Jayb', 'Jay', '', 'Bhakta', '', 0, 0, null, 0, 
	'Qwerty123', 10, GETUTCDATE(), GETUTCDATE(), 0, null, 
	101, GETUTCDATE(), 101, GETUTCDATE())
	
Insert Into t_Constants
Values(1, null, 'All Constants', 'List of Constants', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(10, 1, 'Employee Types', 'Constants for column EmployeeTypeID in t_Employees', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(20, 1, 'Guest Types', 'Constants for column GuestTypeID in t_Guests', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(30, 1, 'Room Types', 'Constants for column RoomTypeID in t_Rooms', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(40, 1, 'Room Status Types', 'Constants for column RoomStatusID in t_Rooms', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(50, 1, 'Payment Method Types', 'Constants for column PaymentMethodTypeId in t_Payments', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(60, 1, 'Card Types', 'Constants for column CardTypeID in t_Payments', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(70, 1, 'Book Types', 'Constants for column BookTypeID in t_Bookings', 0, 101, GETUTCDATE(), 101, GETUTCDATE())

Insert Into t_Constants
Values(1, 10, 'Basic User', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(2, 10, 'Administrator', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())

Insert Into t_Constants
Values(1, 20, 'Standard Guest', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(2, 20, 'Bronze Level Guest', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(3, 20, 'Silver Level Guest', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(4, 20, 'Gold Level Guest', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())

Insert Into t_Constants
Values(1, 30, 'Single Bed', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(2, 30, 'Double Bed', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(3, 30, 'Two Single Bed', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(4, 30, 'Two Double Bed', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(5, 30, 'Water Bed', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())

Insert Into t_Constants
Values(1, 40, 'Available', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(2, 40, 'Booked', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(3, 40, 'Available', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(4, 40, 'To be Cleaned', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())

Insert Into t_Constants
Values(1, 50, 'Cash', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(2, 50, 'Card - Debit', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(3, 50, 'Card - Credit', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())

Insert Into t_Constants
Values(1, 60, 'Discover', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(2, 60, 'MasterCard', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(3, 60, 'Visa', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())

Insert Into t_Constants
Values(1, 70, 'In Advance - Card', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(2, 70, 'At Time - Card', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(3, 70, 'At Time - Cash', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())
Insert Into t_Constants
Values(4, 70, 'Future With Deposit', '', 0, 101, GETUTCDATE(), 101, GETUTCDATE())