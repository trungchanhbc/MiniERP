CREATE 	DATABASE 		MiniERP 
		CHARACTER SET 	UTF8MB4
		COLLATE 		utf8mb4_unicode_ci;
    
USE MiniERP;

CREATE TABLE Supplier (
    Id INT NOT NULL,
    Name VARCHAR(200) NOT NULL,
    Address TEXT,
    Contractor VARCHAR(100),
    Phone VARCHAR(20),
    Email VARCHAR(200),
    UNIQUE KEY (Id),
    PRIMARY KEY (Id)
);

CREATE TABLE Unit (
    Id INT NOT NULL AUTO_INCREMENT,
    Name VARCHAR(45) NOT NULL,
    UNIQUE KEY (Id),
    PRIMARY KEY (Id)
);

CREATE TABLE CustomsDeclaration (
    Code VARCHAR(30) NOT NULL,
    OpenDate DATE NOT NULL,
    GoodsArrivalDate DATE NOT NULL,
    InputDate DATE,
    UNIQUE KEY (Code),
    PRIMARY KEY (Code)
);

CREATE TABLE RawMaterialInfo (
    Code VARCHAR(30) NOT NULL,
    Name VARCHAR(200) NOT NULL,
    UnitId INT NOT NULL,
    UNIQUE KEY (Code),
    PRIMARY KEY (Code),
    FOREIGN KEY (UnitId)
        REFERENCES Unit (Id)
);

CREATE TABLE RawMaterial (
    Code VARCHAR(30) NOT NULL,
    HSCode VARCHAR(30),
    ImportPrice DECIMAL(20 , 10 ),
    ExportPrice DECIMAL(20 , 10 ),
    ExchangeRate DECIMAL(20 , 10 ),
    Tax DECIMAL(10 , 10 ),
    Quantity DECIMAL(20 , 10 ) NOT NULL,
    CustomsDeclarationCode VARCHAR(30),
    UNIQUE KEY (Code),
    PRIMARY KEY (Code),
    FOREIGN KEY (Code)
        REFERENCES RawMaterialInfo (Code),
    FOREIGN KEY (CustomsDeclarationCode)
        REFERENCES CustomsDeclaration (Code)
);

CREATE TABLE Formula (
    Code VARCHAR(30) NOT NULL,
    RawMaterialCode VARCHAR(30) NOT NULL,
    OriginalConsumed DECIMAL(20 , 10 ) NOT NULL,
    LossRate DECIMAL(10 , 10 ) NOT NULL,
    ActualConsumed DECIMAL(20 , 10 ) NOT NULL,
    SupplierId INT,
    PRIMARY KEY (Code),
    FOREIGN KEY (RawMaterialCode)
        REFERENCES RawMaterialInfo (Code),
    FOREIGN KEY (SupplierId)
        REFERENCES Supplier (Id)
);

CREATE TABLE FinishGood (
    Code VARCHAR(30) NOT NULL,
    Name VARCHAR(200) NOT NULL,
    HSCode VARCHAR(30),
    FormulaCode VARCHAR(30) NOT NULL,
    Quantity DECIMAL(20 , 10 ) NOT NULL,
    CustomerName VARCHAR(200),
    Po VARCHAR(100),
    Invoice VARCHAR(200),
    Date DATE,
    UNIQUE KEY (Code),
    PRIMARY KEY (Code),
    FOREIGN KEY (FormulaCode)
        REFERENCES Formula (Code)
);

