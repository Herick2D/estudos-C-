namespace PetShop.Controllers;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models; // Importa o namespace do modelo Pet

[ApiController]
[Route("[controller]")] // Esse padr�o de rota � o mesmo que o nome do controller sem o sufixo Controller
public class PetController : ControllerBase // Herda de ControllerBase para fornecer funcionalidades de API (sem renderizar views), similar � anota��o @RestController do Spring Boot no Java
{
	private static List<Pet> pets = new(); // Simula um banco de dados com uma lista de pets
	[HttpGet] // Define que essa rota responde a requisi��es GET, similar � anota��o @GetMapping do Spring Boot no Java
	public IActionResult GetPets()
	{
		return Ok(pets); // Retorna um status 200 OK, m�todo auxiliar do ControllerBase
	}

	[HttpPost] // Define que essa rota responde a requisi��es POST, similar � anota��o @PostMapping do Spring Boot no Java
	public IActionResult PostPet([FromBody] Pet pet) // FromBody indica que o par�metro vem do corpo da requisi��o, assim como no spring boot � @RequestBody
	{
		pet.Id = pets.Count + 1; // Define o ID do pet como o pr�ximo n�mero da lista
		pets.Add(pet); // Adiciona o pet � lista
		return Created("", pet); // Retorna um status 201 Created, m�todo auxiliar do ControllerBase, o primeiro par�metro � a URI do novo recurso criado (n�o � obrigat�rio)
	}

	[HttpPut("{PetId}")] // Define que essa rota responde a requisi��es PUT, similar � anota��o @PutMapping do Spring Boot no Java
	public IActionResult PutPet(int PetId, [FromBody] Pet pet)
	{   // Adicionado l�gica diretamente no Controller pois n�o h� camada de servi�o e esse projeto possui cunho acad�mico. 
		Pet petToUpdate = pets.FirstOrDefault(p => p.Id == PetId);
		if (petToUpdate == null) return NotFound();
		petToUpdate.Name = pet.Name;
		petToUpdate.Breed = pet.Breed;
		petToUpdate.Age = pet.Age;
		return Ok(petToUpdate);
	}

	[HttpDelete("{PetId}")] // Define que essa rota responde a requisi��es DELETE, similar � anota��o @DeleteMapping do Spring Boot no Java
	public IActionResult DeletePet(int PetId)
	{
		Pet petToDelete = pets.FirstOrDefault(p => p.Id == PetId);
		if (petToDelete == null) return NotFound();
		pets.Remove(petToDelete);
		return NoContent(); // Retorna um status 204 No Content, m�todo auxiliar do ControllerBase
	}
}
