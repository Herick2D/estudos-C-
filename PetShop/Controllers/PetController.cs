namespace PetShop.Controllers;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models; // Importa o namespace do modelo Pet
using PetShop.Services; // Importa o namespace do servi�o de pets

[ApiController]
[Route("[controller]")] // Esse padr�o de rota � o mesmo que o nome do controller sem o sufixo Controller
public class PetController : ControllerBase // Herda de ControllerBase para fornecer funcionalidades de API (sem renderizar views), similar � anota��o @RestController do Spring Boot no Java
{

	private IPetService _service; // Invers�o de depend�ncia do servi�o de pets, pensando nos principios S.O.L.I.D. de responsabilidade �nica e invers�o de depend�ncia

	public PetController(IPetService service) // Inje��o de depend�ncia do servi�o de pets no construtor do controller, similar � anota��o @Autowired do Spring Boot no Java, padr�o de projeto de inje��o de depend�ncia
	{
		_service = service; // Inicializa��o do service, similar � inje��o de depend�ncia do Spring Boot no Java
	}


	[HttpGet] // Define que essa rota responde a requisi��es GET, similar � anota��o @GetMapping do Spring Boot no Java
	public IActionResult GetPets()
	{
		/* return Ok(pets); // Retorna um status 200 OK, m�todo auxiliar do ControllerBase */
		return Ok(_service.GetPets()); // Atualiza��o para chamar o m�todo GetPets do servi�o de pets
	}

	[HttpPost] // Define que essa rota responde a requisi��es POST, similar � anota��o @PostMapping do Spring Boot no Java
	public IActionResult PostPet([FromBody] Pet pet) // FromBody indica que o par�metro vem do corpo da requisi��o, assim como no spring boot � @RequestBody
	{
		/* pet.Id = pets.Count + 1; // Define o ID do pet como o pr�ximo n�mero da lista
		 pets.Add(pet); // Adiciona o pet � lista
		 return Created("", pet); // Retorna um status 201 Created, m�todo auxiliar do ControllerBase, o primeiro par�metro � a URI do novo recurso criado (n�o � obrigat�rio)
		*/
		return Created("", _service.PostPet(pet)); // Atualiza��o para chamar o m�todo PostPet do servi�o de pets
	}

	[HttpPut("{PetId}")] // Define que essa rota responde a requisi��es PUT, similar � anota��o @PutMapping do Spring Boot no Java
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

	[HttpDelete("{PetId}")] // Define que essa rota responde a requisi��es DELETE, similar � anota��o @DeleteMapping do Spring Boot no Java
	public IActionResult DeletePet(int PetId)
	{
		try
		{
			_service.DeletePet(PetId);
			return NoContent(); // Retorna um status 204 No Content, m�todo auxiliar do ControllerBase
		}
		catch (Exception err)
		{
			return NotFound(new { message = err.Message });
		}

	}
}
