namespace PetShop.Services;
using PetShop.Models;

public interface IPetService // Interface para definir os métodos que a classe de serviço deve implementar, similar à implementação do ORM no Spring Boot no Java
{
    List<Pet> GetPets(); // Método para retornar todos os pets
    Pet PostPet(Pet pet); // Método para adicionar um pet
    Pet PutPet(int PetId, Pet pet); // Método para atualizar um pet
    void DeletePet(int PetId); // Método para deletar um pet
}