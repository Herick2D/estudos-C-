namespace PetShop.Services;
using PetShop.Models;

public interface IPetService // Interface para definir os m�todos que a classe de servi�o deve implementar, similar � implementa��o do ORM no Spring Boot no Java
{
    List<Pet> GetPets(); // M�todo para retornar todos os pets
    Pet PostPet(Pet pet); // M�todo para adicionar um pet
    Pet PutPet(int PetId, Pet pet); // M�todo para atualizar um pet
    void DeletePet(int PetId); // M�todo para deletar um pet
}