using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_6.Tables;

internal class Location
{
    [Key]
    public int Id { get; set; }

    [Column("location_name")]
    public string LocationName {  get; set; } 
}
