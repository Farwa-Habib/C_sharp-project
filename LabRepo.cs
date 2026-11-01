using LabManagement.LabTechnician;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManagement.LabTech.Repo
{
    public class LabTechnicianRepo
    {
            private readonly string filePath = "technicians.txt";

            public void SaveInFile(LabTechnicianModel technician)
            {
                using (StreamWriter stream = new StreamWriter(filePath, true))
                {
                    stream.WriteLine(
                        $"{technician.GetTechnician_ID()}," +
                        $"{technician.GetName()}," +
                        $"{technician.GetPassword()}"
                    );
                }
            }

            public List<LabTechnicianModel> GetTechniciansFromFile()
            {
                List<LabTechnicianModel> technicians =new List<LabTechnicianModel>();

                if (!File.Exists(filePath))
                {
                    return technicians;
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 3)
                        {
                            LabTechnicianModel technician =new LabTechnicianModel(int.Parse(parts[0]),
                                    parts[1],parts[2]);

                            technicians.Add(technician);
                        }
                    }
                }

                return technicians;
            }
        }
    }
