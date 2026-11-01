
using LabManagement.Patient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManagement.Patient.UI
{
    public class PatientUI
    {
        private PatientService service = new PatientService();

        public void PatientMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== PATIENT PORTAL =====");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. Exit");

                Console.Write("Enter option: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    RegisterPatient();
                }
                else if (choice == 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public void RegisterPatient()
        {
            Console.Clear();

            Console.WriteLine("===== PATIENT REGISTRATION =====");

            Console.Write("Enter Patient ID: ");
            int patient_id = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Referred Doctor: ");
            string referreddoctor = Console.ReadLine();

            Console.Write("Enter Medical History: ");
            string medicalhistory = Console.ReadLine();

            Console.Write("Enter Comments: ");
            string comments = Console.ReadLine();

            PatientModel patient = new PatientModel( patient_id, name, age, gender, phone,
                email, referreddoctor, medicalhistory, comments
            );

            if (service.AddPatient(patient))
            {
                Console.WriteLine("Patient registered successfully!");
                Console.WriteLine("Your Patient ID is: " + patient_id);
            }
            else
            {
                Console.WriteLine("This Patient ID already exists!");
            }
        }
    }
}