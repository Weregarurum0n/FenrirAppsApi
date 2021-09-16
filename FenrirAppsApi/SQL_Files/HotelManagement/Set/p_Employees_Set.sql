Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Employees_Set','P') Is Null
    Exec('Create Procedure dbo.p_Employees_Set As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Employees_Set @UserID = 0, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Employees_Set
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@EmployeeID Int,
	@UserName Varchar(50),
	@FirstName Varchar(50),
	@MidName Varchar(50),
	@LastName1 Varchar(50),
	@LastName2 Varchar(50),
	@Locked Bit,
	@LockedDateTime DateTime,
	@RequiresReset Bit,
	@EmployeeTypeID Int,
	@StartDateTime DateTime,
	@LastLoginDateTime  DateTime,
	@Terminated Bit,
	@TerminatedDateTime  DateTime
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @EmployeeID = IsNull(@EmployeeID, 0),
	@UserName = IsNull(@UserName, ''),
	@FirstName = IsNull(@FirstName, ''),
	@MidName = IsNull(@MidName, ''),
	@LastName1 = IsNull(@LastName1, ''),
	@LastName2 = IsNull(@LastName2, ''),
	@EmployeeTypeID = IsNull(@EmployeeTypeID, 0),
	@Terminated = IsNull(@Terminated, 0)

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

Declare @dUtcNow DateTime = GetUtcDate()

If (@EmployeeID = 0)
Begin

	Insert Into dbo.t_Employees
	(EmployeeID, UserName, FirstName, MidName, LastName1, LastName2, Locked, LockedDateTime, RequiresReset, EmployeeTypeID, StartDateTime, LastLoginDateTime, Terminated, TerminatedDateTime, CreatedID, CreatedDateTime)
	Values
	(@EmployeeID, @UserName, @FirstName, @MidName, @LastName1, @LastName2, 0, null, 0, @EmployeeTypeID, @StartDateTime, @LastLoginDateTime, @Terminated, @TerminatedDateTime, @UserID, @dUtcNow)

	If (@@RowCount = 0)
	Begin
		Select @RetVal = 81, @RetMsg = 'Unable to Insert new Entry'
	End
	Else
	Begin
		Select @RetVal = 1, @RetMsg = 'Successfully Created New Entry'
	End
End
Else
Begin

	Update dbo.t_Employees
	Set EmployeeID = @EmployeeID, UserName = @UserName, FirstName = @FirstName, MidName = @MidName, LastName1 = @LastName1, LastName2 = @LastName2, EmployeeTypeID = @EmployeeTypeID, 
	StartDateTime = @StartDateTime, LastLoginDateTime = @LastLoginDateTime, Terminated = @Terminated, TerminatedDateTime = @TerminatedDateTime,
	ModifiedID = @UserID, ModifiedDateTime = @dUtcNow

	If (@@RowCount = 0)
	Begin
		Select @RetVal = 91, @RetMsg = 'Unable to Update Entry'
	End
	Else
	Begin
		Select @RetVal = 1, @RetMsg = 'Successfully Updated Entry'
	End
End

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: