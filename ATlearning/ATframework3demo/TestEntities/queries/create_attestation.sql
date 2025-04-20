-- Добавим сертификации
INSERT INTO up_certification (ID, DATE, MANAGER_ID, EMPLOYEE_ID, SPECIALIST_ID) VALUES
(1, NOW(), 999, 1, (SELECT ID FROM up_specialist WHERE NAME = 'QA Engineer')),        -- Employee 1
(2, NOW(), 999, 2, (SELECT ID FROM up_specialist WHERE NAME = 'QA Engineer')),        -- Employee 2
(3, NOW(), 999, 3, (SELECT ID FROM up_specialist WHERE NAME = 'UI/UX Designer')),     -- Employee 3
(4, NOW(), 999, 4, (SELECT ID FROM up_specialist WHERE NAME = 'UI/UX Designer')),     -- Employee 4
(5, NOW(), 999, 5, (SELECT ID FROM up_specialist WHERE NAME = 'UI/UX Designer'));     -- Employee 5


-- Вставим оценки по навыкам для QA (2 сертифицированных сотрудника)
-- QA имеет 4 навыка: нужно минимум 3 на уровне грейда

-- Employee 1: Junior → оценки: 10, 10, 10 (>=10) → 75% ок
INSERT INTO up_skill_certification (SKILL_ID, CERTIFICATION_ID, SCORE)
SELECT ID, 1, 10
FROM up_skill WHERE SPECIALIST_ID = (SELECT ID FROM up_specialist WHERE NAME = 'QA Engineer')
LIMIT 3;

-- Добавим 4-й скилл с низкой оценкой
INSERT INTO up_skill_certification (SKILL_ID, CERTIFICATION_ID, SCORE)
SELECT ID, 1, 5
FROM up_skill WHERE SPECIALIST_ID = (SELECT ID FROM up_specialist WHERE NAME = 'QA Engineer')
ORDER BY ID DESC
LIMIT 1;


-- Employee 2: Middle → оценки: 20, 20, 20 (>=20) → 75% ок
INSERT INTO up_skill_certification (SKILL_ID, CERTIFICATION_ID, SCORE)
SELECT ID, 2, 20
FROM up_skill WHERE SPECIALIST_ID = (SELECT ID FROM up_specialist WHERE NAME = 'QA Engineer')
LIMIT 3;

-- Один навык чуть ниже
INSERT INTO up_skill_certification (SKILL_ID, CERTIFICATION_ID, SCORE)
SELECT ID, 2, 15
FROM up_skill WHERE SPECIALIST_ID = (SELECT ID FROM up_specialist WHERE NAME = 'QA Engineer')
ORDER BY ID DESC
LIMIT 1;


-- Вставим оценки для UI/UX (3 сотрудника)

-- Employee 3: Senior (все 4 >=30)
INSERT INTO up_skill_certification (SKILL_ID, CERTIFICATION_ID, SCORE)
SELECT ID, 3, 30
FROM up_skill WHERE SPECIALIST_ID = (SELECT ID FROM up_specialist WHERE NAME = 'UI/UX Designer');

-- Employee 4: Senior (3 по 30, 1 по 25)
INSERT INTO up_skill_certification (SKILL_ID, CERTIFICATION_ID, SCORE)
SELECT ID, 4, CASE WHEN ROW_NUMBER() OVER () = 4 THEN 25 ELSE 30 END
FROM (
    SELECT ID FROM up_skill WHERE SPECIALIST_ID = (SELECT ID FROM up_specialist WHERE NAME = 'UI/UX Designer')
    ORDER BY ID
) AS skills;

-- Employee 5: Junior (3 по 10, 1 по 5)
INSERT INTO up_skill_certification (SKILL_ID, CERTIFICATION_ID, SCORE)
SELECT ID, 5, CASE WHEN ROW_NUMBER() OVER () = 4 THEN 5 ELSE 10 END
FROM (
    SELECT ID FROM up_skill WHERE SPECIALIST_ID = (SELECT ID FROM up_specialist WHERE NAME = 'UI/UX Designer')
    ORDER BY ID
) AS skills;
