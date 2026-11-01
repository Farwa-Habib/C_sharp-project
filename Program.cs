using LabManagement.Patient.UI;
using LabManagement.LabTechnician;
using LabManagement.LabTech.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManagement
{
     class Program
    {
        static void Main(string[] args)
            {
                PatientUI patientUI = new PatientUI();
            LabTechUI technicianUI = new LabTechUI();

                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("================================");
                    Console.WriteLine("   LABORATORY MANAGEMENT SYSTEM");
                    Console.WriteLine("================================");

                    Console.WriteLine("1. Patient Portal");
                    Console.WriteLine("2. Lab Technician Portal");
                    Console.WriteLine("3. Exit");

                    Console.Write("\nEnter option: ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        patientUI.PatientMenu();
                    }
                    else if (choice == 2)
                    {
                    technicianUI.TechnicianMenu();
                    }
                    else if (choice == 3)
                    {
                        Console.WriteLine("Thank you for using our system!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option!");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
