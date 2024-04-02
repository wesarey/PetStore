


using PetStore;
using System.Text.Json;

namespace PetStore
{    
    public class Program
    {
        private static ProductLogic productLogic = new ProductLogic();
        static void Main(string[] args)
        {
            PromptUser();
        }

        private static void PromptUser()
        {
            DisplayWelcome();

            Console.WriteLine("Type '1' to Add a product");
            Console.WriteLine("Type '2' to Retrieve a product");
            Console.WriteLine("Type 'exit' to quit");
            string userInput = Console.ReadLine();

            HandleUserInput(userInput);
        }

        private static void HandleUserInput(string userInput)
        {
            if (userInput != "exit")
            {
                if (userInput == "1")
                {
                    AddProduct();
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("What type of product would you like to retrieve?");
                    Console.WriteLine("Type '1' for Cat Food");
                    Console.WriteLine("Type '2' for Dog Leash");
                    string retrieveInput = Console.ReadLine();
                    if (retrieveInput == "1")
                    {
                        RetrieveCatFood();
                    }
                    else if (retrieveInput == "2")
                    {
                        RetrieveDogLeash();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                        PromptUser();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    PromptUser();
                }
            }
        }

        private static void RetrieveDogLeash()
        {
            Console.WriteLine("What is the name of the dog leash you would like to retrieve?");
            string dogLeashName = Console.ReadLine();
            DogLeash dogLeash = productLogic.GetDogLeashByName(dogLeashName);
            if (dogLeash == null)
            {
                Console.WriteLine("Product not found. Please try again.");
                PromptUser();
            }
            else
            {
                Console.WriteLine(dogLeash.DisplayName);
                Console.WriteLine("press enter to continue...");
                Console.ReadLine();
                PromptUser();
            }
        }

        private static void RetrieveCatFood()
        {
            Console.WriteLine("What is the name of the cat food you would like to retrieve?");
            string catFoodName = Console.ReadLine();
            CatFood catFood = productLogic.GetCatFoodByName(catFoodName);
            if (catFood == null)
            {
                Console.WriteLine("Product not found. Please try again.");
                PromptUser();
            }
            else
            {
                Console.WriteLine(catFood.DisplayName);
                Console.WriteLine("press enter to continue...");
                Console.ReadLine();
                PromptUser();
            }
        }

        private static void DisplayWelcome()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Pet Store!");
            Console.WriteLine("What would you like to do?");
        }

        private static void AddProduct()
        {
            Console.WriteLine("What type of product would you like to add?");
            Console.WriteLine("Type '1' for Cat Food");
            Console.WriteLine("Type '2' for Dog Leash");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                try
                {
                    AddCatFood();
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Whoops! Please try again");
                    AddCatFood();
                }
            }
            else if (userInput == "2")
            {
                try
                {
                    AddDogLeash();
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Whoops! Please try again");
                    AddDogLeash();
                }                
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
                AddProduct();
            }
        }

        private static void AddDogLeash()
        {
            Console.WriteLine("What is the name of the product?");
            string name = Console.ReadLine();
            Console.WriteLine("What is the price of the product?");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("What is the quantity of the product?");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is the description of the product?");
            string description = Console.ReadLine();
            Console.WriteLine("What is the material of the leash?");
            string material = Console.ReadLine();
            Console.WriteLine("What is the length of the leash in inches?");
            int lengthInches = Convert.ToInt32(Console.ReadLine());
            DogLeash leash = new DogLeash
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                Description = description,
                Material = material,
                LengthInches = lengthInches
            };
            Console.WriteLine("You have added a new dog leash to the store!");

            //Console.WriteLine(JsonSerializer.Serialize(leash));
            productLogic.AddProduct(leash);
            
            Console.WriteLine("press enter to continue...");
            Console.ReadLine();
            PromptUser();
        }

        private static void AddCatFood()
        {
            Console.WriteLine("What is the name of the product?");
            string name = Console.ReadLine();
            Console.WriteLine("What is the price of the product?");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("What is the quantity of the product?");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is the description of the product?");
            string description = Console.ReadLine();
            Console.WriteLine("What is the weight of the cat food in pounds?");
            double weightPounds = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Is this kitten food? Type 'yes' or 'no'");
            string kittenFood = Console.ReadLine();
            bool isKittenFood = false;
            if (kittenFood == "yes")
            {
                isKittenFood = true;
            }
            CatFood food = new CatFood
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                Description = description,
                WeightPounds = weightPounds,
                KittenFood = isKittenFood
            };
            Console.WriteLine("You have added a new cat food to the store!");
            
            //Console.WriteLine(JsonSerializer.Serialize(food));
            productLogic.AddProduct(food);
            
            Console.WriteLine("press enter to continue...");
            Console.ReadLine();
            PromptUser();
        }
    }
}
