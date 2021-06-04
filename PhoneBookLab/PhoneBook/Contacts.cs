using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookLab
{
    public class Contacts
    {
        public string fName;
        public string lName;
        public string address;
        public string phoneNumber;
        

        public List<Contacts> People = new List<Contacts>();


        public void DisplayContacts()
        {

        }

        public void addUser()
        {
            #region addUser
            bool isCorrect = true;
            while (isCorrect) // change to a foreach loop if possible
            {

                Contacts person = new Contacts();
                Console.WriteLine("Please enter in this order, First name, Last name, address, and phone number: and be sure to press enter after each field: ");
                person.fName = Console.ReadLine();
                person.lName = Console.ReadLine();
                person.address = Console.ReadLine();
                person.phoneNumber = Console.ReadLine();
                People.Add(person);

                Console.WriteLine($"You added {person.fName} {person.lName}, address: {person.address}, phone number: {person.phoneNumber} " + " Is that correct? Y/N: ");
                var correct = Console.ReadLine();
                if (correct.ToLower() == "y")
                {
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
            Console.WriteLine("Edit User");
        }
        public void deleteUser()
        {
            Console.WriteLine("Delete User");
        }
        public void viewAllContacts()
        {

        }
    }
}
