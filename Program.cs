using SellCarApp.controller;
using SellCarApp.model;
using System.Text.RegularExpressions;

namespace SellCarApp
{
    internal class Program
    {

        public static void login()
        {
            StreamReader reader = File.OpenText("C:\\Users\\Liviu\\Desktop\\code\\C#\\SellCarApp\\data\\logins.txt");
            string line;
            Dictionary<string, string> logins = new Dictionary<string, string>();
            line = reader.ReadLine();
            while (line != null)
            {
                string[] values = line.Split(" ");
                logins[values[0]] = values[1];
                line = reader.ReadLine();
            }
            bool check = true;
            while (check)
            {
                string us = Read("Enter the user: ");
                string pass = Read("Enter the password: ");

                try
                {
                    if (logins[us] == pass)
                    {
                        check = false;
                        Console.WriteLine("Login succesfull !");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("User or password incorrect. Please try again!");
                    }
                    Console.WriteLine("If you want to stop , enter 'stop'");
                    string readed = Read("Enter: ");
                    if (readed == "stop")
                    {
                        check = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("User or password incorrect. Please try again!");
                }


            }
            reader.Close();

        }
        public static void register()
        {
            StreamWriter writer = new StreamWriter("C:\\Users\\Liviu\\Desktop\\code\\C#\\SellCarApp\\logins.txt");
            string user,pass;
            do
            {
                user = Read("Enter a new user: ");
            } while (!checkUser(user));
            do
            {
                pass = Read("Enter a new password: ");
            } while (!checkPassword(pass));
            writer.WriteLine(user + " " + pass);
            writer.Close();
        }

        public static bool checkUser(string user)
        {
            Regex regex = new Regex(@"^[A-za-z0-9_$]{3,15}$");
            if (regex.IsMatch(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkPassword(string pass)
        {
            Regex regex = new Regex(@"^[A-za-z0-9.,_$-]{8,25}$");
            if (regex.IsMatch(pass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string Read(string name)
        {

            Console.Write(name);
            return Console.ReadLine();

        }

        public static int mainMenuSellCarCompany()
        {
            Console.WriteLine("Welcome to Main Menu of Sell Car Company");
            Console.WriteLine("What is your choice -> ");
            Console.WriteLine("1. Manage Cars");
            Console.WriteLine("2. Manage Customers");
            Console.WriteLine("3. Manage Salepersones");
            Console.WriteLine("4. Manage StoreBranches");
            Console.WriteLine("5. Manage Sales");
            Console.WriteLine("6. Sign Out And Save All Changes");
            Console.WriteLine("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }

        public static int secondaryMenuSellCarCompany(string s)
        {
            Console.WriteLine("Welcome to Secondary Menu of Sell Car Company");
            Console.WriteLine("What is your choice -> ");
            Console.WriteLine($"1. Get {s}");
            Console.WriteLine($"2. Get By Id {s}");
            Console.WriteLine($"3. Create {s}");
            Console.WriteLine($"4. Update {s}");
            Console.WriteLine($"5. Delete {s}");
            Console.WriteLine($"6. Return back to main menu");
            Console.WriteLine("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }

        public static int loginMenu()
        {
            Console.WriteLine("Welcome !");
            Console.WriteLine("Please make a choice !");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3.");
            return Convert.ToInt32(Read("Enter :"));
        }

        // -----------------------------------------------------------------
        static void Main(string[] args)
        {
            bool choice1 = false, choice2 = true, check;
            string choiceStr = null, id;
            CarController carController = new CarController();
            CustomerController customerController = new CustomerController();
            SaleController saleController = new SaleController();
            SalepersonController salepersonController = new SalepersonController();
            StoreBrancheController storeBrancheController = new StoreBrancheController();
            bool choice = true;
            while(choice)
            {
                Console.Clear();
                int option = loginMenu();
                switch(option)
                {
                    case 1: login(); choice1 = true; break;
                    case 2: register(); break;
                    case 3: return;
                }

                while (choice1)
                {
                    Console.Clear();
                    int op = mainMenuSellCarCompany();
                    choice2 = true;
                    switch (op)
                    {
                        case 1: choiceStr = "Car"; break;
                        case 2: choiceStr = "Customer"; break;
                        case 3: choiceStr = "Saleperson"; break;
                        case 4: choiceStr = "StoreBranche"; break;
                        case 5: choiceStr = "Sale"; break;
                        case 6: choice1 = false; break;
                    }


                    switch (op)
                    {
                        case 1:

                            while (choice2)
                            {
                                Console.Clear();
                                int op2 = secondaryMenuSellCarCompany(choiceStr);

                                switch (op2)
                                {
                                    case 1:
                                        if (carController.getAll().Count() != 0)
                                        {
                                            foreach (Car car in carController.getAll())
                                            {
                                                Console.WriteLine(car.toString());
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Elements");
                                        }

                                        break;
                                    case 2:
                                        id = Read("Enter the id for the element your searching :");
                                        Console.WriteLine(carController.getById(id).toString());
                                        break;
                                    case 3:
                                        Console.WriteLine("Create a new Car!");
                                        do
                                        {
                                            id = Read("Enter id : ");
                                        } while (!carController.SearchIdIfExist(id));
                                        string producer = Read("Enter Producer : ");
                                        string model = Read("Enter Model : ");
                                        int year = Convert.ToInt32(Read("Enter Year : "));
                                        int mileage = Convert.ToInt32(Read("Enter Mileage : "));
                                        double price = Convert.ToDouble(Read("Enter Price : "));
                                        carController.create(new Car(id, producer, model, year, mileage, price));
                                        break;
                                    case 4:

                                        Console.WriteLine("Update a Car from the list !");
                                        foreach (Car car in carController.getAll())
                                        {
                                            Console.WriteLine(car.toString());
                                        }
                                        string idx = Read("Enter the car id on which you want to update : ");
                                        id = "";
                                        producer = "";
                                        model = "";
                                        year = -1;
                                        mileage = -1;
                                        price = -1;
                                        bool update = true;
                                        while (update)
                                        {
                                            Console.WriteLine("What do you want to update ?");
                                            Console.WriteLine("1. Id");
                                            Console.WriteLine("2. Producer");
                                            Console.WriteLine("3. Model");
                                            Console.WriteLine("4. Year");
                                            Console.WriteLine("5. Mileage");
                                            Console.WriteLine("6. Price");
                                            Console.WriteLine("7. Done with updates");
                                            int whatUp = Convert.ToInt32(Read("Enter your choice: "));
                                            switch (whatUp)
                                            {
                                                case 1:
                                                    do
                                                    {
                                                        id = Read("Enter the new Id : ");
                                                        if (id == idx) break;
                                                    } while (!carController.SearchIdIfExist(id));
                                                    break;
                                                case 2:
                                                    producer = Read("Enter the new Producer: ");
                                                    break;
                                                case 3:
                                                    model = Read("Enter the new Model : ");
                                                    break;
                                                case 4:
                                                    year = Convert.ToInt32(Read("Enter the new Year : "));
                                                    break;
                                                case 5:
                                                    mileage = Convert.ToInt32(Read("Enter the new Mileage : "));
                                                    break;
                                                case 6:
                                                    price = Convert.ToInt32(Read("Enter the new Price : "));
                                                    break;
                                                case 7:
                                                    update = false;
                                                    break;
                                            }
                                        }


                                        carController.update(idx, new Car(id, producer, model, year, mileage, price));
                                        break;
                                    case 5:
                                        Console.WriteLine("Delete a Car from the list!");
                                        foreach (Car car in carController.getAll())
                                        {
                                            Console.WriteLine(car.toString());
                                        }
                                        idx = "";
                                        do
                                        {
                                            idx = Read("Enter the car id on which you want to delete : ");
                                        } while (carController.SearchIdIfExist(idx));
                                        carController.remove(idx);
                                        break;
                                    case 6:
                                        choice2 = false;
                                        break;
                                }
                                id = Read("Press any key to continue !");
                            }


                            break;

                        case 2:

                            while (choice2)
                            {
                                Console.Clear();
                                int op2 = secondaryMenuSellCarCompany(choiceStr);

                                switch (op2)
                                {
                                    case 1:
                                        if (customerController.getAll().Count() != 0)
                                        {
                                            foreach (Customer customer in customerController.getAll())
                                            {
                                                Console.WriteLine(customer.toString());
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Elements");
                                        }
                                        break;
                                    case 2:
                                        id = Read("Enter the id for the element your searching :");
                                        Console.WriteLine(customerController.getById(id).toString());
                                        break;
                                    case 3:
                                        Console.WriteLine("Create a new Customer!");
                                        do
                                        {
                                            id = Read("Enter id : ");
                                        } while (!customerController.SearchIdIfExist(id));
                                        string name = Read("Enter name: ");
                                        string address = Read("Enter address: ");
                                        string phoneNumber = Read("Enter phone number: ");
                                        customerController.create(new Customer(id, name, address, phoneNumber));
                                        break;
                                    case 4:

                                        Console.WriteLine("Update a Customer from the list !");
                                        foreach (Customer customer in customerController.getAll())
                                        {
                                            Console.WriteLine(customer.toString());
                                        }
                                        string idx = Read("Enter the Customer id on which you want to update : ");
                                        id = "";
                                        name = "";
                                        address = "";
                                        phoneNumber = "";
                                        bool update = true;
                                        while (update)
                                        {
                                            Console.WriteLine("What do you want to update ?");
                                            Console.WriteLine("1. Id");
                                            Console.WriteLine("2. Name");
                                            Console.WriteLine("3. Address");
                                            Console.WriteLine("4. Phone Number");
                                            Console.WriteLine("5. Done with updates");
                                            int whatUp = Convert.ToInt32(Read("Enter your choice: "));
                                            switch (whatUp)
                                            {
                                                case 1:
                                                    do
                                                    {
                                                        id = Read("Enter the new Id : ");
                                                        if (id == idx) break;
                                                    } while (!customerController.SearchIdIfExist(id));
                                                    break;
                                                case 2:
                                                    name = Read("Enter the new Name: ");
                                                    break;
                                                case 3:
                                                    address = Read("Enter the new Address : ");
                                                    break;
                                                case 4:
                                                    phoneNumber = Read("Enter the new Phone Number : ");
                                                    break;
                                                case 5:
                                                    update = false;
                                                    break;

                                            }
                                        }


                                        customerController.update(idx, new Customer(id, name, address, phoneNumber));
                                        break;
                                    case 5:
                                        Console.WriteLine("Delete a Car from the list!");
                                        foreach (Customer customer in customerController.getAll())
                                        {
                                            Console.WriteLine(customer.toString());
                                        }
                                        idx = "";
                                        do
                                        {
                                            idx = Read("Enter the customer id on which you want to delete : ");
                                        } while (customerController.SearchIdIfExist(idx));
                                        customerController.remove(idx);
                                        break;
                                    case 6:
                                        choice2 = false;
                                        break;
                                }
                                id = Read("Press any key to continue !");
                            }


                            break;

                        case 3:

                            while (choice2)
                            {
                                Console.Clear();
                                int op2 = secondaryMenuSellCarCompany(choiceStr);

                                switch (op2)
                                {
                                    case 1:
                                        if (salepersonController.getAll().Count() != 0)
                                        {
                                            foreach (Saleperson saleperson in salepersonController.getAll())
                                            {
                                                Console.WriteLine(saleperson.toString());
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Elements");
                                        }
                                        break;
                                    case 2:
                                        id = Read("Enter the id for the element your searching :");
                                        Console.WriteLine(salepersonController.getById(id).toString());
                                        break;
                                    case 3:
                                        Console.WriteLine("Create a new Saleperson!");
                                        do
                                        {
                                            id = Read("Enter id : ");
                                        } while (!salepersonController.SearchIdIfExist(id));
                                        string name = Read("Enter name: ");
                                        int age = Convert.ToInt32(Read("Enter age: "));
                                        int experience = Convert.ToInt32(Read("Enter experience: "));
                                        double commission = Convert.ToDouble(Read("Enter commission: "));
                                        salepersonController.create(new Saleperson(id, name, age, experience, commission));
                                        break;
                                    case 4:

                                        Console.WriteLine("Update a Saleperson from the list !");
                                        foreach (Saleperson saleperson in salepersonController.getAll())
                                        {
                                            Console.WriteLine(saleperson.toString());
                                        }
                                        string idx = Read("Enter the Customer id on which you want to update : ");
                                        id = "";
                                        name = "";
                                        age = -1;
                                        experience = -1;
                                        commission = -1;
                                        bool update = true;
                                        while (update)
                                        {
                                            Console.WriteLine("What do you want to update ?");
                                            Console.WriteLine("1. Id");
                                            Console.WriteLine("2. Name");
                                            Console.WriteLine("3. Age");
                                            Console.WriteLine("4. Experience");
                                            Console.WriteLine("5. Commission Percentage");
                                            Console.WriteLine("6. Done with updates");
                                            int whatUp = Convert.ToInt32(Read("Enter your choice: "));
                                            switch (whatUp)
                                            {
                                                case 1:
                                                    do
                                                    {
                                                        id = Read("Enter the new Id : ");
                                                        if (id == idx) break;
                                                    } while (!salepersonController.SearchIdIfExist(id));
                                                    break;
                                                case 2:
                                                    name = Read("Enter the new Name: ");
                                                    break;
                                                case 3:
                                                    age = Convert.ToInt32(Read("Enter the new Age : "));
                                                    break;
                                                case 4:
                                                    experience = Convert.ToInt32(Read("Enter the new Experience : "));
                                                    break;
                                                case 5:
                                                    commission = Convert.ToDouble(Read("Enter the new Commission Percentage : "));
                                                    break;
                                                case 6:
                                                    update = false;
                                                    break;

                                            }
                                        }


                                        salepersonController.update(idx, new Saleperson(id, name, age, experience, commission));
                                        break;
                                    case 5:
                                        Console.WriteLine("Delete a Saleperson from the list!");
                                        foreach (Saleperson saleperson in salepersonController.getAll())
                                        {
                                            Console.WriteLine(saleperson.toString());
                                        }
                                        idx = "";
                                        do
                                        {
                                            idx = Read("Enter the Saleperson id on which you want to delete : ");
                                        } while (salepersonController.SearchIdIfExist(idx));
                                        salepersonController.remove(idx);
                                        break;
                                    case 6:
                                        choice2 = false;
                                        break;
                                }
                                id = Read("Press any key to continue !");
                            }


                            break;
                        case 4:

                            while (choice2)
                            {
                                Console.Clear();
                                int op2 = secondaryMenuSellCarCompany(choiceStr);

                                switch (op2)
                                {
                                    case 1:
                                        if (storeBrancheController.getAll().Count() != 0)
                                        {
                                            foreach (StoreBranche storeBranche in storeBrancheController.getAll())
                                            {
                                                Console.WriteLine(storeBranche.toString());
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Elements");
                                        }
                                        break;
                                    case 2:
                                        id = Read("Enter the id for the element your searching :");
                                        Console.WriteLine(storeBrancheController.getById(id).toString());
                                        break;
                                    case 3:
                                        Console.WriteLine("Create a new storeBranche!");
                                        do
                                        {
                                            id = Read("Enter id : ");
                                        } while (!storeBrancheController.SearchIdIfExist(id));
                                        string name = Read("Enter name: ");
                                        string address = Read("Enter address: ");
                                        storeBrancheController.create(new StoreBranche(id, name, address));
                                        break;
                                    case 4:

                                        Console.WriteLine("Update a StoreBranche from the list !");
                                        foreach (StoreBranche storeBranche in storeBrancheController.getAll())
                                        {
                                            Console.WriteLine(storeBranche.toString());
                                        }
                                        string idx = Read("Enter the storeBranche id on which you want to update : ");
                                        id = "";
                                        name = "";
                                        address = "";
                                        bool update = true;
                                        while (update)
                                        {
                                            Console.WriteLine("What do you want to update ?");
                                            Console.WriteLine("1. Id");
                                            Console.WriteLine("2. Name");
                                            Console.WriteLine("3. Address");
                                            Console.WriteLine("4. Done with updates");
                                            int whatUp = Convert.ToInt32(Read("Enter your choice: "));
                                            switch (whatUp)
                                            {
                                                case 1:
                                                    do
                                                    {
                                                        id = Read("Enter the new Id : ");
                                                        if (id == idx) break;
                                                    } while (!storeBrancheController.SearchIdIfExist(id));
                                                    break;
                                                case 2:
                                                    name = Read("Enter the new Name: ");
                                                    break;
                                                case 3:
                                                    address = Read("Enter the new Address : ");
                                                    break;
                                                case 4:
                                                    update = false;
                                                    break;

                                            }
                                        }


                                        storeBrancheController.update(idx, new StoreBranche(id, name, address));
                                        break;
                                    case 5:
                                        Console.WriteLine("Delete a StoreBranche from the list!");
                                        foreach (StoreBranche storeBranche in storeBrancheController.getAll())
                                        {
                                            Console.WriteLine(storeBranche.toString());
                                        }
                                        idx = "";
                                        do
                                        {
                                            idx = Read("Enter the storeBranche id on which you want to delete : ");
                                        } while (storeBrancheController.SearchIdIfExist(idx));
                                        storeBrancheController.remove(idx);
                                        break;
                                    case 6:
                                        choice2 = false;
                                        break;
                                }
                                id = Read("Press any key to continue !");
                            }


                            break;
                        case 5:

                            while (choice2)
                            {
                                Console.Clear();
                                int op2 = secondaryMenuSellCarCompany(choiceStr);

                                switch (op2)
                                {
                                    case 1:
                                        if (saleController.getAll().Count() != 0)
                                        {
                                            foreach (Sale sale in saleController.getAll())
                                            {
                                                Console.WriteLine(sale.toString());
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No Elements");
                                        }
                                        break;
                                    case 2:
                                        id = Read("Enter the id for the element your searching :");
                                        Console.WriteLine(saleController.getById(id).toString());
                                        break;
                                    case 3:
                                        string carId, storeId, customerId, salepersonId = "";
                                        Console.WriteLine("Create a new sale!");
                                        do
                                        {
                                            id = Read("Enter id : ");
                                        } while (!saleController.SearchIdIfExist(id));
                                        do
                                        {
                                            carId = Read("Enter car id : ");
                                        } while (carController.SearchIdIfExist(carId));
                                        do
                                        {
                                            storeId = Read("Enter store id : ");
                                        } while (storeBrancheController.SearchIdIfExist(storeId));
                                        do
                                        {
                                            customerId = Read("Enter customer id : ");
                                        } while (customerController.SearchIdIfExist(customerId));
                                        do
                                        {
                                            salepersonId = Read("Enter saleperson id : ");
                                        } while (salepersonController.SearchIdIfExist(salepersonId));
                                        DateTime saleDate = Convert.ToDateTime(Read("Enter the sale date : "));
                                        double salePrice = Convert.ToDouble(Read("Enter the sale price : "));
                                        saleController.create(new Sale(id, carId, customerId, salepersonId, saleDate, salePrice));
                                        break;
                                    case 4:

                                        Console.WriteLine("Update a sale from the list !");
                                        foreach (Sale sale in saleController.getAll())
                                        {
                                            Console.WriteLine(sale.toString());
                                        }
                                        string idx = Read("Enter the storeBranche id on which you want to update : ");
                                        id = "";
                                        carId = "";
                                        storeId = "";
                                        customerId = "";
                                        salepersonId = "";
                                        saleDate = new DateTime(01 / 01 / 0001);
                                        salePrice = -1;
                                        bool update = true;
                                        while (update)
                                        {
                                            Console.WriteLine("What do you want to update ?");
                                            Console.WriteLine("1. Id");
                                            Console.WriteLine("2. Car Id");
                                            Console.WriteLine("3. Store Id");
                                            Console.WriteLine("4. Customer Id");
                                            Console.WriteLine("5. Saleperson Id");
                                            Console.WriteLine("6. Sale Date");
                                            Console.WriteLine("7. Sale Price");
                                            Console.WriteLine("8. Done with updates");
                                            int whatUp = Convert.ToInt32(Read("Enter your choice: "));
                                            switch (whatUp)
                                            {
                                                case 1:
                                                    do
                                                    {
                                                        id = Read("Enter the new Id : ");
                                                        if (id == idx) break;
                                                    } while (!saleController.SearchIdIfExist(id));
                                                    break;
                                                case 2:
                                                    do
                                                    {
                                                        carId = Read("Enter the new Car Id : ");
                                                    } while (carController.SearchIdIfExist(carId));
                                                    break;
                                                case 3:
                                                    do
                                                    {
                                                        storeId = Read("Enter the new Store Id : ");
                                                    } while (storeBrancheController.SearchIdIfExist(storeId));
                                                    break;
                                                case 4:
                                                    do
                                                    {
                                                        customerId = Read("Enter the new Customer Id : ");
                                                    } while (customerController.SearchIdIfExist(customerId));
                                                    break;
                                                case 5:
                                                    do
                                                    {
                                                        salepersonId = Read("Enter the new Saleperson Id : ");
                                                    } while (salepersonController.SearchIdIfExist(salepersonId));
                                                    break;
                                                case 6:
                                                    saleDate = Convert.ToDateTime(Read("Enter the new Sale Date : "));
                                                    break;
                                                case 7:
                                                    salePrice = Convert.ToDouble(Read("Enter the new Sale Price : "));
                                                    break;
                                                case 8:
                                                    update = false;
                                                    break;

                                            }
                                        }


                                        saleController.update(idx, new Sale(id, carId, customerId, salepersonId, saleDate, salePrice));
                                        break;
                                    case 5:
                                        Console.WriteLine("Delete a Sale from the list!");
                                        foreach (Sale sale in saleController.getAll())
                                        {
                                            Console.WriteLine(sale.toString());
                                        }
                                        idx = "";
                                        do
                                        {
                                            idx = Read("Enter the sale id on which you want to delete : ");
                                        } while (saleController.SearchIdIfExist(idx));
                                        saleController.remove(idx);
                                        break;
                                    case 6:
                                        choice2 = false;
                                        break;
                                }
                                id = Read("Press any key to continue !");
                            }


                            break;
                        case 6:

                            choice1 = false;

                            break;
                    }


                }

            }


        }
        
    }
}