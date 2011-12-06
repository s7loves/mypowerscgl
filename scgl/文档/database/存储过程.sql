USE [EbadaScgl]
GO
if (exists (select * from sys.objects where name = 'proc_byq_count'))
    drop proc proc_byq_count
    GO
/****** Object:  StoredProcedure [dbo].[proc_byq_count]  变压器数量  Script Date: 12/01/2011 20:35:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_byq_count]
@orgCode nvarchar(50),
@lineCode nvarchar(50),
@selectType int,
@bytCount int out

as
if @selectType = 1
begin
  SELECT @bytCount=COUNT(*)
  FROM [EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.OrgCode = @orgCode;
end
if @selectType = 2
begin
 SELECT @bytCount=COUNT(*)
  FROM [EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and (PS_xl.LineCode = @lineCode or PS_xl.ParentID = @lineCode);
end
if @selectType = 0
begin
	 SELECT @bytCount=COUNT(*)
	  FROM [EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
	  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode;
end
GO


USE [EbadaScgl]
GO
if (exists (select * from sys.objects where name = 'proc_byqCapcity_sum'))
    drop proc proc_byqCapcity_sum
   GO
/****** Object:  StoredProcedure [dbo].[proc_byqCapcity_sum]    Script Date: 12/03/2011 16:09:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[proc_byqCapcity_sum]
@orgCode nvarchar(50),
@lineCode nvarchar(50),
@owner nvarchar(50),
@selectType int,
@bytCapcitySum decimal out

as
if @selectType = 1
 if @owner  <> ''
 begin
  SELECT @bytCapcitySum=SUM(PS_tqbyq.byqCapcity)
  FROM [EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.OrgCode = 

@orgCode and PS_tq.Owner = @owner;
end
ELSE  begin
SELECT @bytCapcitySum=SUM(PS_tqbyq.byqCapcity)
  FROM [EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.OrgCode = 

@orgCode ;
end
if @selectType = 2
if @owner  <> ''
begin
 SELECT @bytCapcitySum=SUM(PS_tqbyq.byqCapcity)
  FROM [EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and (PS_xl.LineCode = 

@lineCode or PS_xl.ParentID = @lineCode) and PS_tq.Owner = @owner;
end
else
begin
 SELECT @bytCapcitySum=SUM(PS_tqbyq.byqCapcity)
  FROM [EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and (PS_xl.LineCode = 

@lineCode or PS_xl.ParentID = @lineCode);
end
if @selectType = 0
if @owner  <> ''
begin
 SELECT @bytCapcitySum=SUM(PS_tqbyq.byqCapcity)
  FROM [EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_tq.Owner = @owner;
end 
else
begin
 SELECT @bytCapcitySum=SUM(PS_tqbyq.byqCapcity)
  FROM [EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode;
  end

GO

GO

USE [EbadaScgl]
GO
if (exists (select * from sys.objects where name = 'proc_xl_maxgdbj'))
    drop proc proc_xl_maxgdbj
    GO
/****** Object:  StoredProcedure [dbo].[proc_byq_count] 最大供电半径   Script Date: 12/01/2011 20:35:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_xl_maxgdbj]
@orgCode nvarchar(50),
@lineCode nvarchar(50),
@selectType int,
@xlMaxgdbj int out

as
if @selectType = 1
begin
  SELECT @xlMaxgdbj=MAX(gdbj)
  FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_xl.OrgCode = mOrg.OrgCode and PS_xl.OrgCode = @orgCode;
end
if @selectType = 2
begin
  SELECT @xlMaxgdbj=MAX(gdbj)
  FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_xl.OrgCode = mOrg.OrgCode and (PS_xl.LineCode = @lineCode or PS_xl.ParentID = @lineCode);
end
if @selectType = 0
begin
  SELECT @xlMaxgdbj=MAX(gdbj)
  FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_xl.OrgCode = mOrg.OrgCode;
end
GO

USE [EbadaScgl]
GO
if (exists (select * from sys.objects where name = 'proc_xl_length'))
    drop proc proc_xl_length
    GO
/****** Object:  StoredProcedure [dbo].[proc_byq_count]  线路长度  Script Date: 12/01/2011 20:35:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_xl_length]
@orgCode nvarchar(50),
@lineCode nvarchar(50),
@selectType int,
@lineVol nvarchar(50),
@lineType nvarchar(150),
@xlLength int out

as
if @selectType = 1
if @lineType  <> ''
begin
  SELECT @xlLength=SUM(TotalLength)
  FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where  PS_xl.OrgCode = mOrg.OrgCode and PS_xl.OrgCode = @orgCode and PS_xl.LineVol = @lineVol and PS_xl.LineType = @lineType;
end
else
begin
  SELECT @xlLength=SUM(TotalLength)
  FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where  PS_xl.OrgCode = mOrg.OrgCode and PS_xl.OrgCode = @orgCode and PS_xl.LineVol = @lineVol;
  end
if @selectType = 2
if @lineType  <> ''
begin
  SELECT @xlLength=SUM(TotalLength)
  FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where  PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineVol = @lineVol and (PS_xl.LineCode = 
@lineCode or PS_xl.ParentID = @lineCode) and PS_xl.LineType = @lineType;
end
else 
begin 
  SELECT @xlLength=SUM(TotalLength)
  FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where  PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineVol = @lineVol and (PS_xl.LineCode = 
@lineCode or PS_xl.ParentID = @lineCode);
end
if @selectType = 0
if @lineType  <> ''
begin
 SELECT @xlLength=SUM(TotalLength)
 FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
 where PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineVol = @lineVol and PS_xl.LineType = @lineType;
end
else
begin
 SELECT @xlLength=SUM(TotalLength)
 FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
 where PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineVol = @lineVol;
 end
GO

USE [EbadaScgl]
GO
if (exists (select * from sys.objects where name = 'proc_xl_count'))
    drop proc proc_xl_count
    GO
/****** Object:  StoredProcedure [dbo].[proc_byq_count]  线路分支数  Script Date: 12/01/2011 20:35:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_xl_count]
@orgCode nvarchar(50),
@lineCode nvarchar(50),
@selectType int,
@lineVol nvarchar(50),
@lineType nvarchar(150),
@xlCount int out

as
if @selectType = 1
if @lineType  <> ''
begin
  SELECT @xlCount=count(*)
  FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where  PS_xl.OrgCode = mOrg.OrgCode and PS_xl.OrgCode = @orgCode and PS_xl.LineVol = @lineVol and PS_xl.LineType = @lineType;
end
else
begin
  SELECT @xlCount=count(*)
  FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where  PS_xl.OrgCode = mOrg.OrgCode and PS_xl.OrgCode = @orgCode and PS_xl.LineVol = @lineVol;
  end
if @selectType = 2
if @lineType  <> ''
begin
  SELECT @xlCount=count(*)
  FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where  PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineVol = @lineVol and (PS_xl.LineCode = 
@lineCode or PS_xl.ParentID = @lineCode) and PS_xl.LineType = @lineType;
end
else
begin
  SELECT @xlCount=count(*)
  FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where  PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineVol = @lineVol and (PS_xl.LineCode = 
@lineCode or PS_xl.ParentID = @lineCode);
end
if @selectType = 0
if @lineType  <> ''
begin
 SELECT @xlCount=count(*)
 FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
 where PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineVol = @lineVol and PS_xl.LineType = @lineType;
end
else
begin
 SELECT @xlCount=count(*)
 FROM [EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
 where PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineVol = @lineVol;
 end
GO

USE [EbadaScgl]
GO
if (exists (select * from sys.objects where name = 'proc_gt_count'))
    drop proc proc_gt_count
    GO
/****** Object:  StoredProcedure [dbo].[proc_xl_length] 杆塔数   Script Date: 12/02/2011 09:41:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[proc_gt_count]
@orgCode nvarchar(50),
@lineCode nvarchar(50),
@selectType int,
@lineVol nvarchar(50),
@gtcount int out

as
if @selectType = 1
begin
  SELECT @gtcount=count(*)
  FROM [EbadaScgl].[dbo].[PS_gt],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.OrgCode = @orgCode and PS_xl.LineVol = @lineVol;
end
if @selectType = 2
begin
  SELECT @gtcount=count(*)
   FROM [EbadaScgl].[dbo].[PS_gt],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineVol = @lineVol and (PS_xl.LineCode = 
@lineCode or PS_xl.ParentID = @lineCode);
end
if @selectType = 0
begin
 SELECT @gtcount=count(*)
  FROM [EbadaScgl].[dbo].[PS_gt],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.LineVol = @lineVol;
end

GO

USE [EbadaScgl]
GO
if (exists (select * from sys.objects where name = 'proc_tq_count'))
    drop proc proc_tq_count
    GO
/****** Object:  StoredProcedure [dbo].[proc_byq_count]  变台数量  Script Date: 12/01/2011 20:35:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_tq_count]
@orgCode nvarchar(50),
@lineCode nvarchar(50),
@owner nvarchar(50),
@selectType int,
@tqCount int out

as
if @selectType = 1
if @owner  <> ''
begin
  SELECT @tqCount=COUNT(*)
  FROM [EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.OrgCode = 
@orgCode and PS_tq.Owner = @owner;
end
else
begin
  SELECT @tqCount=COUNT(*)
  FROM [EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.OrgCode = 
@orgCode;
end
if @selectType = 2
if @owner  <> ''
begin
 SELECT @tqCount=COUNT(*)
    FROM [EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and (PS_xl.LineCode = 
@lineCode or PS_xl.ParentID = @lineCode) and PS_tq.Owner = @owner;
end
else
begin
 SELECT @tqCount=COUNT(*)
    FROM [EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and (PS_xl.LineCode = 
@lineCode or PS_xl.ParentID = @lineCode);
end
if @selectType = 0
if @owner  <> ''
begin
	 SELECT @tqCount=COUNT(*)
	    FROM [EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
	  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and 
PS_tq.Owner = @owner;
end
else
begin
	 SELECT @tqCount=COUNT(*)
	    FROM [EbadaScgl].[dbo].[PS_tq],[EbadaScgl].[dbo].[PS_tqbyq],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
	  where PS_tqbyq.tqID = PS_tq.tqID and PS_tq.xlCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode;
end
GO

USE [EbadaScgl]
GO
if (exists (select * from sys.objects where name = 'proc_gtsb'))
    drop proc proc_gtsb
    GO
/****** Object:  StoredProcedure [dbo].[proc_byqCapcity_sum]  杆塔设备  Script Date: 12/04/2011 15:35:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create proc [dbo].[proc_gtsb]
@orgCode nvarchar(50),
@lineCode nvarchar(50),
@selectType int
as 
if @selectType = 1
begin
select DISTINCT sbname from [EbadaScgl].[dbo].PS_gtsb, [EbadaScgl].[dbo].[PS_gt],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.OrgCode = @orgCode  order by ps_gtsb.sbname;
end
if @selectType =2
begin
select DISTINCT sbname from [EbadaScgl].[dbo].PS_gtsb, [EbadaScgl].[dbo].[PS_gt],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and (PS_xl.LineCode = 
@lineCode or PS_xl.ParentID = @lineCode) order by ps_gtsb.sbname;
end
if @selectType = 0
begin
select DISTINCT sbname from [EbadaScgl].[dbo].PS_gtsb, [EbadaScgl].[dbo].[PS_gt],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode order by ps_gtsb.sbname;
end

GO


USE [EbadaScgl]
GO
if (exists (select * from sys.objects where name = 'proc_gtsb_count'))
    drop proc proc_gtsb_count
    GO
/****** Object:  StoredProcedure [dbo].[proc_byqCapcity_sum]  杆塔设备数量  Script Date: 12/04/2011 15:35:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create proc [dbo].[proc_gtsb_count]
@orgCode nvarchar(50),
@lineCode nvarchar(50),
@selectType int,
@sbName nvarchar(500),
@gtsbCount int out
as 
if @selectType = 1
begin
select @gtsbCount=COUNT(*) from [EbadaScgl].[dbo].PS_gtsb, [EbadaScgl].[dbo].[PS_gt],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_xl.OrgCode = @orgCode and PS_gtsb.sbName = @sbName;
end
if @selectType =2
begin
select @gtsbCount=COUNT(*) from [EbadaScgl].[dbo].PS_gtsb, [EbadaScgl].[dbo].[PS_gt],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and (PS_xl.LineCode = 
@lineCode or PS_xl.ParentID = @lineCode) and PS_gtsb.sbName = @sbName;
end
if @selectType = 0
begin
select @gtsbCount=COUNT(*) from [EbadaScgl].[dbo].PS_gtsb, [EbadaScgl].[dbo].[PS_gt],[EbadaScgl].[dbo].[PS_xl],[EbadaScgl].[dbo].[mOrg]
where PS_gtsb.gtID = PS_gt.gtID and PS_gt.LineCode = PS_xl.LineCode and PS_xl.OrgCode = mOrg.OrgCode and PS_gtsb.sbName = @sbName;
end

GO