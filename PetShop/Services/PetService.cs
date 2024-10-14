namespace PetShop.Services;
using PetShop.Models;

public class PetService : IPetService
{
    private static List<Pet> pets = new(); // Simula um banco de dados com uma lista de pets

    public List<Pet> GetPets()
    {
        return pets;
    }

    public Pet PostPet(Pet pet)
    {
        pet.Id = pets.Count + 1;
        pets.Add(pet);
        return pet;
    }

    public Pet PutPet(int PetId, Pet pet)
    {
        Pet petToUpdate = pets.FirstOrDefault(p => p.Id == PetId);
        if (petToUpdate == null) throw new Exception("Pet not found");
        petToUpdate.Name = pet.Name;
        petToUpdate.Breed = pet.Breed;
        petToUpdate.Age = pet.Age;
        return petToUpdate;
    }


    public void DeletePet(int PetId)
    {
        Pet petToDelete = pets.FirstOrDefault(p => p.Id == PetId);
        if (petToDelete == null) throw new Exception("Pet not found");
        pets.Remove(petToDelete);
    }
}