using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue once
    // Expected Result: Item with highest priority is returned
    // Defect(s) Found: Initial implementation did not store priority correctly due to incorrect assignment in constructor, causing wrong dequeue order.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("medium", 3);
        priorityQueue.Enqueue("high", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("high", result);
    }

    [TestMethod]
    // Scenario: Multiple items with same priority (FIFO check)
    // Expected Result: First inserted item among same priority is returned
    // Defect(s) Found: FIFO ordering for equal priorities was broken because Enqueue inserted items using >= instead of >, causing later items to be placed incorrectly.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("second", 5);
        priorityQueue.Enqueue("third", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("first", result);
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: No defects found. The queue correctly throws an InvalidOperationException with the expected message when dequeuing from an empty queue.
    public void TestPriorityQueue_EmptyQueue_ThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });

        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Multiple enqueues and full dequeue order check
    // Expected Result: Items come out in correct priority order
    // Defect(s) Found: Priority ordering was incorrect due to improper comparison logic and incorrect priority storage, causing items to dequeue in wrong order.
    public void TestPriorityQueue_FullOrderTest()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 10);
        priorityQueue.Enqueue("medium", 5);
        priorityQueue.Enqueue("high2", 10);

        // First highest priority (10), should be "high"
        Assert.AreEqual("high", priorityQueue.Dequeue());

        // Same priority (10), FIFO should give "high2"
        Assert.AreEqual("high2", priorityQueue.Dequeue());

        // Next priority 5
        Assert.AreEqual("medium", priorityQueue.Dequeue());

        // Last priority 1
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Ensure Enqueue always adds to back (not sorted insertion)
    // Expected Result: FIFO is preserved when priorities match
    // Defect(s) Found: FIFO stability was initially incorrect when multiple items had the same priority because Enqueue logic sorted instead of preserving insertion order.
    public void TestPriorityQueue_FifoStabilityTest()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }
}