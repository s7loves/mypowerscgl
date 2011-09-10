USE [EbadaScgl]
alter table [PJ_22] add
	[tdxlgt] [nvarchar](50) null default '',
	[tdcz1xz] [bit] NULL,
	[tdcz1cz] [bit] NULL,
	[tdcz2xz] [bit] NULL,
	[tdcz2cz] [bit] NULL,
	[tdcz3xz] [bit] NULL,
	[tdcz3cz] [bit] NULL,
	[tdcz4xz] [bit] NULL,
	[tdcz4cz] [bit] NULL,
	[tdcz5xz] [bit] NULL,
	[tdcz5cz] [bit] NULL,
	[tdcz6xz] [bit] NULL,
	[tdcz6cz] [bit] NULL,
	[tdcz7xz] [bit] NULL,
	[tdcz7cz] [bit] NULL,
	[tdcz8xz] [bit] NULL,
	[tdcz8cz] [bit] NULL,
	[tdczjxname1] [nvarchar](50) null default '',
	[tdczjxname2] [nvarchar](50) null default '',
	[tdczjxname3] [nvarchar](50) null default '',
	[sdcz1xz] [bit] NULL,
	[sdcz1cz] [bit] NULL,
	[sdcz2xz] [bit] NULL,
	[sdcz2cz] [bit] NULL,
	[sdcz3xz] [bit] NULL,
	[sdcz3cz] [bit] NULL,
	[sdcz4xz] [bit] NULL,
	[sdcz4cz] [bit] NULL,
	[sdcz5xz] [bit] NULL,
	[sdcz5cz] [bit] NULL,
	[sdcz6xz] [bit] NULL,
	[sdcz6cz] [bit] NULL,
	[sdcz7xz] [bit] NULL,
	[sdcz7cz] [bit] NULL,
	[sdcz8xz] [bit] NULL,
	[sdcz8cz] [bit] NULL,
	[sdczjxname1] [nvarchar](50) null default '',
	[sdczjxname2] [nvarchar](50) null default ''
go


execute sp_addextendedproperty 'MS_Description', 'ͣ����·�˺�' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdxlgt'
GO
execute sp_addextendedproperty 'MS_Description', '������ѹ����ѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz1xz'
GO
execute sp_addextendedproperty 'MS_Description', '������ѹ���ز���' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz1cz'
GO
execute sp_addextendedproperty 'MS_Description', '������ѹ��բ�����գ�ѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz2xz'
GO
execute sp_addextendedproperty 'MS_Description', '������ѹ��բ�����գ�����' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz2cz'
GO
execute sp_addextendedproperty 'MS_Description', '������ѹ���أ�����ʽ�۶�����ѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz3xz'
GO
execute sp_addextendedproperty 'MS_Description', '������ѹ���أ�����ʽ�۶���������' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz3cz'
GO
execute sp_addextendedproperty 'MS_Description', '�ڱ�ѹ����ѹ�׹ܶ��Ӵ���������ȷ�޵�ѹѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz4xz'
GO
execute sp_addextendedproperty 'MS_Description', '�ڱ�ѹ����ѹ�׹ܶ��Ӵ���������ȷ�޵�ѹ����' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz4cz'
GO
execute sp_addextendedproperty 'MS_Description', '�ڱ�ѹ����ѹ�׹ܶ��Ӵ��ҵ�#��һ��ѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz5xz'
GO
execute sp_addextendedproperty 'MS_Description', '�ڱ�ѹ����ѹ�׹ܶ��Ӵ��ҵ�#��һ�����' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz5cz'
GO
execute sp_addextendedproperty 'MS_Description', '�ڵ�ѹ����������ȷ�޵�ѹѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz6xz'
GO
execute sp_addextendedproperty 'MS_Description', '�ڵ�ѹ����������ȷ�޵�ѹ����' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz6cz'
GO
execute sp_addextendedproperty 'MS_Description', '�ڵ�ѹ���#����һ��ѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz7xz'
GO
execute sp_addextendedproperty 'MS_Description', '�ڵ�ѹ���#����һ�����' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz7cz'
GO
execute sp_addextendedproperty 'MS_Description', '�ڹ����ص��#С����ѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz8xz'
GO
execute sp_addextendedproperty 'MS_Description', '�ڹ����ص��#С���߲���' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdcz8cz'
GO
execute sp_addextendedproperty 'MS_Description', '�ڱ�ѹ����ѹ�׹ܶ��Ӵ��ҵ�#������' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdczjxname1'
GO
execute sp_addextendedproperty 'MS_Description', '�ڵ�ѹ���#��������' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdczjxname2'
GO
execute sp_addextendedproperty 'MS_Description', '�ڹ����ص��#С��������' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','tdczjxname3'
GO
execute sp_addextendedproperty 'MS_Description', '�����λ�Ƿ���ȷѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz1xz'
GO
execute sp_addextendedproperty 'MS_Description', '�����λ�Ƿ���ȷ����' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz1cz'
GO
execute sp_addextendedproperty 'MS_Description', '��������ص�С����ѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz2xz'
GO
execute sp_addextendedproperty 'MS_Description', '��������ص�С���߲���' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz2cz'
GO
execute sp_addextendedproperty 'MS_Description', '�����ѹ��ѡ��#��һ��ѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz3xz'
GO
execute sp_addextendedproperty 'MS_Description', '�����ѹ��ѡ��#��һ�����' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz3cz'
GO
execute sp_addextendedproperty 'MS_Description', '�����ѹ����ѹ�׹ܶ��Ӵ�#����һ��ѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz4xz'
GO
execute sp_addextendedproperty 'MS_Description', '�����ѹ����ѹ�׹ܶ��Ӵ�#����һ�����' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz4cz'
GO
execute sp_addextendedproperty 'MS_Description', '���ϸ�ѹ���أ�����ʽ�۶�����ѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz5xz'
GO
execute sp_addextendedproperty 'MS_Description', '���ϸ�ѹ���أ�����ʽ�۶���������' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz5cz'
GO
execute sp_addextendedproperty 'MS_Description', '���ϵ�ѹ����ѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz6xz'
GO
execute sp_addextendedproperty 'MS_Description', '���ϵ�ѹ���ز���' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz6cz'
GO
execute sp_addextendedproperty 'MS_Description', '���ϵ�ѹ��բ�����գ�ѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz7xz'
GO
execute sp_addextendedproperty 'MS_Description', '���ϵ�ѹ��բ�����գ�����' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz7cz'
GO
execute sp_addextendedproperty 'MS_Description', '����û��Ƿ��е�ѡ��' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz8xz'
GO
execute sp_addextendedproperty 'MS_Description', '����û��Ƿ��е����' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdcz8cz'
GO
execute sp_addextendedproperty 'MS_Description', '�����ѹ��ѡ��#������' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdczjxname1'
GO
execute sp_addextendedproperty 'MS_Description', '�����ѹ����ѹ�׹ܶ��Ӵ�#��������' , 'user','dbo', 'TABLE','PJ_22', 'COLUMN','sdczjxname2'
GO
