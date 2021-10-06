Use Decola

CREATE TABLE Clientes 
    ( 
     Id int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	 Nome nvarchar(255) NOT NULL,
	 Sobrenome nvarchar(255) NOT NULL,
	 Idade numeric(3) NOT NULL,
	 Email nvarchar(255) NOT NULL,
	 CEP nvarchar (9) NOT NULL,
    )   
;

CREATE TABLE Carros 
    ( 
     Id int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	 Modelo nvarchar(120) NOT NULL,
	 Marca nvarchar(120) NOT NULL,
    )   
;

ALTER TABLE Clientes ALTER COLUMN Nome nvarchar(2000);

DROP TABLE Carros;

CREATE TABLE Carros 
    ( 
     Id int NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	 Modelo nvarchar(120) NOT NULL,
	 Marca nvarchar(120) NOT NULL,
	 Ano numeric(4) NOT NULL
    )   
;

ALTER TABLE Carros ADD Versao nvarchar(120) NULL;

ALTER TABLE Carros ADD KM int NULL;

ALTER TABLE Carros ALTER COLUMN KM numeric(18,2) NULL;

ALTER TABLE Clientes ADD Endereco nvarchar(255) NOT NULL;

ALTER TABLE Clientes ADD Numero numeric(5) NOT NULL;

INSERT INTO Clientes
     VALUES
           ('Marcos', 'Borba', 20, 'marcos.borba@iteris.com.br', '02214-120', 'Rua A', 234),
           ('Eduardo', 'Vicente', 25, 'eduardo.vicente@iteris.com.br', '02354-001', 'Rua B', 231),
		   ('Haroldo', 'Medeiros', 19, 'haroldo.medeiros@iteris.com.br', '13514-024', 'Rua C', 543),
		   ('Julio', 'Guzelotto', 36, 'julio.guzelotto@iteris.com.br', '12345-123', 'Rua A', 12314),
		   ('Luis', 'Imoto', 28, 'luis.imoto@iteris.com.br', '12352-090', 'Rua B', 1235),
		   ('Rafael', 'Francisco', 34, 'rafael.francisco@iteris.com.br', '24678-221', 'Rua C', 65),	
		   ('Alex', 'Oshika', 37, 'alex.oshika@iteris.com.br', '35552-119', 'Rua A', 321),		
		   ('Juliana', 'Sandow', 41, 'juliana.sandow@iteris.com.br', '23452-234', 'Rua B', 32),		
		   ('Tony', 'Rodrigues', 33, 'tony.rodrigues@iteris.com.br', '13212-534', 'Rua C', 4),		
			('Thiago', 'Boldrin', 36, 'thiago.boldrin@iteris.com.br', '45345-766', 'Rua A', 66);

--insert na tabela carros importando do excel para a tabela Carros$

ALTER TABLE dbo.Carros$ DROP COLUMN KM;

ALTER TABLE dbo.Carros$ ADD KM numeric(18,2) null;

INSERT INTO Carros SELECT * FROM Carros$;

UPDATE Carros SET Modelo = 'Carro caro'  WHERE Marca = 'BMW';

DELETE FROM Carros WHERE Marca = 'Peugeot';

UPDATE Carros SET Modelo = 'carros de tiozão' WHERE Marca = 'Toyota' OR Marca = 'Honda' OR Marca = 'Audi' AND ANO <= 2015;

SELECT * FROM Clientes;

SELECT * FROM Carros;

SELECT * FROM Clientes WHERE Endereco NOT LIKE 'Rua A';

SELECT * FROM Carros WHERE Ano BETWEEN 2000 AND 2010;

SELECT * FROM Carros WHERE Marca IN ('Ferrari', 'Chevrolet', 'Ford', 'Fiat');

SELECT * FROM Carros WHERE Modelo LIKE '%Palio%';