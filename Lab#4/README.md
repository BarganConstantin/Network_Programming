# Lab 4: HTTP Client Console Application in C# 💻

A console application built with C# to interact with an API using HTTP requests. 🌐

## Description 📝

This project is a console application that serves as an HTTP client to interact with an API that manages categories and products. The application can enumerate the list of categories, show details about a category, create a new category, delete a category, change the title of a category, create new products in a category, and see the list of products in a category. The application makes HTTP requests to the API using various HTTP methods such as GET, POST, PUT, and DELETE to perform these operations.

## Features 🌟

The HTTP Client Console Application will have the following features:

- Enumerate the list of categories 📋: The application can send a GET request to the API to fetch the list of categories and display them in the console.
- Show details about a category 📊: The application can send a GET request to the API to fetch the details of a specific category based on its ID and display them in the console.
- Create a new category ➕: The application can send a POST request to the API to create a new category by providing the necessary information such as title. The created category's details are displayed in the console.
- Delete a category ❌: The application can send a DELETE request to the API to delete a category based on its ID.
- Change the title of a category ✏️: The application can send a PUT request to the API to update the title of a category based on its ID.
- Create new products in a category ➕: The application can send a POST request to the API to create new products in a specific category by providing the necessary information such as title, category, price, etc.
- See the list of products in a category 📋: The application can send a GET request to the API to fetch the list of products in a specific category based on its ID and display them in the console.

## Installation 💾

1. Clone the repository of the API 📦
2. Open the solution of the API in Visual Studio 🧰
3. Build and run the API project to start the API server 🔨
4. Clone the repository of the HTTP Client Console Application 📦
5. Open the solution of the HTTP Client Console Application in Visual Studio 🧰
6. Build and run the HTTPClientApp project to start the console application 🚀

## Usage 📖

Once you have started the application, you can use the console commands to interact with the API and perform the various operations described above. The application will display the results of the API requests in the console, allowing you to view and manage categories and products effectively.

## Conclusion 🎓

This lab provided a practical experience in building an HTTP client console application in C# to interact with an API. Through this project, we gained knowledge and skills in making HTTP requests, handling responses, and performing CRUD (Create, Read, Update, Delete) operations on categories and products. This application can be extended and customized to interact with any API that follows the same API contract. We hope that this project will be helpful for others who are interested in learning more about HTTP client programming in C# and working with APIs! 😊
