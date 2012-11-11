use ebadascgl;
alter table PJ_qxfl add
[xlid] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,--线路
[byqid] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,--变压器
[tqid] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,--台区
[kgid] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,--开关
[xlname] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
[byqname] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
[tqname] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
[kgname] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
[rid] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL    --其它
