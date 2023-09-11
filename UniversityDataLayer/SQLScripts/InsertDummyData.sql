
INSERT INTO Course (Name, Description)
VALUES
    ('Mathematics', 'Advanced calculus and algebra'),
    ('Physics', 'Classical mechanics and electromagnetism'),
    ('Computer Science', 'Data structures and algorithms'),
    ('Chemistry', 'Inorganic and organic chemistry'),
    ('Biology', 'Cellular biology and genetics'),
    ('English Literature', 'Study of classic and modern literature'),
    ('History', 'World history and civilizations'),
    ('Art History', 'Exploration of art movements and styles'),
    ('Geography', 'Study of Earths physical and cultural features'),
    ('Psychology', 'Understanding human behavior and mental processes'),
    ('Economics', 'Principles of microeconomics and macroeconomics'),
    ('Sociology', 'Societal structures and dynamics'),
    ('Political Science', 'Government systems and political theories'),
    ('Music', 'Theory, composition, and performance'),
    ('Physical Education', 'Fitness and sports activities'),
    ('Statistics', 'Data analysis and probability'),
    ('Philosophy', 'Critical thinking and philosophical theories'),
    ('Environmental Science', 'Ecology and sustainability'),
    ('Foreign Language', 'Learning a foreign language'),
    ('Engineering', 'Principles of engineering and problem-solving'),
    ('Anthropology', 'Study of human cultures and societies'),
    ('Marketing', 'Principles of marketing and consumer behavior'),
    ('Film Studies', 'Analysis of films and cinematic techniques'),
    ('Communication', 'Effective communication strategies'),
    ('Nursing', 'Fundamentals of nursing care and patient health'),
    ('Theater', 'Acting, directing, and theater production'),
    ('Journalism', 'News reporting and media ethics'),
    ('Astrophysics', 'Study of celestial objects and space exploration'),
    ('Religious Studies', 'Exploration of religious beliefs and practices'),
    ('Law', 'Legal systems and principles of justice'),
    ('Architecture', 'Design and construction of buildings'),
    ('Fashion Design', 'Fashion industry and clothing design'),
    ('Graphic Design', 'Visual communication and graphic arts'),
    ('Dance', 'Techniques and choreography'),
    ('Business Administration', 'Management and organizational behavior'),
    ('Food Science', 'Food production and safety'),
    ('Meteorology', 'Weather patterns and atmospheric phenomena'),
    ('Criminal Justice', 'Law enforcement and criminal behavior'),
    ('Education', 'Pedagogy and teaching methods'),
    ('Health Sciences', 'Study of health-related disciplines'),
    ('Social Work', 'Supporting individuals and communities'),
    ('Digital Media', 'Digital communication and multimedia production'),
    ('Philology', 'Linguistic study and language analysis'),
    ('Archaeology', 'Study of human history through artifacts'),
    ('Chemical Engineering', 'Chemical processes and plant design'),
    ('Mathematical Biology', 'Mathematical modeling of biological systems'),
    ('Urban Planning', 'Design and development of urban areas'),
    ('Linguistics', 'Language structure and linguistic theories'),
    ('Human Resource Management', 'Management of human resources in organizations'),
    ('Public Health', 'Health promotion and disease prevention');

INSERT INTO [dbo].[GROUP] (COURSEID, NAME)
VALUES
    (1, 'Math Group 1'),
    (1, 'Math Group 2'),
    (2, 'Physics Group 1'),
    (3, 'Computer Science Group 1'),
    (4, 'Chemistry Group 1'),
    (4, 'Chemistry Group 2'),
    (5, 'Biology Group 1'),
    (6, 'English Literature Group 1'),
    (7, 'History Group 1'),
    (8, 'Art History Group 1'),
    (9, 'Geography Group 1'),
    (10, 'Psychology Group 1'),
    (11, 'Economics Group 1'),
    (12, 'Sociology Group 1'),
    (13, 'Political Science Group 1'),
    (14, 'Music Group 1'),
    (15, 'Physical Education Group 1'),
    (16, 'Statistics Group 1'),
    (17, 'Philosophy Group 1'),
    (18, 'Environmental Science Group 1'),
    (19, 'Foreign Language Group 1'),
    (20, 'Engineering Group 1'),
    (21, 'Anthropology Group 1'),
    (22, 'Marketing Group 1'),
    (23, 'Film Studies Group 1'),
    (24, 'Communication Group 1'),
    (25, 'Nursing Group 1'),
    (26, 'Theater Group 1'),
    (27, 'Journalism Group 1'),
    (28, 'Astrophysics Group 1'),
    (29, 'Religious Studies Group 1'),
    (30, 'Law Group 1'),
    (31, 'Architecture Group 1'),
    (32, 'Fashion Design Group 1'),
    (33, 'Graphic Design Group 1'),
    (34, 'Dance Group 1'),
    (35, 'Business Administration Group 1'),
    (36, 'Food Science Group 1'),
    (37, 'Meteorology Group 1'),
    (38, 'Criminal Justice Group 1'),
    (39, 'Education Group 1'),
    (40, 'Health Sciences Group 1'),
    (41, 'Social Work Group 1'),
    (42, 'Digital Media Group 1'),
    (43, 'Philology Group 1'),
    (44, 'Archaeology Group 1'),
    (45, 'Chemical Engineering Group 1'),
    (46, 'Mathematical Biology Group 1'),
    (47, 'Urban Planning Group 1'),
    (48, 'Linguistics Group 1'),
    (49, 'Human Resource Management Group 1'),
    (50, 'Public Health Group 1');

INSERT INTO STUDENT (GROUPID, FIRSTNAME, LASTNAME)
VALUES
    (1, 'John', 'Doe'),
    (1, 'Jane', 'Smith'),
    (2, 'Mark', 'Johnson'),
    (2, 'Emily', 'Davis'),
    (3, 'Robert', 'Anderson'),
    (4, 'Sarah', 'Wilson'),
    (1, 'Michael', 'Brown'),
    (2, 'Olivia', 'Taylor'),
    (3, 'William', 'Jones'),
    (4, 'Sophia', 'Miller'),
    (5, 'Alexander', 'Wilson'),
    (6, 'Ava', 'Davis'),
    (7, 'Daniel', 'Thomas'),
    (8, 'Mia', 'Martinez'),
    (9, 'Joseph', 'Taylor'),
    (10, 'Charlotte', 'Anderson'),
    (11, 'Ethan', 'Moore'),
    (12, 'Amelia', 'Wilson'),
    (13, 'David', 'Clark'),
    (14, 'Abigail', 'Rodriguez'),
    (15, 'James', 'Lopez'),
    (16, 'Harper', 'Lee'),
    (17, 'Benjamin', 'Lewis'),
    (18, 'Victoria', 'Harris'),
    (19, 'Michael', 'Garcia'),
    (20, 'Emily', 'Walker'),
    (21, 'Daniel', 'Allen'),
    (22, 'Sofia', 'Young'),
    (23, 'Matthew', 'Scott'),
    (24, 'Avery', 'King'),
    (25, 'Scarlett', 'Murphy'),
    (26, 'Jacob', 'Perez'),
    (27, 'Lily', 'Gonzalez'),
    (28, 'William', 'Wright'),
    (29, 'Grace', 'Turner'),
    (30, 'Daniel', 'Carter'),
    (31, 'Sophia', 'Baker'),
    (32, 'Logan', 'Adams'),
    (33, 'Mia', 'Thomas'),
    (34, 'Alexander', 'Hill'),
    (35, 'Ella', 'Campbell'),
    (36, 'Benjamin', 'Mitchell'),
    (37, 'Chloe', 'Roberts'),
    (38, 'William', 'Clark'),
    (39, 'Evelyn', 'Walker'),
    (40, 'Emily', 'Allen'),
    (41, 'James', 'Wood'),
    (42, 'Charlotte', 'Morris'),
    (43, 'Jacob', 'Baker'),
    (44, 'Sophia', 'Flores');