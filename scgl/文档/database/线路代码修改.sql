--以下是线路代码修改
--2012-11-12
--select * from ps_xl
declare @OldLineCode varchar(50) --旧线路代码
declare @NewLineCode varchar(50) --新线路代码
declare @LineVol varchar(10) --电压等级
set @OldLineCode='201001'
set @NewLineCode='201001'
set @LineVol='0.4'
--更新线路代码
--update set LineCode=replace(LineCode,@OldLineCode,@NewLineCode) 
select * 
from ps_xl where linecode like @OldLineCode+'%' and linevol=@LineVol
--更新杆塔代码
--update set gtCode = LineCode+gth
select * 
from ps_gt where linecode in
(
select linecode from ps_xl where linecode like @NewLineCode+'%' and linevol=@LineVol
)
if(@LineVol='10')
begin
--更新台区所属线路代码
--update set xlcode2=replace(xlcode2,@OldLineCode,@NewLineCode) 
select * 
from ps_tq where xlcode2 in 
(
select linecode from ps_xl where linecode like @OldLineCode+'%' and linevol=@LineVol
)
if(len(@OldLineCode)=6)
begin
--update set xlcode=replace(xlcode,@OldLineCode,@NewLineCode) 
select * 
from ps_tq where xlcode in 
(
select linecode from ps_xl where linecode like @OldLineCode+'%' and linevol=@LineVol
)

end
end