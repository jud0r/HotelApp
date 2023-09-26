/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists (select 1 from dbo.RoomTypes)
begin
    insert into dbo.RoomTypes(Title, Description, Price)
    values ('Cama King Size', 'Quarto com uma cama king size e uma janela.', 100),
    ('Duas Camas Queen Size', 'Quarto com duas camas queen size e uma janela.', 115),
    ('Suite Executiva', 'Dois quartos com uma cama king size cada e uma janela.', 205);
end

if not exists (select 1 from dbo.Rooms)
begin
    declare @roomId1 int;
    declare @roomId2 int;
    declare @roomId3 int;

    select @roomId1 = Id from dbo.RoomTypes where Title = 'Cama King Size';
    select @roomId2 = Id from dbo.RoomTypes where Title = 'Duas Camas Queen Size';
    select @roomId3 = Id from dbo.RoomTypes where Title = 'Suite Executiva';

    insert into dbo.Rooms(RoomNumber, RoomTypeId)
    values ('101', @roomId1),
    ('102', @roomId1),
    ('103', @roomId1),
    ('201', @roomId2),
    ('202', @roomId2),
    ('301', @roomId3);
end