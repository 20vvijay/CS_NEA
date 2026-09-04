-- Roles ---------------------------------------------------------------------
-- A job role a user can hold. Roles carry permissions (see RolePermissions),
-- so access is granted to a role rather than to an individual person.
-- ---------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS Roles
(
    roleId   INT UNSIGNED NOT NULL AUTO_INCREMENT,
    roleName VARCHAR(45)  NOT NULL,

    PRIMARY KEY (roleId),
    UNIQUE KEY ux_Roles_roleName (roleName)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_unicode_ci;
