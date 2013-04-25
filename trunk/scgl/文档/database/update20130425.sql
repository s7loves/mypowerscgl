USE [ebadascgl]
GO
/****** 对象:  View [dbo].[v_jhsumscore]    脚本日期: 04/25/2013 16:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_jhsumscore]
AS
SELECT     a.单位代码, a.姓名 AS xm, a.y, a.ym, a.num, b.num AS ynum
FROM         (SELECT     单位代码, 姓名, SUBSTRING(ParentID, 1, 4) AS y, SUBSTRING(ParentID, 1, 6) AS ym, SUM(CASE WHEN (考核结果 = 'A') 
                                              THEN 4 WHEN 考核结果 = ' B' THEN 3 WHEN 考核结果 = ' C' THEN 2 WHEN 考核结果 = ' D' THEN 1 ELSE 4 END) AS num
                       FROM          dbo.JH_weekmant
                       GROUP BY 单位代码, 姓名, SUBSTRING(ParentID, 1, 4), SUBSTRING(ParentID, 1, 6)) AS a INNER JOIN
                          (SELECT     单位代码, 姓名, SUBSTRING(ParentID, 1, 4) AS y, SUM(CASE WHEN (考核结果 = 'A') 
                                                   THEN 4 WHEN 考核结果 = ' B' THEN 3 WHEN 考核结果 = ' C' THEN 2 WHEN 考核结果 = ' D' THEN 1 ELSE 4 END) AS num
                            FROM          dbo.JH_weekmant AS JH_weekmant_1
                            GROUP BY 单位代码, 姓名, SUBSTRING(ParentID, 1, 4)) AS b ON a.单位代码 = b.单位代码 AND a.姓名 = b.姓名 AND a.y = b.y

GO
