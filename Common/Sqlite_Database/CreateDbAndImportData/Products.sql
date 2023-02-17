CREATE TABLE Products (
    Id         INTEGER PRIMARY KEY AUTOINCREMENT,
    Guid       TEXT    NOT NULL,
    Name       TEXT    NOT NULL,
    Price      INTEGER NOT NULL,
    Validation TEXT    NOT NULL,
    CategoryId INTEGER NOT NULL
);
