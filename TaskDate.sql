USE [Task]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Email], [Fullname], [Mobileno], [HashedPassword], [Salt]) VALUES (1, N'abc@abc.com', N'Richard wu', N'3478277101', N'k+/TpQlcSGJSYsFxlF3lO7vgUl2PJIpcsarWWgF07XM=', N'uAuQ9kCZiemUtNYv9r9sRA==')
INSERT [dbo].[Users] ([Id], [Email], [Fullname], [Mobileno], [HashedPassword], [Salt]) VALUES (2, N'abc1@abc.com', N'Richard wu', N'9123123322', N'Owb88W0ij2x5Gq3yHEfK4VrgicVtUMT5inLXQoYIINk=', N'rlU3MIjyOuBV3o9SwbyTlQ==')
INSERT [dbo].[Users] ([Id], [Email], [Fullname], [Mobileno], [HashedPassword], [Salt]) VALUES (3, N'user123@example.com', N'string one', N'7778889999', N'vneXP6LQ1MBq28dJEhvvRJlIbh9g/wJsshT4WOBypvk=', N'y70O89Ysk6IFyyD4ExktZQ==')
INSERT [dbo].[Users] ([Id], [Email], [Fullname], [Mobileno], [HashedPassword], [Salt]) VALUES (4, N'user4@example.com', N'string', N'1234567899', N'hPX3hkTCKV2NN76sbmPOs33k3Y4wkNIggYTqg4CUQ6s=', N'gsqv9JdFyaiUUtojSAZa/w==')
INSERT [dbo].[Users] ([Id], [Email], [Fullname], [Mobileno], [HashedPassword], [Salt]) VALUES (5, N'user5@example.com', N'string', N'1234567899', N'gQAZsjPObJFim9dqpWLMETGyKeLx80iBew8CXo8SIeU=', N'YptQbaZx1KtEY1u8cN1uNQ==')
INSERT [dbo].[Users] ([Id], [Email], [Fullname], [Mobileno], [HashedPassword], [Salt]) VALUES (6, N'user6@example.com', N'string', N'1234567899', N'dPtWN9KkXVil8TuDEvIbOxsT4UsqUiveNmy/xmxBwGU=', N'qy2leD6Nr5Hh1fRYvrWscA==')
INSERT [dbo].[Users] ([Id], [Email], [Fullname], [Mobileno], [HashedPassword], [Salt]) VALUES (7, N'user7@example.com', N'string', N'1234567899', N'sM2setFg4yoRcku/KavNEJjyLJ2x3pignsAVL+/7RjQ=', N'Wl1Apwk86gYFKyffAogcCg==')
INSERT [dbo].[Users] ([Id], [Email], [Fullname], [Mobileno], [HashedPassword], [Salt]) VALUES (8, N'user8@example.com', N'string', N'1234567899', N'epg0Deip2xR+F1jV9gX/5qovf0ms7heG3NrxW7HAODg=', N'cK7vLzXXm2k9zkdFg0x0HA==')
INSERT [dbo].[Users] ([Id], [Email], [Fullname], [Mobileno], [HashedPassword], [Salt]) VALUES (9, N'user9@example.com', N'string', N'1234567899', N'Yd1GtzRoz4ajBUuQtUHXNYOoxkDHjNrsL08kDUKobCA=', N'p56OPjmc9LzTNcMKa6770Q==')
INSERT [dbo].[Users] ([Id], [Email], [Fullname], [Mobileno], [HashedPassword], [Salt]) VALUES (10, N'user10@example.com', N'string', N'1234567899', N'npv8syMKh40XPyxbDeCFdoh97bAdNHao/B08/+nElhY=', N'5SFY5NHMuIFHQd6+jdO/JA==')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Tasks] ON 

INSERT [dbo].[Tasks] ([Id], [userid], [Title], [Description], [DueDate], [Priority], [Remarks]) VALUES (1, 1, N'string1', N'string1', CAST(N'2022-07-27T19:10:18.4400000' AS DateTime2), N'1', N'string1')
INSERT [dbo].[Tasks] ([Id], [userid], [Title], [Description], [DueDate], [Priority], [Remarks]) VALUES (2, 2, N'string2', N'string2', CAST(N'2022-07-27T19:11:27.0160000' AS DateTime2), N'2', N'string2')
INSERT [dbo].[Tasks] ([Id], [userid], [Title], [Description], [DueDate], [Priority], [Remarks]) VALUES (4, 3, N'string3', N'string3', CAST(N'2023-07-27T21:48:54.4890000' AS DateTime2), N'3', N'hurry!')
INSERT [dbo].[Tasks] ([Id], [userid], [Title], [Description], [DueDate], [Priority], [Remarks]) VALUES (7, 4, N'string4', N'string4', CAST(N'2022-07-28T04:03:28.6930000' AS DateTime2), N'4', N'string4')
INSERT [dbo].[Tasks] ([Id], [userid], [Title], [Description], [DueDate], [Priority], [Remarks]) VALUES (8, 5, N'string5', N'string5', CAST(N'2022-07-28T04:03:28.6930000' AS DateTime2), N'5', N'string5')
INSERT [dbo].[Tasks] ([Id], [userid], [Title], [Description], [DueDate], [Priority], [Remarks]) VALUES (9, 6, N'string6', N'string6', CAST(N'2022-07-28T04:03:28.6930000' AS DateTime2), N'6', N'string6')
INSERT [dbo].[Tasks] ([Id], [userid], [Title], [Description], [DueDate], [Priority], [Remarks]) VALUES (10, 7, N'string7', N'string7', CAST(N'2022-07-28T04:03:28.6930000' AS DateTime2), N'7', N'string7')
INSERT [dbo].[Tasks] ([Id], [userid], [Title], [Description], [DueDate], [Priority], [Remarks]) VALUES (11, 8, N'string8', N'string8', CAST(N'2022-07-28T04:03:28.6930000' AS DateTime2), N'8', N'string8')
INSERT [dbo].[Tasks] ([Id], [userid], [Title], [Description], [DueDate], [Priority], [Remarks]) VALUES (12, 9, N'string9', N'string9', CAST(N'2022-07-28T04:03:28.6930000' AS DateTime2), N'9', N'string9')
INSERT [dbo].[Tasks] ([Id], [userid], [Title], [Description], [DueDate], [Priority], [Remarks]) VALUES (14, 10, N'string10', N'string10', CAST(N'2022-07-28T04:03:28.6930000' AS DateTime2), N'1', N'string10')
SET IDENTITY_INSERT [dbo].[Tasks] OFF
GO
INSERT [dbo].[TaskHistory] ([TaskId], [UserId], [Title], [Description], [DueDate], [Completed], [Remarks]) VALUES (1, 1, N'string', N'string', CAST(N'2021-07-28T00:38:25.3430000' AS DateTime2), CAST(N'2021-07-27T20:38:51.9000000' AS DateTime2), N'string')
INSERT [dbo].[TaskHistory] ([TaskId], [UserId], [Title], [Description], [DueDate], [Completed], [Remarks]) VALUES (2, 2, N'string2', N'string2', NULL, CAST(N'2021-07-27T23:31:44.9100000' AS DateTime2), N'string2')
INSERT [dbo].[TaskHistory] ([TaskId], [UserId], [Title], [Description], [DueDate], [Completed], [Remarks]) VALUES (4, 3, N'string', N'string', CAST(N'2021-07-28T00:38:25.3430000' AS DateTime2), CAST(N'2021-07-27T20:39:13.2166667' AS DateTime2), N'string')
INSERT [dbo].[TaskHistory] ([TaskId], [UserId], [Title], [Description], [DueDate], [Completed], [Remarks]) VALUES (11, 9, N'string11', N'string11', CAST(N'2022-07-28T14:51:36.7360000' AS DateTime2), CAST(N'2021-07-28T10:53:01.0133333' AS DateTime2), N'string11')
INSERT [dbo].[TaskHistory] ([TaskId], [UserId], [Title], [Description], [DueDate], [Completed], [Remarks]) VALUES (12, 8, N'string12', N'string12', CAST(N'2022-07-28T14:54:44.5300000' AS DateTime2), CAST(N'2021-07-28T10:55:13.9666667' AS DateTime2), N'string12')
INSERT [dbo].[TaskHistory] ([TaskId], [UserId], [Title], [Description], [DueDate], [Completed], [Remarks]) VALUES (13, 7, N'string13', N'string13', CAST(N'2022-07-28T14:54:44.5300000' AS DateTime2), CAST(N'2021-07-28T10:55:40.1866667' AS DateTime2), N'string13')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210726205919_InitialMigration', N'5.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210726210106_updateTasks', N'5.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210726210644_updateTasksHistory', N'5.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210727001802_updateForeginKey', N'5.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210727081850_UserHashPassword', N'5.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210728003651_dropTaskHistoryTable', N'5.0.8')
GO
