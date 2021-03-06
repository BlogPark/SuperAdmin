USE [SuperWebSite]
GO
/****** Object:  StoredProcedure [dbo].[SeleArticleByPage]    Script Date: 03/17/2016 17:08:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	分页读取文章信息
-- =============================================
ALTER PROCEDURE [dbo].[SeleArticleByPage]
    @pageindex INT ,
    @pagesize INT ,
    @starttime NVARCHAR(100) ,
    @endtime NVARCHAR(100) ,
    @statusnum INT ,
    @aid INT ,
    @arttitle NVARCHAR(1000) ,
    @memberID INT ,
    @arttypeid INT ,
    @artcid INT = -1 ,
    @totalrowcount INT OUTPUT ,
    @pageCount INT OUTPUT
AS
    BEGIN
        SET NOCOUNT ON;
        DECLARE @sqltxt NVARCHAR(4000) ,
            @where NVARCHAR(500)
        SET @where = ' WHERE 1=1 '
        IF ( @starttime IS NOT NULL )
            SET @where = @where + ' AND ArtPublishTime >= ''' + @starttime + ''''
        IF ( @endtime IS NOT NULL )
            SET @where = @where + ' AND ArtPublishTime <= ''' + @endtime + ''''
        IF ( @statusnum <> 100 )
            SET @where = @where + ' AND ArtStatus = '
                + CONVERT(NVARCHAR(20), @statusnum)
        IF ( @memberID <> 0 )
            SET @where = @where + ' AND MemberID = '
                + CONVERT(NVARCHAR(20), @memberID)
        IF ( @arttypeid <> 0 )
            SET @where = @where + ' AND ArtType = '
                + CONVERT(NVARCHAR(20), @arttypeid)
        IF ( LEN(@arttitle) > 0 )
            SET @where = @where + ' AND ArtTitle like ''%' + @arttitle + '%'''
        IF ( @aid <> 0 )
            SET @where = @where + ' AND Id = ' + CONVERT(NVARCHAR(20), @aid)
            
        IF ( @artcid <>0 )
            SET @where = @where + ' AND ArtCID = '''
                + CONVERT(NVARCHAR(20), @artcid) + ''''
            
        SET @sqltxt = 'SELECT @totalrowcount=COUNT(*) FROM  dbo.Articles '
            + @where + ' '
	  --统计记录总数
        EXEC SP_EXECUTESQL @sqltxt, N'@totalrowcount INT OUTPUT ',
            @totalrowcount OUTPUT
    --统计分页总数
        SET @pageCount = ( @totalrowcount + @pageSize - 1 ) / @pageSize
	--判断当前页是否大于总页数
        IF @pageindex > @pageCount
            BEGIN
                SET @pageindex = @pageCount
                --SELECT  *
                --FROM    MediaTopicComment
                --WHERE   0 > 1
                RETURN
            END
             --判断当前页是否小于第一页
        IF @pageindex < 1
            SET @pageindex = 1
        DECLARE @vStart INT ,
            @vEnd INT ,
            @vTop INT
	--确定起始位置
        SET @vStart = ( @pageindex - 1 ) * @pageSize + 1
	--确定结束位置
        SET @vEnd = @vStart + @pageSize - 1
	--只提取包含目标记录的最小数量
        SET @vTop = @pageindex * @pageSize

        DECLARE @sStart NVARCHAR(10) ,
            @sEnd NVARCHAR(10) ,
            @sTop NVARCHAR(10)
        SET @sStart = CAST(@vStart AS NVARCHAR(10))
        SET @sEnd = CAST(@vEnd AS NVARCHAR(10))
	--提取包含检索记录的最小记录数量
        SET @sTop = CAST(@vTop AS NVARCHAR(10))

        SET @sqltxt = ' SET ROWCOUNT ' + @sTop
        SET @sqltxt = @sqltxt
            + ' ;WITH TempABC AS(SELECT ROW_NUMBER() OVER (order by ArtPublishTime desc ) AS ROWID,Temp_O.ID ,Temp_O.MemberID,Temp_O.ArtTitle ,Temp_O.MemberName ,Temp_O.ArtPic ,Temp_O.ArtPicWidth ,Temp_O.ArtPicHeight ,Temp_O.ArtSummary ,Temp_O.ArtContent ,Temp_O.ArtTags ,Temp_O.ArtPublishTime ,Temp_O.ArtType ,Temp_O.ArtFavoriteCount ,Temp_O.ArtCommentCount ,Temp_O.ArtHitCount ,Temp_O.AddTime,Temp_O.ArtFrom ,Temp_O.ArtFromUrl ,Temp_O.ArtOuterchain ,Temp_O.AntitrialReasons ,Temp_O.CheckUserID ,Temp_O.CheckUserName ,Temp_O.ArtCID ,Temp_O.ArtCName ,ISNULL(Temp_O.ArtIsTop,0) as ArtIsTop ,Temp_O.ArtUserTags,CASE Temp_O.ArtType WHEN 1 THEN ''原创文章'' WHEN 2 THEN ''原创图集'' WHEN 3 THEN ''广告软文'' WHEN 4 THEN ''引用文章'' WHEN 5 THEN ''引用图集''  END AS ArtTypeName,CASE Temp_O.ArtStatus WHEN 10 THEN ''未审'' WHEN 20 THEN ''已审'' WHEN 30 THEN ''删除'' END AS ArtStatusName,Temp_O.ArtStatus FROM dbo.Articles AS Temp_O  '
            + @where + ' )'
        SET @sqltxt = @sqltxt + ' SELECT * FROM TempABC WHERE ROWID BETWEEN '
            + @sStart + ' AND ' + @sEnd
        SET @sqltxt = @sqltxt + ' SET ROWCOUNT 0'
        PRINT @sqltxt
        EXEC SP_EXECUTESQL @sqltxt
    END
