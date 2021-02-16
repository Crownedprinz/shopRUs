--Table Scripts
CREATE TABLE Tbl_Customer (
    id          INTEGER       PRIMARY KEY
                              NOT NULL,
    fullName    VARCHAR (100),
    address     VARCHAR (100),
    isAffiliate BOOLEAN       NOT NULL
                              DEFAULT (0),
    isEmployee  BOOLEAN       NOT NULL
                              DEFAULT (0),
    timestamp   TIMESTAMP     NOT NULL
                              DEFAULT (CURRENT_TIMESTAMP) 
);

INSERT INTO Tbl_Customer (id, fullName, address, isAffiliate, isEmployee, timestamp) VALUES (1, 'Chukwukaelor Okafor', 'Kaduna', 1, 0, '2021-02-15 21:43:16');
INSERT INTO Tbl_Customer (id, fullName, address, isAffiliate, isEmployee, timestamp) VALUES (2, 'John Ademola', 'Lagos', 1, 1, '2018-02-15 21:43:16');
INSERT INTO Tbl_Customer (id, fullName, address, isAffiliate, isEmployee, timestamp) VALUES (3, 'Wilson Aku', 'Porthacourt', 0, 1, '2021-02-15 21:43:16');
INSERT INTO Tbl_Customer (id, fullName, address, isAffiliate, isEmployee, timestamp) VALUES (4, 'Charity Olong', 'Abuja', 0, 0, '2018-02-15 21:43:16');


CREATE TABLE Tbl_Discounts (
    id         INTEGER      PRIMARY KEY
                            NOT NULL,
    type       VARCHAR (30) NOT NULL
                            UNIQUE,
    percentage DECIMAL
);


INSERT INTO Tbl_Discounts (id, type, percentage) VALUES (1, 'affiliate', 10);
INSERT INTO Tbl_Discounts (id, type, percentage) VALUES (2, 'employee', 30);
INSERT INTO Tbl_Discounts (id, type, percentage) VALUES (3, 'loyalty', 5);


CREATE TABLE Tbl_Products (
    id       INTEGER       PRIMARY KEY,
    product  VARCHAR (100),
    amount   DECIMAL,
    category VARCHAR (50) 
);
INSERT INTO Tbl_Products (id, product, amount, category) VALUES (1, 'airpods max pro 2', 120000, 'devices');
INSERT INTO Tbl_Products (id, product, amount, category) VALUES (2, 'cashew nuts pack', 5000, 'grocery');




CREATE TABLE Tbl_Invoices (
    id                     INTEGER   PRIMARY KEY,
    customerId             INTEGER,
    discountsId            INTEGER,
    billDiscountPercentage INTEGER,
    billDiscountAmount     DECIMAL,
    totalDiscountAmount    DECIMAL,
    totalProductsAmount    DECIMAL,
    subTotal               DECIMAL,
    totalAmount            DECIMAL,
    issueDate              TIMESTAMP DEFAULT (CURRENT_TIMESTAMP) 
                                     NOT NULL,
    modifiedDate           TIMESTAMP DEFAULT (CURRENT_TIMESTAMP) 
);

INSERT INTO Tbl_Invoices (id, customerId, discountsId, billDiscountPercentage, billDiscountAmount, totalDiscountAmount, totalProductsAmount, subTotal, totalAmount, issueDate, modifiedDate) VALUES (1, 2, 0, 5, 60250, 421750, 1205000, NULL, 783250, '0001-01-01 00:00:00', '2021-02-16 12:08:17');
INSERT INTO Tbl_Invoices (id, customerId, discountsId, billDiscountPercentage, billDiscountAmount, totalDiscountAmount, totalProductsAmount, subTotal, totalAmount, issueDate, modifiedDate) VALUES (2, 2, 0, 5, 1250, 8750, 25000, NULL, 16250, '2021-02-16 13:17:41.0095026', '2021-02-16 12:17:41');
INSERT INTO Tbl_Invoices (id, customerId, discountsId, billDiscountPercentage, billDiscountAmount, totalDiscountAmount, totalProductsAmount, subTotal, totalAmount, issueDate, modifiedDate) VALUES (3, 1, 0, 5, 120000, 360000, 2400000, NULL, 2040000, '2021-02-16 13:43:28.4336765', '2021-02-16 12:43:32');
INSERT INTO Tbl_Invoices (id, customerId, discountsId, billDiscountPercentage, billDiscountAmount, totalDiscountAmount, totalProductsAmount, subTotal, totalAmount, issueDate, modifiedDate) VALUES (4, 3, 0, 5, 1750, 12250, 35000, NULL, 22750, '2021-02-16 13:44:01.6599682', '2021-02-16 12:44:01');
INSERT INTO Tbl_Invoices (id, customerId, discountsId, billDiscountPercentage, billDiscountAmount, totalDiscountAmount, totalProductsAmount, subTotal, totalAmount, issueDate, modifiedDate) VALUES (5, 4, 0, 5, 92500, 185000, 1850000, NULL, 1665000, '2021-02-16 13:44:28.4536495', '2021-02-16 12:44:28');

CREATE TABLE Tbl_InvoiceItems (
    id         INTEGER PRIMARY KEY,
    productsId INTEGER,
    invoicesId INTEGER,
    quantity   INTEGER,
    unitPrice  DECIMAL,
    isGrocery  BOOLEAN NOT NULL
                       DEFAULT (0) 
);

INSERT INTO Tbl_InvoiceItems (id, productsId, invoicesId, quantity, unitPrice, isGrocery) VALUES (1, 1, 1, 10, 120000, 0);
INSERT INTO Tbl_InvoiceItems (id, productsId, invoicesId, quantity, unitPrice, isGrocery) VALUES (2, 2, 1, 1, 5000, 1);
INSERT INTO Tbl_InvoiceItems (id, productsId, invoicesId, quantity, unitPrice, isGrocery) VALUES (3, 2, 2, 5, 5000, 1);
INSERT INTO Tbl_InvoiceItems (id, productsId, invoicesId, quantity, unitPrice, isGrocery) VALUES (4, 1, 3, 20, 120000, 0);
INSERT INTO Tbl_InvoiceItems (id, productsId, invoicesId, quantity, unitPrice, isGrocery) VALUES (5, 2, 4, 7, 5000, 1);
INSERT INTO Tbl_InvoiceItems (id, productsId, invoicesId, quantity, unitPrice, isGrocery) VALUES (6, 1, 5, 15, 120000, 0);
INSERT INTO Tbl_InvoiceItems (id, productsId, invoicesId, quantity, unitPrice, isGrocery) VALUES (7, 2, 5, 10, 5000, 1);


