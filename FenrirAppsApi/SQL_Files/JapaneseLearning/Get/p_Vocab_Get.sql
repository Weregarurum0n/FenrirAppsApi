Use JapaneseLearning
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Vocab_Get','P') Is Null
    Exec('Create Procedure dbo.p_Vocab_Get As Select 1')
Go
/*
	Revision History:
		Date		Editor					Comment
		9/15/2021 	Jay Bhakta				Initial Version
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Vocab_Get @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Vocab_Get
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@VocabID Int = 0,
	
	@Word Varchar(50) = '',
	@Romaji Varchar(50) = '',
	@Level Int = 0,
	@IncludeDisabled Bit = 0
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @VocabID = IsNull(@VocabID, 0),
	@Word = IsNull(@Word, ''),
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

Select v.VocabID, v.Word, v.Romaji, v.Level, v.Example1, v.Example2, v.Example3, v.Sound,
	v.Disabled, v.CreatedID, c.FirstName + ' ' + c.LastName1 CreatedBy, v.CreatedDateTime, v.ModifiedID, m.FirstName + ' ' + m.LastName1 ModifiedBy, v.ModifiedDateTime 
From dbo.t_Kanji As v With (NoLock)
Left Join dbo.t_Users As c With (NoLock) On v.CreatedID = c.UserID
Left Join dbo.t_Users As m With (NoLock) On v.ModifiedID = m.UserID
Where v.VocabID In (0, @VocabID)
And (h.Word = '' Or h.Word Like '%' + @Word + '%')
And (h.Romaji = '' Or h.Romaji Like '%' + @Romaji + '%')
And v.Level In (0, @Level)
And v.Disabled In (0, @IncludeDisabled)

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: