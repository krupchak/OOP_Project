USE Zoo

-- Volunteers
INSERT INTO Volunteers (Name, PhoneNumber, Address, AnimalId, DepartmentId)
VALUES ('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
       ('Dimitur Stoev', '0877564223', NULL, 42, 4),
       ('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
	   ('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8);

-- Animals
INSERT INTO Animals (Name, BirthDate, OwnerId, AnimalTypeId)
VALUES ('Giraffe', '2018-09-21', 21, 1),
       ('Harpy Eagle', '2015-04-17', 15, 3),
       ('Hamadryas Baboon', '2017-11-02', NULL, 1),
       ('Tuatara', '2021-06-30', 2, 4);

-- Оновлення записів тварин, які не мають власника
UPDATE Animals
SET OwnerId = (SELECT Id FROM Owners WHERE Name = 'Kaloqn Stoqnov')
WHERE OwnerId IS NULL;

-- Видалення відділу з бази даних
UPDATE Volunteers
SET DepartmentId = NULL
WHERE DepartmentId = (SELECT Id FROM VolunteersDepartment WHERE DepartmentName = 'Education program assistant');

DELETE FROM VolunteersDepartment
WHERE DepartmentName = 'Education program assistant';

SELECT Volunteers.Name, Volunteers.PhoneNumber, Volunteers.Address, Volunteers.AnimalId, Volunteers.DepartmentId
FROM Volunteers
ORDER BY Volunteers.Name ASC, Volunteers.AnimalId ASC, Volunteers.DepartmentId ASC;

SELECT Animals.Name, AnimalType, FORMAT(Animals.BirthDate, 'dd.MM.yyyy') AS BirthDate
FROM Animals
JOIN AnimalTypes ON Animals.AnimalTypeId = AnimalTypes.Id
ORDER BY Animals.Name ASC;

SELECT TOP 5 Owners.Name, COUNT(Animals.Id) AS NumberOfAnimals
FROM Owners
JOIN Animals ON Owners.Id = Animals.OwnerId
GROUP BY Owners.Name
ORDER BY NumberOfAnimals DESC, Owners.Name ASC;


