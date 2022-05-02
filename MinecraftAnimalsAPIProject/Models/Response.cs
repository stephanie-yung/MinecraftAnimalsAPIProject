using System;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace MCAnimalsAPI.Models
{
	public class Response
	{
		public int statusCode { get; set; }
		public string? statusDescription { get; set; }
		public List<BreedableAnimal> breedableanimalsresponse { get; set; } = new();
		public List<AnimalCategories> animalcategoriesresponse { get; set; } = new();

	}
}

