Use JapaneseLearning
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Profile_Get','P') Is Null
    Exec('Create Procedure dbo.p_Profile_Get As Select 1')
Go
/*
	Revision History:
		Date		Editor					Comment
		9/15/2021 	Jay Bhakta				Initial Version
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Profile_Get @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out, @EmployeeId = 1
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Profile_Get
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out
)

As Set NoCount On

Select @UserID = IsNull(@UserID, 0)

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

If (Select Top 1 1 From dbo.t_Users With (NoLock) Where UserID = @UserID And RequiresReset = 1)
Begin
	Select @RetVal = 41, @RetMsg = 'User Password has Expired, Please Reset It.'
	GoTo EndProc
End

Select u.UserID, u.Username, u.FirstName, u.LastName, u.UserTypeID, ut.Name UserType, u.DateJoined, u.Gender, 
	u.SessionId, u.ThemeID, u.AccentID, pf.ImageBitMap ProfilePicture, bi.ImageBitMap BannerImage, wp.ImageBitMap Wallpaper, 
	p.HiraganaLevel, p.KatakanaLevel, p.KanjiLevel, p.VocabLevel,
From dbo.t_Users As u With (NoLock)
Left Join dbo.t_Constants As ut With (NoLock) On ut.ConstantID = u.UserTypeID And ut.ParentID = 10
Left Join dbo.t_UserImage As pf With (NoLock) On pf.UserID = u.UserID And pf.ImageTypeID = 1
Left Join dbo.t_UserImage As bi With (NoLock) On bi.UserID = u.UserID And bi.ImageTypeID = 2
Left Join dbo.t_UserImage As wp With (NoLock) On wp.UserID = u.UserID And wp.ImageTypeID = 3
Left Join dbo.t_Progress As p With (NoLock) On p.UserID = u.UserID
Where u.UserID = @UserID

Select @RetVal = 1, @RetMsg = 'Successfully Loaded'

EndProc: