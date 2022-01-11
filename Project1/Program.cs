using System.Data.SqlClient;
using System.IO;
using static System.Console;
using Project1.Dtos;
using Project1.StoreServices;

//CustomerDtos customerDtos = await LoadService.CustomerLoadServiceAsync("Samantha", "Roderick");
//Console.WriteLine(customerDtos.firstName);
//Console.WriteLine(customerDtos.lastName);

//CustomerDtos newCustomer = new CustomerDtos();
//newCustomer.firstName = "Megan";
//newCustomer.lastName = "Postlewait";
//newCustomer.address = "12345 6th Street";
//newCustomer.city = "Astoria";
//newCustomer.state = "Oregon";
//await CustomerPostServiceAsync.PostNewCustomerServiceAsync(newCustomer);


///<summary>
///everything in the console side is doing the opposite of the controller side
///also, every method in a controller needs to have a paired method on the console side that's the opposite of the controller
/// </summary>






namespace Project1
{

    class Program
    {
        public static async Task Main(string[] args)
        {
            #region fields
            int userStatueSelection = 0;
            int userDesiredQuantity = 0;
            int[] allowedQuantity = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string[] stores = { "Seattle", "Portland", "Sacramento" };
            int storeChoice = 0;
            string response;
            bool verifyCustomer = false;
            bool keepShopping = false;
            string? toContinue = "";
            string statueStyle = "";
            int[] statueMenuOptions = { 1, 2, 3, 4, 5 };
            int storeID;
            string modifyInventoryCommand = "";
            #endregion
            WriteLine("\n\nWelcome to the Garden Ceramics Store!\n");
            do
            {
                WriteLine("Are you a new customer? y/n?");
                response = ReadLine();
                string yesno = response.ToLower();
                if (yesno == "y")
                {
                    CustomerDtos customer = new CustomerDtos();
                    CustomerHandler customerH = new CustomerHandler();
                    WriteLine("Please enter your first name.");
                    customer.firstName = ReadLine();
                    WriteLine("Please enter your last name");
                    customer.lastName = ReadLine();
                    WriteLine("What is the first line of your address for shipping?");
                    customer.address = ReadLine();
                    WriteLine("What is your city?");
                    customer.city = ReadLine();
                    WriteLine("What is your state?");
                    customer.state = ReadLine();
                    await customerH.AddCustomerAsync(customer);
                    

                    WriteLine($"It's nice to meet you, {customer.firstName} {customer.lastName}!");
                    verifyCustomer = true;
                    
                    break;
                }
                else
                {
                    CustomerHandler customerH = new CustomerHandler();
                    CustomerDtos customer = new CustomerDtos();
                    WriteLine("Let's look you up in our database. What is your first name?");
                    customer.firstName = ReadLine();
                    WriteLine("What is your last name?");
                    customer.lastName = ReadLine();
                    try
                    {
                        WriteLine("\nPrinting search results... \n\n-----------------------------------------------------------------------------");
                        var custom = await customerH.CustomerLookupAsync(customer);
                        string customerDisp = $"{custom.firstName} {custom.lastName} {custom.city} {custom.state}";
                        WriteLine(customerDisp);
                        WriteLine("----------------------------------------------------------------------------- \n\nIs this you? y/n");

                        string verifyCorrect = ReadLine();
                        yesno = verifyCorrect.ToLower();
                        if (yesno == "y")
                        {
                            WriteLine($"Welcome back, {customer.firstName}!");
                            verifyCustomer = true;
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        WriteLine("\nWe could not find you in our database. Please verify that your information is correct.\n");
                    }
                }
            } while (!verifyCustomer);



            WriteLine("\nWhat store would you like to order from?");
            StoreHandler storeHandler = new StoreHandler();
            StoreDtos store = new StoreDtos();
            //var sto = await storeHandler.DisplayStoreOptionsAsync(store);
            //string storeDisplay = $"{sto.StoreID}";
            WriteLine("\nPlease select from the following:\nFor Seattle, enter 1 \nFor Portland, enter 2 \nFor Sacramento, enter 3");


            do
            {
                storeChoice = Convert.ToInt32(ReadLine());
                if (storeChoice == 1)
                {
                    store.StoreID = 80;
                }
                else if (storeChoice == 2)
                {
                    store.StoreID = 81;
                }
                else if (storeChoice == 3)
                {
                    store.StoreID = 82;
                }
                else
                {
                    storeID = 0;
                }
                try
                {
                    WriteLine($"You have selected {stores[storeChoice - 1]}. Excellent choice!");
                    break;
                }
                catch (IndexOutOfRangeException)
                {
                    WriteLine("Error: Options are from 1 to 3 \nPlease enter 1 for Seattle, 2 for Portland, or 3 for Sacramento.");
                    continue;
                }
                catch (FormatException)
                {
                    WriteLine("Error: you did not enter a number. \nPlease enter 1 for Seattle, 2 for Portland, or 3 for Sacramento.");
                    continue;
                }
            }
            while (storeChoice != 0);

            StatueHandler statueHandler = new StatueHandler();
            StatueDtos statue = new StatueDtos();
            var stat = await statueHandler.DisplayStatues(store.StoreID);
            string statueDisplay = $"Enter: {statue.itemID}, to select {statue.style}\t${statue.price}";
            WriteLine(statueDisplay);

            do
                {
                    userStatueSelection = Convert.ToInt32(ReadLine());
                    //decimal total = 0;
                    try
                    {
                        WriteLine($"You have chosen {statueMenuOptions[userStatueSelection - 1]}");
                        break;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        WriteLine("That is not a valid choice. Please make a selection from 1 to 5.");
                        continue;
                    }
                } while (userStatueSelection != 0);
                WriteLine($"How many would you like to order? (Order quantity must not exceed 10.");
                while (userDesiredQuantity != null)
                {
                    try
                    {
                        userDesiredQuantity = Convert.ToInt32(ReadLine());
                        WriteLine($"You would like to purchase {allowedQuantity[userDesiredQuantity - 1]}.");

                        break;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        WriteLine("Error: Quantity must not be less than 1, or more than 10.\nHow many would you like to order?)");
                        continue;
                    }
                    catch (FormatException)
                    {
                        WriteLine("Error: you did not enter a number. \nPlease enter a number 1 - 10 as your desired quantity.");
                        continue;
                    }
                    catch (ArgumentNullException)
                    {
                        WriteLine("Please enter a valid quantity as a number value.");
                        continue;
                    }
                }
            //StatueHandler statueHandler = new StatueHandler();
            //StatueDtos statue = new StatueDtos();
            await statueHandler.UpdateStoreQuantity(userDesiredQuantity, store.StoreID);

            WriteLine("Thank you for your purchase. Please see your order history:");
            CustomerHandler customerHandler = new CustomerHandler();
            CustomerDtos customerDtos = new CustomerDtos();
            OrderDtos order = new OrderDtos();
            var cust = await customerHandler.CustomerOrderHistoryAsync(customerDtos);
            string customerDisplay = $"{order.orderID} {order.storeID} {order.storeLocation}";
            WriteLine(customerDisplay);
        }
    }
}