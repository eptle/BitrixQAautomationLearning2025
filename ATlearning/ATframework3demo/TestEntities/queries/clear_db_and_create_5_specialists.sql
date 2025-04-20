TRUNCATE TABLE up_specialist;

TRUNCATE TABLE up_skill;

TRUNCATE TABLE up_grade;

TRUNCATE TABLE up_skill_grade;

TRUNCATE TABLE up_certification;

TRUNCATE TABLE up_skill_certification;

TRUNCATE TABLE up_ind_dev_plan;

INSERT
IGNORE INTO up_grade (NAME, LEVEL)
VALUES ('Junior', 10),
	   ('Middle', 20),
	   ('Senior', 30);


SET @time = NOW() - INTERVAL 60 DAY;

-- === Добавление 5 специалистов ===
INSERT INTO up_specialist (NAME, UPDATED_BY, UPDATED_AT) VALUES 
('QA Engineer', 1, DATE_ADD(@time, INTERVAL 1 DAY)),
('PHP Developer', 1, DATE_ADD(@time, INTERVAL 2 DAY)),
('UI/UX Designer', 1, DATE_ADD(@time, INTERVAL 3 DAY)),
('DevOps Engineer', 1, DATE_ADD(@time, INTERVAL 4 DAY)),
('Project Manager', 1, DATE_ADD(@time, INTERVAL 5 DAY));

-- === Добавление навыков (20 штук, по 4 на каждого специалиста) ===
-- Специалист ID = 1 (QA Engineer)
INSERT INTO up_skill (NAME, SPECIALIST_ID) VALUES 
('API Testing', 1),
('UI Testing', 1),
('Test Automation', 1),
('Performance Testing', 1);

-- Специалист ID = 2 (PHP Developer)
INSERT INTO up_skill (NAME, SPECIALIST_ID) VALUES 
('PHP OOP', 2),
('Laravel Framework', 2),
('MySQL', 2),
('REST API Development', 2);

-- Специалист ID = 3 (UI/UX Designer)
INSERT INTO up_skill (NAME, SPECIALIST_ID) VALUES 
('Wireframing', 3),
('Prototyping', 3),
('Figma', 3),
('UX Research', 3);

-- Специалист ID = 4 (DevOps Engineer)
INSERT INTO up_skill (NAME, SPECIALIST_ID) VALUES 
('Docker', 4),
('Kubernetes', 4),
('CI/CD Pipelines', 4),
('Infrastructure as Code', 4);

-- Специалист ID = 5 (Project Manager)
INSERT INTO up_skill (NAME, SPECIALIST_ID) VALUES 
('Agile Methodologies', 5),
('Risk Management', 5),
('Project Planning', 5),
('Stakeholder Communication', 5);

-- === Добавление грейдов для каждого навыка ===
-- Пояснение:
--   GRADE_ID 1 = Junior  (MIN_SCORE = 10)
--   GRADE_ID 2 = Middle  (MIN_SCORE = 20)
--   GRADE_ID 3 = Senior  (MIN_SCORE = 30)

-- SKILL_ID от 1 до 20
-- Для каждого SKILL_ID создаём по 3 записи в up_skill_grade

INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
-- Навык 1
(1, 1, 10, 'Junior level API Testing', 'https://example.com/api-testing-junior'),
(1, 2, 20, 'Middle level API Testing', 'https://example.com/api-testing-middle'),
(1, 3, 30, 'Senior level API Testing', 'https://example.com/api-testing-senior'),

-- Навык 2
(2, 1, 10, 'Junior level UI Testing', 'https://example.com/ui-testing-junior'),
(2, 2, 20, 'Middle level UI Testing', 'https://example.com/ui-testing-middle'),
(2, 3, 30, 'Senior level UI Testing', 'https://example.com/ui-testing-senior'),

-- Навык 3
(3, 1, 10, 'Junior level Test Automation', 'https://example.com/test-automation-junior'),
(3, 2, 20, 'Middle level Test Automation', 'https://example.com/test-automation-middle'),
(3, 3, 30, 'Senior level Test Automation', 'https://example.com/test-automation-senior'),

-- Навык 4
(4, 1, 10, 'Junior level Performance Testing', 'https://example.com/performance-testing-junior'),
(4, 2, 20, 'Middle level Performance Testing', 'https://example.com/performance-testing-middle'),
(4, 3, 30, 'Senior level Performance Testing', 'https://example.com/performance-testing-senior'),

-- Навык 5
(5, 1, 10, 'Junior level PHP OOP', 'https://example.com/php-oop-junior'),
(5, 2, 20, 'Middle level PHP OOP', 'https://example.com/php-oop-middle'),
(5, 3, 30, 'Senior level PHP OOP', 'https://example.com/php-oop-senior'),

-- Навык 6
(6, 1, 10, 'Junior level Laravel Framework', 'https://example.com/laravel-framework-junior'),
(6, 2, 20, 'Middle level Laravel Framework', 'https://example.com/laravel-framework-middle'),
(6, 3, 30, 'Senior level Laravel Framework', 'https://example.com/laravel-framework-senior'),

-- Навык 7
(7, 1, 10, 'Junior level MySQL', 'https://example.com/mysql-junior'),
(7, 2, 20, 'Middle level MySQL', 'https://example.com/mysql-middle'),
(7, 3, 30, 'Senior level MySQL', 'https://example.com/mysql-senior'),

-- Навык 8
(8, 1, 10, 'Junior level REST API Development', 'https://example.com/rest-api-development-junior'),
(8, 2, 20, 'Middle level REST API Development', 'https://example.com/rest-api-development-middle'),
(8, 3, 30, 'Senior level REST API Development', 'https://example.com/rest-api-development-senior'),

-- Навык 9
(9, 1, 10, 'Junior level Wireframing', 'https://example.com/wireframing-junior'),
(9, 2, 20, 'Middle level Wireframing', 'https://example.com/wireframing-middle'),
(9, 3, 30, 'Senior level Wireframing', 'https://example.com/wireframing-senior'),

-- Навык 10
(10, 1, 10, 'Junior level Prototyping', 'https://example.com/prototyping-junior'),
(10, 2, 20, 'Middle level Prototyping', 'https://example.com/prototyping-middle'),
(10, 3, 30, 'Senior level Prototyping', 'https://example.com/prototyping-senior'),

-- Навык 11
(11, 1, 10, 'Junior level Figma', 'https://example.com/figma-junior'),
(11, 2, 20, 'Middle level Figma', 'https://example.com/figma-middle'),
(11, 3, 30, 'Senior level Figma', 'https://example.com/figma-senior'),

-- Навык 12
(12, 1, 10, 'Junior level UX Research', 'https://example.com/ux-research-junior'),
(12, 2, 20, 'Middle level UX Research', 'https://example.com/ux-research-middle'),
(12, 3, 30, 'Senior level UX Research', 'https://example.com/ux-research-senior'),

-- Навык 13
(13, 1, 10, 'Junior level Docker', 'https://example.com/docker-junior'),
(13, 2, 20, 'Middle level Docker', 'https://example.com/docker-middle'),
(13, 3, 30, 'Senior level Docker', 'https://example.com/docker-senior'),

-- Навык 14
(14, 1, 10, 'Junior level Kubernetes', 'https://example.com/kubernetes-junior'),
(14, 2, 20, 'Middle level Kubernetes', 'https://example.com/kubernetes-middle'),
(14, 3, 30, 'Senior level Kubernetes', 'https://example.com/kubernetes-senior'),

-- Навык 15
(15, 1, 10, 'Junior level CI/CD Pipelines', 'https://example.com/cicd-pipelines-junior'),
(15, 2, 20, 'Middle level CI/CD Pipelines', 'https://example.com/cicd-pipelines-middle'),
(15, 3, 30, 'Senior level CI/CD Pipelines', 'https://example.com/cicd-pipelines-senior'),

-- Навык 16
(16, 1, 10, 'Junior level Infrastructure as Code', 'https://example.com/infrastructure-as-code-junior'),
(16, 2, 20, 'Middle level Infrastructure as Code', 'https://example.com/infrastructure-as-code-middle'),
(16, 3, 30, 'Senior level Infrastructure as Code', 'https://example.com/infrastructure-as-code-senior'),

-- Навык 17
(17, 1, 10, 'Junior level Agile Methodologies', 'https://example.com/agile-methodologies-junior'),
(17, 2, 20, 'Middle level Agile Methodologies', 'https://example.com/agile-methodologies-middle'),
(17, 3, 30, 'Senior level Agile Methodologies', 'https://example.com/agile-methodologies-senior'),

-- Навык 18
(18, 1, 10, 'Junior level Risk Management', 'https://example.com/risk-management-junior'),
(18, 2, 20, 'Middle level Risk Management', 'https://example.com/risk-management-middle'),
(18, 3, 30, 'Senior level Risk Management', 'https://example.com/risk-management-senior'),

-- Навык 19
(19, 1, 10, 'Junior level Project Planning', 'https://example.com/project-planning-junior'),
(19, 2, 20, 'Middle level Project Planning', 'https://example.com/project-planning-middle'),
(19, 3, 30, 'Senior level Project Planning', 'https://example.com/project-planning-senior'),

-- Навык 20
(20, 1, 10, 'Junior level Stakeholder Communication', 'https://example.com/stakeholder-communication-junior'),
(20, 2, 20, 'Middle level Stakeholder Communication', 'https://example.com/stakeholder-communication-middle'),
(20, 3, 30, 'Senior level Stakeholder Communication', 'https://example.com/stakeholder-communication-senior');

