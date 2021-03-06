/*
   2016年2月2日15:28:09
   用户: sa
   服务器: .
   数据库: SuperWebSite
   应用程序: 
*/

/* 为了防止任何可能出现的数据丢失问题，您应该先仔细检查此脚本，然后再在数据库设计器的上下文之外运行此脚本。*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.MemberInfo
	(
	ID int NOT NULL IDENTITY (1, 1),
	MemberName nvarchar(60) NULL,
	MPassword nvarchar(100) NULL,
	Mgender nvarchar(2) NULL,
	MEmail nvarchar(50) NULL,
	MRegisterTime datetime NULL,
	MStatus int NULL,
	CheckUserID int NULL,
	CheckUserName nvarchar(50) NULL,
	CheckTime datetime NULL,
	HeadImg nvarchar(500) NULL,
	ContactMsg nvarchar(500) NULL,
	MGrade int NULL,
	LastLoginTime datetime NULL,
	LastLoginIP nvarchar(50) NULL,
	Paperworkpic nvarchar(100) NULL,
	PaperworkImg nvarchar(100) NULL,
	TruethName nvarchar(20) NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'自增主键'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'ID'
GO
DECLARE @v sql_variant 
SET @v = N'会员名'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'MemberName'
GO
DECLARE @v sql_variant 
SET @v = N'登录密码'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'MPassword'
GO
DECLARE @v sql_variant 
SET @v = N'性别'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'Mgender'
GO
DECLARE @v sql_variant 
SET @v = N'邮箱'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'MEmail'
GO
DECLARE @v sql_variant 
SET @v = N'注册时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'MRegisterTime'
GO
DECLARE @v sql_variant 
SET @v = N'会员状态（100 等待审核 200 审核通过 300 账户停用）'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'MStatus'
GO
DECLARE @v sql_variant 
SET @v = N'审核人ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'CheckUserID'
GO
DECLARE @v sql_variant 
SET @v = N'审核人名字'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'CheckUserName'
GO
DECLARE @v sql_variant 
SET @v = N'审核时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'CheckTime'
GO
DECLARE @v sql_variant 
SET @v = N'头像'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'HeadImg'
GO
DECLARE @v sql_variant 
SET @v = N'联系信息'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'ContactMsg'
GO
DECLARE @v sql_variant 
SET @v = N'会员等级(1 普通 2 银牌 3 金牌 4 至尊VIP)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'MGrade'
GO
DECLARE @v sql_variant 
SET @v = N'上次登录时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'LastLoginTime'
GO
DECLARE @v sql_variant 
SET @v = N'上次登录IP'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'LastLoginIP'
GO
DECLARE @v sql_variant 
SET @v = N'证件照'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'Paperworkpic'
GO
DECLARE @v sql_variant 
SET @v = N'证件照'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'PaperworkImg'
GO
DECLARE @v sql_variant 
SET @v = N'真实姓名'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'MemberInfo', N'COLUMN', N'TruethName'
GO
ALTER TABLE dbo.MemberInfo ADD CONSTRAINT
	PK_MemberInfo PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.MemberInfo SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.MemberInfo', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.MemberInfo', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.MemberInfo', 'Object', 'CONTROL') as Contr_Per 