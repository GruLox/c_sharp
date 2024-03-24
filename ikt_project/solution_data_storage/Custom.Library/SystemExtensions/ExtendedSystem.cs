namespace System;
public static class ExtendedSystem
{
    public static void WriteToConsole(this object objectToDisplay) => Console.Write(objectToDisplay);

    public static void WriteCollectionToConsole<T>(this IEnumerable<T> collection)
    {
        if (!collection.Any())
        {
            Console.WriteLine("No items found");
            return;
        }
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
}

