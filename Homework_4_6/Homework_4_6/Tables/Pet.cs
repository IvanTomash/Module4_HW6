using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_6.Tables;

internal class Pet
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    [ForeignKey("petCategory")]
    [Column("category_id")]
    public int? CategoryId { get; set; }

    public Category Category { get; set; }

    [ForeignKey("petBreed")]
    [Column("breed_id")]
    public int? BreedId { get; set; }

    public Breed Breed { get; set; }

    public float Age { get; set; }

    [ForeignKey("petLocation")]
    [Column("location_id")]
    public int? LocationId { get; set; }

    public Location Location { get; set; }

    [Column("image_url")]
    public string ImageUrl { get; set; }

    public string Description { get; set; }
}
