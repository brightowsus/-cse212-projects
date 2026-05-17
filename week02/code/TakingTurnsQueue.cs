using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private Queue<Person> _queue = new Queue<Person>();

    public int Length => _queue.Count;

    public void AddPerson(string name, int turns)
    {
        _queue.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person current = _queue.Dequeue();

        // Infinite turn case
        if (current.Turns <= 0)
        {
            _queue.Enqueue(current);
            return current;
        }

        // Finite turns case
        current.Turns--;

        if (current.Turns > 0)
        {
            _queue.Enqueue(current);
        }

        return current;
    }
}