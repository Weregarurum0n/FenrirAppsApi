Use JapaneseLearning
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_AccentTheme_Get','P') Is Null
    Exec('Create Procedure dbo.p_AccentTheme_Get As Select 1')
Go
/*
	Revision History:
		Date		Editor					Comment
		9/15/2021 	Jay Bhakta				Initial Version
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_AccentTheme_Get @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out, @GuestID = 0
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_AccentTheme_Get
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

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

Select u.ThemeID, u.AccentID,
	v.Disabled, v.CreatedID, c.FirstName + ' ' + c.LastName1 CreatedBy, v.CreatedDateTime, v.ModifiedID, m.FirstName + ' ' + m.LastName1 ModifiedBy, v.ModifiedDateTime 
dbo.t_Users u With (NoLock) 
Left Join dbo.t_Users As c With (NoLock) On u.CreatedID = c.UserID
Left Join dbo.t_Users As m With (NoLock) On u.ModifiedID = m.UserID
Where UserID = @UserID

Select @RetVal = 1, @RetMsg = 'Successfully Loaded'

EndProc: