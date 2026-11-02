using LabManagement.Patient.Repo;
using LabManagement.Patient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LabManagement.Patient.Services
{
    public class PatientService
    {
        private PatientRepo repo;

        public PatientService()
        {
            repo = new PatientRepo();
        }

        // Add Patient
        public bool AddPatient(PatientModel patient)
        {
            if (GetPatientById(patient.GetPatient_ID()) != null)
            {
                return false;
            }

            repo.SaveInFile(patient);
            return true;
        }

        // Search Patient By ID
        public PatientModel GetPatientById(int patient_id)
        {
            List<PatientModel> patients = repo.GetPatientsFromFile();

            foreach (PatientModel patient in patients)
            {
                if (patient.GetPatient_ID() == patient_id)
                {
                    return patient;
                }
            }

            return null;
        }

        // Get All Patients
        public List<PatientModel> GetAllPatients()
        {
            return repo.GetPatientsFromFile();
        }

        // Update Patient
        public bool UpdatePatient(int patient_id, PatientModel updatedPatient)
        {
            List<PatientModel> patients = repo.GetPatientsFromFile();

            foreach (PatientModel patient in patients)
            {
                if (patient.GetPatient_ID() == patient_id)
                {
                    patient.SetName(updatedPatient.GetName());
                    patient.SetAge(updatedPatient.GetAge());
                    patient.SetGender(updatedPatient.GetGender());
                    patient.SetPhone(updatedPatient.GetPhone());
                    patient.SetEmail(updatedPatient.GetEmail());
                    patient.SetReferredDoctor(updatedPatient.GetReferredDoctor());
                    patient.SetMedicalHistory(updatedPatient.GetMedicalHistory());
                    patient.SetComments(updatedPatient.GetComments());

                    repo.SaveAllDataIntoFile(patients);

                    return true;
                }
            }

            return false;
        }

        // Delete Patient
        public bool DeletePatient(int patient_id)
        {
            List<PatientModel> patients = repo.GetPatientsFromFile();

            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].GetPatient_ID() == patient_id)
                {
                    patients.RemoveAt(i);

                    repo.SaveAllDataIntoFile(patients);

                    return true;
                }
            }

            return false;
        }
        // new embeded code 
        // view patient by name 
        public PatientModel GetPatientByName(string name)
        {
            List<PatientModel> patients = repo.GetPatientsFromFile();

            foreach (PatientModel patient in patients)
            {
                if (patient.GetName() == name)
                {
                    return patient;
                }
            }

            return null;
        }
        
        public PatientModel Searchbycategory(string medicalhistory)
        {
            List<PatientModel> patients = repo.GetPatientsFromFile();
            foreach (PatientModel patient in patients)
            {
                if (PatientModel.GetMedicalHistory() == medicalhistory)
                {
                    return patient;
                }

            }
            return null;
        }
        public List<PatientModel> SortAllPatients(int age)
        {
            List<PatientModel> patients = repo.GetPatientsFromFile();
            foreach (PatientModel patient in patients)
            {
                for (int i = 0; i < patients.Count; i++)
                {
                    for (int j = 0; j = patient - i - 1; j++)
                    {
                        if (patient[i]>= patient[j])
                        {
                            continue;
                        }
                        int temp = 0;
                        patient[temp] = patient[i];
                        patient[i] = patient[j];
                        patient[j] = patienttemp[i];
                    }
                }

                return patient[0] && patient[count - 1];
            }
            return null;
        }
    }
}