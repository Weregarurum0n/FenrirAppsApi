Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Rooms_Get','P') Is Null
    Exec('Create Procedure dbo.p_Rooms_Get As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Rooms_Get @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Rooms_Get
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@RoomID Int = 0,
	@RoomNo Int = 0,
	@RoomTypeID Int = 0,
	@RoomRate Money = 0,
	@RoomStatusID Int = 0,
	@MaxCapacity Int = 0,
	@IncludeDisabled Bit = 0
)

As Set NoCount On

Select @RetVal = 99, @RetMsg = 'Unidentified Error'

Select @UserID = IsNull(@UserID, 0)
Select @RoomID = IsNull(@RoomID, 0),
	@RoomNo = IsNull(@RoomNo, 0),
	@RoomTypeID = IsNull(@RoomTypeID, 0),
	@RoomRate = IsNull(@RoomRate, 0),
	@RoomStatusID = IsNull(@RoomStatusID, 0),
	@MaxCapacity = IsNull(@MaxCapacity, 0),
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

Select r.RoomID, r.RoomNo, r.RoomTypeID, r.RoomRate, r.RoomStatusID, r.MaxCapacity, r.Disabled,
	r.CreatedID, c.FirstName + ' ' + c.LastName1 CreatedBy, r.CreatedDateTime, r.ModifiedID, m.FirstName + ' ' + m.LastName1 ModifiedBy, r.ModifiedDateTime 
From dbo.t_Rooms As r With (NoLock)
Left Join dbo.t_Employees As c With (NoLock) On r.CreatedID = c.EmployeeID And c.Terminated = 0
Left Join dbo.t_Employees As m With (NoLock) On r.ModifiedID = m.EmployeeID And m.Terminated = 0
Where r.RoomID In (0, @RoomID)
And r.RoomNo In (0, @RoomNo)
And r.RoomTypeID In (0, @RoomTypeID)
And r.RoomRate In (0, @RoomRate)
And r.RoomStatusID In (0, @RoomStatusID)
And r.MaxCapacity In (0, @MaxCapacity)
And r.Disabled In (1, @IncludeDisabled)

Select @RetVal = 1, @RetMsg = 'Successfully Listed'

EndProc: