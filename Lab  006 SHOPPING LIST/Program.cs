using System.Diagnostics;
using System.Threading.Tasks;
//VARIABLES
decimal total = 0;
Console.WriteLine("Welcome to my store.");

//DICTIONARY - store list of items and prices
Dictionary<string, decimal> store = new Dictionary<string, decimal> //store is the collection of items
//store.Add("apple", 0.99);
//store.Add("chicken", 4.99);
//store.Add("lettuce", 2.49);
//store.Add("cheese", 5.29);
//store.Add("cherries", 3.00);
//store.Add("strawberries", 2.99);
//store.Add("cake", 10.99);
//store.Add("icecream", 3.99);
{
    { "apple", 0.99m },
    { "chicken", 4.99m },
    { "lettuce", 2.49m },
    { "cheese", 5.29m},
    { "cherries", 3.00m},
    { "strawberries", 2.99m},
    { "cake", 10.99m},
    { "icecream", 3.99m}
};
//Console.WriteLine(store["chicken"]);



Console.WriteLine("Enter an item name.");


//view the store list
Console.WriteLine(String.Format("{0,15} {1,15}", "Item", "Price"));
Console.WriteLine(String.Format("{0,15} {1,15}", "------", "------"));

foreach (KeyValuePair<string, decimal> kvp in store)
{
    Console.WriteLine(String.Format("{0,15} {1,15}", kvp.Key, kvp.Value));
}

//ASK THE USER TO ENTER AN ITEM NAME
List<string> cart = new List<string>();
while (true)
{
    Console.WriteLine("What do you want to add to your cart?");
    string item = Console.ReadLine().ToLower().Trim();
    if (store.ContainsKey(item)) //call up the dictionary "store" and look for the user input
    {
        //display the item to add to the cart
        Console.WriteLine($"You added {item} for {store[item]} to your cart"); //inside [] is the key

        //add item to the shopping cart
        //LIST - store user choices in a shopping cart
        

        cart.Add(item);
       
    }
    else
    {
        Console.WriteLine("item not found");
    }


    //ask user if they want to add something else
    Console.WriteLine("Do you want to add something else? y/n");
    string answer = Console.ReadLine().ToLower().Trim();
    if (answer == "n")
    {
        //create a new list for the organized cart
        //display the cart
        Console.Clear();
        Console.WriteLine("Here is your cart");
        Console.WriteLine("*****************");
        Console.WriteLine(String.Format("{0,10} {1,10}", "Item", "Price"));
        Console.WriteLine(String.Format("{0,10} {1,10}", "------", "------"));

        foreach (string c in cart) // display the items in the cart
        {

            total += store[c];
            Console.WriteLine(String.Format("{0,10} {1,10}", c, store[c]));
            //Console.WriteLine(String.Format("{0,10} {1,10}", c, store[item]).OrderByDescending(x => x));//prints the entire list
            Console.WriteLine(c);
        }
        //average total == store[item].Count
        Console.WriteLine($"Please pay: {total}");
        // Display the most and least expensive items
        var sortedCart = cart.OrderBy(c => store[c]);
        var mostExpensive = sortedCart.Last();
        var leastExpensive = sortedCart.First();

        Console.WriteLine($"Most expensive item: {mostExpensive}: {store[mostExpensive]}");
        Console.WriteLine($"Least expensive item: {leastExpensive}: {store[leastExpensive]}");

        break;
        break; //stops asking if they want to add something to the cart
        
    }
    else if (answer == "y")
    {
        continue; //keeps asking if they want to add something to the cart
    }
}

//METHOD
static bool Continue(){    while (true)    {        string x = Console.ReadLine().ToLower().Trim();        if ("yes".Contains(x))        {            return true;        }        else if ("no".Contains(x))        {            return false;        }        else        {            Console.WriteLine("Invalid response. Please try again. y/n");        }    }}