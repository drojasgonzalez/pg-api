CREATE PROCEDURE GetClientsPaged
    @PageNumber INT,
    @PageSize INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM (
        SELECT *,
               ROW_NUMBER() OVER (ORDER BY id) AS RowNum
        FROM Clients
    ) AS Pagination
    WHERE RowNum > (@PageNumber - 1) * @PageSize
      AND RowNum <= @PageNumber * @PageSize;
END

-- DROP PROCEDURE GetClientsPaged