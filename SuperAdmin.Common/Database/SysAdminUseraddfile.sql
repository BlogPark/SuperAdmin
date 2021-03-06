/*
   2015年12月25日9:59:26
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
DECLARE @v sql_variant 
SET @v = N'登录名称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'SysAdminUser', N'COLUMN', N'LoginName'
GO
ALTER TABLE dbo.SysAdminUser SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.SysAdminUser', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.SysAdminUser', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.SysAdminUser', 'Object', 'CONTROL') as Contr_Per 