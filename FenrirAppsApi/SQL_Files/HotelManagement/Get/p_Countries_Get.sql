Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Countries_Get','P') Is Null
    Exec('Create Procedure dbo.p_Countries_Get As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Countries_Get @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Countries_Get
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@CountryID Int = 0,
	@Name Varchar(50) = 0,
	@Abbrev Varchar(3) = 0,
	@IncludeDisabled Bit = 0
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @CountryID = IsNull(@CountryID, 0),
	@Name = IsNull(@Name, ''),
	@Abbrev = IsNull(@Abbrev, ''),
	@IncludeDisabled = IsNull(@IncludeDisabled, 0)

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

Select l.CountryID, l.Name, l.Abbrev, l.Disabled,
	l.CreatedID, c.FirstName + ' ' + c.LastName1 CreatedBy, l.CreatedDateTime, l.ModifiedID, m.FirstName + ' ' + m.LastName1 ModifiedBy, l.ModifiedDateTime 
From dbo.t_Countries As l With (NoLock)
Left Join dbo.t_Employees As c With (NoLock) On l.CreatedID = c.EmployeeID And c.Terminated = 0
Left Join dbo.t_Employees As m With (NoLock) On l.ModifiedID = m.EmployeeID And m.Terminated = 0
Where l.CountryID In (0, @CountryID)
And (l.Name = '' Or l.Name Like '%' + @Name + '%')
And (l.Abbrev = '' Or l.Abbrev Like '%' + @Abbrev + '%')
And l.Disabled In (1, @IncludeDisabled)

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: