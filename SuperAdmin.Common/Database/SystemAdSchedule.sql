/*
   2016年1月7日18:11:46
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
CREATE TABLE dbo.SystemAdSchedule
	(
	ID int NOT NULL IDENTITY (1, 1),
	ScheduleName nvarchar(500) NULL,
	AdSiteID int NULL,
	AdPID int NULL,
	AdID int NULL,
	AreaName nvarchar(50) NULL,
	ControllerName nvarchar(50) NULL,
	ActionName nvarchar(50) NULL,
	GivenID nvarchar(50) NULL,
	IntervalNum int NULL,
	StarTime datetime NULL,
	EndTime datetime NULL,
	AddTime datetime NULL,
	AddUserID int NULL,
	AddUserName nvarchar(50) NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'排期名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSchedule', N'COLUMN', N'ScheduleName'
GO
DECLARE @v sql_variant 
SET @v = N'站点ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSchedule', N'COLUMN', N'AdSiteID'
GO
DECLARE @v sql_variant 
SET @v = N'位置ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSchedule', N'COLUMN', N'AdPID'
GO
DECLARE @v sql_variant 
SET @v = N'广告ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSchedule', N'COLUMN', N'AdID'
GO
DECLARE @v sql_variant 
SET @v = N'所属区域'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSchedule', N'COLUMN', N'AreaName'
GO
DECLARE @v sql_variant 
SET @v = N'控制器名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSchedule', N'COLUMN', N'ControllerName'
GO
DECLARE @v sql_variant 
SET @v = N'方法名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSchedule', N'COLUMN', N'ActionName'
GO
DECLARE @v sql_variant 
SET @v = N'特定字符串'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSchedule', N'COLUMN', N'GivenID'
GO
DECLARE @v sql_variant 
SET @v = N'广告中间间隔数目'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSchedule', N'COLUMN', N'IntervalNum'
GO
DECLARE @v sql_variant 
SET @v = N'排期开始时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSchedule', N'COLUMN', N'StarTime'
GO
DECLARE @v sql_variant 
SET @v = N'排期结束时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSchedule', N'COLUMN', N'EndTime'
GO
DECLARE @v sql_variant 
SET @v = N'添加时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSchedule', N'COLUMN', N'AddTime'
GO
DECLARE @v sql_variant 
SET @v = N'添加人ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSchedule', N'COLUMN', N'AddUserID'
GO
DECLARE @v sql_variant 
SET @v = N'添加人名字'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SystemAdSchedule', N'COLUMN', N'AddUserName'
GO
ALTER TABLE dbo.SystemAdSchedule ADD CONSTRAINT
	PK_SystemAdSchedule PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.SystemAdSchedule SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.SystemAdSchedule', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.SystemAdSchedule', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.SystemAdSchedule', 'Object', 'CONTROL') as Contr_Per 