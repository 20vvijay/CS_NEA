-- Permissions ---------------------------------------------------------------
-- Named in dotted form so they read as a sentence at the call site, and split
-- finely enough that an employee can be trusted to receive a delivery without
-- also being able to write off stock - the adjustment that hides a theft.
-- ---------------------------------------------------------------------------
INSERT IGNORE INTO Permissions (permissionName, description)
VALUES ('products.view', 'View the product catalogue'),
       ('products.manage', 'Add, edit and retire products'),
       ('stock.view', 'View stock levels and batches'),
       ('stock.count', 'Carry out a stock count'),
       ('stock.adjust', 'Adjust stock levels outside a count'),
       ('suppliers.view', 'View suppliers and their prices'),
       ('suppliers.manage', 'Add and edit suppliers and accounts'),
       ('prices.record', 'Record supplier prices and promotions'),
       ('orders.view', 'View purchase orders'),
       ('orders.place', 'Place and amend purchase orders'),
       ('deliveries.receive', 'Book in a delivery'),
       ('deliveries.claim', 'Raise and settle delivery claims'),
       ('trips.plan', 'Plan shopping trips and routes'),
       ('losses.record', 'Record theft, damage and wastage'),
       ('losses.report', 'View loss and shrinkage reporting'),
       ('seasonal.plan', 'Plan seasonal and occasion stock'),
       ('alerts.view', 'View alerts'),
       ('alerts.manage', 'Acknowledge and resolve alerts'),
       ('users.manage', 'Manage users and their roles');
