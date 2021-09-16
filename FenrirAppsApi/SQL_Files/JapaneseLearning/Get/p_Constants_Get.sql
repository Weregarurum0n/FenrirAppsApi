Use JapaneseLearning
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Constants_Get','P') Is Null
    Exec('Create Procedure dbo.p_Constants_Get As Select 1')
Go
/*
	Revision History:
		Date		Editor					Comment
		9/15/2021 	Jay Bhakta				Initial Version
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Constants_Get @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Constants_Get
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@ConstantID Int = 0,
	@ParentID Int = 0,
	@Name Varchar(50) = '',
	@Description Varchar(500) = '',
	@IncludeDisabled Bit = 0
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @ConstantID = IsNull(@ConstantID, 0),
	@ParentID = IsNull(@ParentID, 0),
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

Select s.ConstantID, s.ParentID, s.Name, s.Description, s.Disabled,
	s.CreatedID, c.FirstName + ' ' + c.LastName1 CreatedBy, s.CreatedDateTime, s.ModifiedID, m.FirstName + ' ' + m.LastName1 ModifiedBy, s.ModifiedDateTime 
From dbo.t_Constants As s With (NoLock)
Left Join dbo.t_Employees As c With (NoLock) On s.CreatedID = c.EmployeeID And c.Terminated = 0
Left Join dbo.t_Employees As m With (NoLock) On s.ModifiedID = m.EmployeeID And m.Terminated = 0
Where s.ConstantID In (0, @ConstantID)
And s.ParentID In (0, @ParentID)
And (s.Name = '' Or s.Name Like '%' + @Name + '%')
And (s.Description = '' Or s.Description Like '%' + @Description + '%')
And s.Disabled In (1, @IncludeDisabled)

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: