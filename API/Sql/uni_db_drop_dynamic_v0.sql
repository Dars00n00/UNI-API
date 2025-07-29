DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql += N'
ALTER TABLE ' + QUOTENAME(s.name) + N'.' + QUOTENAME(t.name) +
N' DROP CONSTRAINT ' + QUOTENAME(fk.name) + N';'
FROM sys.foreign_keys AS fk
JOIN sys.tables AS t ON fk.parent_object_id = t.object_id
JOIN sys.schemas AS s ON t.schema_id = s.schema_id
-- Optional filter: exclude system tables
WHERE t.is_ms_shipped = 0;

-- Review output:
PRINT @sql;

-- Once verified, uncomment to run:
 EXEC sys.sp_executesql @sql;

 SELECT 'DROP TABLE ' + QUOTENAME(s.name) + N'.' + QUOTENAME(t.name) + ';'
FROM sys.tables t
JOIN sys.schemas s ON t.schema_id = s.schema_id
WHERE t.is_ms_shipped = 0
ORDER BY OBJECT_NAME(t.object_id) DESC;  -- reverse alphabetical helps dependency order

