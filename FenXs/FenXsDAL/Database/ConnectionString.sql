SELECT
    'data source=' + @@servername +
    ';initial catalog=' + db_name() +
    CASE TYPE_DESC
        WHEN 'WINDOWS_LOGIN'
            THEN ';trusted_connection=true'
        ELSE
            ';user id=' + suser_name() + ';password=<<YourPassword>>'
    END
    AS ConnectionString
FROM sys.server_principals
WHERE NAME = suser_name()