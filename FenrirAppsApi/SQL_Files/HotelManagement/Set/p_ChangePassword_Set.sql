Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_ChangePassword_Set','P') Is Null
    Exec('Create Procedure dbo.p_ChangePassword_Set As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_ChangePassword_Set @ @RetVal = @RetVal out, @RetMsg = @RetMsg out, @UserName = '', @Password = ''
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_ChangePassword_Set
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,
	
	@UserName varchar(50),

	@CurrentPassword varchar(50),
	@NewPassword varchar(50)
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @CurrentPassword = IsNull(@CurrentPassword, ''),
	@NewPassword = IsNull(@NewPassword, '')

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

If @CurrentPassword = ''
Begin
	Select @RetVal = 41, @RetMsg = 'Username is Required'
	GoTo EndProc
End

If @NewPassword = ''
Begin
	Select @RetVal = 51, @RetMsg = 'Password is Required'
	GoTo EndProc
End

Declare @unencryptedCurrent Varchar(50)
Select @unencryptedCurrent = dbo.f_UnEncryptPassword_Get(@CurrentPassword)

Declare @unencryptedNew Varchar(50)
Select @unencryptedNew = dbo.f_UnEncryptPassword_Get(@NewPassword)


If Not Exists (Select Top 1 1 From dbo.t_Employees With (NoLock) Where UserName = @UserName And Password = @NewPassword)
Begin
	Select @RetVal = 61, @RetMsg = 'Unable to verify password'
	GoTo EndProc
End

If Not Exists (Select Top 1 1 From dbo.t_Employees With (NoLock) Where UserName = @UserName)
Begin
	Select @RetVal = 41, @RetMsg = 'User not Found'
	GoTo EndProc
End

Select e.EmployeeID, e.FirstName, e.MidName, e.LastName1, e.LastName2, e.Locked, e.LockedDateTime, e.RequiresReset, e.EmployeeTypeID, e.StartDateTime, e.LastLoginDateTime, e.Terminated, e.TerminatedDateTime, 
	e.CreatedID, c.FirstName + ' ' + c.LastName1 CreatedBy, e.CreatedDateTime, e.ModifiedID, m.FirstName + ' ' + m.LastName1 ModifiedBy, e.ModifiedDateTime 
From dbo.t_Employees As e With (NoLock)
Left Join dbo.t_Constants As t With (NoLock) On e.EmployeeTypeID = t.Name And t.ParentID = 1 And t.Disabled = 0
Left Join dbo.t_Employees As c With (NoLock) On e.CreatedID = c.EmployeeID And c.Terminated = 0
Left Join dbo.t_Employees As m With (NoLock) On e.ModifiedID = m.EmployeeID And m.Terminated = 0
Where e.UserName = @UserName and e.Password = @unencryptedNew

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: