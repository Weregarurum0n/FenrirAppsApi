Use HotelManagement
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_ID('dbo.p_Rooms_Set','P') Is Null
    Exec('Create Procedure dbo.p_Rooms_Set As Select 1')
Go
/*
	Revision History:
		2/27/2019	Created
	Example Query:
		Declare @RetVal Int, @RetMsg Varchar(50)
		Exec dbo.p_Rooms_Set @UserID = 1, @RetVal = @RetVal out, @RetMsg = @RetMsg out
		Select @RetVal, @RetMsg
*/

Alter Procedure dbo.p_Rooms_Set
(
	@UserID Int,

	@RetVal Int out,
	@RetMsg Varchar(50) out,

	@RoomID Int,
	@RoomNo Int,
	@RoomTypeID Int,
	@RoomRate Money,
	@RoomStatusID Int,
	@MaxCapacity Int,
	@Disable Bit
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
	@Disable = IsNull(@Disable, 0)

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

If (@RoomID = 0)
Begin

	Insert Into dbo.t_Rooms
	(RoomID, RoomNo, RoomTypeID, RoomRate, RoomStatusID, MaxCapacity, Disabled, CreatedID, CreatedDateTime)
	Values
	(@RoomID, @RoomNo, @RoomTypeID, @RoomRate, @RoomStatusID, @MaxCapacity, @Disable, @UserID, @dUtcNow)

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

	Update dbo.t_Rooms
	Set RoomID = @RoomID, RoomNo = @RoomNo, RoomTypeID = @RoomTypeID, RoomRate = @RoomRate, RoomStatusID = @RoomStatusID, MaxCapacity = @MaxCapacity, Disabled = @Disable,
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

EndProc: