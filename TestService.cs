using LabManagement.Patient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManagement.Test
{
    public class TestService
        {
            private TestRepo repo;
            private PatientService patientService;

            public TestService()
            {
                repo = new TestRepo();
                patientService = new PatientService();
            }

            public int GetNextTestId()
            {
                List<TestModel> tests = repo.GetTestsFromFile();
                int nextId = 1;

                foreach (TestModel test in tests)
                {
                    if (test.GetTest_ID() >= nextId)
                    {
                        nextId = test.GetTest_ID() + 1;
                    }
                }

                return nextId;
            }

            public bool AddTest(TestModel test)
            {
                if (patientService.GetPatientById(test.GetPatient_ID()) == null)
                {
                    return false;
                }

                repo.SaveInFile(test);
                return true;
            }

            public TestModel GetTestById(int test_id)
            {
                List<TestModel> tests = repo.GetTestsFromFile();

                foreach (TestModel test in tests)
                {
                    if (test.GetTest_ID() == test_id)
                    {
                        return test;
                    }
                }

                return null;
            }

            public List<TestModel> GetTestsByPatientId(int patient_id)
            {
                List<TestModel> allTests = repo.GetTestsFromFile();
                List<TestModel> patientTests = new List<TestModel>();

                foreach (TestModel test in allTests)
                {
                    if (test.GetPatient_ID() == patient_id)
                    {
                        patientTests.Add(test);
                    }
                }

                return patientTests;
            }

            public List<TestModel> GetAllTests()
            {
                return repo.GetTestsFromFile();
            }

            public bool UpdateTest(int test_id, TestModel updatedTest)
            {
                List<TestModel> tests = repo.GetTestsFromFile();

                foreach (TestModel test in tests)
                {
                    if (test.GetTest_ID() == test_id)
                    {
                        test.SetTestName(updatedTest.GetTestName());
                        test.SetPrice(updatedTest.GetPrice());

                        repo.SaveAllDataIntoFile(tests);
                        return true;
                    }
                }

                return false;
            }

            public bool DeleteTest(int test_id)
            {
                List<TestModel> tests = repo.GetTestsFromFile();

                for (int i = 0; i < tests.Count; i++)
                {
                    if (tests[i].GetTest_ID() == test_id)
                    {
                        tests.RemoveAt(i);
                        repo.SaveAllDataIntoFile(tests);
                        return true;
                    }
                }

                return false;
            }
        public bool PatientExists(int patient_id)
        {
            return patientService.GetPatientById(patient_id) != null;
        }
    }
}
