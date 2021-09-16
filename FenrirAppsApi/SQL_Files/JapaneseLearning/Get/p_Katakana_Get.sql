Use JapaneseLearning
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Katakana_Get','P') Is Null
    Exec('Create Procedure dbo.p_Katakana_Get As Select 1')
Go
/*
	Revision History:
		Date		Editor					Comment
		9/15/2021 	Jay Bhakta				Initial Version
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Katakana_Get @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Katakana_Get
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@KatakanaID Int = 0,
	
	@Character Char(1) = '',
	@Romaji Varchar(50) = '',
	@Level Int = 0,
	@IncludeDisabled Bit = 0
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @KatakanaID = IsNull(@KatakanaID, 0),
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

Select k.KatakanaID, k.Character, k.Romaji, k.Level, k.Example1, k.Example2, k.Example3, k.Sound,
	k.Disabled, k.CreatedID, c.FirstName + ' ' + c.LastName1 CreatedBy, k.CreatedDateTime, k.ModifiedID, m.FirstName + ' ' + m.LastName1 ModifiedBy, k.ModifiedDateTime 
From dbo.t_Katakana As k With (NoLock)
Left Join dbo.t_Users As c With (NoLock) On k.CreatedID = c.UserID
Left Join dbo.t_Users As m With (NoLock) On k.ModifiedID = m.UserID
Where k.KatakanaID In (0, @KatakanaID)
And (h.Character = '' Or h.Character Like '%' + @Character + '%')
And (h.Romaji = '' Or h.Romaji Like '%' + @Romaji + '%')
And k.Level In (0, @Level)
And k.Disabled In (0, @IncludeDisabled)

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: