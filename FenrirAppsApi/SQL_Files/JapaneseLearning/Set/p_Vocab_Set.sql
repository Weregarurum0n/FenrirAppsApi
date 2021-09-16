Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Vocab_Set','P') Is Null
    Exec('Create Procedure dbo.p_Vocab_Set As Select 1')
Go
/*
	Revision History:
		Date		Editor					Comment
		9/15/2021 	Jay Bhakta				Initial Version
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Vocab_Set @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Vocab_Set
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,
	
	@VocabID Int = 0,
	@Word Varchar(50) = '',
	@Romaji Varchar(50) = '',
	@Level Int = 0,
	@Example1 Varchar(500) = '',
	@Example2 Varchar(500) = '',
	@Example3 Varchar(500) = '',
	@Sound Image = NULL,
	@Disabled Bit = 0
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @VocabID = IsNull(@VocabID, 0),
	@Word = IsNull(@Word, ''),
	@Romaji = IsNull(@Romaji, ''),
	@Level = IsNull(@Level, 0),
	@Example1 = IsNull(@Example1, ''),
	@Example2 = IsNull(@Example2, ''),
	@Example3 = IsNull(@Example3, ''),
	@Disabled = IsNull(@Disabled, 0)

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

If @Word = ''
Begin
	Select @RetVal = 41, @RetMsg = 'Word is Required'
	GoTo EndProc
End

If @Romaji = ''
Begin
	Select @RetVal = 51, @RetMsg = 'English Translation is Required'
	GoTo EndProc
End

If @Level = 0
Begin
	Select @RetVal = 61, @RetMsg = 'Level is Required'
	GoTo EndProc
End

If @Example1 = ''
Begin
	Select @RetVal = 71, @RetMsg = 'Example is Required'
	GoTo EndProc
End

If @Example2 = ''
Begin
	Select @RetVal = 81, @RetMsg = '2 Examples are Required'
	GoTo EndProc
End

Declare @dUtcNow DateTime = GetUtcDate()

If (@VocabID = 0)
Begin
	Select @VocabID = Max(VocabID) + 10 From dbo.t_Vocab With (NoLock)

	Insert Into dbo.t_Vocab
	(Word, Romaji, Level, Example1, Example2, Example3, Sound,
	Disabled, CreatedID, CreatedDateTime, ModifiedID, ModifiedDateTime)
	Values
	(@Word, @Romaji, @Level, @Example1, @Example2, @Example3, @Sound,
	@Disabled, @UserID, @dUtcNow, @UserID, @dUtcNow)

	If (@@RowCount = 0)
	Begin
		Select @RetVal = 91, @RetMsg = 'Unable to Insert new Entry'
	End
	Else
	Begin
		Select @RetVal = 1, @RetMsg = 'Successfully Created New Entry'
	End
End
Else
Begin

	Update dbo.t_Vocab
	Set Word = @Word, Romaji = @Romaji, Level = @Level, 
	Example1 = @Example1, Example2 = @Example2, Example3 = @Example3, Sound = @Sound,
	Disabled = Disabled, CreatedID = @UserID, CreatedDateTime = @dUtcNow, 
	ModifiedID = @UserID, ModifiedDateTime = @dUtcNow
	Where VocabID = @VocabID
	
	If (@@RowCount = 0)
	Begin
		Select @RetVal = 101, @RetMsg = 'Unable to Update Entry'
	End
	Else
	Begin
		Select @RetVal = 1, @RetMsg = 'Successfully Updated Entry'
	End
End

EndProc: