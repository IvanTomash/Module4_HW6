using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_6.Tables;

internal class Breed
{
    [Key]
    public int Id {  get; set; }

    [Column("breed_name")]
    public string BreedName { get; set; }

    [ForeignKey("breedCategory")]
    [Column("category_id")]
    public int? CategoryId { get; set; }

    public Category Category { get; set; }
}
