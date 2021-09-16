Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_AccentTheme_Set','P') Is Null
    Exec('Create Procedure dbo.p_AccentTheme_Set As Select 1')
Go
/*
	Revision History:
		Date		Editor					Comment
		9/15/2021 	Jay Bhakta				Initial Version
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_AccentTheme_Set @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out, @GuestID = 0
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_AccentTheme_Set
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@ThemeID Int,
	@AccentID Int
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @ThemeID = IsNull(@ThemeID, 0)
Select @AccentID = IsNull(@AccentID, 0)

If @UserID = 0
Begin
	Select @RetVal = 21, @RetMsg = 'Username is Required'
	GoTo EndProc
End

If Not Exists (Select Top 1 1 From dbo.t_Users With (NoLock) Where UserID = @UserID)
Begin
	Select @RetVal = 31, @RetMsg = 'User not Found'
	GoTo EndProc
End

If @ThemeID = 0
Begin
	Select @RetVal = 41, @RetMsg = 'Theme is Required'
	GoTo EndProc
End

If Not Exists (Select Top 1 1 From dbo.t_Constants With (NoLock) Where ConstantID = @ThemeID And ParentID = 40)
Begin
	Select @RetVal = 51, @RetMsg = 'Theme not Found'
	GoTo EndProc
End

If @AccentID = 0
Begin
	Select @RetVal = 61, @RetMsg = 'Accent is Required'
	GoTo EndProc
End

If Not Exists (Select Top 1 1 From dbo.t_Constants With (NoLock) Where ConstantID = @AccentID And ParentID = 50)
Begin
	Select @RetVal = 71, @RetMsg = 'Accent not Found'
	GoTo EndProc
End

Declare @dUtcNow DateTime = GetUtcDate()

Begin

	Update dbo.t_Users
	Set ThemeID = @ThemeID, AccentID = @AccentID,
	ModifiedID = @UserID, ModifiedDateTime = @dUtcNow

	If (@@RowCount = 0)
	Begin
		Select @RetVal = 81, @RetMsg = 'Unable to Update Entry'
	End
	Else
	Begin
		Select @RetVal = 1, @RetMsg = 'Successfully Updated Entry'
	End
End

EndProc: