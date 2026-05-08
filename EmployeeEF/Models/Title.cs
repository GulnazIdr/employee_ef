using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeEF.Models;

public partial class Title
{
    [Column("title_name")]
    public string? TitleName { get; set; }

    [Key]
    [Column("title_id")]
    public int TitleId { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
