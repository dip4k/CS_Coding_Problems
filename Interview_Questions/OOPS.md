### The principles of Object-Oriented Programming (OOP) explained in detail with examples:

1. **Encapsulation**

    Encapsulation is the mechanism of hiding data (variables) and methods within an object from the outside world, typically to hide internal details and to prevent unauthorized access. In C#, encapsulation is implemented using access specifiers (public, private, protected, internal).

    Example:
    ```csharp
    public class Employee
    {
        private int id; // Encapsulated data

        public int Id // Publicly accessible property
        {
            get { return id; }
            set { id = value; }
        }
    }
    ```

    In this example, the `Employee` class encapsulates the `id` field and exposes it through the `Id` property.

2. **Inheritance**

    Inheritance is a mechanism where you can derive a class from another class for a hierarchy of classes that share a set of attributes and methods. The class being inherited from is called the 'base class' or 'superclass', and the class that inherits is called the 'derived class' or 'subclass'.

    Example:
    ```csharp
    public class Vehicle // Base class
    {
        public string Color { get; set; }
    }

    public class Car : Vehicle // Derived class
    {
        public string Brand { get; set; }
    }
    ```

    In this example, `Car` is a `Vehicle` and therefore inherits the `Color` property from `Vehicle`.

3. **Polymorphism**

    Polymorphism is the ability of an object to take on many forms. The most common use of polymorphism in OOP occurs when a parent class reference is used to refer to a child class object.

    Example:
    ```csharp
    public class Animal // Base class
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("The animal makes a sound");
        }
    }

    public class Pig : Animal // Derived class
    {
        public override void MakeSound()
        {
            Console.WriteLine("The pig says: wee wee");
        }
    }

    public class Dog : Animal // Derived class
    {
        public override void MakeSound()
        {
            Console.WriteLine("The dog says: bow wow");
        }
    }
    ```

    In this example, `Animal` is a base class and has a method `MakeSound()`. `Pig` and `Dog` are derived classes and override the `MakeSound()` method.

4. **Abstraction**

    Abstraction is the process of hiding the complex details and showing only the essential features of the object. In C#, abstraction is achieved by using abstract classes and interfaces.

    Example:
    ```csharp
    public abstract class Animal // Abstract class
    {
        public abstract void MakeSound(); // Abstract method
    }

    public class Pig : Animal // Derived class
    {
        public override void MakeSound()
        {
            Console.WriteLine("The pig says: wee wee");
        }
    }
    ```

    In this example, `Animal` is an abstract class and `MakeSound()` is an abstract method. The `Pig` class implements the `MakeSound()` method.

Practical Examples:

- Encapsulation: A `BankAccount` class encapsulates the data (like account number, balance) and methods (like deposit, withdraw) related to a bank account.

- Inheritance: A `SavingsAccount` class inherits from the `BankAccount` class and can add additional properties or methods like minimum balance.

- Polymorphism: A `Shape` class has a method `CalculateArea()`. This method is implemented differently in each derived class like `Circle`, `Rectangle`, `Triangle`.

- Abstraction: A `DatabaseConnection` abstract class has an abstract method `Connect()`. This method is implemented differently in each derived class like `SqlConnection`, `OracleConnection`, `MySqlConnection`.

### The major pillars of Object-Oriented Programming (OOP) are:

1. **Encapsulation**: The process of hiding the internal details and mechanics of how an object does something.

2. **Inheritance**: The ability to create new classes from existing classes, inheriting fields and methods.

3. **Polymorphism**: The ability to use an object of one type as an object of another type.

4. **Abstraction**: The process of simplifying complex systems by modeling classes appropriate to the problem, and working at the most appropriate level of inheritance for a given aspect of the problem.

These four principles are the mainstay of any object-oriented programming language.

However, there are also some minor pillars or principles that are often associated with OOP. These are not as universally recognized as the major pillars, but are often discussed in the context of OOP:

1. **Message Passing**: Objects communicate with each other by sending messages (calling methods).

2. **Modularity**: The source code for an object can be written and maintained independently of the source code for other objects. Once created, an object can be easily passed around inside the system.

3. **Information Hiding**: By interacting only with an object's methods, the details of its internal implementation remain hidden from the outside world.

4. **Composition**: Objects can be composed to create more complex objects.

5. **Interfaces and Contracts**: The definition of methods that a class should implement if it wants to act as a certain type.

While these principles are not always listed as the pillars of OOP, they are certainly part of the foundation that the OOP paradigm is built upon.