using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManagement.Test
{
    public class TestUI
    {
        private TestService service = new TestService();

            public void TestMenu()
            {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== TEST MANAGEMENT =====");
                Console.WriteLine("1. Add Tests");
                Console.WriteLine("2. View Patient Tests");
                Console.WriteLine("3. View All Tests");
                Console.WriteLine("4. Update Test");
                Console.WriteLine("5. Delete Test");
                Console.WriteLine("6. Back");

                Console.Write("Enter option: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    AddTests();
                }
                else if (choice == 2)
                {
                    ViewPatientTests();
                }
                else if (choice == 3)
                {
                    ViewAllTests();
                }
                else if (choice == 4)
                {
                    UpdateTest();
                }
                else if (choice == 5)
                {
                    DeleteTest();
                }
                else if (choice == 6)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option!");

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
              }
            }

            public void AddTests()
            {
                Console.Clear();

                Console.Write("Enter Patient ID: ");
                int patient_id = int.Parse(Console.ReadLine());

                if (!service.PatientExists(patient_id))
                {
                    Console.WriteLine("Patient not found!");
                    return;
                }

                Console.Write("How many tests do you want to add? ");
                int count = int.Parse(Console.ReadLine());

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("Enter details for Test " + (i + 1));

                    int test_id = service.GetNextTestId();

                    Console.WriteLine("Test ID: " + test_id);

                    Console.Write("Enter Test Name: ");
                    string testname = Console.ReadLine();

                    Console.Write("Enter Test Price: ");
                    int price = int.Parse(Console.ReadLine());

                    TestModel test = new TestModel(test_id, patient_id, testname, price );

                    if (service.AddTest(test))
                    {
                        Console.WriteLine("Test added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Test could not be added!");
                    }
                }
            }

            public void ViewPatientTests()
            {
                Console.Write("Enter Patient ID: ");
                int patient_id = int.Parse(Console.ReadLine());

                List<TestModel> tests = service.GetTestsByPatientId(patient_id);

                if (tests.Count == 0)
                {
                    Console.WriteLine("No tests found for this patient!");
                }
                else
                {
                    foreach (TestModel test in tests)
                    {
                        Console.WriteLine(test.ToString());
                        Console.WriteLine("--------------------");
                    }
                }
            }

            public void ViewAllTests()
            {
                List<TestModel> tests = service.GetAllTests();

                if (tests.Count == 0)
                {
                    Console.WriteLine("No tests found!");
                }
                else
                {
                    foreach (TestModel test in tests)
                    {
                        Console.WriteLine(test.ToString());
                        Console.WriteLine("--------------------");
                    }
                }
            }

            public void UpdateTest()
            {
                Console.Write("Enter Test ID to update: ");
                int test_id = int.Parse(Console.ReadLine());

                TestModel oldTest = service.GetTestById(test_id);

                if (oldTest == null)
                {
                    Console.WriteLine("Test not found!");
                    return;
                }

                Console.Write("Enter New Test Name: ");
                string testname = Console.ReadLine();

                Console.Write("Enter New Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                TestModel updatedTest = new TestModel(
                    test_id,
                    oldTest.GetPatient_ID(),
                    testname,
                    price
                );

                if (service.UpdateTest(test_id, updatedTest))
                    Console.WriteLine("Test updated successfully!");
                else
                    Console.WriteLine("Update failed!");
            }

            public void DeleteTest()
            {
                Console.Write("Enter Test ID to delete: ");
                int test_id = int.Parse(Console.ReadLine());

                if (service.DeleteTest(test_id))
                    Console.WriteLine("Test deleted successfully!");
                else
                    Console.WriteLine("Test not found!");
            }
        }
    }
