# Microsoft - Foundations of Coding Full-Stack Course Module | Final Project

## Instructions:

### Step 1: Review the design challenges
#### Inventory management system
- To complete this challenge, you will need to create a console application where users can manage product stock. Users should be able to add new products, update stock, and remove products.
- Some key features include:
    - Add new products with name, price, and stock quantity.
    - Update stock when products are sold or restocked.
    - View all products and their stock levels.
    - Remove products from inventory.

### Step 2: Define the project requirements and objectives
You now know the issue that you’re trying to solve. Take some time to determine the project requirements and objectives. Remember, requirements fall into two categories: functional and non-functional. Then, set the project objectives- the specific results you aim to achieve.  You’ll submit these requirements and objectives at the end of this project. 

### Step 3: Create a design outline
Next, you’ll create a design outline. This process includes breaking the project into tasks and planning the code components needed to accomplish those tasks. Remember, depending on the challenge you chose, you’ll want to plan out the variables, methods, control structures, and loops you’ll need to accomplish each task your application needs to accomplish. 

You should have a diagram or flowchart of your planned application at the end of this process. You also should have a list of each task your application needs to accomplish and what type of code you’ll use to accomplish the task. You can include this in your diagram or in a separate document You can create this documentation using the software of your choice. We recommend using Microsoft Word to complete this task, including the SmartArt diagramming functions, which can help streamline this process. You’ll submit this design outline at the end of this project.  

### Step 4: Build the application
With your plan in place, you can begin creating the application using C# in Visual Studio Code. This is the first time you’ve written code entirely independently, so take your time and review earlier lessons for a refresher. 

Also, feel free to leverage Copilot to help you code. Copilot can help you write, analyze, debug, and optimize your code as you’re going. Remember that all generative AI tools are meant to work in conjunction with you and require your input and knowledge to complete tasks.  

To show your understanding of the concepts in this course, make sure your code includes:
- Control structures like if-else and switch statements
- Loops like for and while
- Methods that you define and call


## Project Requirements and Objectives

### Functional Requirements (What the system must do)
- Add Product: Users can add a product with a name, price, and initial stock quantity.
- Update Stock: Users can update stock levels (increase for restocking, decrease for sales).
- View Products: Users can view a list of all products with their details (name, price, quantity).
- Remove Product: Users can delete products from the inventory.
- User Interface: Interaction is through a console menu.

### Non-Functional Requirements (Quality attributes)
- Usability: The console menu must be clear and easy to navigate.
- Reliability: The system should handle invalid inputs gracefully (e.g., non-numeric input for quantity/price).
- Performance: Application should respond instantly for all operations (all data is in-memory).
- Maintainability: Code should be modular and easy to extend (use of methods/classes).

### Project Objectives (What you aim to achieve)
- Build a C# console application for simple inventory management.
- Demonstrate understanding of:
    - Control structures (if-else, switch)
    - Loops (for, while)
    - Methods (for adding, updating, removing, displaying)
    - Data storage using suitable structures (e.g., List or Dictionary)
- Provide a smooth user experience for basic inventory tasks.

## Design Outline

```
+----------------------------------------------------+
|            Inventory Management System             |
+----------------------------------------------------+
|                   Main Menu                        |
| 1. Add Product                                     |
| 2. Update Stock                                    |
| 3. View Products                                   |
| 4. Remove Product                                  |
| 5. Exit                                            |
+----------------------------------------------------+
                  |
                  v
        +-----------------------+
        |  User selects option  |
        +-----------------------+
                  |
    +------------------------------+------------------------------+-----------------------------+---------------------------+
    |                              |                              |                             |                           |
    v                              v                              v                             v                           v
+-----------------+       +---------------------+        +---------------------+       +-------------------+        +----------+
|  Add Product    |       |   Update Stock      |        |    View Products    |       |  Remove Product   |        |  Exit    |
+-----------------+       +---------------------+        +---------------------+       +-------------------+        +----------+
| Enter Name      |       | List Products       |        | List all products   |       | List Products     |        | Program  |
| Enter Price     |       | Select Product      |        | (Name, Price, Qty)  |       | Select Product    |        | ends     |
| Enter Quantity  |       | Add/Subtract Qty    |        |                     |       | Confirm Remove    |        +----------+
| Confirm Add     |       | Confirm Update      |        |                     |       | Confirmed         |
+-----------------+       +---------------------+        +---------------------+       +-------------------+
    |                              |                              |                             |
    +------------------------------+------------------------------+-----------------------------+
                  |
                  v
        +-----------------------+
        |   Return to Menu      |
        +-----------------------+
```

### Description of Flow

1. Main Menu
    - User is repeatedly presented with options to add, update, view, remove products, or exit.

2. Add Product
    - User inputs product name, price, and quantity.
    - Product is added to inventory.

3. Update Stock
    - User selects a product from the list.
    - User enters a positive (restock) or negative (sale) quantity.
    - Product stock is updated accordingly.

4. View Products
    - User sees a list of all products with name, price, and stock quantity.

5. Remove Product
    - User selects a product from the list.
    - Product is removed from inventory after confirmation.

6. Exit
    - Application ends.

All actions (except exit) loop back to the main menu, allowing continuous interaction.

## Used Software/Service(s)
- Git
- GitHub Desktop
- GitHub Copilot
- Visual Studio Code
- .NET

## Run Locally

Note: Please ensure you have installed <code><a href="https://dotnet.microsoft.com/en-us/download">.NET</a></code>

Clone my repository
```bash
  git clone https://github.com/istvanszasz99/Microsoft_Foundations_of_Coding_Full-Stack_Course_Module_Final_Project.git
```

Run Application
```bash
  dotnet run
```

## Author
- [@istvanszasz99](https://www.github.com/istvanszasz99)
