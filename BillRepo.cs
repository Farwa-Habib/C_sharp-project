using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManagement.Bill.Repo
{ 
    public class BillRepo
        {
            private readonly string filePath = "bills.txt";

            public void SaveInFile(BillModel bill)
            {
                using (StreamWriter stream = new StreamWriter(filePath, true))
                {
                    stream.WriteLine(
                        $"{bill.GetBill_ID()}," +
                        $"{bill.GetPatient_ID()}," +
                        $"{bill.GetPatientName()}," +
                        $"{bill.GetTotalAmount()}"
                    );
                }
            }

            public List<string> GetAllBillsFromFile()
            {
                List<string> bills = new List<string>();

                if (!File.Exists(filePath))
                {
                    return bills;
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line="";

                    while ((line = reader.ReadLine()) != null)
                    {
                        bills.Add(line);
                    }
                }

                return bills;
            }
        }
}
