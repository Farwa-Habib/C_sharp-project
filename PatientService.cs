using LabManagement.Patient.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}