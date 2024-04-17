﻿BEGIN TRANSACTION;
GO

CREATE TABLE [TB_HABILIDADES] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_TB_HABILIDADES] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_PERSONAGENS_HABILIDADES] (
    [PersonagemId] int NOT NULL,
    [HabilidadeId] int NOT NULL,
    CONSTRAINT [PK_TB_PERSONAGENS_HABILIDADES] PRIMARY KEY ([PersonagemId], [HabilidadeId]),
    CONSTRAINT [FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId] FOREIGN KEY ([HabilidadeId]) REFERENCES [TB_HABILIDADES] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [TB_PERSONAGENS] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_HABILIDADES]'))
    SET IDENTITY_INSERT [TB_HABILIDADES] ON;
INSERT INTO [TB_HABILIDADES] ([Id], [Dano], [Nome])
VALUES (1, 35, 'Clone'),
(2, 20, 'Adormecer'),
(3, 41, 'Congelar'),
(4, 10, 'Hipnotizar'),
(5, 15, 'Ressurreição'),
(6, 48, 'Tornado de fogo'),
(7, 49, 'Explosão');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[TB_HABILIDADES]'))
    SET IDENTITY_INSERT [TB_HABILIDADES] OFF;
GO

UPDATE [TB_USUARIOS] SET [PasswordHash] = 0xB697F61B0C211346B100A07C448A79B2261626A7C0044C65323F68C7ED7E978DCB547F48BAD9A51AB433150534EF940B88DE6911C093BB4673345AB88F3408BD, [PasswordSalt] = 0xEC48E229B79B6537AF0FE09BC532AC4339F0203345C94027F83B03DB4E52D5417DC4B4F2E1BCCEC21789C8498A6C251F6DAC0C70A160DA405C011F4ED1E00E2B2AA7ED1F7D3160935BCF90F6DAB731281BEA5FFB5545AA28FD7708DB37A6835EDEDA0D729E08F306C8F865D42EB60D0DDA25BC2451D2ED659146E9A0C0FCC24E
WHERE [id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[TB_PERSONAGENS_HABILIDADES]'))
    SET IDENTITY_INSERT [TB_PERSONAGENS_HABILIDADES] ON;
INSERT INTO [TB_PERSONAGENS_HABILIDADES] ([HabilidadeId], [PersonagemId])
VALUES (1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[TB_PERSONAGENS_HABILIDADES]'))
    SET IDENTITY_INSERT [TB_PERSONAGENS_HABILIDADES] OFF;
GO

CREATE INDEX [IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId] ON [TB_PERSONAGENS_HABILIDADES] ([HabilidadeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240417014312_MigracaoMuitosParaMuitos', N'8.0.3');
GO

COMMIT;
GO

