use ebadascgl
go 


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[p_changecldm]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[p_changecldm]
go

--材料代码修改
create PROCEDURE p_changecldm  
@oldcode varchar(20)='',
@newcode varchar(20)=''

as 
begin
if(@oldcode='' or @newcode='')return
if(len(@oldcode)<>5 or len(@newcode)<>5)return 
SET NOCOUNT ON;
--增加变更日志
begin try   
     begin tran --开始事物
update ps_gtsb set sbtype =replace(sbtype,@oldcode,@newcode) where sbtype like @oldcode+'%';
update ps_gtsbclb set bh =replace(bh,@oldcode,@newcode) where bh like @oldcode+'%';
delete from 
ps_sbcs 
where id in(
select id from ps_sbcs where parentid=@newcode and xh in(
select xh from ps_sbcs where parentid=@oldcode
)
);--删除相同xh的记录
update ps_sbcs set bh=left(@newcode,2) where bh=left(@oldcode,2) and len(parentid)>2;
update ps_sbcs set bh =replace(bh,@oldcode,@newcode),parentid =replace(parentid,@oldcode,@newcode) where parentid like @oldcode+'%';

update ps_tqsb set sbtype =replace(sbtype,@oldcode,@newcode) where sbtype like @oldcode+'%';
update ps_tqsbclb set bh =replace(bh,@oldcode,@newcode) where bh like @oldcode+'%';

delete from ps_sbcs where bh=@oldcode;


commit tran    --结束事物
print '材料代码修改成功：'+@oldcode+'-'+@newcode;
end try   
begin catch   
     rollback tran    
end catch 

end

go


exec p_changecldm '34001','41001'
go
exec p_changecldm '87001','12001'
go
exec p_changecldm '26001','12001'
go
exec p_changecldm '30001','48002'
go
exec p_changecldm '44001','06002'
go
exec p_changecldm '24001','96002'
go
exec p_changecldm '37001','03002'
go
exec p_changecldm '37002','03001'
go
exec p_changecldm '37003','03003'
go
exec p_changecldm '70001','07001'
go
exec p_changecldm '43001','04002'
go
exec p_changecldm '27001','93001'
go
exec p_changecldm '25001','14001'
go
exec p_changecldm '35001','28005'
go
exec p_changecldm '23001','96001'
go
exec p_changecldm '31001','39003'
go
exec p_changecldm '33001','41009'
go
