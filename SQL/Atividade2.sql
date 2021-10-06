Use Atividades2

SELECT * 
FROM Fipe2;

SELECT * 
FROM Fipe2 
WHERE cod_fipe LIKE '%-3';

SELECT * 
FROM Fipe2 
WHERE (cod_fipe LIKE '%-2' AND des_marca IN ('Honda', 'Toyota') AND tipo_veiculo = 1)
ORDER BY des_marca ASC;

SELECT * FROM Fipe2 
WHERE (tipo_veiculo = 3  AND des_marca LIKE 'A%') OR (tipo_veiculo = 1 AND des_marca = 'Volkswagen') 
ORDER BY cod_fipe ASC;

SELECT * 
FROM Fipe2 
WHERE  cod IS NULL or cod_fipe IS NULL;

SELECT TOP (5) * 
FROM Fipe2 
WHERE tipo_veiculo IN (2,3) AND des_marca = 'Volkswagen' ORDER BY des_modelo desc;

SELECT DISTINCT des_marca 
FROM Fipe2 
WHERE cod_fipe IS NOT NULL;
