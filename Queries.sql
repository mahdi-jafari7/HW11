--Query 2
SELECT NAME , Price
From Products
where Price>500

--Query 3
SELECT 
    YEAR(OrderDate) AS OrderYear,
    SUM(TotalAmount) AS TotalOrderAmount
FROM 
    Orders
GROUP BY 
    YEAR(OrderDate)
ORDER BY 
    OrderYear;

-- Query 4
SElect c.Name, SUM(o.TotalAmount)
From Orders o
Join Categories c ON o.Id = c.Id
group by c.Name

-- Query 5
select p.Name, p.Price 
From Products p
Order by(Price) desc

-- Query 6

select c.Name, COUNT(o.CustomerId) as OrderCount
from Customers c
left join Orders o On c.id = o.CustomerId
group by o.CustomerId, c.Name


-- Query 7

select c.NAME , AVG(p.Price) as AeragePrice
from Categories c
join Products p ON c.Id = p.CategoryId
group by c.Name

-- Query 8

select p.Name , c.Name as category
from Products p
 join Categories c On c.Id = p.Id

 -- Query 9

select c.Name , SUM(o.TotalAmount) as TotalOrdersIn2023
from Orders o
join Categories c ON c.Id = o.Id
where YEAR(o.OrderDate) = 2023
group by (c.Name)


-- Query 10

select MONTH(o.Orderdate), Count(MONTH(o.Orderdate))
from Orders o
group by MONTH(o.Orderdate)


-- Query 11

select c.Name , SUM(o.TotalAmount) as TotalPriceOrder
from Customers c 
join Orders o ON c.id = o.CustomerId
group by c.Name 


--Query 12

select c.Name ,  COUNT(o.Id) as OrderCount

from Orders o 
join Products p ON o.ProductId =  p.Id 
join Categories c ON p.CategoryId = c.Id

GROUP BY c.Name;

-- Query 13

select c.name , Count(o.CustomerId) OrdersCount
from Customers c
join Orders o On c.id = o.CustomerId
group by c.Name 
order by COUNT (o.CustomerId) desc


-- Query 14

SELECT 
    YEAR(o.OrderDate) AS OrderYear,
    COUNT(o.Id) AS OrderCount
FROM 
    Orders o
GROUP BY 
    YEAR(o.OrderDate)
ORDER BY 
    OrderYear;



-- Query 15

SELECT 
    p.Name,
    COUNT(DISTINCT o.CustomerID) AS BuyerCount
FROM 
    Orders o
JOIN 
    Products p ON o.ProductID = p.Id
GROUP BY 
    p.Name
ORDER BY 
    BuyerCount DESC;
