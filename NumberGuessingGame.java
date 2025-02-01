import java.util.Random;
import java.util.Scanner;

public class NumberGuessingGame {

    public static void main(String[] args) {
        // Create a Scanner object for user input
        Scanner scanner = new Scanner(System.in);
        
        // Generate a random number between 1 and 100
        Random random = new Random();
        int numberToGuess = random.nextInt(100) + 1;
        
        // Variable to store the user's guess
        int userGuess = 0;
        
        // Variable to count the number of attempts
        int attempts = 0;
        
        // Game loop
        System.out.println("Welcome to the Number Guessing Game!");
        System.out.println("I have selected a number between 1 and 100. Try to guess it!");
        
        // Loop until the user guesses the correct number
        while (userGuess != numberToGuess) {
            System.out.print("Enter your guess: ");
            userGuess = scanner.nextInt();  // Get user's guess
            
            attempts++;  // Increment attempts
            
            // Check if the guess is correct, too high, or too low
            if (userGuess < numberToGuess) {
                System.out.println("Too low! Try again.");
            } else if (userGuess > numberToGuess) {
                System.out.println("Too high! Try again.");
            } else {
                System.out.println("Congratulations! You guessed the number correctly.");
                System.out.println("It took you " + attempts + " attempts.");
            }
        }
        
        // Close the scanner to prevent memory leaks
        scanner.close();
    }
}
