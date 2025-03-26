using System;

// Enum for log levels
public enum LogLevel
{
    Comment,
    Warning,
    Error
}

// Singleton Logger
public class SingletonLogger
{
    private static SingletonLogger _instance;

    private SingletonLogger() { }

    public static SingletonLogger Instance
    {
        get
        {
            if (_instance == null)
                _instance = new SingletonLogger();
            return _instance;
        }
    }

    public void Log(LogLevel level, string message)
    {
        switch (level)
        {
            case LogLevel.Comment:
                Console.ResetColor();
                Console.WriteLine($"Comment: {message}");
                break;
            case LogLevel.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Warning: {message}");
                Console.ResetColor();
                break;
            case LogLevel.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {message}");
                Console.ResetColor();
                Environment.Exit(1);
                break;
        }
    }
}

// Static Logger
public static class StaticLogger
{
    public static void Log(LogLevel level, string message)
    {
        switch (level)
        {
            case LogLevel.Comment:
                Console.ResetColor();
                Console.WriteLine($"Comment: {message}");
                break;
            case LogLevel.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Warning: {message}");
                Console.ResetColor();
                break;
            case LogLevel.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {message}");
                Console.ResetColor();
                Environment.Exit(1);
                break;
        }
    }
}

// Factory Interface
public interface IAnimal
{
    void Speak();
}

public class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("woof");
    }
}

public class Cat : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("meow");
    }
}

// Simple Factory
public static class AnimalFactory
{
    public static IAnimal CreateAnimal(string type)
    {
        switch (type.ToLower())
        {
            case "dog":
                return new Dog();
            case "cat":
                return new Cat();
            default:
                throw new ArgumentException("Invalid animal type");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Singleton Logger Example
        var logger = SingletonLogger.Instance;
        logger.Log(LogLevel.Comment, "This is a comment.");
        logger.Log(LogLevel.Warning, "This is a warning.");
        // logger.Log(LogLevel.Error, "This is an error."); // Uncomment to see exit behavior

        // Static Logger Example
        StaticLogger.Log(LogLevel.Comment, "Static comment.");
        StaticLogger.Log(LogLevel.Warning, "Static warning.");
        // StaticLogger.Log(LogLevel.Error, "Static error."); // Uncomment to see exit behavior

        // Factory Example
        IAnimal dog = AnimalFactory.CreateAnimal("dog");
        dog.Speak(); // woof

        IAnimal cat = AnimalFactory.CreateAnimal("cat");
        cat.Speak(); // meow
    }
}
