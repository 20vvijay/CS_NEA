-- Drop Permissions ----------------------------------------------------------
-- Numbered so the drop set runs in the exact reverse of the create set, which
-- means no table is ever dropped while another still points a foreign key at it.
-- ---------------------------------------------------------------------------
DROP TABLE IF EXISTS Permissions;
