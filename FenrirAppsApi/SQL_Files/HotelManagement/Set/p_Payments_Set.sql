Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Payments_Set','P') Is Null
    Exec('Create Procedure dbo.p_Payments_Set As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Payments_Set @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Payments_Set
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@PaymentID Int,
	@GuestID Int,
	@Amount Money,
	@CardTypeID Int,
	@SafetyDeposit Money,
	@Comment Varchar(1000)
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @PaymentID = IsNull(@PaymentID, 0),
	@GuestID = IsNull(@GuestID, 0),
	@Amount = IsNull(@Amount, 0),
	@CardTypeID = IsNull(@CardTypeID, 0),
	@SafetyDeposit = IsNull(@SafetyDeposit, 0),
	@Comment = IsNull(@Comment, 0)

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

If (@PaymentID = 0)
Begin

	Insert Into dbo.t_Payments
	(PaymentID, GuestID, Amount, CardTypeID, SafetyDeposit, Comment,
	CreatedID, CreatedDateTime)
	Values
	(@PaymentID, @GuestID, @Amount, @CardTypeID, @SafetyDeposit, @Comment,
	@UserID, @dUtcNow)

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

	Update dbo.t_Payments
	Set PaymentID = @PaymentID, GuestID = @GuestID, Amount = @Amount, CardTypeID = @CardTypeID, SafetyDeposit = @SafetyDeposit, Comment = @Comment,
	ModifiedID = @UserID, ModifiedDateTime = @dUtcNow

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