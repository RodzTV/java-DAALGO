using System;

public class Test
{
    public static void Main(String[] args)
    {
        Console.WriteLine("ATM SYSTEM \n CREATED BY RODRIGURZ\n\n");
        Console.WriteLine("Welcome to Banko");
        double Balance = 1000;
        bool Run = true;

        while (Run)
        {
            // Menu
            Console.WriteLine("Menu");
            Console.WriteLine("1 FOR Checking the Balance");
            Console.WriteLine("2 FOR Deposit Money");
            Console.WriteLine("3 FOR Withdraw Money");
            Console.WriteLine("4 Exit the System");

            // Fixed typo: Covert to Convert
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1: // Fixed syntax error: removed colon after case
                    Console.WriteLine("Your Balance now is " + Balance);
                    break;

                case 2: // Fixed syntax error: removed colon after case
                    Console.WriteLine("Please Enter the amount");
                    // Fixed typo: Covert to Convert
                    int Deposit = Convert.ToInt32(Console.ReadLine());
                    Balance += Deposit;
                    Console.WriteLine("Your New Balance is " + Balance);
                    continue; // This will continue to the next iteration of the while loop

                case 3: // Fixed syntax error: removed colon after case
                    while (true) // Changed from goto to a while loop for better practice
                    {
                        Console.WriteLine("\nPlease enter the amount");
                        // Fixed typo: Covert to Convert
                        int Withdraw = Convert.ToInt32(Console.ReadLine());

                        // Added condition to check for negative withdraw
                        if (Withdraw < 0)
                        {
                            Console.WriteLine("Invalid amount. Please enter a positive value.");
                            continue; // Continue to ask for a valid amount
                        }

                        if (Balance <= 0)
                        {
                            Console.WriteLine("System Error: Insufficient funds. Please try again.");
                            continue; // Continue to ask for a valid amount
                        }
                        else if (Balance < Withdraw)
                        {
                            Console.WriteLine("You don't have enough money.");
                        }
                        else
                        {
                            Balance -= Withdraw;
                            Console.WriteLine("Your new Balance is " + Balance);
                            break; // Exit the while loop after a successful withdrawal
                        }
                    }
                    break;
                case 4: // Fixed syntax error: removed colon after case
                    Console.WriteLine("Thank you for using our system. Bye!");
                    Run = false; // Set Run to false to exit the loop
                    break;

                default: // Added default case for invalid options
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}