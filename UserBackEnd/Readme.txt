1.- Cambiar conexión a BBDD 
2.- Ejecutar en consola nuget: Update-Database
3.- Ejecutar script a continuación:

    USE [CarvajalPrueba]
    GO
    SET IDENTITY_INSERT [dbo].[IdentificationTypes] ON 
    GO
    INSERT [dbo].[IdentificationTypes] ([IdentificationTypeId], [Description]) VALUES (1, N'CC')
    GO
    SET IDENTITY_INSERT [dbo].[IdentificationTypes] OFF
    GO
    SET IDENTITY_INSERT [dbo].[Users] ON 
    GO
    INSERT [dbo].[Users] ([UserId], [Name], [LastName], [IdentificationTypeId], [IdentificationNumber], [Email], [Password]) VALUES (1, N'Admin', N'Admin', 1, N'1000000000', N'hola@example.com', N'$2a$11$11tTpJHruwnzQElbBY2KO.V5Us4moZD2/imOSIBSWZ3u3DdJ.oNLK')
    GO
    SET IDENTITY_INSERT [dbo].[Users] OFF
    GO

4.- Ejecutar proyecto principal