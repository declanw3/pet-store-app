using PetStore.Resources;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore
{
    class PetStoreApp
    {
        protected IPetResource _petResource;

        public PetStoreApp(IPetResource petResource) =>
            (_petResource) = (petResource);

        public async Task RunApp()
        {
            var pets = await _petResource.GetPetsByStatusAsync(Models.Pet.StatusEnum.Available);
            var groupedPets = pets.GroupBy(p => p.Category?.Id,
                                            (categoryId, pets) => new
                                            {
                                                Key = categoryId,
                                                CategoryName = pets?.First().Category?.Name,
                                                Pets = pets
                                            });

            foreach(var group in groupedPets)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine($"{group.CategoryName}");
                Console.WriteLine("---------------------");

                foreach (var pet in group.Pets)
                    Console.WriteLine(pet.ToString());
            }

            Console.ReadLine();
        }
    }
}
