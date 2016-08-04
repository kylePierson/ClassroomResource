DROP TABLE Question;
DROP TABLE TrueFalse;
DROP TABLE MultipleChoice;
DROP TABLE ShortAnswer;
DROP TABLE Quiz;

CREATE TABLE Instructor(
	user_name varchar(32) NOT NULL,
	password varchar(32) NOT NULL,
	CONSTRAINT pk_Instructor_user_name PRIMARY KEY (user_name)
);

CREATE TABLE Question (
	question_id integer identity NOT NULL,
	quiz_id integer NOT NULL,
	question_text varchar(50) NOT NULL,
	CONSTRAINT pk_Question_question_id PRIMARY KEY (question_id)
);

CREATE TABLE TrueFalse (
	question_id integer NOT NULL,
	correct_answer bit NOT NULL,
	CONSTRAINT pk_TrueFalse_question_id_correct_answer PRIMARY KEY (question_id, correct_answer)
);

CREATE TABLE MultipleChoice (
	question_id integer NOT NULL,
	correct_answer bit NOT NULL,
	answer_text varchar NOT NULL,
	CONSTRAINT pk_MultipleChoice_question_id_answer_text PRIMARY KEY (question_id, answer_text)
);

CREATE TABLE ShortAnswer (
	question_id integer NOT NULL,
	case_sensitive bit NOT NULL,
	answer_text varchar NOT NULL,
	CONSTRAINT pk_ShortAnswer_question_id_answer_text PRIMARY KEY (question_id, answer_text)
);

CREATE TABLE Quiz (
	quiz_id integer identity NOT NULL,
	instructor varchar(32) NOT NULL,
	quiz_title varchar NOT NULL,
	CONSTRAINT pk_Question_quiz_id PRIMARY KEY (quiz_id)
);

ALTER TABLE ShortAnswer ADD FOREIGN KEY (question_id) REFERENCES Question(question_id);

ALTER TABLE MultipleChoice ADD FOREIGN KEY (question_id) REFERENCES Question(question_id);

ALTER TABLE TrueFalse ADD FOREIGN KEY (question_id) REFERENCES Question(question_id);

ALTER TABLE Question ADD FOREIGN KEY (quiz_id) REFERENCES Quiz(quiz_id);

ALTER TABLE Quiz ADD FOREIGN KEY (instructor) REFERENCES Instructor(user_name);