Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Permissions_Get','P') Is Null
    Exec('Create Procedure dbo.p_Permissions_Get As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Permissions_Get @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Permissions_Get
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@PermissionID Int = 0,
	@ParentID Int = 0,
	@Code Int = 0,
	@Name Varchar(50) = '',
	@Description Varchar(50) = '',
	@IncludeDisabled Bit = 0
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @PermissionID = IsNull(@PermissionID, 0),
	@ParentID = IsNull(@ParentID, 0),
	@Code = IsNull(@Code, 0),
	@Name = IsNull(@Name, ''),
	@Description = IsNull(@Description, ''),
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

Select p.PermissionID, p.ParentID, p.Code, p.Name, p.Description, p.Disabled,
	p.CreatedID, c.FirstName + ' ' + c.LastName1 CreatedBy, p.CreatedDateTime, p.ModifiedID, m.FirstName + ' ' + m.LastName1 ModifiedBy, p.ModifiedDateTime 
From dbo.t_Permissions As p With (NoLock)
Left Join dbo.t_Employees As c With (NoLock) On p.CreatedID = c.EmployeeID And c.Terminated = 0
Left Join dbo.t_Employees As m With (NoLock) On p.ModifiedID = m.EmployeeID And m.Terminated = 0
Where p.PermissionID In (0, @PermissionID)
And p.ParentID In (0, @ParentID)
And p.Code In (0, @Code)
And (p.Name = '' Or p.Name Like '%' + @Name + '%')
And (p.Description = '' Or p.Description Like '%' + @Description + '%')
And p.Disabled In (1, @IncludeDisabled)

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: