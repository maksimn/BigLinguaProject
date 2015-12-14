CREATE DATABASE [LinguaNotebookDB]
ON ( 
   NAME = 'LinguaNotebookDB', 
   FILENAME = 'C:\Users\MSSQLSERVER\DataBases\LinguaNotebookDB.mdf', 
   SIZE = 6000KB , MAXSIZE = 106000KB , FILEGROWTH = 10000KB 
)
LOG ON ( 
   NAME = 'LinguaNotebookDB_log', 
   FILENAME = 'C:\Users\MSSQLSERVER\DataBases\LinguaNotebookDB.ldf', 
   SIZE = 2000KB , MAXSIZE = 102000KB , FILEGROWTH = 10000KB 
);

GO