using PetStore.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PetStore.Repositories
{
    class PetRepository : IPetRepository
    {
        public async Task<IEnumerable<Pet>> GetPetsByStatusAsync(Pet.StatusEnum petStatus)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://petstore.swagger.io/v2/pet/findByStatus?status={petStatus.ToString().ToLower()}");
                var pets = await response.Content.ReadAsAsync<IEnumerable<Pet>>();

                return pets;
            }
        }
    }
}
