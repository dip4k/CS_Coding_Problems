Sure, here are the SOLID principles explained in detail with examples:

1. **Single Responsibility Principle (SRP)**

   A class should have only one reason to change. This principle is about actors and high-level architecture. If there are more than one actors (reasons to change), the class should be split.

   Example:
   ```csharp
   // Good: Each class has a single responsibility
   public class OrderProcessor
   {
       public void Process(Order order)
       {
           // Process the order
       }
   }

   public class OrderValidator
   {
       public bool Validate(Order order)
       {
           // Validate the order
           return true;
       }
   }
   ```

2. **Open/Closed Principle (OCP)**

   Entities (classes, modules, functions, etc.) should be open for extension, but closed for modification. This principle prevents situations when a change to one of your classes also requires you to adapt all depending classes.

   Example:
   ```csharp
   // Good: Shape is open for extension (you can add more shapes), but closed for modification
   public abstract class Shape
   {
       public abstract double Area();
   }

   public class Circle : Shape
   {
       public double Radius { get; set; }

       public override double Area()
       {
           return Radius * Radius * Math.PI;
       }
   }
   ```

3. **Liskov Substitution Principle (LSP)**

   Subtypes must be substitutable for their base types. Derived classes should be able to extend their base classes without changing their behavior.

   Example:
   ```csharp
   // Good: The behavior of the base class does not change
   public class Bird
   {
       public virtual void Fly()
       {
           // Default bird flying
       }
   }

   public class Duck : Bird
   {
       public override void Fly()
       {
           // Ducks fly differently but they still fly
       }
   }
   ```

4. **Interface Segregation Principle (ISP)**

   Clients should not be forced to depend on interfaces they do not use. This principle deals with the disadvantages of fat interfaces.

   Example:
   ```csharp
   // Good: Interfaces are segregated and each class implements only the interfaces it needs
   public interface IFly
   {
       void Fly();
   }

   public interface IWalk
   {
       void Walk();
   }

   public class Bird : IFly
   {
       public void Fly()
       {
           // Fly
       }
   }

   public class Human : IWalk
   {
       public void Walk()
       {
           // Walk
       }
   }
   ```

5. **Dependency Inversion Principle (DIP)**

   High-level modules should not depend on low-level modules. Both should depend on abstractions. Abstractions should not depend on details. Details should depend on abstractions. This principle allows for decoupling.

   Example:
   ```csharp
   // Good: High-level and low-level modules depend on the abstraction
   public interface IReader
   {
       string Read();
   }

   public class KeyboardReader : IReader
   {
       public string Read()
       {
           // Read from keyboard
           return "";
       }
   }

   public class Computer
   {
       private IReader _reader;

       public Computer(IReader reader)
       {
           _reader = reader;
       }

       public void Start()
       {
           string inputData = _reader.Read();
           // Process the data
       }
   }
   ```

Real-world examples of SOLID principles:

- In a software company, different teams have different responsibilities. For example, the development team is responsible for building the product, the QA team is responsible for testing, and the DevOps team is responsible for deployment. This is an example of the Single Responsibility Principle.

- In a library, you can borrow and return books. But if you want to extend the functionality to include CDs and DVDs, you don't have to change the existing system. You can just add new modules for CDs and DVDs. This is an example of the Open/Closed Principle.

- In a zoo, you can replace a Tiger with a Lion in a Tiger's cage, and it will still behave as expected (like eating meat). This is an example of the Liskov Substitution Principle.

- In a restaurant, a customer should not be forced to order dessert if they only want a main course. This is an example of the Interface Segregation Principle.

- In a computer system, high-level modules like the User Interface should not depend on low-level modules like the Database. They should both depend on abstractions like Service Interfaces. This is an example of the Dependency Inversion Principle.

Sure, let's dive into more practical scenarios for each SOLID principle:

1. **Single Responsibility Principle (SRP)**

   Consider an application that handles user requests for a library system. You might have a `LibraryManager` class that handles operations like issuing books, returning books and calculating fines. According to SRP, these operations should be handled by separate classes.

   ```csharp
   public class BookIssueManager
   {
       public void IssueBook(string bookId, string memberId)
       {
           // Issue book
       }
   }

   public class BookReturnManager
   {
       public void ReturnBook(string bookId, string memberId)
       {
           // Return book
       }
   }

   public class FineCalculator
   {
       public double CalculateFine(string memberId)
       {
           // Calculate fine
           return 0.0;
       }
   }
   ```

2. **Open/Closed Principle (OCP)**

   Let's consider a `NotificationService` that sends notifications to users. Initially, it supports email notifications only. But in future, if you want to add SMS notifications, you should not modify the `NotificationService`. Instead, you should be able to extend it.

   ```csharp
   public interface INotification
   {
       void SendNotification(string message);
   }

   public class EmailNotification : INotification
   {
       public void SendNotification(string message)
       {
           // Send email
       }
   }

   public class SmsNotification : INotification
   {
       public void SendNotification(string message)
       {
           // Send SMS
       }
   }

   public class NotificationService
   {
       public void Notify(INotification notification, string message)
       {
           notification.SendNotification(message);
       }
   }
   ```

3. **Liskov Substitution Principle (LSP)**

   Consider a `Shape` class and two subclasses `Rectangle` and `Square`. If you have a method that calculates the area of the `Rectangle` and you replace `Rectangle` with `Square` in that method, it should still calculate the area correctly.

   ```csharp
   public abstract class Shape
   {
       public abstract int Area();
   }

   public class Rectangle : Shape
   {
       public int Width { get; set; }
       public int Height { get; set; }

       public override int Area()
       {
           return Width * Height;
       }
   }

   public class Square : Shape
   {
       public int Side { get; set; }

       public override int Area()
       {
           return Side * Side;
       }
   }

   public class AreaCalculator
   {
       public int CalculateArea(Shape shape)
       {
           return shape.Area();
       }
   }
   ```

4. **Interface Segregation Principle (ISP)**

   Consider a `MultiFunctionPrinter` class that implements an `IMultiFunctionDevice` interface. If a client only wants to use the `Print` functionality, it should not be forced to depend on `Fax` and `Scan` functionalities.

   ```csharp
   public interface IPrinter
   {
       void Print(Document d);
   }

   public interface IScanner
   {
       void Scan(Document d);
   }

   public interface IFax
   {
       void Fax(Document d);
   }

   public class MultiFunctionPrinter : IPrinter, IScanner, IFax
   {
       public void Print(Document d)
       {
           // Print document
       }

       public void Scan(Document d)
       {
           // Scan document
       }

       public void Fax(Document d)
       {
           // Fax document
       }
   }

   public class OldFashionedPrinter : IPrinter
   {
       public void Print(Document d)
       {
           // Print document
       }
   }
   ```

5. **Dependency Inversion Principle (DIP)**

   Consider a `UserPasswordChanger` class that depends on a `MySQLDatabase` class to change the password. According to DIP, `UserPasswordChanger` should not depend directly on `MySQLDatabase`. Instead, it should depend on an abstraction like `IDatabase`.

   ```csharp
   public interface IDatabase
   {
       void ChangePassword(string userId, string newPassword);
   }

   public class MySQLDatabase : IDatabase
   {
       public void ChangePassword(string userId, string newPassword)
       {
           // Change password in MySQL database
       }
   }

   public class UserPasswordChanger
   {
       private IDatabase _database;

       public UserPasswordChanger(IDatabase database)
       {
           _database = database;
       }

       public void ChangePassword(string userId, string newPassword)
       {
           _database.ChangePassword(userId, newPassword);
       }
   }
   ```

### **Single Responsibility Principle (SRP)**

The Single Responsibility Principle states that a class should have only one reason to change. This means that a class should only have one job or responsibility. If a class has more than one responsibility, it becomes coupled. A change to one responsibility results in modification of the other responsibility.

The principle provides a couple of benefits such as high cohesion, lower coupling, easier navigation, and increased readability.

**Example 1: User and UserDB**

Let's consider a `User` class in an application. The `User` class should handle tasks related to the user's properties and behaviors, such as setting or getting the user's name or email. If we also let the `User` class handle tasks such as saving the user to a database (`UserDB`), then the `User` class would have more than one reason to change.

```csharp
public class User
{
    public string Name { get; set; }
    public string Email { get; set; }

    // User class should not be responsible for database operations
    // This violates the Single Responsibility Principle
    public void SaveUser(User user)
    {
        // Save user to database
    }
}
```

A better approach would be to create a separate `UserDB` class that is responsible for saving the user to the database.

```csharp
public class UserDB
{
    public void SaveUser(User user)
    {
        // Save user to database
    }
}
```

**Example 2: Book and BookPrinter**

Consider a `Book` class that has properties like `Title` and `Author` and methods like `GetTitle`, `GetAuthor`. If we also add a method `Print` to print the book, then the `Book` class has more than one responsibility.

```csharp
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    // Book class should not be responsible for printing the book
    // This violates the Single Responsibility Principle
    public void Print()
    {
        // Print the book
    }
}
```

A better approach would be to create a separate `BookPrinter` class that is responsible for printing the book.

```csharp
public class BookPrinter
{
    public void Print(Book book)
    {
        // Print the book
    }
}
```

In both examples, we see that by ensuring that each class adheres to the Single Responsibility Principle, we can make our code more robust and easier to maintain. Changes to the way we save a user to the database or the method we use to print a book will not affect the `User` or `Book` classes, respectively.

### **Open/Closed Principle (OCP)**

The Open/Closed Principle states that software entities (classes, modules, functions, etc.) should be open for extension but closed for modification. This means that a class should be easily extendable without modifying the class itself.

The principle provides several benefits such as promoting decoupling and reducing the risk of breaking existing functionality when implementing new features.

**Example 1: Logger**

Consider a `Logger` class that logs messages to a file.

```csharp
public class Logger
{
    public void Log(string message)
    {
        // Write message to a log file
    }
}
```

Now, suppose you want to support logging to a database. If you modify the `Logger` class to add this functionality, you would violate the Open/Closed Principle.

A better approach would be to create an `ILogger` interface, and implement this interface in separate classes for each logging method.

```csharp
public interface ILogger
{
    void Log(string message);
}

public class FileLogger : ILogger
{
    public void Log(string message)
    {
        // Write message to a log file
    }
}

public class DatabaseLogger : ILogger
{
    public void Log(string message)
    {
        // Write message to a database
    }
}
```

**Example 2: Discount Calculator**

Consider a `DiscountCalculator` class that calculates a discount for a standard customer.

```csharp
public class DiscountCalculator
{
    public decimal CalculateDiscount(Customer customer)
    {
        // Calculate discount for standard customer
        return 10.0m;
    }
}
```

Now, suppose you want to support a higher discount for VIP customers. If you modify the `DiscountCalculator` class to add this functionality, you would violate the Open/Closed Principle.

A better approach would be to create an `IDiscountCalculator` interface, and implement this interface in separate classes for each customer type.

```csharp
public interface IDiscountCalculator
{
    decimal CalculateDiscount(Customer customer);
}

public class StandardDiscountCalculator : IDiscountCalculator
{
    public decimal CalculateDiscount(Customer customer)
    {
        // Calculate discount for standard customer
        return 10.0m;
    }
}

public class VipDiscountCalculator : IDiscountCalculator
{
    public decimal CalculateDiscount(Customer customer)
    {
        // Calculate higher discount for VIP customer
        return 20.0m;
    }
}
```

In both examples, we see that by ensuring that each class adheres to the Open/Closed Principle, we can easily extend our application with new functionality without modifying the existing code. This makes our application more robust and easier to maintain.

### **Liskov Substitution Principle (LSP)**

The Liskov Substitution Principle (LSP) is a principle of object-oriented design that states if a program is using a base class, it should be able to use any of its subclasses without the program knowing it. In other words, the subclasses should be substitutable for their base class.

This principle is about contracts and specifications. It means that a subclass should not strengthen preconditions, should not weaken postconditions, should maintain invariants of the base class, and should not throw new exceptions unless they are part of the base class contract.

**Example 1: Bank Accounts**

Consider a base class `BankAccount` and two subclasses `SavingsAccount` and `CurrentAccount`. The `BankAccount` class has a method `Withdraw` that allows you to withdraw money. The `SavingsAccount` class also has a `Withdraw` method, but it has a precondition that you cannot withdraw money if it results in a balance less than the minimum balance.

In this case, you cannot substitute `SavingsAccount` for `BankAccount` without changing the behavior of the program, because `SavingsAccount` strengthens the precondition of the `Withdraw` method. This violates the Liskov Substitution Principle.

```csharp
public abstract class BankAccount
{
    public decimal Balance { get; protected set; }

    public virtual void Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
        }
        else
        {
            throw new Exception("Insufficient balance");
        }
    }
}

public class SavingsAccount : BankAccount
{
    private const decimal MinimumBalance = 1000;

    public override void Withdraw(decimal amount)
    {
        if (Balance - amount >= MinimumBalance)
        {
            base.Withdraw(amount);
        }
        else
        {
            throw new Exception("Cannot withdraw as it results in balance less than minimum balance");
        }
    }
}
```

**Example 2: Employees and their Work Hours**

Consider a base class `Employee` and a subclass `PartTimeEmployee`. The `Employee` class has a method `SetWorkHours` that sets the work hours of the employee. The `PartTimeEmployee` class also has a `SetWorkHours` method, but it has a precondition that the work hours cannot be more than a certain limit.

In this case, you cannot substitute `PartTimeEmployee` for `Employee` without changing the behavior of the program, because `PartTimeEmployee` strengthens the precondition of the `SetWorkHours` method. This violates the Liskov Substitution Principle.

```csharp
public class Employee
{
    public int WorkHours { get; private set; }

    public virtual void SetWorkHours(int hours)
    {
        WorkHours = hours;
    }
}

public class PartTimeEmployee : Employee
{
    private const int MaximumHours = 30;

    public override void SetWorkHours(int hours)
    {
        if (hours <= MaximumHours)
        {
            base.SetWorkHours(hours);
        }
        else
        {
            throw new Exception("Cannot set work hours more than maximum hours for part time employee");
        }
    }
}
```

In both examples, to adhere to the Liskov Substitution Principle, we should not strengthen the preconditions in the subclasses. Instead, we can model the system in a different way or use a different design pattern like the Strategy pattern.

### **Interface Segregation Principle (ISP)**

The Interface Segregation Principle states that clients should not be forced to depend upon interfaces that they do not use. This means that a class should not have to implement methods it doesn’t use. Instead of one fat interface many small interfaces are preferred based on groups of methods, each one serving one submodule.

The principle provides several benefits such as reducing the side effects of change (a change in one module doesn't require changing classes that don't use it), and promoting system decoupling leading to more easily maintainable code.

**Example 1: Printer**

Consider a `IPrinter` interface that has methods for `Print`, `Scan` and `Fax`.

```csharp
public interface IPrinter
{
    void Print(Document d);
    void Scan(Document d);
    void Fax(Document d);
}
```

A `MultiFunctionPrinter` class may need all of these methods, but a `SimplePrinter` class may only need the `Print` method. It doesn't make sense for `SimplePrinter` to have `Scan` and `Fax` methods.

A better approach would be to break down the `IPrinter` interface into smaller interfaces, each with only the methods that are relevant to a particular type of printer.

```csharp
public interface IPrinter
{
    void Print(Document d);
}

public interface IScanner
{
    void Scan(Document d);
}

public interface IFaxMachine
{
    void Fax(Document d);
}

public class MultiFunctionPrinter : IPrinter, IScanner, IFaxMachine
{
    public void Print(Document d) { /*...*/ }
    public void Scan(Document d) { /*...*/ }
    public void Fax(Document d) { /*...*/ }
}

public class SimplePrinter : IPrinter
{
    public void Print(Document d) { /*...*/ }
}
```

**Example 2: Worker**

Consider an `IWorker` interface that has methods for `Work` and `Eat`.

```csharp
public interface IWorker
{
    void Work();
    void Eat();
}
```

A `HumanWorker` class would need both of these methods, but a `RobotWorker` class may only need the `Work` method. It doesn't make sense for `RobotWorker` to have an `Eat` method.

A better approach would be to segregate the `IWorker` interface into smaller interfaces.

```csharp
public interface IWorker
{
    void Work();
}

public interface IEater
{
    void Eat();
}

public class HumanWorker : IWorker, IEater
{
    public void Work() { /*...*/ }
    public void Eat() { /*...*/ }
}

public class RobotWorker : IWorker
{
    public void Work() { /*...*/ }
}
```

In both examples, we see that by ensuring that each class only needs to implement the methods that it actually uses, we can make our code more robust and easier to understand. This is the essence of the Interface Segregation Principle.