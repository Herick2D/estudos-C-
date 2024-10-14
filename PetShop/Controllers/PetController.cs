namespace PetShop.Controllers;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models; // Importa o namespace do modelo Pet

[ApiController]
[Route("[controller]")] // Esse padrão de rota é o mesmo que o nome do controller sem o sufixo Controller
public class PetController : ControllerBase // Herda de ControllerBase para fornecer funcionalidades de API (sem renderizar views), similar à anotação @RestController do Spring Boot no Java
{
	private static List<Pet> pets = new(); // Simula um banco de dados com uma lista de pets
	[HttpGet] // Define que essa rota responde a requisições GET, similar à anotação @GetMapping do Spring Boot no Java
	public IActionResult GetPets()
	{
		return Ok(pets); // Retorna um status 200 OK, método auxiliar do ControllerBase
	}

	[HttpPost] // Define que essa rota responde a requisições POST, similar à anotação @PostMapping do Spring Boot no Java
	public IActionResult PostPet([FromBody] Pet pet) // FromBody indica que o parâmetro vem do corpo da requisição, assim como no spring boot é @RequestBody
	{
		pet.Id = pets.Count + 1; // Define o ID do pet como o próximo número da lista
		pets.Add(pet); // Adiciona o pet à lista
		return Created("", pet); // Retorna um status 201 Created, método auxiliar do ControllerBase, o primeiro parâmetro é a URI do novo recurso criado (não é obrigatório)
	}

	[HttpPut("{PetId}")] // Define que essa rota responde a requisições PUT, similar à anotação @PutMapping do Spring Boot no Java
	public IActionResult PutPet(int PetId, [FromBody] Pet pet)
	{   // Adicionado lógica diretamente no Controller pois não há camada de serviço e esse projeto possui cunho acadêmico. 
		Pet petToUpdate = pets.FirstOrDefault(p => p.Id == PetId);
		if (petToUpdate == null) return NotFound();
		petToUpdate.Name = pet.Name;
		petToUpdate.Breed = pet.Breed;
		petToUpdate.Age = pet.Age;
		return Ok(petToUpdate);
	}

	[HttpDelete("{PetId}")] // Define que essa rota responde a requisições DELETE, similar à anotação @DeleteMapping do Spring Boot no Java
	public IActionResult DeletePet(int PetId)
	{
		Pet petToDelete = pets.FirstOrDefault(p => p.Id == PetId);
		if (petToDelete == null) return NotFound();
		pets.Remove(petToDelete);
		return NoContent(); // Retorna um status 204 No Content, método auxiliar do ControllerBase
	}
}
