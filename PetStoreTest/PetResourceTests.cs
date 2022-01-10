using Moq;
using PetStore.Models;
using PetStore.Repositories;
using PetStore.Resources;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PetStoreTest
{
    public class PetResourceTests
    {
        [Fact]
        public void Get_Pets_Available_Sorted_By_Category_And_Name()
        {
            var petRepo = new Mock<IPetRepository>();
            petRepo.Setup(x => x.GetPetsByStatusAsync(Pet.StatusEnum.Available))
                    .ReturnsAsync(new[] { new Pet(id: null, category: new Category { Id = 2, Name = "Dogs" }, name: "Ruby", photoUrls: new List<string>() ),
                                            new Pet(id: null, category: new Category { Id = 1, Name = "Cats" }, name: "John", photoUrls: new List<string>()),
                                            new Pet(id: null, category: new Category { Id = 2, Name = "Dogs" }, name: "Kate", photoUrls: new List<string>()),
                                            new Pet(id: null, category: new Category { Id = 1, Name = "Cats" }, name: "Paul", photoUrls: new List<string>()) } );

            IPetResource petResource = new PetResource(petRepo.Object);
            var pets = petResource.GetPetsByStatusAsync(Pet.StatusEnum.Available).Result.ToList();

            Assert.Equal("Paul", pets[0].Name);
            Assert.Equal("John", pets[1].Name);
            Assert.Equal("Ruby", pets[2].Name);
            Assert.Equal("Kate", pets[3].Name);
        }
    }
}
