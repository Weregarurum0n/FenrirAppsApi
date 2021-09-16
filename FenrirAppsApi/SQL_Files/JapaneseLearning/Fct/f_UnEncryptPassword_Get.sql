Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.f_UnEncryptPassword_Get','P') Is Null
    Exec('Create Procedure dbo.f_UnEncryptPassword_Get As Select 1')
Go
/*
	Revision History:
		Date		Editor					Comment
		9/15/2021 	Jay Bhakta				Initial Version
	Example Query:
		Exec dbo.f_UnEncryptPassword_Get @Password = 'SomePassword'
*/

Alter Procedure dbo.f_UnEncryptPassword_Get
(
	@Password varchar(50)
)

As Set NoCount On

Select @Password = IsNull(@Password, '')

Select @Password + 'isnowencrypted' As UnencryptedPassword

EndProc: