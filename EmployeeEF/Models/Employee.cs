using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeEF.Models;

public partial class Employee
{

    static Employee emp;
    public static Employee CreateEmployee(string firstname, string lastname, string patronymic, int titleid)
    {
        emp = new Employee();
        emp.Firstname = firstname;
        emp.Lastname = lastname;
        emp.Patronymic = patronymic;
        emp.TitleId = titleid;
        return emp;
    }

    [Column("birthday")]

    public DateTime Birthday
    {
        get
        {

            return Birthdate;
        }
        set
        {
            Birthdate = value;
            Birthdate = DateTime.SpecifyKind(Birthdate, DateTimeKind.Utc);
        }
    }

    [Column("lastname")]
    public string? Lastname { get; set; }

    [Column("firstname")]
    public string? Firstname { get; set; }

    [Column("patronymic")]
    public string? Patronymic { get; set; }

    [Column("telephone")]
    public string? Telephone { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("title_id")]
    public int? TitleId { get; set; }


    DateTime Birthdate { get; set; }

    [Key]
    [Column("employee_id")]
    public int EmployeeId { get; set; }

    public virtual Title? Title { get; set; }
}
