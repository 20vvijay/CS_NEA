CREATE Table RolePermissions
(
    roleId int,
    permissionId int,
    FOREIGN KEY roleId REFERENCES Roles(roleId),
    FOREIGN KEY permissionId REFERENCES Permissions(permissionId),
    PRIMARY KEY (roleId, permissionId)
);