DELETE FROM reservation;
DELETE FROM site;
DELETE FROM campground;
DELETE FROM park;


SET IDENTITY_INSERT park ON;
INSERT INTO park (park_id, name, location, establish_date, area, visitors, description) VALUES (1, 'Park', 'Ohio', '2018-01-01', 10000, 2, 'Description');
INSERT INTO park (park_id, name, location, establish_date, area, visitors, description) VALUES (2, 'Other Park', 'Florida', '2018-02-01', 4500, 9382, 'Description 2');
SET IDENTITY_INSERT park OFF;

SET IDENTITY_INSERT campground ON;
INSERT INTO campground (campground_id, park_id, name, open_from_mm, open_to_mm, daily_fee) VALUES (1, 1, 'Test campground', '1', '12', '45.00');
INSERT INTO campground (campground_id, park_id, name, open_from_mm, open_to_mm, daily_fee) VALUES (2, 2, 'Test campground', '4', '6', '75.00');
INSERT INTO campground (campground_id, park_id, name, open_from_mm, open_to_mm, daily_fee) VALUES (3, 2, 'Test campground', '5', '9', '50.00');
SET IDENTITY_INSERT campground OFF;

SET IDENTITY_INSERT site ON;
INSERT INTO site (site_id, campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities) VALUES (1, 1, 1, '10', '0', '12', '0');
INSERT INTO site (site_id, campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities) VALUES (2, 1, 2, '8', '0', '6', '1');
INSERT INTO site (site_id, campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities) VALUES (3, 2, 3, '3', '0', '9', '1');
INSERT INTO site (site_id, campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities) VALUES (4, 2, 4, '2', '1', '0', '0');
INSERT INTO site (site_id, campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities) VALUES (5, 3, 5, '6', '1', '0', '0');
INSERT INTO site (site_id, campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities) VALUES (6, 3, 6, '8', '1', '0', '1');
SET IDENTITY_INSERT site OFF;

SET IDENTITY_INSERT reservation ON;
INSERT INTO reservation (reservation_id, site_id, name, from_date, to_date, create_date) VALUES (1, 6, 'Reservation test 1', '2018-06-20', '2018-06-25', '2018-03-01');
INSERT INTO reservation (reservation_id, site_id, name, from_date, to_date, create_date) VALUES (2, 5, 'Reservation test 2', '2018-08-01', '2018-08-30', '2018-01-01');
INSERT INTO reservation (reservation_id, site_id, name, from_date, to_date, create_date) VALUES (3, 4, 'Reservation test 3', '2018-04-20', '2018-04-25', '2018-03-01');
INSERT INTO reservation (reservation_id, site_id, name, from_date, to_date, create_date) VALUES (4, 3, 'Reservation test 4', '2018-05-01', '2018-05-30', '2018-01-01');
INSERT INTO reservation (reservation_id, site_id, name, from_date, to_date, create_date) VALUES (5, 2, 'Reservation test 5', '2018-06-20', '2018-06-25', '2018-03-01');
INSERT INTO reservation (reservation_id, site_id, name, from_date, to_date, create_date) VALUES (6, 1, 'Reservation test 6', '2018-08-01', '2018-08-30', '2018-01-01');
SET IDENTITY_INSERT reservation OFF;