USE mydb;

-- 6.1.1)

SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
START TRANSACTION;

UPDATE Дисциплина
SET Кол_во_часов = 111
WHERE idДисциплина = 1;


-- 6.1.2)

ROLLBACK;

-- 6.2.1) 

SET SESSION TRANSACTION ISOLATION LEVEL READ COMMITTED;
START TRANSACTION;

UPDATE Дисциплина
SET Кол_во_часов = 222
WHERE idДисциплина = 1;
-- НЕ COMMIT

-- 6.2.2)

COMMIT;


-- 7.1.1)

SET SESSION TRANSACTION ISOLATION LEVEL READ COMMITTED;
START TRANSACTION;

SELECT idДисциплина, Название, Кол_во_часов
FROM Дисциплина
WHERE idДисциплина = 1;

-- 7.1.2)

SELECT idДисциплина, Название, Кол_во_часов
FROM Дисциплина
WHERE idДисциплина = 1;

-- 7.2.1)

SET SESSION TRANSACTION ISOLATION LEVEL REPEATABLE READ;
START TRANSACTION;

SELECT idДисциплина, Название, Кол_во_часов
FROM Дисциплина
WHERE idДисциплина = 1;

-- 7.2.2)

SELECT idДисциплина, Название, Кол_во_часов
FROM Дисциплина
WHERE idДисциплина = 1;
