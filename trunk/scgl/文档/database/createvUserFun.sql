USE [ebadascgl]
GO
/****** 对象:  View [dbo].[vUserFun]    脚本日期: 07/25/2012 18:03:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vUserFun]
AS
SELECT DISTINCT 
                      TOP (100) PERCENT dbo.mUser.UserID, dbo.mModule.ModuTypes, dbo.mModulFun.FunCode, dbo.mModulFun.FunName, dbo.mUser.UserCode, 
                      dbo.mUser.UserName, dbo.mUser.LoginID
FROM         dbo.mModule INNER JOIN
                      dbo.mModulFun ON dbo.mModule.Modu_ID = dbo.mModulFun.Modu_ID INNER JOIN
                      dbo.rRoleFun ON dbo.mModulFun.FunID = dbo.rRoleFun.FunID INNER JOIN
                      dbo.mRole ON dbo.rRoleFun.RoleID = dbo.mRole.RoleID INNER JOIN
                      dbo.rRoleModul ON dbo.mModule.Modu_ID = dbo.rRoleModul.Modu_ID AND dbo.mRole.RoleID = dbo.rRoleModul.RoleID INNER JOIN
                      dbo.rUserRole ON dbo.mRole.RoleID = dbo.rUserRole.RoleID INNER JOIN
                      dbo.mUser ON dbo.rUserRole.UserID = dbo.mUser.UserID
ORDER BY dbo.mUser.UserID
GO