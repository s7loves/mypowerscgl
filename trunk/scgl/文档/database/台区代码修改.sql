--������̨�������޸�
--2012-11-12

declare @OldCode varchar(50) --�ɴ���
declare @NewCode varchar(50) --�´���
set @OldCode='2010010010'
set @NewCode='2010010010'

--����̨������
--update set tqCode=@NewCode
select * 
from ps_tq where tqCode=@OldCode

--������·����
--update set LineCode=replace(LineCode,@OldCode,@NewCode) 
select * 
from ps_xl where linecode like @OldCode+'%' and linevol='0.4'
--���¸�������
--update set gtCode = LineCode+gth
select * 
from ps_gt where linecode in
(
select linecode from ps_xl where linecode like @NewCode+'%' and linevol='0.4'
)

--���±�ѹ��
--update set byqcode = replace(LineCode,@OldCode,@NewCode) 
select * 
from ps_tqbyq where  byqcode like @OldCode+'%'
