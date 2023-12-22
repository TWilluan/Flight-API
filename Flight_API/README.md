# Flight Management RESTful API

Welcome to the Flight REST API documentation! This API provides a set of endpoints to access and manage flight and Passenger-related  basic information. Whether you're building a travel application, tracking flights, integrating flight data, or retrieving and editing passengers' information into your system, this API has you covered.

---

# Table of Contents

- [Getting Started](#getting-started)
  - [Base URL](#base-url)
  - [Technologies](#technologies)
- [API endpoints](#api-endpoints)
  - [1. Flight](#flight)
    - [1. Create Flight](#1-create-flight)
    - [2. Get Flight](#1-get-flight)
    - [3. Get All Flights](#3-get-all-flight)
    - [4. Get All Passengers in Flight](#4-get-all-passenger-in-flight)
    - [5. Update Flight](#5-update-flight)
    - [6. Delete Flight](#6-delete-flight)
  - [2. Passenger](#passenger)
    - [1. Create Passenger](#1-create-passenger)
    - [2. Get Passengers](#1-get-passenger)
    - [3. Get All Passengers](#3-get-all-passengers)
    - [4. Get All Passengers in Flight](#4-get-all-passenger-in-flight)
    - [5. Update Passenger](#5-update-passenger)
    - [6. Delete Passenger](#6-delete-passenger)
  - [3. Booking](#booking)
    - [1. Booking](#1-get-flights)
    - [2. Get Booking](#2-get-flight-details)
    - [3. Change Seat](#3-book-a-flight)
    - [4. Cancel Booking](#4-cancel-booking)
- [Error and Exception Handling](#error-and-exception-handling)
- [Sample Requests and Responses](#sample-requests-and-responses)

---
# Getting Started
## Base URL
```http
http://localhost:5212/
```
## Technologies
1. C#
2. ASP.NET 7.0
3. EntityFramwork 7.0
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="7.0.2">
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="7.0.2">
```
4. MySQL
```xml
<PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="7.0.0" />
```
5. LINQ

# API endpoints
## Flight
#### Create Flight
```js
POST http://localhost:5212/breakfasts HTTP/1.1
Content-Type: application/json
```
```json
{
    "FlightNo": "TE001",
    "Capacity": 160,
    "Origin": "USA",
    "Destination": "USA",
    "Gate": ""
}
```
#### Get Flight
```js
GET http://localhost:5212/flight/AYE23 HTTP/1.1
```
#### Get All Flights
```js
GET http://localhost:5212/flight/ HTTP/1.1
```
#### Get All Passengers in Flight
```js
GET http://localhost:5212/flight/AYE35/allpassenger HTTP/1.1
```
#### Update Flight
```js
PUT http://localhost:5212/flight/TES01 HTTP/1.1
Content-Type: application/json
```
```json
{
    "FlightNo": "TES01",
    "Capacity": 180,
    "Origin": "HCM",
    "Destination": "USA",
    "Gate": "A16"
}
```
#### Delete Flight
```js
DELETE http://localhost:5212/flight/AYE23 HTTP/1.1
```
---
## Passenger
#### Create Passenger
```js
POST http://localhost:5212/passenger/ HTTP/1.1
Content-Type: application/json
```
```json
{
    "FirstName": "",
    "LastName": "Nguyen",
    "Email": "abc@gmail.com"
}
```
#### Get Passenger
```js
GET http://localhost:5212/passenger/1 HTTP/1.1
```
#### Get All Passengers
```js
GET http://localhost:5212/passenger HTTP/1.1
```
#### Get All Flights Passenger has
```js
GET http://localhost:5212/passenger/1/allflight HTTP/1.1
```
#### Update Passenger
```js
PUT http://localhost:5212/passenger/3 HTTP/1.1
Content-Type: application/json
```
```json
{
    "FirstName": "Miu",
    "LastName": "Le",
    "Email": "miule@gmail.com"
}
```
#### Delete Passenger
```js
DELETE http://localhost:5212/passenger/3 HTTP/1.1
```

## Booking
#### Booking
```js
POST http://localhost:5212/booking?pass_id=2&flightno=AYE35 HTTP/1.1
```
#### Get Booking
```js
GET http://localhost:5212/booking?pass_id=1&flightno=AYE35 HTTP/1.1
```
#### Change Seat
```js
PUT http://localhost:5212/booking?pass_id=1&flightno=AYE35&seat=A13 HTTP/1.1
```
#### Cancel Booking
```js
DELETE  http://localhost:5212/booking?pass_id=2&flightno=AYE35 HTTP/1.1
```
## Error and Exception Handling
## Common Error Codes

### 400 Bad Request

- **Description**: Indicates that the client's request is malformed or invalid.
- **Example Scenario**: Invalid or missing input parameters.

### 401 Unauthorized

- **Description**: Indicates that authentication is required and has failed or has not been provided.
- **Example Scenario**: Invalid API key.

### 403 Forbidden

- **Description**: Indicates that the requested resource could not be completed due to business logic
- **Example Scenario**: Passenger can not book full flight.

### 404 Not Found

- **Description**: Indicates that the requested resource could not be found.
- **Example Scenario**: Requested flight, passenger, or booking not found.

### 500 Internal Server Error

- **Description**: Indicates that an unexpected error occurred on the server.
- **Example Scenario**: Database connection issues.

## Custom Error Responses

In addition to standard HTTP error codes, the Flight API may return custom error responses with detailed information about the issue.

### Example Custom Error Response

```json
{
  "Status": "Exception.statuscode",
  "Type": "[Custome Middleware] Error",
  "Title": "Exception.message",
  "Detail": "Exception.stacktrace"
}
```

## Sample Requests and Responses
#### Usage
Simply `git clone https://github.com/TWilluan/Flight-API.git`
Then move to Flight_API folder using `cd`
Run the project `dotnet run`

#### Request
There are sample requests in folder [request](./Request/)
