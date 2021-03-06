/*
   2016年1月7日17:35:35
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
CREATE TABLE dbo.SystemAd
	(
	ID int NOT NULL IDENTITY (1, 1),
	AdTitle nvarchar(50) NULL,
	AdType int NULL,
	AdWidth int NULL,
	AdHeight int NULL,
	AdSummary nvarchar(500) NULL,
	AdPic nvarchar(200) NULL,
	AdBackgroundPic nvarchar(200) NULL,
	AdLinkUrl nvarchar(300) NULL,
	AdSourceCode nvarchar(2000) NULL,
	AdRemark nvarchar(500) NULL,
	AdStatus int NULL,
	AdAddTime datetime NULL,
	AdSiteID int NULL,
	AdSiteName nvarchar(50) NULL,
	AddUserID int NULL,
	AddUserName nvarchar(50) NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'主键自增'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'ID'
GO
DECLARE @v sql_variant 
SET @v = N'广告标题'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AdTitle'
GO
DECLARE @v sql_variant 
SET @v = N'广告类型(1 图片广告 2  图文广告)'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AdType'
GO
DECLARE @v sql_variant 
SET @v = N'广告宽度'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AdWidth'
GO
DECLARE @v sql_variant 
SET @v = N'广告区域高度'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AdHeight'
GO
DECLARE @v sql_variant 
SET @v = N'广告描述'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AdSummary'
GO
DECLARE @v sql_variant 
SET @v = N'广告图片'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AdPic'
GO
DECLARE @v sql_variant 
SET @v = N'广告区背景图'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AdBackgroundPic'
GO
DECLARE @v sql_variant 
SET @v = N'链接目标地址'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AdLinkUrl'
GO
DECLARE @v sql_variant 
SET @v = N'广告区源代码'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AdSourceCode'
GO
DECLARE @v sql_variant 
SET @v = N'广告区备注'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AdRemark'
GO
DECLARE @v sql_variant 
SET @v = N'广告区状态'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AdStatus'
GO
DECLARE @v sql_variant 
SET @v = N'添加时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AdAddTime'
GO
DECLARE @v sql_variant 
SET @v = N'平台ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AdSiteID'
GO
DECLARE @v sql_variant 
SET @v = N'平台名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AdSiteName'
GO
DECLARE @v sql_variant 
SET @v = N'添加人'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AddUserID'
GO
DECLARE @v sql_variant 
SET @v = N'添加人名字'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAd', N'COLUMN', N'AddUserName'
GO
ALTER TABLE dbo.SystemAd ADD CONSTRAINT
	PK_SystemAd PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.SystemAd SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.SystemAd', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.SystemAd', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.SystemAd', 'Object', 'CONTROL') as Contr_Per 