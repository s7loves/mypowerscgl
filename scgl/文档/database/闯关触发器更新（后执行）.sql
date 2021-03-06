
/****** 对象:  Trigger [dbo].[Trigger_Prize_UpdateNum]    脚本日期: 11/19/2013 20:33:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER  [dbo].[Trigger_Prize_UpdateNum]
   ON   [dbo].[E_UserPrizeRecord]
   AFTER INSERT,DELETE
AS 
BEGIN

	DECLARE @Num int,@PrizeID nvarchar(50),@UserID nvarchar(50),@BuyNum int,@Prize int, @ID nvarchar(50),@PrizeName nvarchar(50)
	if (exists (select  1 from inserted))
	begin
    --重新计算奖品的剩余数量
    set @UserID=(select  UserID from inserted );
	set @PrizeID=(select PrizeID from inserted );
    set @BuyNum=(select PrizeNum from inserted );
	set @Num=(select sum(PrizeNum) from dbo.E_UserPrizeRecord  where PrizeID=@PrizeID);
	update dbo.E_Prize set CurrentNum=(AllNum-@Num) where ID=@PrizeID;
    --在个人的分数记录中减少此次奖品的分数
    set @Prize=(select top 1 Price from dbo.E_Prize   where ID=@PrizeID);
    set @PrizeName=(select top 1 PrizeName from dbo.E_Prize   where ID=@PrizeID);
    set @PrizeName='奖品:'+@PrizeName+'    数量:'+convert( nvarchar(50),@BuyNum);
    set @ID=(select replace(replace(replace(replace(CONVERT(varchar, getdate(), 121 ),'-',''),' ',''),':',''),'.','') );
    insert into dbo.E_UserScoreRecord(ID,UserID,Flag,Score,CreateTime,Reason,ByScol4,ByScol5) values(@ID,@UserID,'-1',(@Prize*@BuyNum),getdate(),'兑换奖品',@PrizeName,@PrizeID);
	end
END



/****** 对象:  Trigger [dbo].[Trigger_Prop_UpdateNum]    脚本日期: 11/19/2013 22:37:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER  [dbo].[Trigger_Prop_UpdateNum] 
   ON  [dbo].[E_UserPropRecord]
   AFTER  INSERT,DELETE
AS 
BEGIN
	DECLARE @PropID nvarchar(50),@UserID nvarchar(50),@BuyNum int,@Price int,@AllNum int,@UsedNum int, @ID nvarchar(50),@PropName nvarchar(50),@Flag nvarchar(50)
	if (exists (select  1 from inserted))
	begin
      set @Flag=(select  Flag from inserted )
      set @UserID=(select  UserID from inserted );
	  set @PropID=(select  PropID from inserted );
	  set @BuyNum=(select  Num from inserted );
      --如果是购买道具
      if(@Flag='+1')
        begin
			--计算道具的花费
			
			set @Price=(select top 1 Price from  dbo.E_Prop  where ID=@PropID);
			set @PropName=(select top 1 PropName from  dbo.E_Prop  where ID=@PropID);
			--在个人的分数记录中减少此次道具的分数
			set @PropName='道具:'+@PropName+'    数量:'+convert( nvarchar(50),@BuyNum);
			set @ID=(select replace(replace(replace(replace(CONVERT(varchar, getdate(), 121 ),'-',''),' ',''),':',''),'.','') );
			insert into dbo.E_UserScoreRecord(ID,UserID,Flag,Score,CreateTime,Reason,ByScol4,ByScol5) values(@ID,@UserID,'-1',(@Price*@BuyNum),getdate(),'购买道具',@PropName,@PropID);
	    end
        set @AllNum=(select sum(Num) from dbo.E_UserPropRecord where Flag='+1' and UserID=@UserID and PropID=@PropID);
		set @UsedNum=(select sum(Num) from dbo.E_UserPropRecord where Flag='-1' and UserID=@UserID and PropID=@PropID);
        if(@AllNum is NUll)
         set @AllNum=0;
        if(@UsedNum is NUll)
         set @UsedNum=0;
       if(exists (select top 1 ID from dbo.E_UserProp where UserID=@UserID and PropID=@PropID))
        begin
         set @ID=(select top 1 ID from dbo.E_UserProp where UserID=@UserID and PropID=@PropID);
  	     update dbo.E_UserProp set Num=@AllNum,UsedNum=@UsedNum,CanUseNum=(@AllNum-@UsedNum),UpdateTime=getdate() where UserID=@UserID and PropID=@PropID;
        end
		else
		 insert into dbo.E_UserProp(ID,UserID,PropID,Num,UsedNum,CanUseNum,UpdateTime) values(@ID,@UserID,@PropID,@AllNum,@UsedNum,(@AllNum-@UsedNum),getdate());
    end 
END



/****** 对象:  Trigger [dbo].[Trigger_UserScore_UpdateScore]    脚本日期: 11/19/2013 20:34:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER  [dbo].[Trigger_UserScore_UpdateScore] 
   ON  [dbo].[E_UserScoreRecord]
   AFTER  INSERT
AS 
BEGIN
	DECLARE @UserID nvarchar(50),@AllScore int ,@xhScore int, @ID nvarchar(50)
	if (exists (select 1 from inserted))
	 begin
         set @UserID=(select  UserID from inserted );
         set @ID=(select replace(replace(replace(replace(CONVERT(varchar, getdate(), 121 ),'-',''),' ',''),':',''),'.','') );
    	 set @AllScore=(select sum(Score) from dbo.E_UserScoreRecord where Flag='+1' and UserID=@UserID);
		 set @xhScore=(select sum(Score) from dbo.E_UserScoreRecord where Flag='-1' and UserID=@UserID);
        if(@AllScore is NUll)
         set @AllScore=0;
        if(@xhScore is NUll)
        set @xhScore=0;
		if(exists (select top 1 ID from dbo.E_UserScore where UserID=@UserID))
        begin
         set @ID=(select top 1 ID from dbo.E_UserScore where UserID=@UserID);
  	     update dbo.E_UserScore set AllScore=@AllScore,CurrtenScore=(@AllScore-@xhScore),UpdateTime=getdate() where UserID=@UserID;
        end
		else
		 insert into dbo.E_UserScore(ID,UserID,AllScore,CurrtenScore,UpdateTime) values(@ID,@UserID,@AllScore,(@AllScore-@xhScore),getdate());
	  end
END
