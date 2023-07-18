using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problem_statement9
{
    internal class Program
    {
       
        
            public class ValidationException : Exception
        {
            public ValidationException(string message) : base(message)
            {
            }
        }

        public class User
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class UserRegistrationSystem
        {
            public static void Main(string[] args)
            {
                try
                {
                    Console.Write("Enter your name: ");
                    string name = ReadStringInput();
                    Console.Write("Enter your email: ");
                    string email = ReadEmailInput();
                    Console.Write("Enter your password: ");
                    string password = ReadPasswordInput();
                    ValidateInput(name, email, password);
                    User user = new User
                    {
                        Name = name,
                        Email = email,
                        Password = password
                    };
                    Console.WriteLine("User registration successful!");
                    Console.WriteLine("Password: " + password);
                    InsertUserDetails(user);
                }
                catch (ValidationException ex)
                {
                    Console.WriteLine("Validation Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            private static string ReadStringInput()
            {
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    throw new ValidationException("Input is required.");
                }

                if (!input.All(char.IsLetter))
                {
                    throw new ValidationException("Name should only contain alphabetic characters.");
                }

                return input;
            }

            private static string ReadEmailInput()
            {
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    throw new ValidationException("Email is required.");
                }
                if (!input.Contains("@") || !input.Contains("."))
                {
                    throw new ValidationException("Invalid email format.");
                }

                return input;
            }

            private static string ReadPasswordInput()
            {
                string input = string.Empty;

                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                    if (!char.IsControl(key.KeyChar))
                    {
                        input += key.KeyChar;
                        Console.Write("*");
                    }
                } while (key.Key != ConsoleKey.Enter);

                Console.WriteLine();
                if (input.Length < 8)
                {
                    throw new ValidationException("Password must have at least 8 characters.");
                }

                return input;
            }

            private static void ValidateInput(string name, string email, string password)
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ValidationException("Name is required.");
                }

                if (string.IsNullOrEmpty(email))
                {
                    throw new ValidationException("Email is required.");
                }

                if (string.IsNullOrEmpty(password))
                {
                    throw new ValidationException("Password is required.");
                }
                if (name.Length < 6)
                {
                    throw new ValidationException("Name must have at least 6 characters.");
                }
            }

            private static void InsertUserDetails(User user)
            {
                Console.WriteLine("User details inserted: Name = " + user.Name + ", Email = " + user.Email + ", Password = " + user.Password);
            }
        }
    }
    }

