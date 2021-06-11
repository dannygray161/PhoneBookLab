using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookLab
{
    public class Contacts
    {
        public string fName;
        public string lName;
        public string[] address;
        public string phoneNumber;
        public string filePath = @"C:\Users\Daniel\OneDrive\Desktop\Contacts.txt";


        public static List<Contacts> People = new List<Contacts>();


        public void DisplayContacts(Contacts contacts)
        {
            Console.WriteLine($"First Name: {contacts.fName}");
            Console.WriteLine($"Last Name: {contacts.lName}");
            Console.WriteLine($"Address 1: {contacts.address[0]}");
            Console.WriteLine($"Address 2: {contacts.address[1]}");
            Console.WriteLine($"Phone Nnumber: {contacts.phoneNumber}");
            Console.WriteLine($"<-------------------------------------->");
        }


        public void addUser()
        {
            #region addUser

            bool isCorrect = true;


                while (isCorrect) 
                {
                Contacts contacts = new Contacts();
                Console.Write("Enter first name: ");
                contacts.fName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                contacts.lName = Console.ReadLine();

                Console.Write("Enter address 1 : ");
                string[] addresses = new string[2];
                addresses[0] = Console.ReadLine();
                Console.Write("Enter address 2 : (Optional) ");
                addresses[1] = Console.ReadLine();
                contacts.address = addresses;

                Console.Write("Enter phone number: ");
                contacts.phoneNumber = Console.ReadLine();

                     Console.WriteLine($"You added {contacts.fName} {contacts.lName}, address: {contacts.address[0]}, {contacts.address[1]}, phone number: {contacts.phoneNumber} " + " Is that correct? Y/N: ");
                    var correct = Console.ReadLine();
                    if (correct.ToLower() == "y")
                    {
                        People.Add(contacts);
                        using(StreamWriter sw = new StreamWriter(filePath))
                        {
                        foreach(var contact in People)
                        {
                            sw.WriteLine(contact.fName);
                            sw.WriteLine(contact.lName);
                            sw.WriteLine(contact.address[0]);
                            sw.WriteLine(contact.address[1] + "(Optional Address 2)");
                            sw.WriteLine(contact.phoneNumber);
                            Console.WriteLine("<------------------->");
                        }

                        }
                        Console.WriteLine("Alright, we got them added for you!! ");
                        isCorrect = false;
                        break;

                    }
                    else
                    {
                        Console.WriteLine("Sorry bout that, lets try again! ");
                        isCorrect = true;
                        continue;
                    }


            }
            #endregion  
        }
        public void editUser()
        {
            Console.WriteLine("Please enter the first name of the user you wish to edit: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter the last name of the user you wish to edit: ");
            string lastName = Console.ReadLine();
            Contacts contacts = Contacts.People.FirstOrDefault(x => x.fName.ToLower() == firstName.ToLower());
            contacts = Contacts.People.FirstOrDefault(y => y.lName.ToLower() == lastName.ToLower());

            if (contacts == null)
            {
                Console.WriteLine("I am sorry, contact not found, press any key to continue: ");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Are you sure you want to edit this person: Y/N");
                DisplayContacts(contacts);
                if(Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.WriteLine("Okay");
                    Console.WriteLine("What would you like to edit: 1. First Name, 2. Last Name, 3. Address 1, 4. Address 2, or 5. Phone Number? Please enter the corresponding number:  ");
                    int userChooses = Convert.ToInt32(Console.ReadLine());
                    switch (userChooses)
                    {
                        case 1:
                            changeFirstName(contacts);
                            break;
                        case 2:
                            changeLastName(contacts);
                            break;
                        case 3:
                            changeAddress1(contacts);
                            break;
                        case 4:
                            changeAddress2(contacts);
                            break;
                        case 5:
                            changePhoneNumber(contacts);
                            break;
                        default:
                            Console.WriteLine("Im sorry, invalid selection");
                            break;
                    }
                }
            }
        }
        public void deleteUser()
        {
            Console.WriteLine("Please enter the first name of the user you wish to delete: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter the last name of the user you wish to delete: ");
            string lastName = Console.ReadLine();
            Contacts contacts = Contacts.People.FirstOrDefault(x => x.fName.ToLower() == firstName.ToLower());
            contacts = Contacts.People.FirstOrDefault(y => y.lName.ToLower() == lastName.ToLower());
            if(contacts == null)
            {
                Console.WriteLine("That person could not be found, Press any key to continue: ");
                Console.ReadKey();
                return;
            }else
            {
                Console.WriteLine("Are you sure you want to remove this person? Y/N");
                DisplayContacts(contacts);
                if(Console.ReadKey().Key == ConsoleKey.Y)
                {
                    People.Remove(contacts);
                    Console.WriteLine("Person Removed, Press any key to continue: ");
                    Console.ReadKey();
                }
            }
        }
        public void viewAllContacts()
        {
            if (Contacts.People.Count == 0)
            {
                Console.WriteLine("You have not added any people yet, try adding some and then come back to this option! Press any key to continue: ");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Here are all the people in your address book: ");
            foreach(var person in People)
            {
                DisplayContacts(person);
               
               
            }
            Console.WriteLine("Press any key to continue: ");
            Console.ReadKey();
        }
        public void viewTextFile()
        {
           if(Contacts.People.Count == 0)
            {
                Console.WriteLine("Im sorry, there are no contacts, would you like to add some? Y/N: ");
                if(Console.ReadKey().Key == ConsoleKey.Y)
                {
                    return;
                }
                
            }
           else
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    foreach (var contact in People)
                    {
                        Console.WriteLine("First Name: " + sr.ReadLine());
                        Console.WriteLine("Last Name: " + sr.ReadLine());
                        Console.WriteLine("Address 1: " + sr.ReadLine());
                        Console.WriteLine("Address 2: (optional) " + sr.ReadLine());
                        Console.WriteLine("Phone Number: " + sr.ReadLine());
                        Console.WriteLine("<-------------------------->");


                    }
                }
            }
           
        }

        #region Edit Methods
        public void changeFirstName(Contacts contacts)
        {
            Console.WriteLine($"What would you like to change {contacts.fName} to? Please enter is below:  ");
            contacts.fName = Console.ReadLine();
            Console.WriteLine($"Okay, first name now changed to {contacts.fName}");
        }
        public void changeLastName(Contacts contacts)
        {
            Console.WriteLine($"What would you like to change {contacts.lName} to? Please enter is below:  ");
            contacts.lName = Console.ReadLine();
            Console.WriteLine($"Okay, last name now changed to {contacts.lName}");
        }
        public void changeAddress1(Contacts contacts)
        {
            Console.WriteLine($"What would you like to change {contacts.address[0]} to? Please enter is below:  ");
            contacts.address[0] = Console.ReadLine();
            Console.WriteLine($"Okay, first name now changed to {contacts.address[0]}");
        }
        public void changeAddress2(Contacts contacts)
        {
            Console.WriteLine($"What would you like to change {contacts.address[1]} to? Please enter is below:  ");
            contacts.address[1] = Console.ReadLine();
            Console.WriteLine($"Okay, first name now changed to {contacts.address[1]}");
        }
        public void changePhoneNumber(Contacts contacts)
        {
            Console.WriteLine($"What would you like to change {contacts.phoneNumber} to? Please enter is below:  ");
            contacts.phoneNumber = Console.ReadLine();
            Console.WriteLine($"Okay, first name now changed to {contacts.phoneNumber}");
        }

        #endregion
    }
}
