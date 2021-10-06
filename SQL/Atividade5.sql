Use Atividade3

ALTER TABLE Clientes 
ADD DataNascimento DATE null

UPDATE Clientes
SET DataNascimento = 
	(CASE 
		WHEN (ABS(Id - MONTH(GETDATE())) > 0) THEN DATEFROMPARTS(ABS(Idade - YEAR(GETDATE())), Id, ABS(Id - DAY(GETDATE())))
		ELSE DATEFROMPARTS(ABS(Idade - YEAR(GETDATE())), Id, ABS(Id - DAY(GETDATE())) + 1 )
	END);  

SELECT DATEFROMPARTS(
		YEAR(DataNascimento), 
		MONTH(DataNascimento) + 1,
		1
	)
FROM Clientes

SELECT DATEDIFF(DAY, DataNascimento, GETDATE()) 
FROM Clientes 
WHERE Id = 1 OR Id = 2;

SELECT DATEDIFF(MONTH, DataNascimento, GETDATE()) 
FROM Clientes 
WHERE Id = 1 OR Id = 2;

SELECT DATEDIFF(YEAR, DataNascimento, GETDATE()) 
FROM Clientes 
WHERE Id = 1 OR Id = 2;

ALTER TABLE Veiculos 
ALTER COLUMN tipo_veiculo NVARCHAR(20) null;

UPDATE Veiculos 
SET tipo_veiculo = 
	(CASE 
		WHEN (tipo_veiculo = 1) THEN 'Carro' 
		WHEN (tipo_veiculo = 2) THEN 'Moto' 
		WHEN (tipo_veiculo = 3) THEN 'Caminhão'
	END);  

SELECT c.Nome, v.des_modelo, a.Preco, CONCAT(c.Nome, ' ',A.Descricao,' ', A.Preco) 
FROM Clientes as c
INNER JOIN Anuncios as a ON c.Id = a.[Id Cliente]
INNER JOIN Veiculos as v ON v.cod = a.[Id Carro]
WHERE a.Preco > 250000 AND v.des_marca = 'Ford'

ALTER TABLE Veiculos
ADD Descricao nvarchar(255) null;

UPDATE Veiculos
SET 
	Descricao = CONCAT(c.Nome, ' - ',A.Descricao,' - ', A.Preco) 
FROM
	Clientes as c
	INNER JOIN Anuncios as a ON c.Id = a.[Id Cliente]
	INNER JOIN Veiculos as v ON v.cod = a.[Id Carro]
WHERE 
	cod = v.cod;

