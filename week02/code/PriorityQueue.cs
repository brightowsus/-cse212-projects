using System;
using System.Collections.Generic;
using System.Linq;

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

        int bestIndex = 0;

        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > _queue[bestIndex].Priority)
            {
                bestIndex = i;
            }
        }

        string value = _queue[bestIndex].Value;
        _queue.RemoveAt(bestIndex);

        return value;
    }

    public override string ToString()
    {
        return "[" + string.Join(", ", _queue.Select(x => $"{x.Value} (Pri:{x.Priority})")) + "]";
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