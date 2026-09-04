-- RolePermissions -----------------------------------------------------------
-- The owner gets everything. A manager gets everything operational but not
-- user administration. An employee can see stock and receive deliveries, and
-- can count, but cannot adjust a level or place an order on their own.
-- Both sides are looked up by name so the grants survive any id ordering.
-- ---------------------------------------------------------------------------
INSERT IGNORE INTO RolePermissions (roleId, permissionId)
SELECT r.roleId, p.permissionId
FROM Roles r
         CROSS JOIN Permissions p
WHERE r.roleName = 'Owner';

INSERT IGNORE INTO RolePermissions (roleId, permissionId)
SELECT r.roleId, p.permissionId
FROM Roles r
         JOIN Permissions p ON p.permissionName <> 'users.manage'
WHERE r.roleName = 'Manager';

INSERT IGNORE INTO RolePermissions (roleId, permissionId)
SELECT r.roleId, p.permissionId
FROM Roles r
         JOIN Permissions p ON p.permissionName IN ('products.view',
                                                    'stock.view',
                                                    'stock.count',
                                                    'suppliers.view',
                                                    'prices.record',
                                                    'orders.view',
                                                    'deliveries.receive',
                                                    'alerts.view')
WHERE r.roleName = 'Employee';
