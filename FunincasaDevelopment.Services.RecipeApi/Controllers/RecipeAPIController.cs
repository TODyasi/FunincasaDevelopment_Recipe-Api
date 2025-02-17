using AutoMapper;
using FunincasaDevelopment.Services.RecipeApi.Data;
using FunincasaDevelopment.Services.RecipeApi.Models;
using FunincasaDevelopment.Services.RecipeApi.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FunincasaDevelopment.Services.RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeAPIController : Controller
    {
        private readonly ApplicationDbContext _database;
        private IMapper _mapper;
        private ResponseDto _response;

        public RecipeAPIController(ApplicationDbContext database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        // HTTP GET method to retrieve a list of recipes
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                // Fetching all recipes from the database as a list
                IEnumerable<Recipe> recipeObjList = _database.Recipes.ToList();

                // Mapping the list of Recipe objects to a list of RecipeDto objects for the response
                // _mapper is assumed to be a service for mapping entities to DTOs
                _response.Result = _mapper.Map<IEnumerable<RecipeDto>>(recipeObjList);
            }
            catch (Exception ex)
            {
                // If any exception occurs during the database fetch or mapping, we handle it here
                _response.IsSuccess = false; // Indicate that the request was not successful
                _response.Message = ex.Message; // Capture and return the exception message for debugging
            }

            // Returning the response containing either the list of recipes or an error message
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Recipe recipe = _database.Recipes.First(u=>u.RecipeId== id);
                _response.Result = _mapper.Map<RecipeDto>(recipe);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


    }
}
