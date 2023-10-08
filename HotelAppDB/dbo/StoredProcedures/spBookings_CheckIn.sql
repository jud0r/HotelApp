CREATE PROCEDURE [dbo].[spBookingsCheckIn]
    @Id int
AS
begin
    set nocount on;

    update dbo.Bookings
    set CheckedIn = 1
    where Id = @Id;
end