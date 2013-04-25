USE [ebadascgl]
GO
/****** ����:  View [dbo].[v_jhsumscore]    �ű�����: 04/25/2013 16:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_jhsumscore]
AS
SELECT     a.��λ����, a.���� AS xm, a.y, a.ym, a.num, b.num AS ynum
FROM         (SELECT     ��λ����, ����, SUBSTRING(ParentID, 1, 4) AS y, SUBSTRING(ParentID, 1, 6) AS ym, SUM(CASE WHEN (���˽�� = 'A') 
                                              THEN 4 WHEN ���˽�� = ' B' THEN 3 WHEN ���˽�� = ' C' THEN 2 WHEN ���˽�� = ' D' THEN 1 ELSE 4 END) AS num
                       FROM          dbo.JH_weekmant
                       GROUP BY ��λ����, ����, SUBSTRING(ParentID, 1, 4), SUBSTRING(ParentID, 1, 6)) AS a INNER JOIN
                          (SELECT     ��λ����, ����, SUBSTRING(ParentID, 1, 4) AS y, SUM(CASE WHEN (���˽�� = 'A') 
                                                   THEN 4 WHEN ���˽�� = ' B' THEN 3 WHEN ���˽�� = ' C' THEN 2 WHEN ���˽�� = ' D' THEN 1 ELSE 4 END) AS num
                            FROM          dbo.JH_weekmant AS JH_weekmant_1
                            GROUP BY ��λ����, ����, SUBSTRING(ParentID, 1, 4)) AS b ON a.��λ���� = b.��λ���� AND a.���� = b.���� AND a.y = b.y

GO
