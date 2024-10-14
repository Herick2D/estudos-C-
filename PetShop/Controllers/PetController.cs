namespace PetShop.Controllers;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models; // Importa o namespace do modelo Pet
using PetShop.Services; // Importa o namespace do serviço de pets

[ApiController]
[Route("[controller]")] // Esse padrão de rota é o mesmo que o nome do controller sem o sufixo Controller
public class PetController : ControllerBase // Herda de ControllerBase para fornecer funcionalidades de API (sem renderizar views), similar à anotação @RestController do Spring Boot no Java
{

	private IPetService _service; // Inversão de dependência do serviço de pets, pensando nos principios S.O.L.I.D. de responsabilidade única e inversão de dependência

	public PetController(IPetService service) // Injeção de dependência do serviço de pets no construtor do controller, similar à anotação @Autowired do Spring Boot no Java, padrão de projeto de injeção de dependência
	{
		_service = service; // Inicialização do service, similar à injeção de dependência do Spring Boot no Java
	}


	[HttpGet] // Define que essa rota responde a requisições GET, similar à anotação @GetMapping do Spring Boot no Java
	public IActionResult GetPets()
	{
		/* return Ok(pets); // Retorna um status 200 OK, método auxiliar do ControllerBase */
		return Ok(_service.GetPets()); // Atualização para chamar o método GetPets do serviço de pets
	}

	[HttpPost] // Define que essa rota responde a requisições POST, similar à anotação @PostMapping do Spring Boot no Java
	public IActionResult PostPet([FromBody] Pet pet) // FromBody indica que o parâmetro vem do corpo da requisição, assim como no spring boot é @RequestBody
	{
		/* pet.Id = pets.Count + 1; // Define o ID do pet como o próximo número da lista
		 pets.Add(pet); // Adiciona o pet à lista
		 return Created("", pet); // Retorna um status 201 Created, método auxiliar do ControllerBase, o primeiro parâmetro é a URI do novo recurso criado (não é obrigatório)
		*/
		return Created("", _service.PostPet(pet)); // Atualização para chamar o método PostPet do serviço de pets
	}

	[HttpPut("{PetId}")] // Define que essa rota responde a requisições PUT, similar à anotação @PutMapping do Spring Boot no Java
	public IActionResult PutPet(int PetId, [FromBody] Pet pet)
	{
		try
		{
			return Ok(_service.PutPet(PetId, pet));
		}
		catch (Exception err)
		{
			return NotFound(new { message = err.Message });
		}

	}

	[HttpDelete("{PetId}")] // Define que essa rota responde a requisições DELETE, similar à anotação @DeleteMapping do Spring Boot no Java
	public IActionResult DeletePet(int PetId)
	{
		try
		{
			_service.DeletePet(PetId);
			return NoContent(); // Retorna um status 204 No Content, método auxiliar do ControllerBase
		}
		catch (Exception err)
		{
			return NotFound(new { message = err.Message });
		}

	}
}
