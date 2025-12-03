USE mydb;

-- 6.1.1)

SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
SELECT idДисциплина, Название, Кол_во_часов
FROM Дисциплина
WHERE idДисциплина = 1;

-- 6.1.2)

SELECT idДисциплина, Название, Кол_во_часов
FROM Дисциплина
WHERE idДисциплина = 1;

-- 6.2.1)

SET SESSION TRANSACTION ISOLATION LEVEL READ COMMITTED;
SELECT idДисциплина, Название, Кол_во_часов
FROM Дисциплина
WHERE idДисциплина = 1;


-- 6.2.2)

SELECT idДисциплина, Название, Кол_во_часов
FROM Дисциплина
WHERE idДисциплина = 1;


-- 7.1.1)

SET SESSION TRANSACTION ISOLATION LEVEL READ COMMITTED;
START TRANSACTION;

UPDATE Дисциплина
SET Кол_во_часов = 200
WHERE idДисциплина = 1;
COMMIT;

-- 7.2.1)

SET SESSION TRANSACTION ISOLATION LEVEL REPEATABLE READ;  -- или любой другой
START TRANSACTION;
UPDATE Дисциплина
SET Кол_во_часов = 100
WHERE idДисциплина = 1;
COMMIT;

