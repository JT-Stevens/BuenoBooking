SELECT * FROM Room;
SELECT * FROM Booking;
SELECT * FROM Hotel;
SELECT * FROM guest;

DELETE FROM guest;

INSERT INTO Booking
VALUES ('2019-01-01', '2019-01-02', 1009, 'ABE0129145', 0, 100);

SELECT DISTINCT ROOM.RoomID, RoomType FROM Room LEFT OUTER JOIN Booking ON Booking.RoomID = Room.RoomID WHERE Room.RoomID NOT IN 
(SELECT RoomID FROM Booking WHERE StartDate <= '2019-01-05' AND '2019-01-01' <= EndDate) AND Hotel = 1 OR BookingID = 1;

SELECT RoomNumber FROM Room WHERE RoomType = '2 double';

SELECT RoomId, RoomNumber FROM Room WHERE RoomType = '2 queen'
