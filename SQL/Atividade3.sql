Use Atividades2

SELECT COUNT(*) as qtd 
FROM Fipe2 
WHERE des_marca = 'Ferrari';

SELECT COUNT(*) as qtd 
FROM Fipe2 
WHERE des_marca IN ('Ford', 'Toyota');

SELECT SUM(preco_medio) as valor_total 
FROM Fipe2 
WHERE des_modelo LIKE '%Fiesta%';

SELECT AVG(preco_medio) as media 
FROM Fipe2 
WHERE preco_medio > 50.00 and des_modelo LIKE '%Gol%';

SELECT TOP(10) des_modelo1 
FROM Fipe2 
WHERE des_marca IN ('Toyota', 'Volkswagen') 
GROUP BY des_modelo1 
ORDER BY SUM(preco_medio) DESC;

SELECT SUM(preco_medio) as soma 
FROM Fipe2 
GROUP BY des_modelo1 
HAVING SUM(preco_medio) > 500000 
ORDER BY soma DESC;