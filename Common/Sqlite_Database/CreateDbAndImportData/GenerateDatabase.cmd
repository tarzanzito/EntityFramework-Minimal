rem @echo off
cls

rem delete file
del DB-Products_no_indexes.sqlite

rem create empty file
copy nul DB-Products_no_indexes.sqlite

rem create tables
sqlite3 DB-Products_no_indexes.sqlite ".read CategoryGroups.sql"
sqlite3 DB-Products_no_indexes.sqlite ".read Categories.sql"
sqlite3 DB-Products_no_indexes.sqlite ".read Products.sql"

rem import data from csv
sqlite3 DB-Products_no_indexes.sqlite ".import CategoryGroups.csv CategoryGroups --csv --skip 1 -v"
sqlite3 DB-Products_no_indexes.sqlite ".import Categories.csv Categories --csv --skip 1 -v"
sqlite3 DB-Products_no_indexes.sqlite ".import Products.csv Products --csv --skip 1 -v"

pause


rem import from sqlite3
rem ---------------------------------------------------------
rem sqlite3
rem .open DB-Products_no_indexes.sqlite
rem .separator ,  or .separator ','
rem .mode csv
rem .import Products.csv Products --csv --skip 1 -v

rem export from sqlite3
rem ----------------------------------------------------
rem sqlite3
rem .open DB-Products_no_indexes.sqlite
rem .headers on
rem .mode csv
rem .once c:/work/dataout.csv
rem SELECT * FROM tab1;
rem .system c:/work/dataout.csv

-------------------------------------------------------
