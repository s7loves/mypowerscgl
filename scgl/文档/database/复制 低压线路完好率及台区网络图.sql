USE [EbadaScgl]
insert [LP_Temple] select * from [EbadaScgltemp]..LP_Temple where [EbadaScgltemp]..LP_Temple.CellName='20低压线路完好率及台区网络图'
or ParentID in (select lpid from [EbadaScgltemp]..LP_Temple where [EbadaScgltemp]..LP_Temple.CellName='20低压线路完好率及台区网络图')