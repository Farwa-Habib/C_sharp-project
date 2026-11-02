using LabManagement.LabTechnician;
using LabManagement.LabTechnician.Services;
using LabManagement.Bill.UI;
using LabManagement.Patient;
using LabManagement.Patient.UI;
using LabManagement.LabTech.UI;
using LabManagement.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManagement.LabTech.UI
{
    public class LabTechUI
    {
            private LabTechnicianService service = new LabTechnicianService();

            public void TechnicianMenu()
            {
                while (true)
                {
                    Console.Clear();

                    Console.WriteLine("===== LAB TECHNICIAN PORTAL =====");
                    Console.WriteLine("1. Register Technician");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Back");

                    Console.Write("Enter option: ");
                    int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    RegisterTechnician();
                }
                else if (choice == 2)
                {
                    if (Login())
                        ManagementMenu();
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option!");

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
              }
            }

            public void RegisterTechnician()
            {
                Console.Clear();

                Console.Write("Enter Technician ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Create Password: ");
                string password = Console.ReadLine();

                LabTechnicianModel technician = new LabTechnicianModel(id, name, password);

            if (service.RegisterTechnician(technician))
            {
                Console.WriteLine("Technician registered!");
            }
            else
            {
                Console.WriteLine("Technician ID already exists!");
            }
            }

            public bool Login()
            {
                Console.Clear();

                Console.Write("Enter Technician ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                if (service.Login(id, password))
                {
                    Console.WriteLine("Login successful!");
                    return true;
                }

                Console.WriteLine("Invalid ID or password!");
                return false;
            }

        public void ManagementMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("===== TECHNICIAN DASHBOARD =====");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. View All Patients");
                Console.WriteLine("3. Search Patient by ID");
                Console.WriteLine("4. Update Patient");
                Console.WriteLine("5. Delete Patient");
                Console.WriteLine("6. Test Management");
                Console.WriteLine("7. View Patient Complete Record");
                Console.WriteLine("8. Generate Patient Bill");
                Console.WriteLine("9.Search Patient by name ");
                Console.WriteLine("10.Search Patient by category ");
                Console.WriteLine("11.get maximum age and minimum age ");

                Console.WriteLine("12. LogOut");

                Console.Write("Enter option: ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    PatientUI patientUI = new PatientUI();
                    patientUI.RegisterPatient();
                }
                else if (choice == 2)
                {
                    ViewAllPatients();
                }
                else if (choice == 3)
                {
                    SearchPatient();
                }
                else if (choice == 4)
                {
                    UpdatePatient();
                }
                else if (choice == 5)
                {
                    DeletePatient();
                }
                else if (choice == 6)
                {
                    TestUI testUI = new TestUI();
                    testUI.TestMenu();
                }
                else if (choice == 7)
                {
                    ViewCompleteRecord();
                }
                else if (choice == 8)
                {
                    BillUI billUI = new BillUI();
                    billUI.BillMenu();
                }
                else if (choice == 9)
                {
                    GetPatientByName();

                }
                else if (choice==10)
                {
                    Searchbycategory();
                }
                else if (choice == 11)
                {

                }
                else if (choice == 12)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                    Console.WriteLine(" Press any key to continue");
                    Console.ReadKey();
                }
            }
        }
   
        public void ViewAllPatients()
        {
            List<PatientModel> patients = service.GetAllPatients();

            Console.WriteLine("Total Patients: " + patients.Count);

            if (patients.Count == 0)
            {
                Console.WriteLine("No patients found!");
            }
            else
            {
                foreach (PatientModel patient in patients)
                { 
                    Console.WriteLine(
                    patient.GetPatient_ID() + ", " +
                    patient.GetName() + ", " +
                    patient.GetAge() + ", " +
                    patient.GetGender() + ", " +
                    patient.GetPhone() + ", " +
                    patient.GetEmail() + ", " +
                    patient.GetReferredDoctor() + ", " +
                    patient.GetMedicalHistory() + ", " +
                    patient.GetComments());
                }
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        public void SearchPatient()
        {
            Console.Write("Enter Patient ID: ");
            int id = int.Parse(Console.ReadLine());

            PatientModel patient = service.GetPatientById(id);

            if (patient != null)
            {
                Console.WriteLine("Patient Found!");
                Console.WriteLine(
                    patient.GetPatient_ID() + ", " +
                    patient.GetName() + ", " +
                    patient.GetAge() + ", " +
                    patient.GetGender() + ", " +
                    patient.GetPhone()
                );
            }
            else
            {
                Console.WriteLine("Patient not found!");
            }

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }

        public void UpdatePatient()
            {
                Console.Write("Enter Patient ID to update: ");
                int id = int.Parse(Console.ReadLine());

                PatientModel oldPatient = service.GetPatientById(id);

                if (oldPatient == null)
                {
                    Console.WriteLine("Patient not found!");
                    return;
                }

                Console.Write("Enter New Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter New Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter New Gender: ");
                string gender = Console.ReadLine();

                Console.Write("Enter New Phone: ");
                string phone = Console.ReadLine();

                Console.Write("Enter New Email: ");
                string email = Console.ReadLine();

                Console.Write("Enter New Referred Doctor: ");
                string doctor = Console.ReadLine();

                Console.Write("Enter New Medical History: ");
                string history = Console.ReadLine();

                Console.Write("Enter New Comments: ");
                string comments = Console.ReadLine();

            PatientModel updatedPatient = new PatientModel(id, name, age, gender, phone, email,
                doctor, history, comments);

            if (service.UpdatePatient(id, updatedPatient))
            {

                Console.WriteLine("Patient updated successfully!");
            }
            else
            {
                Console.WriteLine("Update failed!");
            }
            }

            public void DeletePatient()
            {
                Console.Write("Enter Patient ID to delete: ");
                int id = int.Parse(Console.ReadLine());

            if (service.DeletePatient(id))
            {
                Console.WriteLine("Patient deleted successfully!");
            }
            else
            {
                Console.WriteLine("Patient not found!");
            }
        }

            public void ViewCompleteRecord()
            {
                Console.Write("Enter Patient ID: ");
                int id = int.Parse(Console.ReadLine());

                PatientModel patient = service.GetPatientById(id);

                if (patient == null)
                {
                    Console.WriteLine("Patient not found!");
                    return;
                }

                Console.WriteLine("===== PATIENT DETAILS =====");
                Console.WriteLine(patient.ToString());

                List<TestModel> tests = service.GetPatientTests(id);

                Console.WriteLine("===== TEST DETAILS =====");

            if (tests.Count == 0)
            {
                Console.WriteLine("No tests registered!");
            }
            else
            {
                foreach (TestModel test in tests)
                {
                    Console.WriteLine(test.ToString());
                    Console.WriteLine("----------------------");
                }
            }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            

                decimal total = service.CalculatePatientTotal(id);

                Console.WriteLine("===== BILL SUMMARY =====");
                Console.WriteLine("Patient Name: " + patient.GetName());
                Console.WriteLine("Patient ID: " + id);
                Console.WriteLine("Total Amount: Rs. " + total);
            }
        }
    }
