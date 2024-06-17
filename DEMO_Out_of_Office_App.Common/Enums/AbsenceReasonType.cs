using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOOutOfOfficeApp.Common.Enums
{
    //construts the custom atribute to make custom display name 
    public class EnumDisplayNameAttribute : Attribute
    {
        public string DisplayName { get; private set; }

        public EnumDisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }

    public enum AbsenceReasonType
    {
        [EnumDisplayName("Vacation")]
        Vacation = 1,

        [EnumDisplayName("Sick Leave")]
        SickLeave = 2,

        [EnumDisplayName("Family Leave")]
        FamilyLeave = 3,

        [EnumDisplayName("Personal Leave")]
        PersonalLeave = 4
    }
}
