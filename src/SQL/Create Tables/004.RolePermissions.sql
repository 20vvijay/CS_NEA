-- RolePermissions -----------------------------------------------------------
-- Resolves the many-to-many between Roles and Permissions. Both foreign keys
-- cascade so deleting a role or a permission cannot leave an orphaned grant.
-- ---------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS RolePermissions
(
    roleId       INT UNSIGNED NOT NULL,
    permissionId INT UNSIGNED NOT NULL,

    PRIMARY KEY (roleId, permissionId),
    KEY ix_RolePermissions_permissionId (permissionId),
    CONSTRAINT fk_RolePermissions_Roles
        FOREIGN KEY (roleId) REFERENCES Roles (roleId) ON DELETE CASCADE,
    CONSTRAINT fk_RolePermissions_Permissions
        FOREIGN KEY (permissionId) REFERENCES Permissions (permissionId) ON DELETE CASCADE
) ENGINE = InnoDB
  DEFAULT CHARSET = utf8mb4
  COLLATE = utf8mb4_unicode_ci;
