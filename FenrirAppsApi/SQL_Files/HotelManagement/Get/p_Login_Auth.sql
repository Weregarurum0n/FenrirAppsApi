Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Login_Auth','P') Is Null
    Exec('Create Procedure dbo.p_Login_Auth As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Login_Auth @ @RetVal = @RetVal out, @RetMsg = @RetMsg out, @UserName = '', @Password = ''
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Login_Auth
(
	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@UserName varchar(50),
	@Password varchar(50)
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserName = IsNull(@UserName, ''),
	@Password = IsNull(@Password, '')

If @UserName = ''
Begin
	Select @RetVal = 21, @RetMsg = 'Username is Required'
	GoTo EndProc
End

If @Password = ''
Begin
	Select @RetVal = 31, @RetMsg = 'Password is Required'
	GoTo EndProc
End

If Not Exists (Select Top 1 1 From dbo.t_Employees With (NoLock) Where UserName = @UserName)
Begin
	Select @RetVal = 41, @RetMsg = 'Unable to Login'
	GoTo EndProc
End

If (Select Top 1 Locked From dbo.t_Employees With (NoLock) Where UserName = @UserName) = 1
Begin
	Select @RetVal = 51, @RetMsg = 'User is Currently Locked'
	GoTo EndProc
End

If (Select Top 1 LockCount From dbo.t_Employees With (NoLock) Where UserName = @UserName) = 3
Begin
	Update dbo.t_Employees Set LockCount = 0, Locked = 1, LockedDateTime = GetDate() Where UserName = @UserName
	Select @RetVal = 61, @RetMsg = 'User is Currently Locked'
	GoTo EndProc
End

Declare @unencrypted Varchar(50)
Select @unencrypted = dbo.f_UnEncryptPassword_Get(@Password)

If Not Exists (Select Top 1 1 From dbo.t_Employees With (NoLock) Where UserName = @UserName And Password = @Password)
Begin
	Select @RetVal = 71, @RetMsg = 'Unable to Login'

	Declare @count Int = (Select Top 1 LockCount From dbo.t_Employees With (NoLock) Where UserName = @UserName And Password = @Password)
	Set @count = @count + 1
	Update dbo.t_Employees Set LockCount = @count Where UserName = @UserName

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
Where e.UserName = @UserName and e.Password = @unencrypted

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: