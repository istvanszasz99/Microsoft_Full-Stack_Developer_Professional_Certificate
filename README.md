# Microsoft - Foundations of Coding Full-Stack Course Module | Final Project

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