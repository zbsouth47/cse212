public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        // Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: add itmes to the back of the queue
        // Expected Result: first, 1
        Console.WriteLine("Test 1");
        priorityQueue.Enqueue("first", 1);
        priorityQueue.Enqueue("second", 2);
        Console.WriteLine(priorityQueue);

        // Defect(s) Found: none

        Console.WriteLine("---------");

        // Test 2
        // Scenario: remove item from queue with highest priority first
        // Expected Result: first, second, third
        Console.WriteLine("Test 2");
        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("third", 3);
        priorityQueue.Enqueue("second", 4);
        while (priorityQueue.Length > 0)  {
            Console.WriteLine(priorityQueue.Dequeue());
        }

        // Defect(s) Found: index in dequeue wasn't long enough and 
        //                  actually removal from queue was missing

        Console.WriteLine("---------");

        // Test 3
        // Scenario: more than one highest priority, first highest goes first
        // Expected Result: first, alsofirst, second, third
        Console.WriteLine("Test 3");
        priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("third", 3);
        priorityQueue.Enqueue("second", 4);
        priorityQueue.Enqueue("alsofirst", 5);
        while (priorityQueue.Length > 0)  {
            Console.WriteLine(priorityQueue.Dequeue());
        }

        // Defect(s) Found: ">=" in dequeue needed to be just ">"

        Console.WriteLine("---------");

        // Test 4
        // Scenario: error message should return on empty queue
        // Expected Result: The queue is empty.
        Console.WriteLine("Test 4");
        priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();

        // Defect(s) Found: none

        Console.WriteLine("---------");

        // Add more Test Cases As Needed Below
    }
}