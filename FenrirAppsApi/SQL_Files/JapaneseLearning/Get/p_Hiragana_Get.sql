Use JapaneseLearning
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Hiragana_Get','P') Is Null
    Exec('Create Procedure dbo.p_Hiragana_Get As Select 1')
Go
/*
	Revision History:
		Date		Editor					Comment
		9/15/2021 	Jay Bhakta				Initial Version
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Hiragana_Get @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Hiragana_Get
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@HiraganaID Int = 0,
	
	@Character Char(1) = '',
	@Romaji Varchar(50) = '',
	@Level Int = 0,
	@IncludeDisabled Bit = 0
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @HiraganaID = IsNull(@HiraganaID, 0),
	@Character = IsNull(@Character, ''),
	@Romaji = IsNull(@Romaji, ''),
	@Level = IsNull(@Level, 0),
	@IncludeDisabled = IsNull(@IncludeDisabled, 0)

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

Select h.HiraganaID, h.Character, h.Romaji, h.Level, h.Example1, h.Example2, h.Example3, h.Sound,
	h.Disabled, h.CreatedID, c.FirstName + ' ' + c.LastName1 CreatedBy, h.CreatedDateTime, h.ModifiedID, m.FirstName + ' ' + m.LastName1 ModifiedBy, h.ModifiedDateTime 
From dbo.t_Hiragana As h With (NoLock)
Left Join dbo.t_Users As c With (NoLock) On h.CreatedID = c.UserID
Left Join dbo.t_Users As m With (NoLock) On h.ModifiedID = m.UserID
Where h.HiraganaID In (0, @HiraganaID)
And (h.Character = '' Or h.Character Like '%' + @Character + '%')
And (h.Romaji = '' Or h.Romaji Like '%' + @Romaji + '%')
And h.Level In (0, @Level)
And h.Disabled In (0, @IncludeDisabled)

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: