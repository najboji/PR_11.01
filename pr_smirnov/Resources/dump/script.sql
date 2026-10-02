create database pr33_smirnov;
use pr33_smirnov;
create table Role
(
  RoleID int primary key auto_increment,
  RoleName varchar(100) not null
);
create table User
(
  UserID int primary key auto_increment,
  UserSurname varchar(100) not null,
  UserName varchar(100) not null,
  UserPatronymic varchar(100) null,
  UserLogin varchar(100) not null,
  UserPassword varchar(100) not null,
  UserRole int not null,
  foreign key (UserRole) references Role(RoleID) 
);
create table ProductCategory
(
  ProductCategoryID int primary key auto_increment,
  ProductCategoryName varchar(100) not null
);
create table ProductSupplier
(
  ProductSupplierID int primary key auto_increment,
  ProductSupplierName varchar(100) not null
);
create table ProductManufacturer
(
  ProductManufacturerID int primary key auto_increment,
  ProductManufacturerName varchar(100) not null
);
create table Product
(
  ProductArticleNumber varchar(6) primary key,
  ProductName varchar(50) not null,
  ProductUnits varchar(5) not null,
  ProductCost decimal(7,2) not null,
  ProductMaxDiscountAmount int not null,
  ProductManufacturer int not null,
  foreign key (ProductManufacturer) references ProductManufacturer(ProductManufacturerID),
  ProductSupplier int not null,
  foreign key (ProductSupplier) references ProductSupplier(ProductSupplierID),
  ProductCategory int not null,
  foreign key (ProductCategory) references ProductCategory(ProductCategoryID),
  ProductDiscountAmount int not null,
  ProductQuantityInStock int not null,
  ProductDescription text not null,
  ProductPhoto blob not null
);
create table OrderPickupPoint
(
  OrderPickupPointID int primary key auto_increment,
  OrderPickupPointName text not null
);
create table `Order`
(
  OrderID int primary key auto_increment,
  OrderDate date not null,
  OrderDeliveryDate date not null,
  OrderPickupPoint int not null,
  foreign key (OrderPickupPoint) references OrderPickupPoint(OrderPickupPointID),
  FIO varchar(300) not null,
  OrderCode int not null,
  OrderStatus text not null
);
create table OrderProduct
(
  OrderProductID int primary key not null,
  OrderID int not null,
  foreign key (OrderID) references `Order`(OrderID),
  ProductArticleNumber varchar(6)  not null,
  foreign key (ProductArticleNumber) references Product(ProductArticleNumber),
  ProductCount int not null
);