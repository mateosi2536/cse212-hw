using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue "A" (2), "B" (5), "C" (3).
    // Expected Result: Returns "B", "C", "A".
    // Defect(s) Found: Items not removed from queue.
    public void TestPriorityQueue_1()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 2);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 3);

        var first = queue.Dequeue();
        var second = queue.Dequeue();
        var third = queue.Dequeue();

        Assert.AreEqual("B", first);
        Assert.AreEqual("C", second);
        Assert.AreEqual("A", third);
    }

    [TestMethod]
    // Scenario: Enqueue "A" (5), "B" (2), "C" (5).
    // Expected Result: Returns "A" (FIFO tie-breaker).
    // Defect(s) Found: Comparison used >= instead of >.
    public void TestPriorityQueue_2()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 5);
        queue.Enqueue("B", 2);
        queue.Enqueue("C", 5);

        var first = queue.Dequeue();
        Assert.AreEqual("A", first);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: Throws InvalidOperationException.
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        var queue = new PriorityQueue();

        try
        {
            queue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}