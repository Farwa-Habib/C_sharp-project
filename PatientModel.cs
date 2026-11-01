using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabManagement.Patient
{

    public class PatientModel
    {
        private int Patient_ID;
        private string Name;
        private int Age;
        private string Gender;
        private string Phone;
        private string Email;
        private string ReferredDoctor;
        private string MedicalHistory;
        private string Comments;

        // Default Constructor
        public PatientModel()
        {
        }

        // Parameterized Constructor
        public PatientModel(int patient_id, string name, int age, string gender, string phone,
            string email, string referreddoctor, string medicalhistory, string comments)
        {
            Patient_ID = patient_id;
            Name = name;
            Age = age;
            Gender = gender;
            Phone = phone;
            Email = email;
            ReferredDoctor = referreddoctor;
            MedicalHistory = medicalhistory;
            Comments = comments;
        }

        // Patient ID
        public void SetPatient_ID(int patient_id)
        {
            Patient_ID = patient_id;
        }

        public int GetPatient_ID()
        {
            return Patient_ID;
        }

        // Name
        public void SetName(string name)
        {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        // Age
        public void SetAge(int age)
        {
            Age = age;
        }

        public int GetAge()
        {
            return Age;
        }

        // Gender
        public void SetGender(string gender)
        {
            Gender = gender;
        }

        public string GetGender()
        {
            return Gender;
        }

        // Phone
        public void SetPhone(string phone)
        {
            Phone = phone;
        }

        public string GetPhone()
        {
            return Phone;
        }

        // Email
        public void SetEmail(string email)
        {
            Email = email;
        }

        public string GetEmail()
        {
            return Email;
        }

        // Referred Doctor
        public void SetReferredDoctor(string referreddoctor)
        {
            ReferredDoctor = referreddoctor;
        }

        public string GetReferredDoctor()
        {
            return ReferredDoctor;
        }

        // Medical History
        public void SetMedicalHistory(string medicalhistory)
        {
            MedicalHistory = medicalhistory;
        }

        public string GetMedicalHistory()
        {
            return MedicalHistory;
        }

        // Comments
        public void SetComments(string comments)
        {
            Comments = comments;
        }

        public string GetComments()
        {
            return Comments;
        }

        // ToString Method
        public override string ToString()
        {
            return $"Patient ID: {Patient_ID}\n" +
                   $"Name: {Name}\n" +
                   $"Age: {Age}\n" +
                   $"Gender: {Gender}\n" +
                   $"Phone: {Phone}\n" +
                   $"Email: {Email}\n" +
                   $"Referred Doctor: {ReferredDoctor}\n" +
                   $"Medical History: {MedicalHistory}\n" +
                   $"Comments: {Comments}";
        }
    }
}
