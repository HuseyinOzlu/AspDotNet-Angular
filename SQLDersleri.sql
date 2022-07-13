--Select
--ANSII 
Select ContactName adi,CompanyName Sirketadi,City Sehir from Customers; -- Bu bir tablo Türkçe hali alias ekledik

Select * from Customers where City = 'London'; -- sehri sadece londra olanları getirir

--case insensitive 
sElEcT * from Products where categoryId=1 or CategoryID=3 -- categoryid si 1 ve 3 ü getiriyor
--aPaChE sTyLe
sElEcT * from Products where categoryId=1 and unitPrice>=10 -- categoryid si 1 ve unitprice ı 10 dan büyük olanları getiriyor

select * from Products order by ProductName -- ürün ismine göre sırala

select * from Products order by CategoryId, ProductName
-- categoryId ye göre sıralar categoryId ise ProductName e göre sıralar
select * from Products order by UnitPrice asc --ascending
select * from Products order by UnitPrice desc -- asc nin tersi descending

select * from Products where categoryId=1 order by UnitPrice desc -- kategori id si 1 olan ürünleri unitprice göre ters biçimde sıralar

Select count(*) from Products -- kaç tane ürün oldugunu yazdi

SELECT categoryId, count(*) from products group by CategoryID --her bir kategoride kaç ürün oldugunu yazar
-- !!! group by kullandıgın ifadeyi select te göstermen lazım

SELECT categoryId, count(*) from Products group by CategoryID having count(*)<10
-- bana içinden 10 taneden az kalan yeri veriyor

SELECT categoryId, count(*) from Products where UnitPrice>20 group by CategoryID having count(*)<10
-- sayisi 10 dan az olan fiyatı 20 den büyük olan ürünleri sıralar

Select Products.ProductID, Products.ProductName, Products.UnitPrice, Categories.CategoryName 
from Products inner join Categories 
on Products.CategoryID = Categories.CategoryID
where Products.UnitPrice > 10
-- from'a hem products ile Categorisi birleştirip götürür on ise ürünlerdeki categori ile katogorideki ürünlerin sayısı eşit ise getir diyor
-- where de ise unitprice ı 10dan büyük olsn ürünleri categoriesi ile birleştirir

---DTO Data Transformation Object
Select * from Products p inner join [Order Details] od
 on p.ProductID = od.ProductID
-- inner join sadece eşleşen ürünleri gettirir (kesişim kümesi 
Select * from Products p left join [Order Details] od
 on p.ProductID = od.ProductID

-- solda olup sağda olmayanlarıda getir demek
-- inner joinları istediğin kadar kullan

Select * from Customers c left join Orders o
on c.CustomerID = o.CustomerID 
where o.CustomerID is null -- primarykeye uygulanır
-- sol ile sağın farkını getirir ||| right join de tam tersini yapar




