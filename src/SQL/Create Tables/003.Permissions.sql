-- Permissions ---------------------------------------------------------------
-- A single thing the system lets somebody do, named in dotted form such as
-- 'stock.adjust' or 'orders.place'. Pages and handlers check for a permission,
-- never for a role, so adding a role never means editing authorisation code.
-- ---------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS Permissions
(
    permissionId   INT UNSIGNED NOT NULL AUTO_INCREMENT,
    permissionName VARCHAR(60)  NOT NULL,
    description    VARCHAR(255) NULL,

    PRIMARY KEY (permissionId),
    UNIQUE KEY ux_Permissions_permissionName (permissionName)
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_unicode_ci;
