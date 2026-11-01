using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LabManagement.LabTechnician
    {
        public class LabTechnicianModel
        {
            private int Technician_ID;
            private string Name;
            private string Password;

            public LabTechnicianModel()
            {
            }

            public LabTechnicianModel(int technician_id, string name, string password)
            {
                Technician_ID = technician_id;
                Name = name;
                Password = password;
            }

            public int GetTechnician_ID()
            {
                return Technician_ID;
            }

            public void SetTechnician_ID(int technician_id)
            {
                Technician_ID = technician_id;
            }

            public string GetName()
            {
                return Name;
            }

            public void SetName(string name)
            {
                Name = name;
            }

            public string GetPassword()
            {
                return Password;
            }

            public void SetPassword(string password)
            {
                Password = password;
            }
        }
    }
