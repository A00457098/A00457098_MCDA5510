# Flight Reservation System

This is the final project for MCDA5510 on **Flight Reservation System.**
This project is developed by **Team 12**

This application will allow a user to search for flights, login, register, add passenger details, add payment details and finally book a flight. 
The website was developed using ASP .NET Core and deployed on Azure available [here](https://flightreservationsystem.azurewebsites.net/). 

## Team Members:
- Radhika Suri (A00457098)
- Jongwon Shinn (A00407059)
- Mayuresh Sawant (A00442519)

## Pages:
The application has ththe below mentioned pages and functionalities: 

### Flight Search

- User can search the flight based on creteria given. (All fileds should be filled)
- The search result will be based on the data from prepared database on sql server.
- User can sort the flgiht based on colunms on the result page.
- Search function can be done by guest user as well.
- User can book the flight based on the search result, but log-in required.

#### Note
Data is not real data, so there can be mis matched information.
There are some constraints in data. For example, the departure city is Halifax, the price is random and there is no duration time.

### Add passenger
- User can add one passenger with personal details. (All fileds should be filled)
- User can proceed to payment page by creating passenger information.
- User can go back to search page.

### Payment
- The user has to fill their card details and address.
- The card type (Visa/Amex/Mastercard) should correspond to the right type of card number.
- The ZIP code should match the country selected (US/Canada)

### Review Booking
- The user can see the details of their selected flight and their added details for the passengers. 
- They can then proceed with the booking or cancel it. 
