--以下是台区代码修改
--2012-11-12

declare @OldCode varchar(50) --旧代码
declare @NewCode varchar(50) --新代码
set @OldCode='2010010010'
set @NewCode='2010010010'

--更新台区代码
--update set tqCode=@NewCode
select * 
from ps_tq where tqCode=@OldCode

--更新线路代码
--update set LineCode=replace(LineCode,@OldCode,@NewCode) 
select * 
from ps_xl where linecode like @OldCode+'%' and linevol='0.4'
--更新杆塔代码
--update set gtCode = LineCode+gth
select * 
from ps_gt where linecode in
(
select linecode from ps_xl where linecode like @NewCode+'%' and linevol='0.4'
)

--更新变压器
--update set byqcode = replace(LineCode,@OldCode,@NewCode) 
select * 
from ps_tqbyq where  byqcode like @OldCode+'%'
