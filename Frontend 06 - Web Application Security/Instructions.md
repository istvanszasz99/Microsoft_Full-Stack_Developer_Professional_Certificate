# Activity Introduction (Activity 1)
You are developing the business logic for an e-commerce web application called ShopEase. Customers will browse products, add items to a cart, and complete transactions.

In this activity, you will:

- Create a Product class with specific attributes.
- Develop a Cart class to manage products and calculate totals.
- Use Microsoft Copilot to refine and debug your work.

This is the first of five activities in this project. The code you develop here will be integrated into the Blazor front-end in Activity 2.

After you complete the entire project you will present your application in a peer review by answering questions that review, analyze, and describe the project you have completed.

## Activity Instructions
## Step 1: Set Up a Blazor Project

1. Create a new Blazor WebAssembly project in Visual Studio Code.
2. Add a Pages folder inside the project if it doesn't exist already.
3. Ensure your project structure is organized before proceeding.

## Step 2: Implement the Product Class

1. Create a new C# class named Product.
2. Define the following properties in the Product class:
- ProductID (integer)
- Name (string)
- Price (decimal)
- Category (string)
3. Write a method that prints product details in the following format:
- Product: Laptop | Price: $999.99 | Category: Electronics
4. Run a test program that creates an instance of Product and prints its details.

## Step 3: Implement the Cart Class

1. Create a new C# class named Cart.
2. Include a List< Product > to store products.
3. Write the following methods in the Cart class:
- AddProduct(Product product): Adds a product to the cart.
- RemoveProduct(int productId): Removes a product from the cart by its ID.
- DisplayCartItems(): Prints all products in the cart.
- CalculateTotal(): Returns the total price of all products in the cart.
4. Include a database component in your Cart methods
- AddProduct should save cart items to a local MySQL database called Shop and a table called Products
- RemoveProduct should remove cart items from the database
5. Run a test program that:
- Adds at least two products to the cart.
- Removes one product.
- Displays the cart contents and total price.

## Step 4: Debug and Optimize Your Code Using Copilot
1. Run your test program and check for any errors.
2. If errors occur, attempt to debug manually first.
3. If needed, ask Copilot to:
- Identify and fix logic errors.
- Suggest performance optimizations.
- Improve how the cart methods are structured.
4. Ensure that your final code executes without errors.

# Activity Introduction (Activity 2)
Now that the business logic for the e-commerce platform is complete, it’s time to create the front-end components that will display products and allow users to add them to a shopping cart.

In this activity, you will:
- Develop a Blazor component (ProductCard.razor) to display product details.
- Create an event-driven system to handle "Add to Cart" functionality.
- Use Microsoft Copilot to refine and debug your Blazor components.

This is the second of five activities in this project. The components you create here will be enhanced with UI/UX improvements in Activity 3. After you complete the entire project you will present your application in a peer review by answering questions that review, analyze, and describe the project you have completed.

## Activity Instructions
## Step 1: Create the ProductCard.razor Component
1. Create a new file inside the Pages folder named ProductCard.razor.
2. Define a component that:
- Displays product details.
- Includes a button labeled "Add to Cart".
3. Ensure your component accepts a Product object as a parameter.

## Step 2: Implement Event Handling for "Add to Cart"
1. Modify the ProductCard.razor component to:
- Include an event that triggers when the "Add to Cart" button is clicked.
- Send the selected product to the Cart component.
2. Test your component by displaying multiple products and adding them to the cart.

## Step 3: Debug and Optimize Your Code Using Copilot
1. Run your Blazor project and ensure the product details render correctly.
2. If errors occur, attempt to debug manually first.
3. If needed, ask Copilot to:
- Suggest improvements to the event-handling system.
- Identify any performance optimizations.
4. Ensure that your final Blazor component functions correctly.

## Step 4: Save and Submit Your Work
By completing this activity, you now have:
- A functional ProductCard.razor component displaying product details.
- An event-driven system for adding products to the cart.
- A working Blazor project that will be used in Activity 3.

Save your files and place your finalized code into a document (.docx or .pdf).
Submit the document containing your Blazor component code.

# Activity Introduction (Activity 3)
Now that your Blazor components are functional, it's time to refine the user experience by making the interface visually appealing and mobile-friendly.

In this activity, you will:
- Apply CSS styling to improve the layout and design.
- Implement responsive design using media queries.
- Use Microsoft Copilot to enhance styling and ensure accessibility.

This is the third of five activities in this project. The UI enhancements you create here will be integrated with secure coding practices in Activity 4. After you complete the entire project you will present your application in a peer review by answering questions that review, analyze, and describe the project you have completed.

## Activity Instructions
## Step 1: Add Styling to Your Blazor Components
1. Create a new wwwroot/css/site.css file (if not already present).
2. Apply styling to your ProductCard.razor component to:
- Improve text readability.
- Adjust spacing and layout for a polished appearance.

## Step 2: Implement Responsive Design
1. Modify the styles to ensure the product listings are:
- Adaptable to mobile, tablet, and desktop views.
- Using media queries to adjust layout based on screen size.
2. Test your design in browser developer tools to verify responsiveness.

## Step 3: Improve Accessibility
1. Ensure all interactive elements are accessible by:
- Adding proper color contrast.
- Ensuring all elements are keyboard-navigable.
2. Use Copilot to review accessibility compliance and suggest improvements.

## Step 4: Debug and Optimize with Copilot
1. Run your project and review the UI.
2. If issues arise, attempt to resolve them manually first.
3. If needed, ask Copilot to:
- Recommend best practices for responsive design.
- Suggest improvements for visual hierarchy.

## Step 5: Save and Submit Your Work
By completing this activity, you now have:
- A fully styled and responsive UI for your Blazor project.
- An optimized user experience with improved accessibility.
- A working front-end that is ready for security enhancements.

Save your files and place your finalized code into a document (.docx or .pdf).

# Activity Introduction (Activity 4)
Now that your UI is responsive and visually appealing, it's time to secure the application.

In this activity, you will:
- Apply input validation to prevent attacks.
- Implement authentication using ASP.NET Identity.
- Use Microsoft Copilot to detect security vulnerabilities.

This is the fourth of five activities in this project. The security improvements here will be combined with state management in Activity 5. After you complete the entire project you will present your application in a peer review by answering questions that review, analyze, and describe the project you have completed.

## Activity Instructions
## Step 1: Implement Input Validation
1. Modify your Blazor form to:
- Ensure all text inputs are sanitized.
- Prevent SQL Injection and Cross-Site Scripting (XSS).

## Step 2: Implement Authentication
1. Add user authentication to the Blazor app using ASP.NET Identity.
2. Ensure only logged-in users can add products to the cart.

## Step 3: Debug and Optimize Security with Copilot
1. Run security tests and ensure input validation works.
2. If vulnerabilities are found, attempt to fix them manually first.
3. If needed, ask Copilot to:
- Detect security flaws in your input validation.
- Suggest improvements for authentication best practices.

## Step 4: Save and Submit Your Work
By completing this activity, you now have:
- A secure Blazor project with authentication.
- Proper input validation to prevent security risks.

Save your files and place your finalized code into a document (.docx or .pdf).

Submit the document containing your security improvements.

# Activity Introduction (Activity 5)
Now that your application is functional, responsive, and secure, it's time to finalize it by adding state management to retain cart data across sessions.

In this activity, you will:
- Implement state management to persist shopping cart data.
- Optimize final performance and usability improvements.
- Prepare your final submission.

This is the last activity in this project. The finalized version will serve as a portfolio-ready project.

## Activity Instructions
## Step 1: Implement State Management
1. Use session storage or local storage to retain cart data.
2. Ensure the cart persists even after the user refreshes the page.

## Step 2: Final Testing and Optimization
1. Run all project components together and ensure:
- Products display correctly.
- The cart updates and persists.
- Authentication functions properly.
2. Use Copilot to analyze your project for any final refinements.

## Step 3: Save and Submit Your Work
 Submit a document (.docx or .pdf) containing your final project code.