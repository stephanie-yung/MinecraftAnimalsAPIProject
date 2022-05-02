using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace MCAnimalsAPI.Models
{
	public class AnimalCategories
	{

		[Key]
		public int AnimalCategoriesId { get; set; }
		public string AnimalCategory { get; set; }

		public BreedableAnimal? BreedableAnimal { get; set; }

	}
}
