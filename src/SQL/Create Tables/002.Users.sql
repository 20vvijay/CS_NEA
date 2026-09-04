-- Users ---------------------------------------------------------------------
-- A person who can sign in. No plaintext password is ever stored: salt holds a
-- per-user random salt and passwordHash the PBKDF2-SHA256 derived key, both
-- base64 encoded. The columns are sized for a 16-byte salt and 32-byte key with
-- headroom; a VARCHAR(30) would silently truncate the hash and break sign-in.
-- ---------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS Users
(
    userId       CHAR(36)     NOT NULL DEFAULT (UUID()),
    username     VARCHAR(30)  NOT NULL,
    forename     VARCHAR(50)  NULL,
    surname      VARCHAR(50)  NULL,
    emailAddress VARCHAR(255) NULL,
    passwordHash VARCHAR(128) NOT NULL,
    salt         VARCHAR(64)  NOT NULL,
    isActive     BOOLEAN      NOT NULL DEFAULT TRUE,
    roleId       INT UNSIGNED NOT NULL,
    createdUtc   DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
    lastLoginUtc DATETIME     NULL,

    PRIMARY KEY (userId),
    UNIQUE KEY ux_Users_username (username),
    KEY ix_Users_roleId (roleId),
    CONSTRAINT fk_Users_Roles
        FOREIGN KEY (roleId) REFERENCES Roles (roleId)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_unicode_ci;
