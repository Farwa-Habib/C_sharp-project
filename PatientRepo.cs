using LabManagement.Patient;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LabManagement.Patient.Repo
{
    public class PatientRepo
    {
        private readonly string filePath = "patients.txt";

        public PatientRepo()
        {
        }

        public void SaveInFile(PatientModel patient)
        {
            using (StreamWriter stream = new StreamWriter(filePath, true))
            {
                stream.WriteLine(
                    $"{patient.GetPatient_ID()}," +
                    $"{patient.GetName()}," +
                    $"{patient.GetAge()}," +
                    $"{patient.GetGender()}," +
                    $"{patient.GetPhone()}," +
                    $"{patient.GetEmail()}," +
                    $"{patient.GetReferredDoctor()}," +
                    $"{patient.GetMedicalHistory()}," +
                    $"{patient.GetComments()}"
                );
            }
        }

        public void SaveAllDataIntoFile(List<PatientModel> patients)
        {
            File.WriteAllText(filePath, string.Empty);

            foreach (PatientModel patient in patients)
            {
                SaveInFile(patient);
            }
        }

        public List<PatientModel> GetPatientsFromFile()
        {
            List<PatientModel> patients = new List<PatientModel>();

            if (!File.Exists(filePath))
            {
                return patients;
            }

            using (StreamReader stream = new StreamReader(filePath))
            {
                string line="";

                while ((line = stream.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 9)
                    {
                        int patient_id = int.Parse(parts[0]);
                        string name = parts[1];
                        int age = int.Parse(parts[2]);
                        string gender = parts[3];
                        string phone = parts[4];
                        string email = parts[5];
                        string referreddoctor = parts[6];
                        string medicalhistory = parts[7];
                        string comments = parts[8];

                        PatientModel patient = new PatientModel(patient_id, name, age, gender, phone,
                            email, referreddoctor, medicalhistory, comments );

                        patients.Add(patient);
                    }
                }
            }

            return patients;
        }
    }
}
