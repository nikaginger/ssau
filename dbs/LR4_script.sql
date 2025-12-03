USE sakila;

-- 1) Вывести всех покупателей из указанного списка стран: отобразить имя, фамилию, страну.
SELECT 
    c.first_name AS Имя,
    c.last_name AS Фамилия,
    co.country AS Страна
FROM customer c
JOIN address a ON c.address_id = a.address_id
JOIN city ci ON a.city_id = ci.city_id
JOIN country co ON ci.country_id = co.country_id
WHERE co.country IN ('Canada', 'Germany', 'Japan');  -- пример списка стран


-- 2) Вывести все фильмы, в которых снимался указанный актёр: название фильма, жанр.
SELECT 
    f.title AS Фильм,
    cat.name AS Жанр
FROM film_actor fa
JOIN actor a ON fa.actor_id = a.actor_id
JOIN film f ON fa.film_id = f.film_id
JOIN film_category fc ON f.film_id = fc.film_id
JOIN category cat ON fc.category_id = cat.category_id
WHERE a.first_name = 'JOHNNY' AND a.last_name = 'LOLLOBRIGIDA';  -- пример актёра


-- 3) Вывести топ-10 жанров по доходу в указанном месяце: отобразить жанр, доход.
SELECT 
    cat.name AS Жанр,
    SUM(p.amount) AS Доход
FROM payment p
JOIN rental r ON p.rental_id = r.rental_id
JOIN inventory i ON r.inventory_id = i.inventory_id
JOIN film_category fc ON i.film_id = fc.film_id
JOIN category cat ON fc.category_id = cat.category_id
WHERE MONTH(p.payment_date) = 5   -- пример: май
GROUP BY cat.name
ORDER BY Доход DESC
LIMIT 10;

-- 4) Вывести 5 клиентов, начиная с 10-й позиции, упорядоченных по количеству купленных фильмов с указанным актёром.
SELECT 
    c.first_name AS Имя,
    c.last_name AS Фамилия,
    COUNT(*) AS Количество_фильмов
FROM customer c
JOIN rental r ON c.customer_id = r.customer_id
JOIN inventory i ON r.inventory_id = i.inventory_id
JOIN film_actor fa ON i.film_id = fa.film_id
JOIN actor a ON fa.actor_id = a.actor_id
WHERE a.first_name = 'PENELOPE' AND a.last_name = 'GUINESS'
GROUP BY c.customer_id
ORDER BY Количество_фильмов DESC
LIMIT 5 OFFSET 10;


-- 5) Для каждого магазина вывести город, страну и суммарный доход за первую неделю продаж.
SELECT 
    s.store_id AS Магазин,
    ci.city AS Город,
    co.country AS Страна,
    SUM(p.amount) AS Доход_за_неделю
FROM store s
JOIN address a ON s.address_id = a.address_id
JOIN city ci ON a.city_id = ci.city_id
JOIN country co ON ci.country_id = co.country_id
JOIN staff st ON s.store_id = st.store_id
JOIN payment p ON st.staff_id = p.staff_id
WHERE DATE(p.payment_date) BETWEEN '2005-05-24' AND '2005-05-31' -- первая неделя в демо
GROUP BY s.store_id;

-- 6) Вывести всех актёров для фильма, который принёс максимальный доход.
WITH film_income AS (
    SELECT 
        f.film_id,
        f.title,
        SUM(p.amount) AS income
    FROM payment p
    JOIN rental r ON p.rental_id = r.rental_id
    JOIN inventory i ON r.inventory_id = i.inventory_id
    JOIN film f ON i.film_id = f.film_id
    GROUP BY f.film_id
),
max_film AS (
    SELECT *
    FROM film_income
    ORDER BY income DESC
    LIMIT 1
)
SELECT 
    mf.title AS Фильм,
    a.first_name AS Имя,
    a.last_name AS Фамилия
FROM max_film mf
JOIN film_actor fa ON mf.film_id = fa.film_id
JOIN actor a ON fa.actor_id = a.actor_id;

-- 7) Для всех покупателей — вывести покупателей и актёров-однофамильцев (LEFT JOIN). 
SELECT 
    c.first_name AS Имя_покупателя,
    c.last_name AS Фамилия_покупателя,
    a.actor_id AS ID_актёра,
    a.first_name AS Имя_актёра,
    a.last_name AS Фамилия_актёра
FROM customer c
LEFT JOIN actor a ON c.last_name = a.last_name;

-- 8) Для всех актёров — вывести актёров и покупателей-однофамильцев (RIGHT JOIN).
SELECT 
    c.customer_id AS ID_покупателя,
    c.first_name AS Имя_покупателя,
    c.last_name AS Фамилия_покупателя,
    a.first_name AS Имя_актёра,
    a.last_name AS Фамилия_актёра
FROM customer c
RIGHT JOIN actor a ON c.last_name = a.last_name;

-- 9.1) Длина самого длинного фильма и количество фильмов такой длины.
SELECT 
    MAX(length) AS Макс_длина,
    COUNT(*) AS Количество
FROM film
WHERE length = (SELECT MAX(length) FROM film);

-- 9.2) Длина самого короткого фильма и количество таких фильмов.
SELECT 
    MIN(length) AS Мин_длина,
    COUNT(*) AS Количество
FROM film
WHERE length = (SELECT MIN(length) FROM film);

-- 9.3) Максимальное количество актёров в фильме и количество таких фильмов.
WITH actor_counts AS (
    SELECT 
        film_id,
        COUNT(actor_id) AS total_actors
    FROM film_actor
    GROUP BY film_id
)
SELECT 
    MAX(total_actors) AS Макс_актёров,
    COUNT(*) AS Количество_фильмов
FROM actor_counts
WHERE total_actors = (SELECT MAX(total_actors) FROM actor_counts);

-- 9.4) Минимальное количество актёров в фильме и количество таких фильмов.
WITH actor_counts AS (
    SELECT 
        film_id,
        COUNT(actor_id) AS total_actors
    FROM film_actor
    GROUP BY film_id
)
SELECT 
    MIN(total_actors) AS Мин_актёров,
    COUNT(*) AS Количество_фильмов
FROM actor_counts
WHERE total_actors = (SELECT MIN(total_actors) FROM actor_counts);

