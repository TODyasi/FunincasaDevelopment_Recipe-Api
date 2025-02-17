using AutoMapper;
using FunincasaDevelopment.Services.RecipeApi.Models.Dto;
using FunincasaDevelopment.Services.RecipeApi.Models;

namespace FunincasaDevelopment.Services.RecipeApi
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // Define the mappings for Recipe and RecipeDto
                config.CreateMap<Recipe, RecipeDto>();  // Mapping from Recipe to RecipeDto
                config.CreateMap<RecipeDto, Recipe>();  // Mapping from RecipeDto to Recipe
            });

            return mappingConfig;
        }
    }
}
