/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: set a valid and an invalid queue size
        // Expected Result: invalid should set queue size to 10, valid should stay
        Console.WriteLine("Test 1");
        // set max size less than zero
        var newQueue = new CustomerService(-2);
        Console.WriteLine(newQueue);
        // set valid max size
        newQueue = new CustomerService(5);
        Console.WriteLine(newQueue);

        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 2
        // Scenario: add customer to queue
        // Expected Result: customer will be in queue
        Console.WriteLine("Test 2");
        newQueue = new CustomerService(2);
        newQueue.AddNewCustomer();
        Console.WriteLine(newQueue);

        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 3
        // Scenario: add customer to full queue
        // Expected Result: error message
        Console.WriteLine("Test 3");
        newQueue = new CustomerService(1);
        newQueue.AddNewCustomer();
        newQueue.AddNewCustomer();
        Console.WriteLine(newQueue);

        // Defect(s) Found: queue max size wasn't being checked correctly

        Console.WriteLine("=================");
        // Test 4
        // Scenario: remove next in line from the queue
        // Expected Result: next customer should be fremoved from the line
        Console.WriteLine("Test 4");
        newQueue = new CustomerService(1);
        newQueue.AddNewCustomer();
        newQueue.ServeCustomer();
        Console.WriteLine(newQueue);

        // Defect(s) Found: 

        Console.WriteLine("=================");
        // Test 5
        // Scenario: return error message if queue is empty to serve
        // Expected Result: error message on empty queue
        Console.WriteLine("Test 5");
        newQueue.AddNewCustomer();
        newQueue.ServeCustomer();
        newQueue.ServeCustomer();
        Console.WriteLine(newQueue);
        // Defect(s) Found: queue size check was missing from function

        Console.WriteLine("=================");
        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No one left to help!");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + String.Join(", ", _queue) + "]";
    }
}