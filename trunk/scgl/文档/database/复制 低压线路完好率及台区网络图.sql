USE [EbadaScgl]
insert [LP_Temple] select * from [EbadaScgltemp]..LP_Temple where [EbadaScgltemp]..LP_Temple.CellName='20��ѹ��·����ʼ�̨������ͼ'
or ParentID in (select lpid from [EbadaScgltemp]..LP_Temple where [EbadaScgltemp]..LP_Temple.CellName='20��ѹ��·����ʼ�̨������ͼ')