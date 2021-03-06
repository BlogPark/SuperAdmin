/*
   2016年1月7日17:55:25
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
CREATE TABLE dbo.SystemAdSite
	(
	ID int NOT NULL IDENTITY (1, 1),
	AdSiteName nvarchar(50) NULL,
	AdSiteState int NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'站点Id'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSite', N'COLUMN', N'ID'
GO
DECLARE @v sql_variant 
SET @v = N'站点名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSite', N'COLUMN', N'AdSiteName'
GO
DECLARE @v sql_variant 
SET @v = N'状态值（0 禁用 1 启用）'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSite', N'COLUMN', N'AdSiteState'
GO
ALTER TABLE dbo.SystemAdSite ADD CONSTRAINT
	PK_SystemAdSite PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.SystemAdSite SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.SystemAdSite', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.SystemAdSite', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.SystemAdSite', 'Object', 'CONTROL') as Contr_Per 