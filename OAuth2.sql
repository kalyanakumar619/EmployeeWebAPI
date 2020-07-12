USE [EmployeeMaster]  
GO  

CREATE TABLE [dbo].[AuthLogin](  
    [id] [int] IDENTITY(1,1) NOT NULL,  
    [username] [varchar](50) NOT NULL,  
    [password] [varchar](50) NOT NULL,  
 CONSTRAINT [PK_AuthLogin] PRIMARY KEY CLUSTERED   
(  
    [id] ASC  
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]  
) ON [PRIMARY]  
  

SET IDENTITY_INSERT [dbo].[AuthLogin] ON   
  
INSERT [dbo].[AuthLogin] ([id], [username], [password]) VALUES (1, N'admin', N'admin')  

SET IDENTITY_INSERT [dbo].[AuthLogin] OFF  

GO

CREATE PROCEDURE [dbo].[SP_AuthLogin]   
    @username varchar(50),  
    @password varchar(50)  
AS  
BEGIN  
    SELECT id, username, password  
    FROM AuthLogin  
    WHERE username = @username  
    AND password = @password  
END  
  
GO 

--select * from AuthLogin
--[SP_AuthLogin] admin,admin