using APBD_tutor_5.Model;

namespace APBD_tutor_5.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals();
    int CreateAnimal(Animal animal);
    Animal GetAnimal(int id);
    int UpdateAnimal(int id,Animal animal);
    int DeleteAnimal(int id);
}