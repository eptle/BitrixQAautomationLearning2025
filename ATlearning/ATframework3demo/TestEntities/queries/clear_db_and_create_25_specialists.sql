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
('Project Manager', 1, DATE_ADD(@time, INTERVAL 5 DAY)),
('Data Scientist', 1, DATE_ADD(@time, INTERVAL 6 DAY)),
('Frontend Developer', 1, DATE_ADD(@time, INTERVAL 7 DAY)),
('Backend Developer', 1, DATE_ADD(@time, INTERVAL 8 DAY)),
('Business Analyst', 1, DATE_ADD(@time, INTERVAL 9 DAY)),
('Mobile Developer', 1, DATE_ADD(@time, INTERVAL 10 DAY)),
('Security Specialist', 1, DATE_ADD(@time, INTERVAL 11 DAY)),
('Machine Learning Engineer', 1, DATE_ADD(@time, INTERVAL 12 DAY)),
('Database Administrator', 1, DATE_ADD(@time, INTERVAL 13 DAY)),
('System Architect', 1, DATE_ADD(@time, INTERVAL 14 DAY)),
('Tech Lead', 1, DATE_ADD(@time, INTERVAL 15 DAY)),
('Scrum Master', 1, DATE_ADD(@time, INTERVAL 16 DAY)),
('Product Manager', 1, DATE_ADD(@time, INTERVAL 17 DAY)),
('Content Strategist', 1, DATE_ADD(@time, INTERVAL 18 DAY)),
('Game Developer', 1, DATE_ADD(@time, INTERVAL 19 DAY)),
('Support Engineer', 1, DATE_ADD(@time, INTERVAL 20 DAY)),
('SRE Engineer', 1, DATE_ADD(@time, INTERVAL 21 DAY)),
('Embedded Developer', 1, DATE_ADD(@time, INTERVAL 22 DAY)),
('Cloud Engineer', 1, DATE_ADD(@time, INTERVAL 23 DAY)),
('AI Researcher', 1, DATE_ADD(@time, INTERVAL 24 DAY)),
('Tech Recruiter', 1, DATE_ADD(@time, INTERVAL 25 DAY));

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

-- === Добавление 80 навыков (по 4 на каждого из 20 специалистов, ID 21–100) ===
INSERT INTO up_skill (NAME, SPECIALIST_ID) VALUES 
-- Data Scientist (6)
('Data Analysis', 6), ('Statistics', 6), ('Python for Data Science', 6), ('Data Visualization', 6),

-- Frontend Developer (7)
('HTML/CSS', 7), ('JavaScript', 7), ('React.js', 7), ('Frontend Testing', 7),

-- Backend Developer (8)
('Node.js', 8), ('API Design', 8), ('Database Integration', 8), ('Authentication', 8),

-- Business Analyst (9)
('Requirement Gathering', 9), ('Process Modeling', 9), ('Stakeholder Analysis', 9), ('Documentation', 9),

-- Mobile Developer (10)
('Android Development', 10), ('iOS Development', 10), ('Flutter', 10), ('Mobile UI/UX', 10),

-- Security Specialist (11)
('Threat Modeling', 11), ('Penetration Testing', 11), ('Security Protocols', 11), ('Incident Response', 11),

-- Machine Learning Engineer (12)
('Model Training', 12), ('Model Evaluation', 12), ('ML Pipelines', 12), ('Feature Engineering', 12),

-- Database Administrator (13)
('Database Backup', 13), ('Query Optimization', 13), ('Replication', 13), ('Monitoring Tools', 13),

-- System Architect (14)
('System Design', 14), ('Scalability', 14), ('Architecture Patterns', 14), ('Integration Strategies', 14),

-- Tech Lead (15)
('Team Management', 15), ('Code Review', 15), ('Tech Vision', 15), ('Mentorship', 15),

-- Scrum Master (16)
('Scrum Framework', 16), ('Sprint Planning', 16), ('Retrospectives', 16), ('Team Facilitation', 16),

-- Product Manager (17)
('Market Analysis', 17), ('Product Roadmapping', 17), ('KPI Definition', 17), ('User Feedback', 17),

-- Content Strategist (18)
('SEO Basics', 18), ('Content Planning', 18), ('Copywriting', 18), ('Content Auditing', 18),

-- Game Developer (19)
('Game Engines', 19), ('Game Physics', 19), ('Level Design', 19), ('Multiplayer Sync', 19),

-- Support Engineer (20)
('Troubleshooting', 20), ('Ticketing Systems', 20), ('Customer Interaction', 20), ('Issue Escalation', 20),

-- SRE Engineer (21)
('Monitoring & Logging', 21), ('Incident Management', 21), ('Infrastructure Resilience', 21), ('Error Budgets', 21),

-- Embedded Developer (22)
('C Programming', 22), ('Microcontroller Programming', 22), ('RTOS Concepts', 22), ('Low-level Debugging', 22),

-- Cloud Engineer (23)
('AWS Services', 23), ('Terraform', 23), ('Cloud Security', 23), ('Cost Optimization', 23),

-- AI Researcher (24)
('Neural Networks', 24), ('Deep Learning Theory', 24), ('Paper Review', 24), ('Model Explainability', 24),

-- Tech Recruiter (25)
('Tech Screening', 25), ('Interview Coordination', 25), ('Sourcing Strategies', 25), ('Employer Branding', 25);

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

-- Грейды для навыка 21
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(21, 1, 10, 'Junior level for skill 21', 'https://example.com/skill-21-junior'),
(21, 2, 20, 'Middle level for skill 21', 'https://example.com/skill-21-middle'),
(21, 3, 30, 'Senior level for skill 21', 'https://example.com/skill-21-senior');

-- Грейды для навыка 22
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(22, 1, 10, 'Junior level for skill 22', 'https://example.com/skill-22-junior'),
(22, 2, 20, 'Middle level for skill 22', 'https://example.com/skill-22-middle'),
(22, 3, 30, 'Senior level for skill 22', 'https://example.com/skill-22-senior');

-- Грейды для навыка 23
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(23, 1, 10, 'Junior level for skill 23', 'https://example.com/skill-23-junior'),
(23, 2, 20, 'Middle level for skill 23', 'https://example.com/skill-23-middle'),
(23, 3, 30, 'Senior level for skill 23', 'https://example.com/skill-23-senior');

-- Грейды для навыка 24
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(24, 1, 10, 'Junior level for skill 24', 'https://example.com/skill-24-junior'),
(24, 2, 20, 'Middle level for skill 24', 'https://example.com/skill-24-middle'),
(24, 3, 30, 'Senior level for skill 24', 'https://example.com/skill-24-senior');

-- Грейды для навыка 25
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(25, 1, 10, 'Junior level for skill 25', 'https://example.com/skill-25-junior'),
(25, 2, 20, 'Middle level for skill 25', 'https://example.com/skill-25-middle'),
(25, 3, 30, 'Senior level for skill 25', 'https://example.com/skill-25-senior');

-- Грейды для навыка 26
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(26, 1, 10, 'Junior level for skill 26', 'https://example.com/skill-26-junior'),
(26, 2, 20, 'Middle level for skill 26', 'https://example.com/skill-26-middle'),
(26, 3, 30, 'Senior level for skill 26', 'https://example.com/skill-26-senior');

-- Грейды для навыка 27
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(27, 1, 10, 'Junior level for skill 27', 'https://example.com/skill-27-junior'),
(27, 2, 20, 'Middle level for skill 27', 'https://example.com/skill-27-middle'),
(27, 3, 30, 'Senior level for skill 27', 'https://example.com/skill-27-senior');

-- Грейды для навыка 28
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(28, 1, 10, 'Junior level for skill 28', 'https://example.com/skill-28-junior'),
(28, 2, 20, 'Middle level for skill 28', 'https://example.com/skill-28-middle'),
(28, 3, 30, 'Senior level for skill 28', 'https://example.com/skill-28-senior');

-- Грейды для навыка 29
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(29, 1, 10, 'Junior level for skill 29', 'https://example.com/skill-29-junior'),
(29, 2, 20, 'Middle level for skill 29', 'https://example.com/skill-29-middle'),
(29, 3, 30, 'Senior level for skill 29', 'https://example.com/skill-29-senior');

-- Грейды для навыка 30
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(30, 1, 10, 'Junior level for skill 30', 'https://example.com/skill-30-junior'),
(30, 2, 20, 'Middle level for skill 30', 'https://example.com/skill-30-middle'),
(30, 3, 30, 'Senior level for skill 30', 'https://example.com/skill-30-senior');

-- Грейды для навыка 31
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(31, 1, 10, 'Junior level for skill 31', 'https://example.com/skill-31-junior'),
(31, 2, 20, 'Middle level for skill 31', 'https://example.com/skill-31-middle'),
(31, 3, 30, 'Senior level for skill 31', 'https://example.com/skill-31-senior');

-- Грейды для навыка 32
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(32, 1, 10, 'Junior level for skill 32', 'https://example.com/skill-32-junior'),
(32, 2, 20, 'Middle level for skill 32', 'https://example.com/skill-32-middle'),
(32, 3, 30, 'Senior level for skill 32', 'https://example.com/skill-32-senior');

-- Грейды для навыка 33
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(33, 1, 10, 'Junior level for skill 33', 'https://example.com/skill-33-junior'),
(33, 2, 20, 'Middle level for skill 33', 'https://example.com/skill-33-middle'),
(33, 3, 30, 'Senior level for skill 33', 'https://example.com/skill-33-senior');

-- Грейды для навыка 34
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(34, 1, 10, 'Junior level for skill 34', 'https://example.com/skill-34-junior'),
(34, 2, 20, 'Middle level for skill 34', 'https://example.com/skill-34-middle'),
(34, 3, 30, 'Senior level for skill 34', 'https://example.com/skill-34-senior');

-- Грейды для навыка 35
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(35, 1, 10, 'Junior level for skill 35', 'https://example.com/skill-35-junior'),
(35, 2, 20, 'Middle level for skill 35', 'https://example.com/skill-35-middle'),
(35, 3, 30, 'Senior level for skill 35', 'https://example.com/skill-35-senior');

-- Грейды для навыка 36
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(36, 1, 10, 'Junior level for skill 36', 'https://example.com/skill-36-junior'),
(36, 2, 20, 'Middle level for skill 36', 'https://example.com/skill-36-middle'),
(36, 3, 30, 'Senior level for skill 36', 'https://example.com/skill-36-senior');

-- Грейды для навыка 37
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(37, 1, 10, 'Junior level for skill 37', 'https://example.com/skill-37-junior'),
(37, 2, 20, 'Middle level for skill 37', 'https://example.com/skill-37-middle'),
(37, 3, 30, 'Senior level for skill 37', 'https://example.com/skill-37-senior');

-- Грейды для навыка 38
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(38, 1, 10, 'Junior level for skill 38', 'https://example.com/skill-38-junior'),
(38, 2, 20, 'Middle level for skill 38', 'https://example.com/skill-38-middle'),
(38, 3, 30, 'Senior level for skill 38', 'https://example.com/skill-38-senior');

-- Грейды для навыка 39
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(39, 1, 10, 'Junior level for skill 39', 'https://example.com/skill-39-junior'),
(39, 2, 20, 'Middle level for skill 39', 'https://example.com/skill-39-middle'),
(39, 3, 30, 'Senior level for skill 39', 'https://example.com/skill-39-senior');

-- Грейды для навыка 40
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(40, 1, 10, 'Junior level for skill 40', 'https://example.com/skill-40-junior'),
(40, 2, 20, 'Middle level for skill 40', 'https://example.com/skill-40-middle'),
(40, 3, 30, 'Senior level for skill 40', 'https://example.com/skill-40-senior');

-- Грейды для навыка 41
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(41, 1, 10, 'Junior level for skill 41', 'https://example.com/skill-41-junior'),
(41, 2, 20, 'Middle level for skill 41', 'https://example.com/skill-41-middle'),
(41, 3, 30, 'Senior level for skill 41', 'https://example.com/skill-41-senior');

-- Грейды для навыка 42
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(42, 1, 10, 'Junior level for skill 42', 'https://example.com/skill-42-junior'),
(42, 2, 20, 'Middle level for skill 42', 'https://example.com/skill-42-middle'),
(42, 3, 30, 'Senior level for skill 42', 'https://example.com/skill-42-senior');

-- Грейды для навыка 43
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(43, 1, 10, 'Junior level for skill 43', 'https://example.com/skill-43-junior'),
(43, 2, 20, 'Middle level for skill 43', 'https://example.com/skill-43-middle'),
(43, 3, 30, 'Senior level for skill 43', 'https://example.com/skill-43-senior');

-- Грейды для навыка 44
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(44, 1, 10, 'Junior level for skill 44', 'https://example.com/skill-44-junior'),
(44, 2, 20, 'Middle level for skill 44', 'https://example.com/skill-44-middle'),
(44, 3, 30, 'Senior level for skill 44', 'https://example.com/skill-44-senior');

-- Грейды для навыка 45
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(45, 1, 10, 'Junior level for skill 45', 'https://example.com/skill-45-junior'),
(45, 2, 20, 'Middle level for skill 45', 'https://example.com/skill-45-middle'),
(45, 3, 30, 'Senior level for skill 45', 'https://example.com/skill-45-senior');

-- Грейды для навыка 46
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(46, 1, 10, 'Junior level for skill 46', 'https://example.com/skill-46-junior'),
(46, 2, 20, 'Middle level for skill 46', 'https://example.com/skill-46-middle'),
(46, 3, 30, 'Senior level for skill 46', 'https://example.com/skill-46-senior');

-- Грейды для навыка 47
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(47, 1, 10, 'Junior level for skill 47', 'https://example.com/skill-47-junior'),
(47, 2, 20, 'Middle level for skill 47', 'https://example.com/skill-47-middle'),
(47, 3, 30, 'Senior level for skill 47', 'https://example.com/skill-47-senior');

-- Грейды для навыка 48
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(48, 1, 10, 'Junior level for skill 48', 'https://example.com/skill-48-junior'),
(48, 2, 20, 'Middle level for skill 48', 'https://example.com/skill-48-middle'),
(48, 3, 30, 'Senior level for skill 48', 'https://example.com/skill-48-senior');

-- Грейды для навыка 49
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(49, 1, 10, 'Junior level for skill 49', 'https://example.com/skill-49-junior'),
(49, 2, 20, 'Middle level for skill 49', 'https://example.com/skill-49-middle'),
(49, 3, 30, 'Senior level for skill 49', 'https://example.com/skill-49-senior');

-- Грейды для навыка 50
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(50, 1, 10, 'Junior level for skill 50', 'https://example.com/skill-50-junior'),
(50, 2, 20, 'Middle level for skill 50', 'https://example.com/skill-50-middle'),
(50, 3, 30, 'Senior level for skill 50', 'https://example.com/skill-50-senior');

-- Грейды для навыка 51
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(51, 1, 10, 'Junior level for skill 51', 'https://example.com/skill-51-junior'),
(51, 2, 20, 'Middle level for skill 51', 'https://example.com/skill-51-middle'),
(51, 3, 30, 'Senior level for skill 51', 'https://example.com/skill-51-senior');

-- Грейды для навыка 52
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(52, 1, 10, 'Junior level for skill 52', 'https://example.com/skill-52-junior'),
(52, 2, 20, 'Middle level for skill 52', 'https://example.com/skill-52-middle'),
(52, 3, 30, 'Senior level for skill 52', 'https://example.com/skill-52-senior');

-- Грейды для навыка 53
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(53, 1, 10, 'Junior level for skill 53', 'https://example.com/skill-53-junior'),
(53, 2, 20, 'Middle level for skill 53', 'https://example.com/skill-53-middle'),
(53, 3, 30, 'Senior level for skill 53', 'https://example.com/skill-53-senior');

-- Грейды для навыка 54
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(54, 1, 10, 'Junior level for skill 54', 'https://example.com/skill-54-junior'),
(54, 2, 20, 'Middle level for skill 54', 'https://example.com/skill-54-middle'),
(54, 3, 30, 'Senior level for skill 54', 'https://example.com/skill-54-senior');

-- Грейды для навыка 55
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(55, 1, 10, 'Junior level for skill 55', 'https://example.com/skill-55-junior'),
(55, 2, 20, 'Middle level for skill 55', 'https://example.com/skill-55-middle'),
(55, 3, 30, 'Senior level for skill 55', 'https://example.com/skill-55-senior');

-- Грейды для навыка 56
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(56, 1, 10, 'Junior level for skill 56', 'https://example.com/skill-56-junior'),
(56, 2, 20, 'Middle level for skill 56', 'https://example.com/skill-56-middle'),
(56, 3, 30, 'Senior level for skill 56', 'https://example.com/skill-56-senior');

-- Грейды для навыка 57
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(57, 1, 10, 'Junior level for skill 57', 'https://example.com/skill-57-junior'),
(57, 2, 20, 'Middle level for skill 57', 'https://example.com/skill-57-middle'),
(57, 3, 30, 'Senior level for skill 57', 'https://example.com/skill-57-senior');

-- Грейды для навыка 58
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(58, 1, 10, 'Junior level for skill 58', 'https://example.com/skill-58-junior'),
(58, 2, 20, 'Middle level for skill 58', 'https://example.com/skill-58-middle'),
(58, 3, 30, 'Senior level for skill 58', 'https://example.com/skill-58-senior');

-- Грейды для навыка 59
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(59, 1, 10, 'Junior level for skill 59', 'https://example.com/skill-59-junior'),
(59, 2, 20, 'Middle level for skill 59', 'https://example.com/skill-59-middle'),
(59, 3, 30, 'Senior level for skill 59', 'https://example.com/skill-59-senior');

-- Грейды для навыка 60
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(60, 1, 10, 'Junior level for skill 60', 'https://example.com/skill-60-junior'),
(60, 2, 20, 'Middle level for skill 60', 'https://example.com/skill-60-middle'),
(60, 3, 30, 'Senior level for skill 60', 'https://example.com/skill-60-senior');

-- Грейды для навыка 61
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(61, 1, 10, 'Junior level for skill 61', 'https://example.com/skill-61-junior'),
(61, 2, 20, 'Middle level for skill 61', 'https://example.com/skill-61-middle'),
(61, 3, 30, 'Senior level for skill 61', 'https://example.com/skill-61-senior');

-- Грейды для навыка 62
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(62, 1, 10, 'Junior level for skill 62', 'https://example.com/skill-62-junior'),
(62, 2, 20, 'Middle level for skill 62', 'https://example.com/skill-62-middle'),
(62, 3, 30, 'Senior level for skill 62', 'https://example.com/skill-62-senior');

-- Грейды для навыка 63
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(63, 1, 10, 'Junior level for skill 63', 'https://example.com/skill-63-junior'),
(63, 2, 20, 'Middle level for skill 63', 'https://example.com/skill-63-middle'),
(63, 3, 30, 'Senior level for skill 63', 'https://example.com/skill-63-senior');

-- Грейды для навыка 64
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(64, 1, 10, 'Junior level for skill 64', 'https://example.com/skill-64-junior'),
(64, 2, 20, 'Middle level for skill 64', 'https://example.com/skill-64-middle'),
(64, 3, 30, 'Senior level for skill 64', 'https://example.com/skill-64-senior');

-- Грейды для навыка 65
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(65, 1, 10, 'Junior level for skill 65', 'https://example.com/skill-65-junior'),
(65, 2, 20, 'Middle level for skill 65', 'https://example.com/skill-65-middle'),
(65, 3, 30, 'Senior level for skill 65', 'https://example.com/skill-65-senior');

-- Грейды для навыка 66
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(66, 1, 10, 'Junior level for skill 66', 'https://example.com/skill-66-junior'),
(66, 2, 20, 'Middle level for skill 66', 'https://example.com/skill-66-middle'),
(66, 3, 30, 'Senior level for skill 66', 'https://example.com/skill-66-senior');

-- Грейды для навыка 67
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(67, 1, 10, 'Junior level for skill 67', 'https://example.com/skill-67-junior'),
(67, 2, 20, 'Middle level for skill 67', 'https://example.com/skill-67-middle'),
(67, 3, 30, 'Senior level for skill 67', 'https://example.com/skill-67-senior');

-- Грейды для навыка 68
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(68, 1, 10, 'Junior level for skill 68', 'https://example.com/skill-68-junior'),
(68, 2, 20, 'Middle level for skill 68', 'https://example.com/skill-68-middle'),
(68, 3, 30, 'Senior level for skill 68', 'https://example.com/skill-68-senior');

-- Грейды для навыка 69
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(69, 1, 10, 'Junior level for skill 69', 'https://example.com/skill-69-junior'),
(69, 2, 20, 'Middle level for skill 69', 'https://example.com/skill-69-middle'),
(69, 3, 30, 'Senior level for skill 69', 'https://example.com/skill-69-senior');

-- Грейды для навыка 70
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(70, 1, 10, 'Junior level for skill 70', 'https://example.com/skill-70-junior'),
(70, 2, 20, 'Middle level for skill 70', 'https://example.com/skill-70-middle'),
(70, 3, 30, 'Senior level for skill 70', 'https://example.com/skill-70-senior');

-- Грейды для навыка 71
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(71, 1, 10, 'Junior level for skill 71', 'https://example.com/skill-71-junior'),
(71, 2, 20, 'Middle level for skill 71', 'https://example.com/skill-71-middle'),
(71, 3, 30, 'Senior level for skill 71', 'https://example.com/skill-71-senior');

-- Грейды для навыка 72
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(72, 1, 10, 'Junior level for skill 72', 'https://example.com/skill-72-junior'),
(72, 2, 20, 'Middle level for skill 72', 'https://example.com/skill-72-middle'),
(72, 3, 30, 'Senior level for skill 72', 'https://example.com/skill-72-senior');

-- Грейды для навыка 73
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(73, 1, 10, 'Junior level for skill 73', 'https://example.com/skill-73-junior'),
(73, 2, 20, 'Middle level for skill 73', 'https://example.com/skill-73-middle'),
(73, 3, 30, 'Senior level for skill 73', 'https://example.com/skill-73-senior');

-- Грейды для навыка 74
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(74, 1, 10, 'Junior level for skill 74', 'https://example.com/skill-74-junior'),
(74, 2, 20, 'Middle level for skill 74', 'https://example.com/skill-74-middle'),
(74, 3, 30, 'Senior level for skill 74', 'https://example.com/skill-74-senior');

-- Грейды для навыка 75
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(75, 1, 10, 'Junior level for skill 75', 'https://example.com/skill-75-junior'),
(75, 2, 20, 'Middle level for skill 75', 'https://example.com/skill-75-middle'),
(75, 3, 30, 'Senior level for skill 75', 'https://example.com/skill-75-senior');

-- Грейды для навыка 76
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(76, 1, 10, 'Junior level for skill 76', 'https://example.com/skill-76-junior'),
(76, 2, 20, 'Middle level for skill 76', 'https://example.com/skill-76-middle'),
(76, 3, 30, 'Senior level for skill 76', 'https://example.com/skill-76-senior');

-- Грейды для навыка 77
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(77, 1, 10, 'Junior level for skill 77', 'https://example.com/skill-77-junior'),
(77, 2, 20, 'Middle level for skill 77', 'https://example.com/skill-77-middle'),
(77, 3, 30, 'Senior level for skill 77', 'https://example.com/skill-77-senior');

-- Грейды для навыка 78
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(78, 1, 10, 'Junior level for skill 78', 'https://example.com/skill-78-junior'),
(78, 2, 20, 'Middle level for skill 78', 'https://example.com/skill-78-middle'),
(78, 3, 30, 'Senior level for skill 78', 'https://example.com/skill-78-senior');

-- Грейды для навыка 79
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(79, 1, 10, 'Junior level for skill 79', 'https://example.com/skill-79-junior'),
(79, 2, 20, 'Middle level for skill 79', 'https://example.com/skill-79-middle'),
(79, 3, 30, 'Senior level for skill 79', 'https://example.com/skill-79-senior');

-- Грейды для навыка 80
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(80, 1, 10, 'Junior level for skill 80', 'https://example.com/skill-80-junior'),
(80, 2, 20, 'Middle level for skill 80', 'https://example.com/skill-80-middle'),
(80, 3, 30, 'Senior level for skill 80', 'https://example.com/skill-80-senior');

-- Грейды для навыка 81
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(81, 1, 10, 'Junior level for skill 81', 'https://example.com/skill-81-junior'),
(81, 2, 20, 'Middle level for skill 81', 'https://example.com/skill-81-middle'),
(81, 3, 30, 'Senior level for skill 81', 'https://example.com/skill-81-senior');

-- Грейды для навыка 82
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(82, 1, 10, 'Junior level for skill 82', 'https://example.com/skill-82-junior'),
(82, 2, 20, 'Middle level for skill 82', 'https://example.com/skill-82-middle'),
(82, 3, 30, 'Senior level for skill 82', 'https://example.com/skill-82-senior');

-- Грейды для навыка 83
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(83, 1, 10, 'Junior level for skill 83', 'https://example.com/skill-83-junior'),
(83, 2, 20, 'Middle level for skill 83', 'https://example.com/skill-83-middle'),
(83, 3, 30, 'Senior level for skill 83', 'https://example.com/skill-83-senior');

-- Грейды для навыка 84
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(84, 1, 10, 'Junior level for skill 84', 'https://example.com/skill-84-junior'),
(84, 2, 20, 'Middle level for skill 84', 'https://example.com/skill-84-middle'),
(84, 3, 30, 'Senior level for skill 84', 'https://example.com/skill-84-senior');

-- Грейды для навыка 85
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(85, 1, 10, 'Junior level for skill 85', 'https://example.com/skill-85-junior'),
(85, 2, 20, 'Middle level for skill 85', 'https://example.com/skill-85-middle'),
(85, 3, 30, 'Senior level for skill 85', 'https://example.com/skill-85-senior');

-- Грейды для навыка 86
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(86, 1, 10, 'Junior level for skill 86', 'https://example.com/skill-86-junior'),
(86, 2, 20, 'Middle level for skill 86', 'https://example.com/skill-86-middle'),
(86, 3, 30, 'Senior level for skill 86', 'https://example.com/skill-86-senior');

-- Грейды для навыка 87
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(87, 1, 10, 'Junior level for skill 87', 'https://example.com/skill-87-junior'),
(87, 2, 20, 'Middle level for skill 87', 'https://example.com/skill-87-middle'),
(87, 3, 30, 'Senior level for skill 87', 'https://example.com/skill-87-senior');

-- Грейды для навыка 88
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(88, 1, 10, 'Junior level for skill 88', 'https://example.com/skill-88-junior'),
(88, 2, 20, 'Middle level for skill 88', 'https://example.com/skill-88-middle'),
(88, 3, 30, 'Senior level for skill 88', 'https://example.com/skill-88-senior');

-- Грейды для навыка 89
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(89, 1, 10, 'Junior level for skill 89', 'https://example.com/skill-89-junior'),
(89, 2, 20, 'Middle level for skill 89', 'https://example.com/skill-89-middle'),
(89, 3, 30, 'Senior level for skill 89', 'https://example.com/skill-89-senior');

-- Грейды для навыка 90
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(90, 1, 10, 'Junior level for skill 90', 'https://example.com/skill-90-junior'),
(90, 2, 20, 'Middle level for skill 90', 'https://example.com/skill-90-middle'),
(90, 3, 30, 'Senior level for skill 90', 'https://example.com/skill-90-senior');

-- Грейды для навыка 91
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(91, 1, 10, 'Junior level for skill 91', 'https://example.com/skill-91-junior'),
(91, 2, 20, 'Middle level for skill 91', 'https://example.com/skill-91-middle'),
(91, 3, 30, 'Senior level for skill 91', 'https://example.com/skill-91-senior');

-- Грейды для навыка 92
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(92, 1, 10, 'Junior level for skill 92', 'https://example.com/skill-92-junior'),
(92, 2, 20, 'Middle level for skill 92', 'https://example.com/skill-92-middle'),
(92, 3, 30, 'Senior level for skill 92', 'https://example.com/skill-92-senior');

-- Грейды для навыка 93
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(93, 1, 10, 'Junior level for skill 93', 'https://example.com/skill-93-junior'),
(93, 2, 20, 'Middle level for skill 93', 'https://example.com/skill-93-middle'),
(93, 3, 30, 'Senior level for skill 93', 'https://example.com/skill-93-senior');

-- Грейды для навыка 94
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(94, 1, 10, 'Junior level for skill 94', 'https://example.com/skill-94-junior'),
(94, 2, 20, 'Middle level for skill 94', 'https://example.com/skill-94-middle'),
(94, 3, 30, 'Senior level for skill 94', 'https://example.com/skill-94-senior');

-- Грейды для навыка 95
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(95, 1, 10, 'Junior level for skill 95', 'https://example.com/skill-95-junior'),
(95, 2, 20, 'Middle level for skill 95', 'https://example.com/skill-95-middle'),
(95, 3, 30, 'Senior level for skill 95', 'https://example.com/skill-95-senior');

-- Грейды для навыка 96
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(96, 1, 10, 'Junior level for skill 96', 'https://example.com/skill-96-junior'),
(96, 2, 20, 'Middle level for skill 96', 'https://example.com/skill-96-middle'),
(96, 3, 30, 'Senior level for skill 96', 'https://example.com/skill-96-senior');

-- Грейды для навыка 97
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(97, 1, 10, 'Junior level for skill 97', 'https://example.com/skill-97-junior'),
(97, 2, 20, 'Middle level for skill 97', 'https://example.com/skill-97-middle'),
(97, 3, 30, 'Senior level for skill 97', 'https://example.com/skill-97-senior');

-- Грейды для навыка 98
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(98, 1, 10, 'Junior level for skill 98', 'https://example.com/skill-98-junior'),
(98, 2, 20, 'Middle level for skill 98', 'https://example.com/skill-98-middle'),
(98, 3, 30, 'Senior level for skill 98', 'https://example.com/skill-98-senior');

-- Грейды для навыка 99
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(99, 1, 10, 'Junior level for skill 99', 'https://example.com/skill-99-junior'),
(99, 2, 20, 'Middle level for skill 99', 'https://example.com/skill-99-middle'),
(99, 3, 30, 'Senior level for skill 99', 'https://example.com/skill-99-senior');

-- Грейды для навыка 100
INSERT INTO up_skill_grade (SKILL_ID, GRADE_ID, MIN_SCORE, DESCRIPTION, TRAINING_MATERIAL) VALUES
(100, 1, 10, 'Junior level for skill 100', 'https://example.com/skill-100-junior'),
(100, 2, 20, 'Middle level for skill 100', 'https://example.com/skill-100-middle'),
(100, 3, 30, 'Senior level for skill 100', 'https://example.com/skill-100-senior');
