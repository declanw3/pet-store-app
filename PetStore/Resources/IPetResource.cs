
using PetStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStore.Resources
{
    public interface IPetResource
    {
        Task<IEnumerable<Pet>> GetPetsByStatusAsync(Pet.StatusEnum petStatus);
    }
}
