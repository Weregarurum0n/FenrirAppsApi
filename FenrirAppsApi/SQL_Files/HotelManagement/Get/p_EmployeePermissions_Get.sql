Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_EmployeePermissions_Get','P') Is Null
    Exec('Create Procedure dbo.p_EmployeePermissions_Get As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_EmployeePermissions_Get @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out, @EmployeeId = 1
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_EmployeePermissions_Get
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@EmployeeId Int = 0
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

Select @EmployeeId = IsNull(@EmployeeId, 0)

Select ep.EmployeeID, ep.PermissionID, p.Name, 
ep.CreatedID, c.FirstName + ' ' + c.LastName1 CreatedBy, ep.CreatedDateTime, ep.ModifiedID, m.FirstName + ' ' + m.LastName1 ModifiedBy, ep.ModifiedDateTime 
From dbo.t_Employee_Permissions As ep With (NoLock)
Left Join dbo.t_Permissions As p With (NoLock) On ep.PermissionID = p.PermissionID And p.Disabled = 0
Left Join dbo.t_Employees As c With (NoLock) On ep.CreatedID = c.EmployeeID And c.Terminated = 0
Left Join dbo.t_Employees As m With (NoLock) On p.ModifiedID = m.EmployeeID And m.Terminated = 0
Where ep.PermissionID In (0, @EmployeeId)

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: