Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Payments_Get','P') Is Null
    Exec('Create Procedure dbo.p_Payments_Get As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Payments_Get @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Payments_Get
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@PaymentID Int = 0,
	@GuestID Int = 0,
	@Amount Money = 0,
	@CardTypeID Int = 0,
	@SafetyDeposit Money = 0,
	@Comment Varchar(1000) = ''
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

Select p.PaymentID, p.GuestID, p.Amount, p.CardTypeID, p.SafetyDeposit, p.Comment,
	p.CreatedID, c.FirstName + ' ' + c.LastName1 CreatedBy, p.CreatedDateTime, p.ModifiedID, m.FirstName + ' ' + m.LastName1 ModifiedBy, p.ModifiedDateTime 
From dbo.t_Payments As p With (NoLock)
Left Join dbo.t_Employees As c With (NoLock) On p.CreatedID = c.EmployeeID And c.Terminated = 0
Left Join dbo.t_Employees As m With (NoLock) On p.ModifiedID = m.EmployeeID And m.Terminated = 0
Where p.PaymentID In (0, @PaymentID)
And p.GuestID In (0, @GuestID)
And p.Amount In (0, @Amount)
And p.CardTypeID In (0, @CardTypeID)
And p.SafetyDeposit In (0, @SafetyDeposit)
And p.Comment In ('', @Comment)

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: