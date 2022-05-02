# MinecraftAnimalsAPIProject

## Table of Contents

- [Summary](#summary)
- [Error Handling](#error-handling)
- [Route Parameters](#route-parameters)
- [Data Modeling](#data-modeling)
- [BreedableAnimal API](#BreedableAnimal-api)
- [AnimalCategories API](#AnimalCategories-api)

## Summary

The API is divided into two main sections:

1. Breedable Animals
2. Animal Categories


All API routes return a consistent response object containing a successful or unsuccessful status code, status description, and a list of any applicable items that should be returned. An example response could be the following:

```javascript
{
    "statusCode": 202,
    "statusDescription": "Success. Found All Animal Categories",
    "breedableanimalsresponse": [],
    "animalcategoriesresponse": []
}
```

## Error Handling

If an API endpoint encounters an unexpected error during execution, it will return an unsucessful response. 

```javascript
{
    "statusCode": 404,
    "statusDescription": "Not Found. Unable to retrieve Animal ID. Please try another Animal Id.",
    "breedableanimalsresponse": null,
    "animalcategoriesresponse": []
}
```

## Route Parameters

Route parameters are marked by `<type:animalId>` where `type` is the data type of
the parameter and `animalId` is the internal name for the parameter. For example,
`api/BreedableAnimal/<int:BreedableAnimalId>` can be accessed by `api/BreedableAnimal/1`.

## Data Modeling

### BreedableAnimal Model

```javascript
class BreedableAnimal {
    [Key]
    public int BreedableAnimalId { get; set; }

    public string AnimalName { get; set; }
    public double MaximumHealthPoints { get; set; }
    public string Behavior { get; set; }
    public string Spawn { get; set; }
    public string UsableItems { get; set; }
    public int AnimalCategoriesId { get; set; }
}
```

### AnimalCategories Model

```javascript
class AnimalCategories {
    [Key]
    public int AnimalCategoriesId { get; set; }
    public string AnimalCategory { get; set; }
    public BreedableAnimal? BreedableAnimal { get; set; }

}
```

# Local Development

Visual Studio, MySQLWorkbench, and Postman is needed to run this locally. If you clone this repo, be sure to go to the file appsettings.json and change the connection string with the proper User and Password login for your Database. 

# BreedableAnimal API

### GET ALL BREEDABLE ANIMALS `/api/BreedableAnimal`

**Summary**: Gets all breedable animals from the database


**Returns**: `Bad Request` if unable to retrieve objects from database. Otherwise, returns `BreedableAnimal` from the database.


### GET INDIVIDUAL BREEDABLE ANIMAL `/api/BreedableAnimal/<int:BreedableAnimalId>`

**Summary**: Gets the breedable animal with the associated Id.

**Parameters**:

- Route
  - `<int> BreedableAnimalId`: Id of the Animal to be retrieved.

**Returns**: `Request Not Found` if unable to retrieve objects from database. Otherwise, returns individual `BreedableAnimal` from the database.

```javascript
{
	"statusCode": 202,
	"statusDescription": "Success. Animal ID Found.",
	"breedableanimalsresponse": [
		{
			"breedableAnimalId": 1,
			"animalName": "Axolotl",
			"maximumHealthPoints": 14,
			"behavior": "Passive",
			"spawn": "Lush Caves",
			"usableItems": "Bucket of Tropical Fish, Lead, Water Bucket",
			"animalCategoriesId": 1,
			"animalCategories": null
		}
	],
	"animalcategoriesresponse": []
}

OR

{
  "statusCode": 404,
  "statusDescription": "Request Not Found. Unable to retrieve Animal ID. Please try a valid Animal ID.",
  "breedableanimalsresponse": null,
  "animalcategoriesresponse": []
}

```



### PUT 

## PUT INDIVIDUAL BREEDABLE ANIMAL `/api/BreedableAnimal/<int:BreedableAnimalId>`

**Summary**: Given an object with fields
to be updated, updates the specified BreedableAnimal in the database and returns the updated object.

**Parameters**:

- Route
  - `<int> BreedableAnimalId`: Id of the Animal to be retrieved.
- API
  - `<Object> fields`: represents the property name to updated.

**Response Body**: 

```javascript
{
    "BreedableAnimalId": 18,
    "animalName": "Sheep",
    "maximumHealthPoints": 8,
    "behavior": "Passive",
    "spawn": "Grass Blocks",
    "usableItems": "Lead, Shears, Wheat, Dye.",
    "animalCategoriesId": 1
}
```


**Returns**: updated `BreedableAnimal`. `404` if the animalId does not exist.

```javascript
{
    "statusCode": 201,
    "statusDescription": "Success. Breedable Animal has been Modified.",
    "breedableanimalsresponse": [
        {
            "breedableAnimalId": 18,
            "animalName": "Sheep",
            "maximumHealthPoints": 8,
            "behavior": "Passive",
            "spawn": "Grass Blocks",
            "usableItems": "Lead, Shears, Wheat, Dye.",
            "animalCategoriesId": 1
        }
    ],
    "animalcategoriesresponse": []
}


OR

{
    "statusCode": 404,
    "statusDescription": "Request Not Found. Unable to retrieve Animal ID. Please try a valid Animal ID.",
    "breedableanimalsresponse": null,
    "animalcategoriesresponse": []
}

```
### POST BREEDABLE ANIMAL `/api/BreedableAnimal`

**Summary**: Adds new breedable animal object to the database.


**Parameters**:

- API
  - `<string> AnimalName`: name of animal
  - `<int> MaximumHealthPoints`: maximum health points of animal
  - `<string> Behavior`: Behavioral category of animal
  - `<string> Spawn`: origin locations of animal
  - `<string> UsableItems`: any item associated to animal
  - `<string> AnimalName`: name of animal
  - `<AnimalCategories>`: AnimalCategories Object
  	- `<string> AnimalName`: name of animal
  	- `<boolean> Breedable`: value on classficiation
  	- `<boolean> Tameable`: value on classficiation
  
  
**Response Body**: 
```javascript
{
    "AnimalName": "Zest0",
    "MaximumHealthPoints": 10,
    "Behavior": "Hostile",
    "Spawn": "Lush Caves",
    "UsableItems": "Water Bucket",
    "AnimalCategoriesId": 1
}
```

**Returns**: newly added animal object

```javascript
{
    "statusCode": 201,
    "statusDescription": "Success. Created new breedable animal object.",
    "breedableanimalsresponse": [
        {
            "breedableAnimalId": 23,
            "animalName": "Zest0",
            "maximumHealthPoints": 10,
            "behavior": "Hostile",
            "spawn": "Lush Caves",
            "usableItems": "Water Bucket",
            "animalCategoriesId": 1
        }
    ],
    "animalcategoriesresponse": []
}

```

### DELETE INDIVIDUAL BREEDABLE ANIMAL `/api/BreedableAnimal/<int:BreedableAnimalId>`

**Summary**: Removes the animal from the database from both tables BreedableAnimal and AnimalCategories.

**Parameters**:

- Route
  - `<int> BreedableAnimalId`: Id of the Animal to be retrieved.

**Returns**:  `202` and a successful description confirmation if deleted. `Not Found` if the corresponding
id does not exist.

```javascript
{

    "statusCode": 202,
    "statusDescription": "Success. Animal Id is Deleted.",
    "breedableanimalsresponse": null,
    "animalcategoriesresponse": []

}

OR

{
    "statusCode": 404,
    "statusDescription": " Not Found. Unable to find Animal Id. Please try another Animal Id",
    "breedableanimalsresponse": null,
    "animalcategoriesresponse": []
}

```




## AnimalCategories API 

### GET ALL ANIMAL CATEGORIES `/api/AnimalCategories`

**Summary**: Gets all animals in the AnimalCategories table.

**Returns**: all `AnimalCategories` objects. If theres an error then, `400` is returned in its place.

### GET INDIVIDUAL ANIMAL CATEGORIES `/api/AnimalCategories/AnimalCategoriesId`

**Summary**: Given a list of emails, returns a list of the corresponding users.

**Parameters**:

- API
  - `<int]> AnimalCategoriesId`: Id of animal

**Returns**: individual `AnimalCategories`. If an animal isn't retrieved, `404` is returned in its place.

```javascript
{
    "statusCode": 202,
    "statusDescription": "Success. Animal Category Found.",
    "breedableanimalsresponse": [],
    "animalcategoriesresponse": [
        {
            "animalCategoriesId": 1,
            "animalCategory": "Breedable",
            "breedableAnimal": null
        }
    ]
}

OR

{
    "statusCode": 404,
    "statusDescription": " Not Found. Unable to find Animal Id. Please try another Animal Id",
    "breedableanimalsresponse": null,
    "animalcategoriesresponse": []
}

```

### PUT INDIVIDUAL ANIMAL CATEGORY `/api/AnimalCategories/<int:AnimalCategoriesId>`

**Summary**: Given an object with fields
to be updated, updates the specified AnimalCategories in the database and returns the updated object.

**Parameters**:

- Route
  - `<int> AnimalCategoriesId`: Id of the Animal to be retrieved.
- API
  - `<Object> fields`: represents the property name to updated.


**Request Body**: 
```javascript
{
    "animalCategoriesId": 3,
    "animalCategory": "Tameable"
}

```


**Returns**: updated `AnimalCategories`. `404` if the animalId does not exist.
**Response Body**: 
```javascript
{
    "statusCode": 200,
    "statusDescription": "Success. The Animal Categories Id has been Modified.",
    "breedableanimalsresponse": [],
    "animalcategoriesresponse": [
        {
            "animalCategoriesId": 3,
            "animalCategory": "Tameable",
            "breedableAnimal": null
        }
    ]
}

OR

{
    "statusCode": 404,
    "statusDescription": "Request Not Found. Unable to retrieve Animal ID. Please try a valid Animal ID.",
    "breedableanimalsresponse": [],
    "animalcategoriesresponse": null
}

```

### POST ANIMAL CATEGORY `/api/AnimalCategories`

**Summary**: Given an object with fields
to be added, updates AnimalCategories in the database and returns the added object.

**Parameters**:

- Route
  - `<int> AnimalCategoriesId`: Id of the Animal to be retrieved.
- API
  - `<Object> fields`: represents the property name to updated.


**Request Body**: 
```javascript
{
    "AnimalCategoriesId": 3,
    "AnimalCategory": "Unclassified"
}
```

**Returns**: added object to `AnimalCategories`. `401` if unable to post and create object.

**Response Body**:
```javascript
{
    "statusCode": 201,
    "statusDescription": "Success. Created new breedable animal object.",
    "breedableanimalsresponse": [],
    "animalcategoriesresponse": [
        {
            "animalCategoriesId": 3,
            "animalCategory": "Unclassified",
            "breedableAnimal": null
        }
    ]
}
```

### DELETE INDIVIDUAL Animal Category `/api/AnimalCategories/<int:AnimalCategoriesId>`


**Summary**: Removes the animal category object from the database AnimalCategories.

**Parameters**:

- Route
  - `<int> AnimalCategoriesId`: Id of the Animal Category to be retrieved.

**Returns**:  `202` and a successful description confirmation if deleted. `Not Found` if the corresponding
id does not exist.

```javascript
{
    "statusCode": 202,
    "statusDescription": "Success. Animal Category is Deleted.",
    "breedableanimalsresponse": [],
    "animalcategoriesresponse": null
}

OR

{
    "statusCode": 404,
    "statusDescription": " Not Found. Unable to find Animal Category Id. Please try another Animal Category Id",
    "breedableanimalsresponse": null,
    "animalcategoriesresponse": []
}


