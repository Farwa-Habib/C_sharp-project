using LabManagement.Bill.Repo;
using LabManagement.Patient;
using LabManagement.Patient.Services;
using LabManagement.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

       
namespace LabManagement.Bill.Services
    {
        public class BillService
        {
            private BillRepo repo;
            private PatientService patientService;
            private TestService testService;

            public BillService()
            {
                repo = new BillRepo();
                patientService = new PatientService();
                testService = new TestService();
            }

            public BillModel GenerateBill(int patient_id)
            {
                PatientModel patient =patientService.GetPatientById(patient_id);

                if (patient == null)
                {
                    return null;
                }

                List<TestModel> tests =
                    testService.GetTestsByPatientId(patient_id);

                if (tests.Count == 0)
                {
                    return null;
                }

                decimal total = 0;

                foreach (TestModel test in tests)
                {
                    total += test.GetPrice();
                }

                List<string> oldBills = repo.GetAllBillsFromFile();

                int bill_id = oldBills.Count + 1;

                BillModel bill = new BillModel(bill_id,patient_id,patient.GetName(),tests,total);

                repo.SaveInFile(bill);

                return bill;
            }
        }
    }
