CREATE VIEW dbo.ArticleGroup
AS
SELECT  Id,
		Name,
		CAST(ISNULL(Valor1,0) AS int) AS Code
FROM	dbo.ParameterDetail
WHERE  ParameterId='main.ArticleGroup'