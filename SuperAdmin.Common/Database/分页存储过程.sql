USE [SuperWebSite]
GO
/****** Object:  StoredProcedure [dbo].[PagePro]    Script Date: 04/24/2016 20:47:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PagePro]
    @orderby NVARCHAR(20) ,
    @tablename NVARCHAR(20) ,
    @colums NVARCHAR(500) ,
    @where NVARCHAR(500) ,
    @pageindex INT ,
    @pagesize INT ,
    @totalrecord INT OUT
AS
    BEGIN	
        SET NOCOUNT ON;
        DECLARE @sql NVARCHAR(2000)
        DECLARE @totalsql NVARCHAR(2000)
        DECLARE @wherestr NVARCHAR(2000)=''
        IF LEN(@where)>0
        BEGIN
        SET @wherestr=' where '+@where;
        END
        
        SET @totalsql = 'select @totalrecord=COUNT(0) from ' + @tablename
            + @wherestr
        EXEC SP_EXECUTESQL @totalsql, N'@totalrecord INT OUTPUT ',
            @totalrecord OUTPUT
        SET @sql = 'SELECT TOP ' + CONVERT(NVARCHAR(10), @pagesize) + ' '
            + @colums + ' FROM ( SELECT ROW_NUMBER() OVER (ORDER BY  '
            + @orderby + ' desc) AS RowNumber,' + @colums + ' FROM '
            + @tablename + @wherestr + ')   as A WHERE RowNumber > '
            + CONVERT(NVARCHAR(10), @pagesize) + '*('
            + CONVERT(NVARCHAR(10), @pageindex) + '-1) '
            PRINT @sql;
        EXEC SP_EXECUTESQL @sql;
    END
