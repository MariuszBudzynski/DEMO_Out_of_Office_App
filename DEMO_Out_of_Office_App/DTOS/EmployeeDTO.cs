namespace DEMOOutOfOfficeApp.DTOS
{
    public record EmployeeDTO(int ID,string FullName, string SubdivisionName, string PositionName,string StatusName,string PeoplePartnerName, decimal OutOfOfficeBalance);
 
}
