Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Employees_Get','P') Is Null
    Exec('Create Procedure dbo.p_Employees_Get As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Employees_Get @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Employees_Get
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@EmployeeID Int = 0,
	@UserName Varchar(50) = '',
	@FirstName Varchar(50) = '',
	@MidName Varchar(50) = '',
	@LastName1 Varchar(50) = '',
	@LastName2 Varchar(50) = '',
	@Locked Bit = 0,
	@LockedDateTime DateTime = null,
	@RequiresReset Bit = 0,
	@EmployeeTypeID Int = 0,
	@StartDateTime DateTime = null,
	@LastLoginDateTime  DateTime = null,
	@IncludeTerminated Bit = 0,
	@TerminatedDateTime  DateTime = null
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @EmployeeID = IsNull(@EmployeeID, 0),
	@FirstName = IsNull(@FirstName, ''),
	@MidName = IsNull(@MidName, ''),
	@LastName1 = IsNull(@LastName1, ''),
	@LastName2 = IsNull(@LastName2, ''),
	@Locked = IsNull(@Locked, 0),
	@RequiresReset = IsNull(@RequiresReset, 0),
	@EmployeeTypeID = IsNull(@EmployeeTypeID, 0),
	@IncludeTerminated = IsNull(@IncludeTerminated, 0)

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


Select e.EmployeeID, e.UserName, e.FirstName, e.MidName, e.LastName1, e.LastName2, e.Locked, e.LockedDateTime, e.RequiresReset, e.EmployeeTypeID, e.StartDateTime, e.LastLoginDateTime, e.Terminated, e.TerminatedDateTime, 
	e.CreatedID, c.FirstName + ' ' + c.LastName1 CreatedBy, e.CreatedDateTime, e.ModifiedID, m.FirstName + ' ' + m.LastName1 ModifiedBy, e.ModifiedDateTime 
From dbo.t_Employees As e With (NoLock)
Left Join dbo.t_Constants As t With (NoLock) On e.EmployeeTypeID = t.Name And t.ParentID = 1 And t.Disabled = 0
Left Join dbo.t_Employees As c With (NoLock) On e.CreatedID = c.EmployeeID And c.Terminated = 0
Left Join dbo.t_Employees As m With (NoLock) On e.ModifiedID = m.EmployeeID And m.Terminated = 0
Where e.EmployeeID In (0, @EmployeeID)
And (e.FirstName = '' Or e.FirstName Like '%' + @FirstName + '%')
And (e.UserName = '' Or e.UserName Like '%' + @UserName + '%')
And (e.MidName = '' Or e.MidName Like '%' + @MidName + '%')
And (e.LastName1 = '' Or e.LastName1 Like '%' + @LastName1 + '%')
And (e.LastName2 = '' Or e.LastName2 Like '%' + @LastName2 + '%')
And e.Locked = @Locked
And (e.LockedDateTime Is Null Or e.LockedDateTime = @LockedDateTime)
And e.RequiresReset = @RequiresReset
And e.EmployeeTypeID In (0, @EmployeeTypeID)
And (e.StartDateTime Is Null Or e.StartDateTime = @StartDateTime)
And (e.LastLoginDateTime Is Null Or e.LastLoginDateTime = @LastLoginDateTime)
And e.Terminated In (1, @IncludeTerminated)
And (e.TerminatedDateTime Is Null Or e.TerminatedDateTime = @TerminatedDateTime)

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: