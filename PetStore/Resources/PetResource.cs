using PetStore.Models;
using PetStore.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStore.Resources
{
    public class PetResource : IPetResource
    {
        private IPetRepository _petRepository;

        public PetResource(IPetRepository petRepository) =>
            (_petRepository) = (petRepository);

        public async Task<IEnumerable<Pet>> GetPetsByStatusAsync(Pet.StatusEnum petStatus)
        {
            var pets = await _petRepository.GetPetsByStatusAsync(petStatus);
            var orderedPets = pets.OrderBy(p => p.Category?.Name)
                                    .ThenByDescending(p => p.Name);

            return orderedPets;
        }
    }
}
