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
