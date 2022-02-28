--參考 Ref::https://www.cnblogs.com/mrhgw/p/3566989.html


/* 逆向删除对象 Delete object in reverse
DROP PARTITION SCHEME [PS_DataGuardXcore];
DROP PARTITION FUNCTION [PF_DataGuardXcore];

ALTER DATABASE [DataGuardXcore] REMOVE FILE FG_DataGuardXcore_2022;
ALTER DATABASE [DataGuardXcore] REMOVE FILE FG_DataGuardXcore_2023;
ALTER DATABASE [DataGuardXcore] REMOVE FILE FG_DataGuardXcore_2024;
ALTER DATABASE [DataGuardXcore] REMOVE FILE FG_DataGuardXcore_2025;
ALTER DATABASE [DataGuardXcore] REMOVE FILE FG_DataGuardXcore_2026;

ALTER DATABASE [DataGuardXcore] REMOVE FILEGROUP [FG_DataGuardXcore_2022];
ALTER DATABASE [DataGuardXcore] REMOVE FILEGROUP [FG_DataGuardXcore_2023];
ALTER DATABASE [DataGuardXcore] REMOVE FILEGROUP [FG_DataGuardXcore_2024];
ALTER DATABASE [DataGuardXcore] REMOVE FILEGROUP [FG_DataGuardXcore_2025];
ALTER DATABASE [DataGuardXcore] REMOVE FILEGROUP [FG_DataGuardXcore_2026];
*/


-- 创建文件组
--ALTER DATABASE [DataGuardXcore] ADD FILEGROUP [FG_DataGuardXcore_2022];
--ALTER DATABASE [DataGuardXcore] ADD FILEGROUP [FG_DataGuardXcore_2023];
--ALTER DATABASE [DataGuardXcore] ADD FILEGROUP [FG_DataGuardXcore_2024];
--ALTER DATABASE [DataGuardXcore] ADD FILEGROUP [FG_DataGuardXcore_2025];
--ALTER DATABASE [DataGuardXcore] ADD FILEGROUP [FG_DataGuardXcore_2026];

---- 创建文件
--ALTER DATABASE [DataGuardXcore] ADD FILE ( NAME = N'FG_DataGuardXcore_2022', FILENAME = N'C:\DATABASE\FG_DataGuardXcore_2022.ndf' , SIZE = 3072KB , FILEGROWTH = 1024KB ) TO FILEGROUP [FG_DataGuardXcore_2022];
--ALTER DATABASE [DataGuardXcore] ADD FILE ( NAME = N'FG_DataGuardXcore_2023', FILENAME = N'C:\DATABASE\FG_DataGuardXcore_2023.ndf' , SIZE = 3072KB , FILEGROWTH = 1024KB ) TO FILEGROUP [FG_DataGuardXcore_2023];
--ALTER DATABASE [DataGuardXcore] ADD FILE ( NAME = N'FG_DataGuardXcore_2024', FILENAME = N'C:\DATABASE\FG_DataGuardXcore_2023.ndf' , SIZE = 3072KB , FILEGROWTH = 1024KB ) TO FILEGROUP [FG_DataGuardXcore_2024];
--ALTER DATABASE [DataGuardXcore] ADD FILE ( NAME = N'FG_DataGuardXcore_2025', FILENAME = N'C:\DATABASE\FG_DataGuardXcore_2024.ndf' , SIZE = 3072KB , FILEGROWTH = 1024KB ) TO FILEGROUP [FG_DataGuardXcore_2025];
--ALTER DATABASE [DataGuardXcore] ADD FILE ( NAME = N'FG_DataGuardXcore_2026', FILENAME = N'C:\DATABASE\FG_DataGuardXcore_2025.ndf' , SIZE = 3072KB , FILEGROWTH = 1024KB ) TO FILEGROUP [FG_DataGuardXcore_2026];


-- 如果以上ok,則創建下面的兩個create
-- 创建分区函数
CREATE PARTITION FUNCTION [PF_DataGuardXcore](INT) AS RANGE RIGHT FOR VALUES ('1', '2', '3', '6');

-- 创建分区方案(注意顺序：第一个为Other，共它的文件组对应上面的1,2,3,6，如：FG_DataGuardXcore_Piaomeng对应1，FG_DataGuardXcore_Jinri对应2，以此类推)
-- 上述 on above coresponse values :  '1672502400000'= 2023, '1704038400000'= 2024, '1735660800000'= 2025, '1767196800000' = 2026

CREATE PARTITION SCHEME [PS_DataGuardXcore] AS PARTITION [PF_DataGuardXcore] TO ([FG_DataGuardXcore_2022], [FG_DataGuardXcore_2023], [FG_DataGuardXcore_2024], [FG_DataGuardXcore_2025], [FG_DataGuardXcore_2026]);
