using APBD_tutor_5.Model;
using APBD_tutor_5.Repositories;

namespace APBD_tutor_5.Services;

public class AnimalService:IAnimalService
{
    private readonly IAnimalRepository _animalRepository;


    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        return _animalRepository.GetAnimals();
    }

    public int CreateAnimal(Animal animal)
    {
        return _animalRepository.CreateAnimal(animal);
    }

    public Animal GetAnimal(int idAnimal)
    {
        return _animalRepository.GetAnimal(idAnimal);
    }

    public int UpdateAnimal(int id,Animal animal)
    {
        return _animalRepository.UpdateAnimal(id,animal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        return _animalRepository.DeleteAnimal(idAnimal);
    }
}