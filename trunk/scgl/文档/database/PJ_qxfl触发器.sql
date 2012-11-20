alter TRIGGER update_PJ_qxfl
   ON  PJ_qxfl
   AFTER INSERT,UPDATE
AS 
BEGIN
	declare @InsertID varchar(50),@qxlb varchar(50),@CreateDate datetime;
	select @InsertID=ID,@qxlb=qxlb,@CreateDate=CreateDate from inserted;
	if(@qxlb='÷ÿ¥Û»±œ›')
		begin
			update PJ_qxfl set xcrq=dateadd(day,3,xcrq) where ID=@InsertID;
		end
	else if(@qxlb='ΩÙº±»±œ›')
		begin
			update PJ_qxfl set xcrq=dateadd(day,1,xcrq) where ID=@InsertID;
		end
END
GO
