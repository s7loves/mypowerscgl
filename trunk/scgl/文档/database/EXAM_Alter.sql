use ebadascgl

ALTER TABLE dbo.E_QuestionBank
ALTER COLUMN ScoreNum float;


ALTER TABLE dbo.E_ExamSetting
ALTER COLUMN SelectScore float;
ALTER TABLE dbo.E_ExamSetting
ALTER COLUMN JudgeScore float;
ALTER TABLE dbo.E_ExamSetting
ALTER COLUMN MuSelectScore float;
ALTER TABLE dbo.E_ExamSetting
ALTER COLUMN PassScore float;
ALTER TABLE dbo.E_ExamSetting
ALTER COLUMN TotalScore float;


ALTER TABLE dbo.E_ExamResult
ALTER COLUMN Score float;

ALTER TABLE dbo.E_ExamAnswerResult
ALTER COLUMN scoure float;


ALTER TABLE dbo.E_ExaminationPaper
ALTER COLUMN TotalScore float;


