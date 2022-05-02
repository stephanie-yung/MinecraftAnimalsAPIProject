using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace MCAnimalsAPI.Models
{
	public class BreedableAnimal
	{
		[Key]
		public int BreedableAnimalId { get; set; }

		public string AnimalName { get; set; }
		public double MaximumHealthPoints { get; set; }
		public string Behavior { get; set; }
		public string Spawn { get; set; }
		public string UsableItems { get; set; }
		public int AnimalCategoriesId { get; set; }

	}
}

