Use JapaneseLearning

Begin Try	Drop Table dbo.t_Hiragana				End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_Katakana				End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_Kanji					End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_Vocab					End Try		Begin Catch	End Catch

Begin Try	Drop Table dbo.t_Users					End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_UserImage				End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_Passwords				End Try		Begin Catch	End Catch
Begin Try	Drop Table dbo.t_Progress				End Try		Begin Catch	End Catch

Begin Try	Drop Table dbo.t_Constants				End Try		Begin Catch	End Catch

IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'JapaneseLearning' And Table_Name = 't_Hiragana'))
	Create Table t_Hiragana (HiraganaID Int Identity(1, 10) Primary Key, Character Char(1), Romaji Varchar(50), 
	Level Int, Example1 Varchar(500), Example2 Varchar(500), Example3 Varchar(500), Sound Image,
	Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)

IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'JapaneseLearning' And Table_Name = 't_Katakana'))
	Create Table t_Katakana (KatakanaID Int Identity(1, 10) Primary Key, Character Char(1), Romaji Varchar(50), 
	Level Int, Example1 Varchar(500), Example2 Varchar(500), Example3 Varchar(500), Sound Image,
	Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)
	
IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'JapaneseLearning' And Table_Name = 't_Kanji'))
	Create Table t_Kanji (KanjiID Int Identity(1, 10) Primary Key, Character Char(1), Romaji Varchar(50), 
	Level Int, Example1 Varchar(500), Example2 Varchar(500), Example3 Varchar(500), Sound Image,
	Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)
	
IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'JapaneseLearning' And Table_Name = 't_Vocab'))
	Create Table t_Vocab (VocabID Int Identity(1, 10) Primary Key, Word Varchar(50), Romaji Varchar(50), 
	Level Int, Example1 Varchar(500), Example2 Varchar(500), Example3 Varchar(500), Sound Image,
	Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)



IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'JapaneseLearning' And Table_Name = 't_Users'))
	Create Table t_Users (UserID Int Identity(101, 100) Primary Key, Username Varchar(50), FirstName Varchar(50), LastName Varchar(50), UserTypeID Int, DateJoined DateTime, 
	Locked Bit, LockCount Int, LockedDateTime DateTime, RequiresReset Bit,
	Gender Int, SessionID Varchar(1000), ThemeID Int, AccentID, LastLoginDateTime DateTime, 
	Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)

IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'JapaneseLearning' And Table_Name = 't_UserImage'))
	Create Table t_UserImage (ImageID Int Identity(1, 10) Primary Key, UserID Int, ImageTypeID Int, ImageBitMap Blob, 
	Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)
	
IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'JapaneseLearning' And Table_Name = 't_Passwords'))
	Create Table t_Passwords (PasswordID Int Identity(1, 10) Primary Key, UserID Int, Password Varchar(500),
	Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)

IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'JapaneseLearning' And Table_Name = 't_Progress'))
	Create Table t_Progress (ProgressID Int Identity(1, 10) Primary Key, UserID Int, HiraganaLevel Int, KatakanaLevel Int, KanjiLevel Int, VocabLevel Int,
	Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)



IF (Not Exists (Select * From Information_Schema.Tables Where Table_Catalog = 'JapaneseLearning' And Table_Name = 't_Constants'))
	Create Table t_Constants (ConstantID Int, ParentID Int, Name Varchar(50), Description Varchar(500), 
	Disabled Bit, CreatedID Int, CreatedDateTime DateTime, ModifiedID Int, ModifiedDateTime DateTime)

Select * From dbo.t_Hiragana
Select * From dbo.t_Katakana
Select * From dbo.t_Kanji
Select * From dbo.t_Vocab

Select * From dbo.t_Users
Select * From dbo.t_UserImage
Select * From dbo.t_Passwords
Select * From dbo.t_Progress

Select * From dbo.t_Constants