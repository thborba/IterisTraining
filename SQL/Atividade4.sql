Use Atividade3

SELECT Nome, COUNT(*) as qtd 
FROM Duplicados 
GROUP BY Nome;

SELECT * 
FROM Veiculos as v 
INNER JOIN Anuncios as a ON v.cod =  a.[Id Carro] 
WHERE a.[Id Cliente] = 1;

SELECT COUNT(*) as qtd 
FROM Anuncios 
GROUP BY [Id Cliente];

SELECT preco_medio 
FROM Veiculos as v 
INNER JOIN Anuncios as a ON v.cod =  a.[Id Carro] 
WHERE a.[Id Cliente] = 3;
-- ou SELECT preco FROM Anuncios WHERE [Id Cliente] = 3;

SELECT * 
FROM Clientes 
WHERE Id NOT IN (SELECT [Id Cliente] FROM Anuncios);

SELECT c.Id, c.Nome, SUM(a.Preco) as valor 
FROM Clientes as c
LEFT JOIN Anuncios as a ON c.Id =  a.[Id Cliente] 
GROUP BY c.Id, c.Nome 
ORDER BY SUM(a.Preco);

SELECT * FROM 
Anuncios 
WHERE Descricao IS NULL;

SELECT c.Nome, v.des_fipe
FROM Anuncios as a
INNER JOIN Clientes as c ON c.Id = a.[Id Cliente]
INNER JOIN Veiculos as v ON v.cod = a.[Id Carro]
WHERE a.Descricao IS NULL;

SELECT * 
FROM Anuncios 
WHERE Preco IS NULL;

UPDATE Anuncios 
SET Preco = (SELECT preco_medio 
			FROM Veiculos 
			WHERE Anuncios.[Id Carro] = Veiculos.cod)
WHERE Preco IS NULL;
