using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManagement.Test
{
    public class TestRepo
        {
            private readonly string filePath = "tests.txt";

            public void SaveInFile(TestModel test)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(
                        $"{test.GetTest_ID()}," +
                        $"{test.GetPatient_ID()}," +
                        $"{test.GetTestName()}," +
                        $"{test.GetPrice()}"
                    );
                }
            }

            public void SaveAllDataIntoFile(List<TestModel> tests)
            {
                File.WriteAllText(filePath, string.Empty);

                foreach (TestModel test in tests)
                {
                    SaveInFile(test);
                }
            }

            public List<TestModel> GetTestsFromFile()
            {
                List<TestModel> tests = new List<TestModel>();

                if (!File.Exists(filePath))
                {
                    return tests;
                }

                using (StreamReader stream = new StreamReader(filePath))
                {
                    string line="";

                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 4)
                        {
                            int test_id = int.Parse(parts[0]);
                            int patient_id = int.Parse(parts[1]);
                            string testname = parts[2];
                            decimal price = decimal.Parse(parts[3]);

                            TestModel test = new TestModel(test_id, patient_id, testname, price
                            );

                            tests.Add(test);
                        }
                    }
                }

                return tests;
            }
        }
    }
