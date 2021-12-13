# FinancialChat

## Introduction

This project is a simple browser-based chat application using .NET.

## Features

User registry and authentication using .NET identity
Multiple Chat Rooms
Create and delete rooms
When enter a room, the last 50 messages shows in a list
Stock consulting using the following command:

    /stock=stock_code
    
Example:

    /stock=APPL.US
    
## Architecture

This project uses MVC structure.

The chat comunications uses SignalR package.

The stock consulting uses RestSharp package.

## Running the project

The project was made in visual studio using c# and asp.net, Visual Studio 2013 and .Net Framework 4.6.1 are the minimum requeriments to run this application, due to unit testing code.

To compile and start the aplication, download the complete code and open the FinancialChat.sln file.
