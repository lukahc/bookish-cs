CREATE TABLE UsersTable (
	UserID SERIAL PRIMARY KEY,
	UserName TEXT,
	UserPass TEXT
);
CREATE TABLE BooksTable (
	ISBN SERIAL PRIMARY KEY,
	Title TEXT,
	Author TEXT,
	TotalCopies int
);
CREATE TABLE BooksBorrowed (
	CopyID SERIAL PRIMARY KEY,
	UserID int,
	ISBN int,
	ReturnDate TEXT,
    CONSTRAINT userCon
        FOREIGN KEY(UserId) 
	        REFERENCES UsersTable(UserID),
	CONSTRAINT bookCon
        FOREIGN KEY(ISBN)
            REFERENCES BooksTable(ISBN)
);