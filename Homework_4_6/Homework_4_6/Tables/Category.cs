using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_6.Tables;

internal class Category
{
    [Key]
    public int Id { get; set; }

    [Column("category_name")]
    public string CategoryName { get; set; }
}
