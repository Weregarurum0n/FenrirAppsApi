Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Bookings_Set','P') Is Null
    Exec('Create Procedure dbo.p_Bookings_Set As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Bookings_Set @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Bookings_Set
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@BookingID Int,
	@GuestID Int,
	@PaymentID Int,
	@CheckInDate DateTime,
	@CheckOutDate DateTime,
	@BookTypeID Int,
	@BookRate Money,
	@Comment Varchar(1000),
	@Cancel Bit,
	@CanceledDate Datetime
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @BookingID = IsNull(@BookingID, 0),
	@GuestID = IsNull(@GuestID, 0),
	@PaymentID = IsNull(@PaymentID, 0),
	@BookTypeID = IsNull(@BookTypeID, 0),
	@BookRate = IsNull(@BookRate, 0),
	@Comment = IsNull(@Comment, ''),
	@Cancel = IsNull(@Cancel, 0)

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

If (@BookingID = 0)
Begin

	Insert Into dbo.t_Bookings
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

	Update dbo.t_Bookings
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