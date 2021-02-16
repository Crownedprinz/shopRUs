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


CREATE TABLE Tbl_InvoiceItems (
    id         INTEGER PRIMARY KEY,
    productsId INTEGER,
    invoicesId INTEGER,
    quantity   INTEGER,
    unitPrice  DECIMAL,
    isGrocery  BOOLEAN NOT NULL
                       DEFAULT (0) 
);


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


CREATE TABLE Tbl_Products (
    id       INTEGER       PRIMARY KEY,
    product  VARCHAR (100),
    amount   DECIMAL,
    category VARCHAR (50) 
);
INSERT INTO Tbl_Products (id, product, amount, category) VALUES (1, 'airpods max pro 2', 120000, 'devices');
INSERT INTO Tbl_Products (id, product, amount, category) VALUES (2, 'cashew nuts pack', 5000, 'grocery');



--Data