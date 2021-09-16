Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Guests_Get','P') Is Null
    Exec('Create Procedure dbo.p_Guests_Get As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Guests_Get @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out, @GuestID = 0
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Guests_Get
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@GuestID Int = 0,
	@FirstName Varchar(50) = '',
	@MidName Varchar(50) = '',
	@LastName1 Varchar(50) = '',
	@LastName2 Varchar(50) = '',
	@GuestTypeID Int = 0,
	@DLNo Varchar(20) = '',
	@IncludeBlackListed Bit = 0,
	@BlackListDate DateTime = null,
	@StreetAddress Varchar(50) = '',
	@CityID Int = 0,
	@StateID Int = 0,
	@CountryID Int = 0,
	@PostalCode Varchar(50) = '',
	@Email Varchar(50) = '',
	@PhoneNumber Varchar(20) = '',
	@Comment Varchar(1000) = ''
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @GuestID = IsNull(@GuestID, 0),
	@FirstName = IsNull(@FirstName, ''),
	@MidName = IsNull(@MidName, ''),
	@LastName1 = IsNull(@LastName1, ''),
	@LastName2 = IsNull(@LastName2, ''),
	@GuestTypeID = IsNull(@GuestTypeID, 0),
	@DLNo = IsNull(@DLNo, ''),
	@IncludeBlackListed = IsNull(@IncludeBlackListed, 0),
	@StreetAddress = IsNull(@StreetAddress, ''),
	@CityID = IsNull(@CityID, 0),
	@StateID = IsNull(@StateID, 0),
	@CountryID = IsNull(@CountryID, 0),
	@PostalCode = IsNull(@PostalCode, ''),
	@Email = IsNull(@Email, ''),
	@PhoneNumber = IsNull(@PhoneNumber, ''),
	@Comment = IsNull(@Comment, '')

If @UserID = 0
Begin
	Select @RetVal = 21, @RetMsg = 'Username is Required'
	GoTo EndProc
End

If Not Exists (Select Top 1 1 From dbo.t_Employees With (NoLock) Where EmployeeID = @UserID)
Begin
	Select @RetVal = 31, @RetMsg = 'User not Found'
	GoTo EndProc
End

Select g.GuestID, g.FirstName, g.MidName, g.LastName1, g.LastName2,
	g.GuestTypeID, g.DLNo, g.BlackListed, g.BlackListedDate,
	g.StreetAddress, g.CityID, g.StateID, g.CountryID, g.PostalCode,
	g.Email, g.PhoneNumber, g.Comment,
	g.CreatedID, c.FirstName + ' ' + c.LastName1 CreatedBy, g.CreatedDateTime, g.ModifiedID, m.FirstName + ' ' + m.LastName1 ModifiedBy, g.ModifiedDateTime 
From dbo.t_Guests As g With (NoLock)
Left Join dbo.t_Employees As c With (NoLock) On g.CreatedID = c.EmployeeID And c.Terminated = 0
Left Join dbo.t_Employees As m With (NoLock) On g.ModifiedID = m.EmployeeID And m.Terminated = 0
Where g.GuestID In (0, @GuestID)
And (g.FirstName = '' Or g.FirstName Like '%' + @FirstName + '%')
And (g.MidName = '' Or g.MidName Like '%' + @MidName + '%')
And (g.LastName1 = '' Or g.LastName1 Like '%' + @LastName1 + '%')
And (g.LastName2 = '' Or g.LastName2 Like '%' + @LastName2 + '%')
And g.GuestTypeID In (0, @GuestTypeID)
And (g.DLNo = '' Or g.DLNo Like '%' + @DLNo + '%')
And g.BlackListed In (1, @IncludeBlackListed)
And (g.BlackListedDate Is Null Or g.BlackListedDate = @BlackListDate)
And (g.StreetAddress = '' Or g.StreetAddress Like '%' + @StreetAddress + '%')
And g.CityID In (0, @CityID)
And g.StateID In (0, @StateID)
And g.CountryID In (0, @CountryID)
And (g.PostalCode = '' Or g.PostalCode Like '%' + @PostalCode + '%')
And (g.Email = '' Or g.Email Like '%' + @Email + '%')
And (g.PhoneNumber = '' Or g.PhoneNumber Like '%' + @PhoneNumber + '%')
And (g.Comment = '' Or g.Comment Like '%' + @Comment + '%')


Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: