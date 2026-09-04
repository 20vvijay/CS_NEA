-- Roles ---------------------------------------------------------------------
-- Three people run the shop, so three roles. Owner and Manager are separated
-- because ordering was handed to staff over time while the accounts were not.
-- INSERT IGNORE against the unique name makes this safe to run repeatedly.
-- ---------------------------------------------------------------------------
INSERT IGNORE INTO Roles (roleName)
VALUES ('Owner'),
       ('Manager'),
       ('Employee');
