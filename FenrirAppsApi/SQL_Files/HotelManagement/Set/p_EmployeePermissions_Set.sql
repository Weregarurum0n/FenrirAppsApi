Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_EmployeePermissions_Set','P') Is Null
    Exec('Create Procedure dbo.p_EmployeePermissions_Set As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_EmployeePermissions_Set @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out, @EmployeeId = 1
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_EmployeePermissions_Set
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@EmployeeId Int,
	@PermissionId Int,
	@Disable Bit
)

As Set NoCount On

Select @UserID = IsNull(@UserID, 0)
Select @EmployeeId = IsNull(@EmployeeId, 0)

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

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

If @EmployeeId = 0
Begin
	Select @RetVal = 41, @RetMsg = 'Employee is Required'
	GoTo EndProc
End

If Not Exists (Select Top 1 1 From dbo.t_Employees With (NoLock) Where EmployeeID = @EmployeeId)
Begin
	Select @RetVal = 51, @RetMsg = 'Employee not Found'
	GoTo EndProc
End

Declare @dUtcNow DateTime = GetUtcDate()

If (@EmployeeId = 0)
Begin

	Insert Into dbo.t_Employee_Permissions
	(CreatedID, CreatedDateTime)
	Values
	(@UserID, @dUtcNow)

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

	Update dbo.t_Employee_Permissions
	Set ModifiedID = @UserID, ModifiedDateTime = @dUtcNow

	If (@@RowCount = 0)
	Begin
		Select @RetVal = 91, @RetMsg = 'Unable to Update Entry'
	End
	Else
	Begin
		Select @RetVal = 1, @RetMsg = 'Successfully Updated Entry'
	End
End

EndProc: