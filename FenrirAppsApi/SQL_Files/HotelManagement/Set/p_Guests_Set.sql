Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Guests_Set','P') Is Null
    Exec('Create Procedure dbo.p_Guests_Set As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Guests_Set @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out, @GuestID = 0
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Guests_Set
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@GuestID Int,
	@FirstName Varchar(50),
	@MidName Varchar(50),
	@LastName1 Varchar(50),
	@LastName2 Varchar(50),
	@GuestTypeID Int,
	@DLNo Varchar(20),
	@BlackList Bit,
	@BlackListDate DateTime,
	@StreetAddress Varchar(50),
	@CityID Int,
	@StateID Int,
	@CountryID Int,
	@PostalCode Varchar(50),
	@Email Varchar(50),
	@PhoneNumber Varchar(20),
	@Comment Varchar(1000)
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @GuestID = IsNull(@GuestID, 0),
	@FirstName = IsNull(@FirstName, ''),
	@MidName = IsNull(@MidName, ''),
	@LastName1 = IsNull(@LastName1, ''),
	@LastName2 = IsNull(@LastName2, ''),
	@GuestTypeID = IsNull(@GuestTypeID, 0),
	@DLNo = IsNull(@DLNo, ''),
	@BlackList = IsNull(@BlackList, 0),
	@StreetAddress = IsNull(@StreetAddress, ''),
	@CityID = IsNull(@CityID, 0),
	@StateID = IsNull(@StateID, 0),
	@CountryID = IsNull(@CountryID, 0),
	@PostalCode = IsNull(@PostalCode, ''),
	@Email = IsNull(@Email, ''),
	@PhoneNumber = IsNull(@PhoneNumber, ''),
	@Comment = IsNull(@Comment, '')

If @UserID = 0
Begin
	Select @RetVal = 21, @RetMsg = 'Username is Required'
	GoTo EndProc
End

If Not Exists (Select Top 1 1 From dbo.t_Employees With (NoLock) Where EmployeeID = @UserID)
Begin
	Select @RetVal = 31, @RetMsg = 'User not Found'
	GoTo EndProc
End

Declare @dUtcNow DateTime = GetUtcDate()

If (@GuestID = 0)
Begin

	Insert Into dbo.t_Guests
	(CreatedID, CreatedDateTime)
	Values
	(@UserID, @dUtcNow)

	If (@@RowCount = 0)
	Begin
		Select @RetVal = 81, @RetMsg = 'Unable to Insert new Entry'
	End
	Else
	Begin
		Select @RetVal = 1, @RetMsg = 'Successfully Created New Entry'
	End
End
Else
Begin

	Update dbo.t_Guests
	Set ModifiedID = @UserID, ModifiedDateTime = @dUtcNow

	If (@@RowCount = 0)
	Begin
		Select @RetVal = 91, @RetMsg = 'Unable to Update Entry'
	End
	Else
	Begin
		Select @RetVal = 1, @RetMsg = 'Successfully Updated Entry'
	End
End

EndProc: