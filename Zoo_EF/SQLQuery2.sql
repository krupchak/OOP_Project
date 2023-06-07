USE Zoo1

-- Table: Owners
SET IDENTITY_INSERT Owners ON

INSERT INTO Owners (Id, Name, PhoneNumber, Address) VALUES
(1, 'Georgi Georgiev', '0883456586', 'Sofia, 2 Zdrave str.'),
(2, 'Petur Petrov', '0897635645', 'Varna, 5 Dragoman str.'),
(3, 'Gergana Mancheva', '0897412123', 'Gabrovo, 21 Vasil Levski str.'),
(4, 'Kaloqn Stoqnov', '0878325642', null),
(5, 'Stamat Kostov', '0857231001', 'Plovdiv'),
(6, 'Milena Dragomirova', '0876542123', 'Sofia, 213 Pirin str.'),
(7, 'Kiril Peshev', '0838654111', 'Sliven, 54 Struma str.'),
(8, 'Krasen Lyubenov', '0788120333', 'Stara Zagora, 2 Trakia str.'),
(9, 'Martin Genchev', '0899452325', 'Varna, 45 Devnya str.'),
(10, 'Kamelia Yancheva', '0876213799', 'Burgas, 21 Alexandrovska str.'),
(11, 'Metodi Dimitrov', '0894568889', null),
(12, 'Matei Kirilov', '0978235641', 'Kalofer, 2 Mladost str.'),
(13, 'Dobrin Krustev', '0978235641', 'Blagoevgrad, 2 Akacia str.'),
(14, 'Kaloyan Dobrev', '0896523145', 'Gorna Oryahovitsa, 12 Angel Georgiev str.'),
(15, 'Miroslav Kirilov', '0874563214', 'Sofia, 156 Mladost str.'),
(16, 'Krasen Stoyanov', '0896333258', 'Plovdiv, 18 Baba Tonka str.'),
(17, 'Bozhidara Stoicheva', '0874569123', 'Provadia, 1 Buk str.'),
(18, 'Petya Dobreva', '0874547896', 'Varna, 65 Vihren str.'),
(19, 'Kristina Kirova', '0888655632', 'Varna, 118 General Kolev str.'),
(20, 'Mila Sotirova', '0877456222', 'Burgas, 15 Glarus str.'),
(21, 'Grigor Litov', '0899366584', 'Sofia, 35 Detelina str.'),
(22, 'Karolina Dukova', '0894562123', 'Sliven, 8 Dobrotitsa str.'),
(23, 'Ivan Fotinov', '0879654125', 'Petrich, 9 Zora str.'),
(24, 'Anelia Mihova', '0897856147', 'Varna, 29 Dunav str.'),
(25, 'Stanislav Peshev', '0889699599', 'Sofia, 22 Karamfil str.'),
(26, 'Borislava Kamenova', '0877477112', 'Burgas, 15 Marek str.')

SET IDENTITY_INSERT Owners OFF

-- Table: AnimalTypes
SET IDENTITY_INSERT AnimalTypes ON

INSERT INTO AnimalTypes(Id, AnimalType) VALUES
(1, 'Mammals'),
(2, 'Fish'),
(3, 'Birds'),
(4, 'Reptiles'),
(5, 'Amphibians'),
(6, 'Invertebrates')

SET IDENTITY_INSERT AnimalTypes OFF

SET IDENTITY_INSERT Animals ON

INSERT INTO Animals(Id, Name, BirthDate, OwnerId, AnimalTypeId) VALUES
(1, 'Brown bear', '2017-07-17', 3, 1),
(2, 'Chimpanzee', '2010-01-21', 6, 1),
(3, 'Chinchilla', '2019-11-01', 11, 1),
(4, 'Elephant', '2009-05-18', 4, 1),
(5, 'Lion', '2018-06-28', 10, 1),
(6, 'Rhinoceros', '2011-12-24', 2, 1),
(7, 'Wolf', '2018-03-09', 7, 1),
(8, 'Leopard', '2017-04-17', 4, 1),
(9, 'Fennec Fox', '2015-09-10', 26, 1),
(10, 'Giant Panda', '2021-11-11', 18, 1),
(11, 'Hippo', '2017-09-07', null, 1),
(12, 'Koala', '2018-06-30', 24, 1),
(13, 'Pumpkinseed Sunfish', '2020-11-04', 10, 2),
(14, 'Banded Archer Fish', '2022-01-15', null, 2),
(15, 'Cichlid', '2021-01-21', 5, 2),
(16, 'Koi', '2021-07-05', null, 2),
(17, 'West African Lungfish', '2019-10-17', 4, 2),
(18, 'Leopard Shark', '2018-02-16', 16, 2),
(19, 'Tufted Puffin', '2017-10-31', 8, 3),
(20, 'Saddlebill Stork', '2019-08-21', null, 3),
(21, 'Ostrich', '2016-05-02', 4, 3),
(22, 'Bald Eagle', '2014-06-29', 12, 3),
(23, 'Swan Goose', '2018-11-12', 9, 3),
(24, 'Northern Pintail Duck', '2019-02-15', 6, 3),
(25, 'African Penguin', '2017-07-17', null, 3),
(26, 'American Kestrel', '2019-04-27', 18, 3),
(27, 'California Condor', '2014-12-19', 16, 3),
(28, 'African Spurred Tortoise', '2009-09-26', 7, 4),
(29, 'Anaconda', '2016-07-13', 10, 4),
(30, 'Boa', '2015-08-21', null, 4),
(31, 'Chameleon', '2018-10-07', null, 4),
(32, 'Crocodilian', '2016-01-11', 11, 4),
(33, 'Iguana', '2019-04-29', 6, 4),
(34, 'Lizard', '2020-12-02', 7, 4),
(35, 'Tuatara', '2021-06-18', 14, 4),
(36, 'Woma Python', '2019-04-26', 19, 4),
(37, 'Rattlesnake', '2017-12-02', 19, 4),
(38, 'Goliath Frog', '2020-01-31', null, 5),
(39, 'Poison Frog', '2020-07-13', null, 5),
(40, 'Mantella', '2022-03-21', 9, 5),
(41, 'Surinam Toad', '2021-06-15', 11, 5),
(42, 'Axolotl', '2019-01-21', 12, 5),
(43, 'Panamanian Golden Frog', '2021-09-30', 23, 5),
(44, 'Desert Hairy Scorpion', '2020-05-13', null, 6),
(45, 'Madagascar Hissing Cockroach', '2021-09-10', 7, 6),
(46, 'Sunburst Diving Beetle', '2022-01-05', 9, 6)

SET IDENTITY_INSERT Animals OFF