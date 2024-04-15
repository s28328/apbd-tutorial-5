namespace APBD_tutor_5.Model;

public class Animal
{
    public int IdAnimal { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    
    public string Description { get; set; }
    public string Area { get; set; }

    public void Copy(Animal animal)
    {
        IdAnimal = animal.IdAnimal;
        Name = animal.Name;
        Category = animal.Category;
        Description = animal.Description;
        Area = animal.Area;
    }
}