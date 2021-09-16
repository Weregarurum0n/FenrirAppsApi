Use JapaneseLearning
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
		Date		Editor					Comment
		9/15/2021 	Jay Bhakta				Initial Version
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
	@Password varchar(500)
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

If Not Exists (Select Top 1 1 From dbo.t_Users With (NoLock) Where UserName = @UserName)
Begin
	Select @RetVal = 41, @RetMsg = 'User not found'
	GoTo EndProc
End

If (Select Top 1 Locked From dbo.t_Users With (NoLock) Where UserName = @UserName) = 1
Begin
	Select @RetVal = 51, @RetMsg = 'User is Currently Locked'
	GoTo EndProc
End

If (Select Top 1 LockCount From dbo.t_Users With (NoLock) Where UserID = @UserID) >= 3
Begin
	Update dbo.t_Users Set Locked = 1, Modified = 1, ModifiedDateTime = GetUtcDate() Where UserID = @UserID
	Select @RetVal = 61, @RetMsg = 'User is Currently Locked'
	GoTo EndProc
End

Declare @UserID Int
Select @UserID = UserID From dbo.t_Passwords With (NoLock) Where UserName = @UserName

Declare @unencrypted Varchar(50)
Select @unencrypted = dbo.f_UnEncryptPassword_Get(@Password)

If Not Exists (Select Top 1 1 From dbo.t_Passwords With (NoLock) Where UserID = @UserID And Disabled = 0)
Begin
	Select @RetVal = 71, @RetMsg = 'incorrect username/password'

	Declare @count Int = (Select Top 1 LockCount From dbo.t_Users With (NoLock) Where UserID = @UserID)
	Set @count = @count + 1
	Update dbo.t_Users Set LockCount = @count Where UserID = @UserID

	GoTo EndProc
End

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: