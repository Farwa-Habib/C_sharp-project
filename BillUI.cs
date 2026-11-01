
 using System;
using LabManagement.Bill;
using LabManagement.Bill.Services;

namespace LabManagement.Bill.UI
    {
        public class BillUI
        {
            private BillService service = new BillService();

            public void BillMenu()
            {
                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("===== BILL MANAGEMENT =====");
                    Console.WriteLine("1. Generate Patient Bill");
                    Console.WriteLine("2. Back");

                    Console.Write("Enter option: ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        GeneratePatientBill();
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

            public void GeneratePatientBill()
            {
                Console.Clear();

                Console.Write("Enter Patient ID: ");
                int patient_id = int.Parse(Console.ReadLine());

                BillModel bill = service.GenerateBill(patient_id);

                if (bill == null)
                {
                    Console.WriteLine(
                        "Patient not found or no tests registered!"
                    );
                }
                else
                {
                    Console.WriteLine("===== PATIENT BILL =====");
                    Console.WriteLine(bill.ToString());
                }
            }
        }
    }
