USE [carrental]
GO

INSERT INTO [dbo].[Users]
           ([FirstName]
           ,[LastName]
           ,[BirthDate]
           ,[LicenseNumber])
     VALUES
           ('Petr', 'Petrov', '1986-12-20', '1254780'),
		   ('Anna', 'Sidorova', '1990-09-04', '5687854'),
		   ('Alex', 'Osipov', '1985-03-15', '34521023'),
		   ('David', 'Krilov', '1987-11-19', '51252301'),
		   ('Den', 'Brown', '1981-09-23', '0123652'),
		   ('Luck', 'Skywalker', '1972-07-26', '1000073'),
		   ('Harry', 'Potter', '1988-06-27', '4256301')
GO
INSERT INTO [dbo].[Cars]
           ([Model]
           ,[Type]
           ,[ManufactureYear]
           ,[RegistrationNumber]
           ,[Vendor])
     VALUES
           ('2101','Business',1980,'9624 OI','VAZ'),
		   ('911','Sportcar',2000,'4521 AA','Porsche'),
		   ('Z4','Sportcar',2010,'2398 BB','BMW'),
		   ('AMG','C',2015,'5547 CC','Mercedes'),
		   ('Civic','Comfort',2005,'8503 DD','Honda'),
		   ('X4','Business',2011,'2236 EE','BMW'),
		   ('X5','Business',2015,'8574 FF','BMW')

GO
INSERT INTO [dbo].[Orders]
           ([UserId]
           ,[CarId]
           ,[BeginDate]
           ,[EndDate]
           ,[Comment])
     VALUES
           (5, 3, '2019-04-04', '2019-05-04', 'everything is ok'),
           (4, 5, '2019-04-14', '2019-04-16', 'no comments'),
		   (6, 6, '2019-04-20', '2019-04-30', 'two pairs of keys'),
		   (3, 4, '2019-04-21', '2019-04-20', ' ')
GO
