CREATE TABLE Users
(
    userId CHAR(36) NOT NULL DEFAULT (UUID()) PRIMARY KEY,
    username VARCHAR(30),
    passwordHash VARCHAR(30),
    salt VARCHAR(30),
    isActive BOOLEAN,
    roleId INT,
    FOREIGN KEY (roleId) REFERENCES Roles(roleId)
);
