# ShopManagementSystem-4LayeredArchitecture-
A console-based Shop Management System built in C# using a four-layered architecture (UI, BLL, DAL, and Model). It efficiently manages products, customers, and orders with data stored through file handling, demonstrating advanced OOP and clean code principles.
# 🛍️ Shop Management System (4-Layered C# Console Application)

## 📖 Overview
The **Shop Management System** is an **advanced console-based application** built in **C#** using a **four-layered architecture** and strong **Object-Oriented Programming (OOP)** principles.  
It helps a shopkeeper manage **Products**, **Customers**, and **Orders (Sales)** in an organized way, ensuring smooth file-based data persistence.

At startup, the system loads data from text files and, before exiting, saves all updates back to those files — preserving records between sessions.

---

## 🧱 4-Layer Architecture

| Layer | Description |
|--------|--------------|
| **1️⃣ Model / Entity Layer** | Contains data models like `Product`, `Customer`, `OrderModel`, and `OrderItem`. Defines constructors, fields, and properties. |
| **2️⃣ Data Access Layer (DAL)** | Handles file reading/writing using `StreamReader` and `StreamWriter`. Performs CRUD operations on text files. |
| **3️⃣ Business Logic Layer (BLL)** | Contains validation, logic, and coordination between UI and DAL. Applies all business rules. |
| **4️⃣ User Interface Layer (UI)** | Handles all user interaction via console menus and options. Displays data and takes inputs. |

This layered structure follows the **Single Responsibility Principle (SRP)** and ensures **clean, modular, and scalable design**.

---

## ⚙️ Key Features

### 🧾 Product Management
- Add, update, delete, and view products  
- Each product includes: *Product Name*, *Purchase Price*, *Sale Price*, and *Discount*  
- Stored permanently in **`products.txt`**

### 👥 Customer Management
- Add, view, delete, or search customers  
- Each customer includes: *Name*, *Phone Number*, *Age*, and *Address*  
- Stored in **`customers.txt`**

### 🛒 Order Management
- Create new sales and view past orders  
- If customer exists → displays their previous orders  
- If new → collects customer details and allows product selection  
- Stores data in **`orders.txt`**

### 📚 Order History
- View all past orders  
- Search orders by customer name  

### 💾 File Handling
- Loads data automatically at startup  
- Saves updated data before program exit  

### 🧠 Advanced OOP Concepts
- Classes, Constructors, Lists  
- Encapsulation & modular design  
- Multi-layered communication (UI → BLL → DAL → Model)  
- Exception and validation handling  

---

## 📂 Folder Structure

