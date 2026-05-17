using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private List<PriorityItem> _queue = new List<PriorityItem>();

    public void Enqueue(string value, int priority)
    {
        _queue.Add(new PriorityItem(value, priority));
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        int highestPriority = _queue[0].Priority;
        int index = 0;

        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > highestPriority)
            {
                highestPriority = _queue[i].Priority;
                index = i;
            }
        }

        string value = _queue[index].Value;
        _queue.RemoveAt(index);

        return value;
    }

    private class PriorityItem
    {
        public string Value { get; set; }
        public int Priority { get; set; }

        public PriorityItem(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }
    }
}