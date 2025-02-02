using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NGWalks.API.Data;
using NGWalks.API.Models.Domain;
using NGWalks.API.Models.DTO;

namespace NGWalks.API.Controllers
{
    //https://localhost:7195/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NGWalksDbContext dbContext;

        public RegionsController(NGWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Get All regions
        //GET: https://localhost:7195/api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            //Get Data from database - Domain models
            var regionsDomain = dbContext.Regions.ToList();

            //Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain) 
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            
            }

            //Return DTOs
            return Ok(regionsDomain);
        }


        //Get single region (get region by id)
        //GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);   //a way to get id colume from the database.

            // another way to get a single colume in region from the database
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regionDomain == null)
            { 
                return NotFound();
            }

            //Map region domain model to region Dto
            //

            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };


            //Return DTO back to client
            return Ok(regionDto);                                                                                                                                                      
        }
    }
}
