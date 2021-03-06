/*
   2016年1月7日17:52:44
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
CREATE TABLE dbo.SystemAdPosition
	(
	ID int NOT NULL IDENTITY (1, 1),
	PName nvarchar(50) NULL,
	AdSiteID int NULL,
	AdSiteName nvarchar(50) NULL,
	PWidth int NULL,
	PHeight int NULL,
	PType int NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'自增主键'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdPosition', N'COLUMN', N'ID'
GO
DECLARE @v sql_variant 
SET @v = N'位置名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdPosition', N'COLUMN', N'PName'
GO
DECLARE @v sql_variant 
SET @v = N'所属站点ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdPosition', N'COLUMN', N'AdSiteID'
GO
DECLARE @v sql_variant 
SET @v = N'所属站点名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdPosition', N'COLUMN', N'AdSiteName'
GO
DECLARE @v sql_variant 
SET @v = N'位置宽度'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdPosition', N'COLUMN', N'PWidth'
GO
DECLARE @v sql_variant 
SET @v = N'位置高度'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdPosition', N'COLUMN', N'PHeight'
GO
DECLARE @v sql_variant 
SET @v = N'位置类型（1 首页 2 子页 3 固定位置）'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdPosition', N'COLUMN', N'PType'
GO
ALTER TABLE dbo.SystemAdPosition ADD CONSTRAINT
	PK_SystemAdPosition PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.SystemAdPosition SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.SystemAdPosition', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.SystemAdPosition', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.SystemAdPosition', 'Object', 'CONTROL') as Contr_Per 