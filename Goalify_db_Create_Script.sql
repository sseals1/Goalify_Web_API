CREATE TABLE [users] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [name] nvarchar(255) NOT NULL,
  [address] nvarchar(255) NOT NULL,
  [email] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [goals] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [userId] int NOT NULL,
  [categoryId] int NOT NULL,
  [priorityId] int NOT NULL,
  [termId] int NOT NULL,
  [milestoneId] int NOT NULL,
  [goalDescrition] nvarchar(255) NOT NULL,
  [goalObjectives] nvarchar(255) NOT NULL,
  [notes] nvarchar(255),
  [goalDate] datetime NOT NULL
)
GO

CREATE TABLE [milestones] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [progressNotes] nvarchar(255),
  [directionNotes] nvarchar(255),
  [definedNotes] nvarchar(255),
  [featuresNotes] nvarchar(255),
  [attainedNotes] nvarchar(255),
  [direction] BIT,
  [defined] BIT,
  [progress] BIT,
  [features] BIT,
  [attained] BIT
)
GO

CREATE TABLE [tips] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [suggestions] nvarchar(255) NOT NULL,
  [tip] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [priority] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [priority] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [terms] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [term] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [categories] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [category] nvarchar(255) NOT NULL,
  [colorId] int NOT NULL
)
GO

ALTER TABLE [goals] ADD FOREIGN KEY ([userId]) REFERENCES [users] ([id])
GO

ALTER TABLE [goals] ADD FOREIGN KEY ([priorityId]) REFERENCES [priority] ([id])
GO

ALTER TABLE [goals] ADD FOREIGN KEY ([termId]) REFERENCES [terms] ([id])
GO

ALTER TABLE [goals] ADD FOREIGN KEY ([categoryId]) REFERENCES [categories] ([id])
GO

ALTER TABLE [goals] ADD FOREIGN KEY ([milestoneId]) REFERENCES [milestones] ([id])
GO
