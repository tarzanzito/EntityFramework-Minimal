
DROP TABLE Products;
DROP TABLE Categories;
DROP TABLE CategoryGroups

//DROP INDEX Index_CategoryGroups_Name;

--------------------------------------------------------

CREATE TABLE CategoryGroups (
    Id   INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT    NOT NULL
);

CREATE UNIQUE INDEX Index_CategoryGroups_Id ON CategoryGroups (
    Id ASC
);


CREATE UNIQUE INDEX Index_CategoryGroups_Name ON CategoryGroups (
    Name ASC
);

----------------------------------------------------

CREATE TABLE Categories (
    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
    Name            TEXT    NOT NULL,
    CategoryGroupId INTEGER NOT NULL
);


CREATE UNIQUE INDEX Index_Categories_Id ON Categories (
    Id ASC
);

CREATE UNIQUE INDEX Index_Categories_Name ON Categories (
    Name ASC
);

CREATE UNIQUE INDEX Index_Categories_CategoryGroupId_Id ON Categories (
    CategoryGroupId ASC,
    Id ASC
);

CREATE UNIQUE INDEX Index_Categories_CategoryGroupId_Name ON Categories (
    CategoryGroupId ASC,
    Name ASC
);

-------------------------------------------------------------------

CREATE TABLE Products (
    Id         INTEGER PRIMARY KEY AUTOINCREMENT,
    Guid       TEXT    NOT NULL,
    Name       TEXT    NOT NULL,
    Price      INTEGER NOT NULL,
    Validation TEXT    NOT NULL,
    CategoryId INTEGER NOT NULL
);

CREATE UNIQUE INDEX Index_Products_Id ON Products (
    Id ASC
);

CREATE UNIQUE INDEX Index_Products_Guid ON Products (
    Guid ASC
);

CREATE UNIQUE INDEX Index_Products_Name ON Products (
    Name ASC
);

CREATE UNIQUE INDEX Index_Products_CategoryId_Id ON Products (
    CategoryId ASC,
    Id ASC
);

CREATE UNIQUE INDEX Index_Products_CategoryId_Guid ON Products (
    CategoryId ASC,
    Guid ASC
);

CREATE UNIQUE INDEX Index_Products_CategoryId_Name ON Products (
    CategoryId ASC,
    Name ASC
);

----------------------------------------------------
SQLite Foreign key constraint 
- constraint without name
CREATE TABLE track(
  trackid     INTEGER, 
  trackname   TEXT, 
  trackartist INTEGER,
  FOREIGN fk_child_parent KEY(trackartist) REFERENCES artist(artistid)
);

- with constraint name
CREATE TABLE track (
    trackid   INTEGER,
    trackname TEXT,
    productId INTEGER,
    CONSTRAINT fk__song_album FOREIGN KEY(productId) REFERENCES Products (Id) 
);


SQLite UNIQUE constraint
CREATE TABLE track(
  trackid     INTEGER, 
  trackname   TEXT UNIQUE, 
  trackartist INTEGER
);

CREATE TABLE track (
    trackid   INTEGER,
    trackname TEXT,
    productId INTEGER,
    FOREIGN fk_xpto KEY (
        productId
    )
    REFERENCES Products (Id) 
);
