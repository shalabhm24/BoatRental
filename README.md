# BoatRental

1. Pull all files
2. Run Database scripts present in Databse folder
3. Change the connection string in Appsetting.json file
4. Build the project and run
Two tabs are present
1. Boat register tab is to create boat and enter its hourls rate
Condition to add-> same name and same hourly rate cannot be added in the database it will redirect to error page if tried to do the same
2. Booking a boat for a customer via user.  Input are boatid and name of customer. 
Condtion ->1. Boat should be registered i.e its entry should be available in tblregister.
            2. Boat will be availabe in case boat is not rented out by another customer. i.e entry already exits in tblbooking table.
