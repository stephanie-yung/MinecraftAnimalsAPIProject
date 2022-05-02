CREATE DATABASE MinecraftAnimals;
USE MinecraftAnimals;

CREATE TABLE BreedableAnimal(
    BreedableAnimalId int AUTO_INCREMENT NOT NULL PRIMARY KEY,
    AnimalName VARCHAR(100) NOT NULL,
    MaximumHealthPoints DOUBLE,
    Behavior VARCHAR(1000) NOT NULL,
    Spawn VARCHAR(1000) NOT NULL,
    UsableItems VARCHAR(1000) NOT NULL,
    AnimalCategoriesId INT NOT NULL
);


CREATE TABLE AnimalCategories(
    AnimalCategoriesId INT NOT NULL PRIMARY KEY, 
    AnimalCategory VARCHAR(100)
); 

ALTER TABLE BreedableAnimal ADD CONSTRAINT FK_AnimalCategoriesID FOREIGN KEY (AnimalCategoriesId) REFERENCES AnimalCategories(AnimalCategoriesId);

ALTER TABLE BreedableAnimal ADD CONSTRAINT UniqueName UNIQUE ( AnimalName );

INSERT INTO AnimalCategories (AnimalCategoriesId, AnimalCategory) VALUES (1, "Breedable");
INSERT INTO AnimalCategories (AnimalCategoriesId, AnimalCategory) VALUES (2, "Anthropod");

INSERT INTO BreedableAnimal( AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ( "Axolotl", 14, "Passive", "Lush Caves", "Bucket of Tropical Fish, Lead, Water Bucket", 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ("Bee", 10, "Passive, Neutral", "Bee Nests", "Flower, Lead" , 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ("Cat", 10, "Passive", "Villages, Swamp huts (only black cats)", "Raw Cod, Raw Salmon, Lead, Dye" , 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ("Chicken", 4, "Passive, Hostile (as a jockey)", "Solid surface blocks, Thrown egg", "Wheat Seeds, Beetroot Seeds, Melon Seeds, Pumpkin Seeds, Lead", 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ("Cow", 10, "Passive", "Grass blocks", "Bucket, Wheat, Lead", 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ("Donkey", 30, "Passive", "Meadow, Plains, Sunflower Plains, Savanna, Savanna Plateau, Windswept Savanna", "Lead, Saddle, Chest, Sugar, Wheat, Apple, Golden Carrot, Golden Apple, Hay Bale", 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ( "Fox", 20, "Passive", "Grove, Snowy Taiga, Old Growth Pine Taiga, Old Growth Spruce Taiga, Taiga", "Glow Berries, Lead, Sweet Berries", 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ("Goat", 10, "Passive, Neutral", "Frozen Peaks, Jagged Peaks, Snowy Slopes", "Bucket, Wheat, Lead" , 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ( "Hoglin", 40, "Hostile", "Crimson Forest, Bastion remnant", "Crimson Fungus, Lead", 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ("Horse", 30, "Passive", "Plains, Sunflower Plains, Savanna, Savanna Plateau, Windswept Savanna, Villages", "Saddle, Lead, Horse Armor, Sugar, Wheat, Apple, Golden Carrot, Golden Apple, Enchanted Golden Apple, Hay Bale" , 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ("Llama", 30, "Passive, Neutral", "Windswept Hills, Windswept Forest, Windswept Gravelly Hills, Savanna, Savanna Plateau, Windswept Savanna", "Chest, Carpet, Lead, Wheat, Hay Bale", 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ( "Mooshroom", 10, "Passive","Mushroom Fields", "Bucket, Bowl, Shears, Wheat, Flower, Lead", 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ("Mule", 30, "Passive","Bred by a horse and donkey", "Saddle, Chest, Sugar, Wheat, Apple, Golden Carrot, Golden Apple, Hay Bale" , 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ("Ocelot", 10, "Passive","Jungle, Bamboo Jungle, Sparse Jungle, Meadow", "Raw Cod, Lead", 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ("Panda", 20, "Passive, Neutral","Jungle, Bamboo Jungle, Sparse Jungle", "Bamboo, Cake", 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ("Pig", 10, "Passive","Grass Blocks", "Lead, Shears, Wheat, Dye", 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ( "Rabbit", 3, "Passive","Frozen River, Snowy Beach, Snowy Plains, Ice Spikes, Snowy Slopes, Grove, Snowy Taiga, Old Growth Pine Taiga, Old Growth Spruce Taiga, Taiga, Flower Forest, Meadow, Desert, Frozen Ocean", "Dandelion, Carrot, Golden Carrot, Lead", 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ("Sheep", 8, "Passive","Grass blocks", "Lead, Shears, Wheat, Dye" , 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ( "Strider", 20, "Passive","Lava Sea, Delta, Nether Wastes, Crimson Forest, Warped Forest, Soul Sand Valley, Basalt Deltas", "Warped Fungus, Saddle, Lead, Warped Fungus on a Stick", 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ( "Trader Llama", 30, "Passive, Neutral","Windswept Hills, Windswept Forest, Windswept Gravelly Hills, Savanna, Savanna Plateau, Windswept Savanna", "Chest, Carpet, Lead, Wheat, Hay Bale", 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ("Turtle", 30,"Passive", "Beach", "Seagrass" , 1 );
INSERT INTO BreedableAnimal(AnimalName, MaximumHealthPoints, Behavior, Spawn, UsableItems, AnimalCategoriesId) VALUES ( "Wolf", 20,"Passive, Neutral", "Grove, Snowy Taiga, Old Growth Pine Taiga, Old Growth Spruce Tiaga, Tiaga, Forest", "Bone, Meat, Fish, Rabbit Stew, Dye, Lead" , 1 );


SELECT * FROM MinecraftAnimals.AnimalCategories;
SELECT * FROM MinecraftAnimals.BreedableAnimal;


