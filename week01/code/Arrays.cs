public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array called multiples
        // The array size should be equal to the length provided
        double[] multiples = new double[length];

        // Step 2: Use a loop to go through each position in the array
        for (int i = 0; i < length; i++)
        {
            // Step 3: Find the multiple of the number
            // Multiply the number by (i + 1)
            // We use (i + 1) because array indexes start from 0
            double result = number * (i + 1);

            // Step 4: Store the result in the array
            multiples[i] = result;
        }

        // Step 5: Return the completed array
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Create a temporary list to store the rotated values
        List<int> rotated = new List<int>();

        // Step 2: Find the position where the rotation should start
        // Example:
        // If the list has 9 items and amount is 3
        // 9 - 3 = 6
        // So index 6 is where the last 3 items begin
        int start = data.Count - amount;

        // Step 3: Add the last 'amount' items to the temporary list first
        for (int i = start; i < data.Count; i++)
        {
            rotated.Add(data[i]);
        }

        // Step 4: Add the remaining items from the beginning of the list
        for (int i = 0; i < start; i++)
        {
            rotated.Add(data[i]);
        }

        // Step 5: Clear the original list
        data.Clear();

        // Step 6: Copy the rotated items back into the original list
        foreach (int item in rotated)
        {
            data.Add(item);
        }
    }
}
