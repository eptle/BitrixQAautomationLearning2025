INSERT INTO up_specialist (NAME, UPDATED_BY, UPDATED_AT) VALUES 
('QA Engineer', 1, NOW());

-- Специалист ID = 1 (QA Engineer)
INSERT INTO up_skill (NAME, SPECIALIST_ID) VALUES 
('API Testing', 1),
('UI Testing', 1),
('Test Automation', 1),
('Performance Testing', 1);

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
(4, 3, 30, 'Senior level Performance Testing', 'https://example.com/performance-testing-senior');