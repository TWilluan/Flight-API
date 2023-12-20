# Flight RESTful API

Welcome to the Flight REST API documentation! This API provides a set of endpoints to access and manage flight and Passenger-related  basic information. Whether you're building a travel application, tracking flights, integrating flight data, retrieving and editing passengers' information into your system, this API has you covered.

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
- [Error Handling](#error-handling)
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
# API Definition

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
## Error and Exception Handlings


## Sample Requests and Responses
There are sample requests in folder [request](./Request/)