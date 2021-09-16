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
		Date		Editor					Comment
		9/15/2021 	Jay Bhakta				Initial Version
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
	Select @RetVal = 21, @RetMsg = 'User ID is Required'
	GoTo EndProc
End

If Not Exists (Select Top 1 1 From dbo.t_Users With (NoLock) Where UserID = @UserID)
Begin
	Select @RetVal = 31, @RetMsg = 'User not Found'
	GoTo EndProc
End

If @CurrentPassword = ''
Begin
	Select @RetVal = 41, @RetMsg = 'Current Password is Required'
	GoTo EndProc
End

If @NewPassword = ''
Begin
	Select @RetVal = 51, @RetMsg = 'New Password is Required'
	GoTo EndProc
End

If Not (Len(@NewPassword) >= 8 And Len(@NewPassword) <= 12)
Begin
	Select @RetVal = 61, @RetMsg = 'The password provided must be between 8 and 12 characters'
	GoTo EndProc
End

If Not (PATINDEX('%[0-9]%', @NewPassword) > 0)
Begin
	Select @RetVal = 71, @RetMsg = 'The password provided must contain at least one digit'
	GoTo EndProc
End

If Not (@MyString LIKE '%[^a-zA-Z0-9]%')
Begin
	Select @RetVal = 81, @RetMsg = 'The password provided must contain at least one special character'
	GoTo EndProc
End

Declare @unencryptedCurrent Varchar(50)
Select @unencryptedCurrent = dbo.f_UnEncryptPassword_Get(@CurrentPassword)

Declare @unencryptedNew Varchar(50)
Select @unencryptedNew = dbo.f_UnEncryptPassword_Get(@NewPassword)


If Not Exists (Select Top 1 1 From dbo.t_Passwords With (NoLock) Where UserID = @UserID And CurrentPassword = @CurrentPassword And Disabled = 0)
Begin
	Select @RetVal = 91, @RetMsg = 'Unable to verify password'
	GoTo EndProc
End

If (@CurrentPassword = @NewPassword)
Begin
	Select @RetVal = 101, @RetMsg = 'New Password cannot be the same as current password'
	GoTo EndProc
End


//check if in last 5 passwords, if so dont allow update

Declare @Date DateTime = GetUtcDate()

Update dbo.t_Passwords
Set Disabled = 1, ModifiedID = @UserID, ModifiedDateTime = @Date
Where UserID = @UserID
	
If (@@RowCount = 0)
Begin
	Select @RetVal = 111, @RetMsg = 'Unable to Update Entry'
End
Else
Begin
	Select @RetVal = 1, @RetMsg = 'Successfully Updated Entry'
End

Insert Into t_Passwords
(UserID, Password, Disabled, CreatedID, CreatedDateTime, ModifiedID, ModifiedDateTime)
Values 
(@UserID, @NewPassword, 0, @UserID, @Date, @UserID, @Date)
	
	
EndProc: