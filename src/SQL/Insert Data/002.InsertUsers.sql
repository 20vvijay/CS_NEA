-- Users ---------------------------------------------------------------------
-- A single starting account so the system can be signed into at all. The hash
-- is PBKDF2-SHA256, 100,000 iterations, 32-byte key, over the 16-byte salt in
-- the row next to it, both base64. The development password is StockRoute!2026
-- and it must be changed before this ever runs anywhere real.
-- roleId is looked up by name rather than hard coded, so the seed does not
-- break if the roles were inserted in a different order.
-- ---------------------------------------------------------------------------
INSERT IGNORE INTO Users (username, forename, surname, passwordHash, salt, isActive, roleId)
VALUES ('Vishaka',
        'Vishaka',
        NULL,
        'u7vbHCrpmhevkU2LsjyF5zHYNdwhbA7WcXHdZoi6yuI=',
        'l+vUCMAtWPrN8evzr170kg==',
        TRUE,
        (SELECT roleId FROM Roles WHERE roleName = 'Owner'));
