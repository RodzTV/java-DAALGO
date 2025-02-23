using System;
using System.Collections;
using System.Linq;
class User {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
}
class Program {
    private static ArrayList users = new ArrayList();
    private static User currentUser = null;
    static void Main(string[] args){
        while (true){
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            switch (choice){
                case "1":
                    Login();
                    break;
                case "2":
                    Register();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
    static void Login() {
        int attempts = 0;
        while (attempts < 3) {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            foreach (User user in users) {
                if (user.Username == username && user.Password == password) {
                    currentUser = user;
                    user.Token = new string(user.Password.Reverse().ToArray()) + user.Username;
                    Console.WriteLine("Login successful! Token: " + user.Token);
                    ShowMainMenu();
                    return;
                }
            }
            attempts++;
            Console.WriteLine("Invalid username or password. Attempts left: " + (3 - attempts));
        }
        Console.WriteLine("Too many failed attempts. Exiting...");
        Environment.Exit(0);
    }
    static void Register(){
        User newUser = new User();
        Console.Write("First Name: ");
        newUser.FirstName = Console.ReadLine();
        Console.Write("Last Name: ");
        newUser.LastName = Console.ReadLine();
        Console.Write("Middle Name (Optional): ");
        newUser.MiddleName = Console.ReadLine();
        Console.Write("Contact Number: ");
        newUser.ContactNumber = Console.ReadLine();
        Console.Write("Email: ");
        newUser.Email = Console.ReadLine();
        Console.Write("Username: ");
        newUser.Username = Console.ReadLine();
        Console.Write("Password: ");
        newUser.Password = Console.ReadLine();
        Console.Write("Role (User/Admin): ");
        newUser.Role = Console.ReadLine();
        
        bool emailExists = users.Cast<User>().Any(u => u.Email == newUser.Email);
        bool usernameExists = users.Cast<User>().Any(u => u.Username == newUser.Username);
        if (emailExists || usernameExists){
            Console.WriteLine("Email or Username already exists. Registration failed.");
            return;
        }
        if (string.IsNullOrEmpty(newUser.Password) || (newUser.Role != "User" && newUser.Role != "Admin")){
            Console.WriteLine("Invalid password or role. Registration failed.");
            return;
        }
        users.Add(newUser);
        Console.WriteLine("Registration successful!");
    }
    static void ShowMainMenu(){
        while (true){
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. View Profile");
            Console.WriteLine("2. View All Profiles (Admin Only)");
            Console.WriteLine("3. Change Password");
            Console.WriteLine("4. Logout");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            switch (choice){
                case "1":
                    ViewProfile();
                    break;
                case "2":
                    ViewAllProfiles();
                    break;
                case "3":
                    ChangePassword();
                    break;
                case "4":
                    currentUser = null;
                    Console.WriteLine("Logged out successfully.");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
    static void ViewProfile(){
        Console.WriteLine("\nProfile Details:");
        Console.WriteLine($"Name: {currentUser.FirstName} {currentUser.MiddleName} {currentUser.LastName}");
        Console.WriteLine($"Contact: {currentUser.ContactNumber}");
        Console.WriteLine($"Email: {currentUser.Email}");
        Console.WriteLine($"Role: {currentUser.Role}");
    }
    static void ViewAllProfiles(){
        if (currentUser.Role != "Admin"){
            Console.WriteLine("Access Denied: This feature is for Admins only!");
            return;
        }

        Console.WriteLine("\nAll Profiles:");
        foreach (User user in users){
            Console.WriteLine($"Name: {user.FirstName} {user.MiddleName} {user.LastName}, Email: {user.Email}, Role: {user.Role}");
        }
    }

    static void ChangePassword(){
        Console.Write("Enter old password: ");
        string oldPassword = Console.ReadLine();
        if (oldPassword != currentUser.Password){
            Console.WriteLine("Incorrect old password.");
            return;
        }

        Console.Write("Enter new password: ");
        string newPassword = Console.ReadLine();
        if (string.IsNullOrEmpty(newPassword)){
            Console.WriteLine("Password cannot be empty.");
            return;
        }

        currentUser.Password = newPassword;
        currentUser.Token = new string(currentUser.Password.Reverse().ToArray()) + currentUser.Username;
        Console.WriteLine("Password changed successfully. New token: " + currentUser.Token);
    }
}