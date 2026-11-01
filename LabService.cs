using LabManagement.LabTech.Repo;
using LabManagement.Patient;
using LabManagement.Patient.Services;
using LabManagement.Test;
using System.Collections.Generic;

namespace LabManagement.LabTechnician.Services
{
    public class LabTechnicianService
    {
        private LabTechnicianRepo repo;
        private PatientService patientService;
        private TestService testService;

        public LabTechnicianService()
        {
            repo = new LabTechnicianRepo();
            patientService = new PatientService();
            testService = new TestService();
        }

        public bool RegisterTechnician(LabTechnicianModel technician)
        {
            List<LabTechnicianModel> technicians =repo.GetTechniciansFromFile();

            foreach (LabTechnicianModel item in technicians)
            {
                if (item.GetTechnician_ID() ==technician.GetTechnician_ID())
                {
                    return false;
                }
            }

            repo.SaveInFile(technician);
            return true;
        }

        public bool Login(int technician_id, string password)
        {
            List<LabTechnicianModel> technicians =repo.GetTechniciansFromFile();

            foreach (LabTechnicianModel technician in technicians)
            {
                if (technician.GetTechnician_ID() == technician_id &&technician.GetPassword() == password)
                {
                    return true;
                }
            }

            return false;
        }

        public List<PatientModel> GetAllPatients()
        {
            return patientService.GetAllPatients();
        }

        public PatientModel GetPatientById(int patient_id)
        {
            return patientService.GetPatientById(patient_id);
        }

        public List<TestModel> GetPatientTests(int patient_id)
        {
            return testService.GetTestsByPatientId(patient_id);
        }

        public decimal CalculatePatientTotal(int patient_id)
        {
            List<TestModel> tests =testService.GetTestsByPatientId(patient_id);

            decimal total = 0;

            foreach (TestModel test in tests)
            {
                total += test.GetPrice();
            }

            return total;
        }

        public bool DeletePatient(int patient_id)
        {
            return patientService.DeletePatient(patient_id);
        }

        public bool UpdatePatient(int patient_id, PatientModel updatedPatient)
        {
            return patientService.UpdatePatient(patient_id, updatedPatient);
        }
        public List<PatientModel> GetAllPatient()
        {
            return patientService.GetAllPatients();
        }

    }
}