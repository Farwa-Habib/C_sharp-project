using LabManagement.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManagement.Bill
{
    public class BillModel
        {
            private int Bill_ID;
            private int Patient_ID;
            private string PatientName;
            private List<TestModel> Tests;
            private decimal TotalAmount;

            public BillModel()
            {
                Tests = new List<TestModel>();
            }

            public BillModel(int bill_id, int patient_id,string patientname, List<TestModel> tests,
                decimal totalamount)
            {
                Bill_ID = bill_id;
                Patient_ID = patient_id;
                PatientName = patientname;
                Tests = tests;
                TotalAmount = totalamount;
            }

            public int GetBill_ID()
            {
                return Bill_ID;
            }

            public void SetBill_ID(int bill_id)
            {
                Bill_ID = bill_id;
            }

            public int GetPatient_ID()
            {
                return Patient_ID;
            }

            public void SetPatient_ID(int patient_id)
            {
                Patient_ID = patient_id;
            }

            public string GetPatientName()
            {
                return PatientName;
            }

            public void SetPatientName(string patientname)
            {
                PatientName = patientname;
            }

            public List<TestModel> GetTests()
            {
                return Tests;
            }

            public void SetTests(List<TestModel> tests)
            {
                Tests = tests;
            }

            public decimal GetTotalAmount()
            {
                return TotalAmount;
            }

            public void SetTotalAmount(decimal totalamount)
            {
                TotalAmount = totalamount;
            }

            public override string ToString()
            {
                string details = "";

                foreach (TestModel test in Tests)
                {
                    details += test.GetTestName() +
                        " - Rs. " + test.GetPrice() ;
                }

                return
                    $"Bill ID: {Bill_ID}" +
                    $"Patient ID: {Patient_ID}" +
                    $"Patient Name: {PatientName}" +
                    $"Tests:{details}" +
                    $"Total Amount: Rs. {TotalAmount}";
            }
        }
    }