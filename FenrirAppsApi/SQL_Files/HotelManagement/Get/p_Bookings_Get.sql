Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Bookings_Get','P') Is Null
    Exec('Create Procedure dbo.p_Bookings_Get As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Bookings_Get @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Bookings_Get
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@BookingID Int = 0,
	@GuestID Int = 0,
	@PaymentID Int = 0,
	@CheckInDate DateTime = null,
	@CheckOutDate DateTime = null,
	@BookTypeID Int = 0,
	@BookRate Money = 0,
	@Comment Varchar(1000) = '',
	@IncludeCanceled Bit = 0,
	@CanceledDate Datetime = null
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @BookingID = IsNull(@BookingID, 0),
	@GuestID = IsNull(@GuestID, 0),
	@PaymentID = IsNull(@PaymentID, 0),
	@BookTypeID = IsNull(@BookTypeID, 0),
	@BookRate = IsNull(@BookRate, 0),
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

Select b.BookingID, b.GuestID, b.PaymentID, b.CheckInDate, b.CheckOutDate, b.BookTypeID, b.BookRate, b.Comment, b.Canceled, b.CanceledDate,
	b.CreatedID, c.FirstName + ' ' + c.LastName1 CreatedBy, b.CreatedDateTime, b.ModifiedID, m.FirstName + ' ' + m.LastName1 ModifiedBy, b.ModifiedDateTime 
From dbo.t_Bookings As b With (NoLock)
Left Join dbo.t_Employees As c With (NoLock) On b.CreatedID = c.EmployeeID And c.Terminated = 0
Left Join dbo.t_Employees As m With (NoLock) On b.ModifiedID = m.EmployeeID And m.Terminated = 0
Where b.BookingID In (0, @BookingID)
And b.GuestID In (0, @GuestID)
And b.PaymentID In (0, @PaymentID)
And (b.CheckInDate Is Null Or b.CheckInDate = @CheckInDate)
And (b.CheckOutDate Is Null Or b.CheckOutDate = @CheckOutDate)
And b.BookTypeID In (0, @BookTypeID)
And b.BookRate In (0, @BookRate)
And (b.Comment = '' Or b.Comment Like '%' + @Comment + '%')
And b.Canceled In (1, @IncludeCanceled)
And (b.CanceledDate Is Null Or b.CanceledDate = @CanceledDate)

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: