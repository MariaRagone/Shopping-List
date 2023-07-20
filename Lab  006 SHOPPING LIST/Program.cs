using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

// ...

decimal total = 0;

Console.WriteLine("Welcome to Maria's Humorous Haberdashery for Humans.");

// Dictionary - store list of items and prices
Dictionary<string, decimal> store = new Dictionary<string, decimal>
{
    // Start with some items and prices
    // store.Add("Ravioli", 17.99)  //can also add
    { "Zany Zoink Zapper", 119.99m },
    { "Shuffle and Sniff Bacon Slippers", 54.99m },
    { "Nostalgia Scented Air Freshener", 2.49m },
    { "Soup-er Hero Supper & Snack Ladle", 5.29m },
    { "Snooze Master Reverse Alarm Clock", 153.00m },
    { "Flame-Defiant Toaster", 72.99m },
    { "Chatter Leaf Talking Houseplant", 10.99m },
    { "Unicorn Glitter Perfume", 45.00m },
    { "Booty Bliss Buzzing Butt-erfly Chair", 749.99m }
};

// View the store list
Console.WriteLine(String.Format("{0,5} {1,-35} {2,10}", "Number", "Item", "Price"));
Console.WriteLine(String.Format("{0,5} {1,-35} {2,10}", "------", "----", "-----"));

// create a way to show a number next to the menu item
int number = 1;
//create the list
foreach (KeyValuePair<string, decimal> kvp in store)
{
    Console.WriteLine(String.Format("{0,5}. {1,-35} {2,10}", number, kvp.Key, kvp.Value));
    number++; // Add index every time
}

//create empty list to add into later
List<string> cart = new List<string>();

// get user input
// Ask the user to enter an item number
while (true)
{
    Console.WriteLine("\nEnter an item number to add to your cart.");
    string input = Console.ReadLine().Trim();
    //if(store.ContainsKey(input)

    //Console.WriteLine(store.ElementAt(int.Parse(numberChoice)).Key);
    //tryparse is a method that tries the input without an exception. if it can then = true
    if (int.TryParse(input, out int numberChoice) && numberChoice >= 1 && numberChoice <= store.Count)
    {
        string item = store.ElementAt(numberChoice - 1).Key;
        Console.WriteLine($"You added {item} for {store[item]} to your cart");
        cart.Add(item);
    }
    else //if user choice is invalid
    {
        Console.WriteLine("Invalid item number. Please try again.");
    }

    // Ask user if they want to add something else
    Console.WriteLine("Do you want to add something else? y/n");
    string answer = Console.ReadLine().ToLower().Trim();
    if (answer == "n")
    {
        // Display the cart
        Console.Clear();
        Console.WriteLine("Here is your cart");
        Console.WriteLine("*****************");
        Console.WriteLine(String.Format("{0,-35} {1,10}", "Item", "Price"));
        Console.WriteLine(String.Format("{0,-35} {1,10}", "------", "------"));

        foreach (string c in cart)
        //foreach (string c in cart.OrderByDescending(c => store[c])) // Display the items in the cart
        {
            total += store[c];
            Console.WriteLine(String.Format("{0,-35} {1,10}", c, store[c]));
        }
        
        //display the total 
        Console.WriteLine($"\nPlease pay: {total}");

        List<string> sortedCart = cart.OrderBy(c => store[c]).ToList();
        // Display the most and least expensive items
        string mostExpensive = sortedCart.Last();
        string leastExpensive = sortedCart.First();

        Console.WriteLine($"Most expensive item: {mostExpensive} @ {store[mostExpensive]}");
        Console.WriteLine($"Least expensive item: {leastExpensive} @ {store[leastExpensive]}");

        break; // Stop asking if they want to add something to the cart
    }
    else if (answer == "y")
    {

    }
    else 
    {
        Console.WriteLine("Invalid response.");
        break;
    }
}
