CREATE DATABASE [LinguaNotebookDB] 
ON ( 
   NAME = 'LinguaNotebookDB', 
   FILENAME = 'C:\Users\MSSQLSERVER\DataBases\LinguaNotebookDB.mdf', 
   SIZE = 6000KB , 
   MAXSIZE = 106000KB , 
   FILEGROWTH = 10000KB 
)
LOG ON ( 
   NAME = 'LinguaNotebookDB_log', 
   FILENAME = 'C:\Users\MSSQLSERVER\DataBases\LinguaNotebookDB.ldf', 
   SIZE = 2000KB , 
   MAXSIZE = 102000KB , 
   FILEGROWTH = 10000KB 
);

GO

USE LinguaNotebookDB;

GO

CREATE TABLE Language (
   Id tinyint NOT NULL,
   Name nvarchar(25) NOT NULL UNIQUE,
   EnglishName nvarchar(25) NOT NULL UNIQUE,
   CONSTRAINT PK_Language PRIMARY KEY(Id)
);

CREATE TABLE _User (
   Id int NOT NULL,
   Name nvarchar(30) NOT NULL UNIQUE, 
   Password char(40) NOT NULL,
   NativeLangId tinyint NOT NULL,
   CONSTRAINT PK__User PRIMARY KEY(Id),
   CONSTRAINT FK__User_Language FOREIGN KEY(NativeLangId) REFERENCES Language(Id)
); 

CREATE TABLE Notebook (
   Id int NOT NULL,
   TargetLangId tinyint NOT NULL,
   BaseLangId tinyint NOT NULL,
   UserId int NOT NULL,
   CONSTRAINT PK_Notebook PRIMARY KEY(Id),
   CONSTRAINT FK_Notebook_User FOREIGN KEY(UserId) REFERENCES _User(Id),
   CONSTRAINT FK_Notebook_Language_Base FOREIGN KEY(BaseLangId) REFERENCES Language(Id),
   CONSTRAINT FK_Notebook_Language_Target FOREIGN KEY(TargetLangId) REFERENCES Language(Id),
);

CREATE TABLE Word (
   Id bigint NOT NULL,
   Spelling nvarchar(50) NOT NULL UNIQUE,
   LangId tinyint NOT NULL,
   CONSTRAINT PK_Word PRIMARY KEY(Id),
   CONSTRAINT FK_Word_Language FOREIGN KEY(LangId) REFERENCES Language(Id)
);

CREATE TABLE Category (
   Id int NOT NULL,
   CategoryName nvarchar(30) NOT NULL,
   CONSTRAINT PK_Category PRIMARY KEY(Id)
);

CREATE TABLE Meaning (
   Id int NOT NULL,
   BaseLangId tinyint NOT NULL,
   WordId bigint NOT NULL,
   Description nvarchar(100) NOT NULL,
   PartOfSpeech nvarchar(20) NOT NULL,
   CategoryId int,
   CONSTRAINT PK_Meaning PRIMARY KEY(Id),
   CONSTRAINT FK_Meaning_Language FOREIGN KEY(BaseLangId) REFERENCES Language(Id),
   CONSTRAINT FK_Meaning_Word FOREIGN KEY(WordId) REFERENCES Word(Id),
   CONSTRAINT FK_Meaning_Category FOREIGN KEY(CategoryId) REFERENCES Category(Id),
);

CREATE TABLE Example (
   Id bigint NOT NULL,
   MeaningId int NOT NULL,
   Text nvarchar(500) NOT NULL,
   CONSTRAINT PK_Example PRIMARY KEY(Id),
   CONSTRAINT FK_Example_Meaning FOREIGN KEY(MeaningId) REFERENCES Meaning(Id)
);

CREATE TABLE Accent (
   Id smallint NOT NULL,
   LangId tinyint NOT NULL,
   Name nvarchar(30) NOT NULL,
   CONSTRAINT PK_Accent PRIMARY KEY(Id),
   CONSTRAINT FK_Accent_Language FOREIGN KEY(LangId) REFERENCES Language(Id)
);

CREATE TABLE Pronunciation (
   WordId bigint NOT NULL,
   AccentId smallint NOT NULL,
   Transcription nvarchar(40) NOT NULL,
   CONSTRAINT PK_Pronunciation PRIMARY KEY(WordId, AccentId),
   CONSTRAINT FK_Pronunciation_Accent FOREIGN KEY(AccentId) REFERENCES Accent(Id),
   CONSTRAINT FK_Pronunciation_Word FOREIGN KEY(WordId) REFERENCES Word(Id)
);

CREATE TABLE Expression (
   Id bigint NOT NULL,
   Text nvarchar(250) NOT NULL,
   LangId tinyint NOT NULL,
   Type varchar(20),
   CategoryId int,
   CONSTRAINT PK_Expression PRIMARY KEY(Id),
   CONSTRAINT FK_Expression_Language FOREIGN KEY(LangId) REFERENCES Language(Id),   
   CONSTRAINT FK_Expression_Category FOREIGN KEY(CategoryId) REFERENCES Category(Id)
);

CREATE TABLE ExpressionTranslation (
   ExprId bigint NOT NULL,
   Text nvarchar(250) NOT NULL,
   LangId tinyint NOT NULL,
   CONSTRAINT PK_ExpressionTranslation PRIMARY KEY(ExprId, LangId),
   CONSTRAINT FK_ExpressionTranslation_Expression FOREIGN KEY(ExprId) REFERENCES Expression(Id),
   CONSTRAINT FK_ExpressionTranslation_Language FOREIGN KEY(LangId) REFERENCES Language(Id)
);

CREATE TABLE ExampleTranslation (
   ExampleId bigint NOT NULL,
   Text nvarchar(500) NOT NULL,
   LangId tinyint NOT NULL,
   CONSTRAINT PK_ExampleTranslation PRIMARY KEY(ExampleId, LangId),
   CONSTRAINT FK_ExampleTranslation_Example FOREIGN KEY(ExampleId) REFERENCES Example(Id),
   CONSTRAINT FK_ExampleTranslation_Language FOREIGN KEY(LangId) REFERENCES Language(Id)
);