﻿namespace DEMOOutOfOfficeApp.DTOS
{
    public record ProjectDTO(int Id,string ProjectName, DateTime StartDate, DateTime? EndDate,string Employee,string Projectmanager,string Comment,string ProjectStatus);

}
