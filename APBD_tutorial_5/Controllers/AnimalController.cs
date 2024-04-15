using APBD_tutor_5.Model;
using APBD_tutor_5.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_tutorial_5.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController:ControllerBase
{
    private IAnimalService _animalService;


    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = _animalService.GetAnimals();
        return Ok(animals);
    }


    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animalService.GetAnimal(id);
        if (animal == null)
        {
            return NotFound("Animal Not found.");
        }
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var affectedCount = _animalService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut]
    public IActionResult UpdateAnimal(int id,Animal animal)
    {
        var affectedCount = _animalService.UpdateAnimal(id,animal);
        return NoContent();
    }

    [HttpDelete]
    public IActionResult DeleteAnimal(int id)
    {
        var affectedCount = _animalService.DeleteAnimal(id);
        return NoContent();
    }
}