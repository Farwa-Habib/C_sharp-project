using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManagement.Test
{
    public class TestModel
    {
            private int Test_ID;
            private int Patient_ID;
            private string TestName;
            private decimal Price;

            public TestModel()
            {
            }

            public TestModel(int test_id, int patient_id, string testname, decimal price)
            {
                Test_ID = test_id;
                Patient_ID = patient_id;
                TestName = testname;
                Price = price;
            }

            public void SetTest_ID(int test_id)
            {
                Test_ID = test_id;
            }

            public int GetTest_ID()
            {
                return Test_ID;
            }

            public void SetPatient_ID(int patient_id)
            {
                Patient_ID = patient_id;
            }

            public int GetPatient_ID()
            {
                return Patient_ID;
            }

            public void SetTestName(string testname)
            {
                TestName = testname;
            }

            public string GetTestName()
            {
                return TestName;
            }

            public void SetPrice(decimal price)
            {
                Price = price;
            }

            public decimal GetPrice()
            {
                return Price;
            }

            public override string ToString()
            {
                return $"Test ID: {Test_ID}" +
                       $"Patient ID: {Patient_ID}" +
                       $"Test Name: {TestName}" +
                       $"Price: Rs. {Price}";
            }
        }
    }
