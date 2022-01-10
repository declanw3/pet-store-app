using PetStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStore.Repositories
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> GetPetsByStatusAsync(Pet.StatusEnum petStatus);
    }
}
