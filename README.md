# Microsoft - Introduction to Programming With C# Course Module | Final Project

## Instructions:

Create a C# console application that manages a small library of books. The program should:

1. Create Variables for Books:
    - Set up five string variables to store the book titles.

2. Add a Book:
    - Prompt the user to input a book title.
    - Check which book variable is empty and store the new book in that variable.
    - If all book slots are full, inform the user that no more books can be added.
  
3. Remove a Book:
    - Ask the user to input the title of the book they want to remove.
    - Check if the title exists in the collection and, if found, clear the corresponding variable.

4. Display the List of Books:
    - Print out the list of books currently in the library, showing only the non-empty book slots.

5. Loop Indefinitely:
    - Continuously prompt the user to choose whether they want to add or remove a book, or exit the program.
    - If the user chooses to exit, break the loop and end the program.

6. Handle Invalid Inputs:
    - If the user enters an invalid action (neither "add" nor "remove"), inform them and prompt again.

7. Conditional Actions:
    - Only allow adding books if there are empty slots.
    - Only allow removing books if there are books in the library.

8. Add a Search Feature
    - Prompt the user to input a book title to search for.
    - If the book is found, display a message indicating it is available.
    - If the book is not found, display a message that it’s not in the collection.

9. Limit Borrowing
    - Add a feature that tracks how many books a user has borrowed.
    - Limit the number of books to 3 at a time.

10. Check-in a borrowed book
    - Add a feature that enables the user to check in a book that’s been checked out.
    - Check If the book is checked out. If it is remove the checked-out flag to check the book in. If it isn’t, inform the user.

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
  git clone https://github.com/istvanszasz99/Microsoft_Introduction_to_Programming_With_C_Sharp_Course_Module_Final_Project.git
```

Run Application
```bash
  dotnet run
```


## Author
- [@istvanszasz99](https://www.github.com/istvanszasz99)
