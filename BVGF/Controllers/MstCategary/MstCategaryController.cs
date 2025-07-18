
using BVGF.Entities;
using BVGFEntities.DTOs;
using BVGFEntities.Entities;
using BVGFServices.Interfaces.MstCategary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BVGF.Controllers.MstCategary
{
    [Route("api/[controller]")]
    [ApiController]
    public class MstCategaryController : ControllerBase
    {
        private readonly IMstCategary _mstCategaryService;
        public MstCategaryController(IMstCategary mstCategaryService)
        {
            _mstCategaryService = mstCategaryService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _mstCategaryService.GetAllAsync();

                if (categories == null || categories.Count == 0)
                    return NotFound(new ResponseEntity
                    {
                        Status = "404",
                        Message = "No categories found",
                        Data = null
                    });

                return Ok(new ResponseEntity
                {
                    Status = "200",
                    Message = "Categaries Founds",
                    Data = categories
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("upsert")]
        public async Task<IActionResult> CreateCategory([FromBody] MstCategoryDto dto)
        {
            try
            {
                if (dto == null || string.IsNullOrWhiteSpace(dto.CategoryName))
                    return BadRequest(new ResponseEntity { Status = "400", Message = "Bad Request", Data = null });

                var result = await _mstCategaryService.CreateAsync(dto);

                if (dto.CategoryID == 0 || dto.CategoryID == null)
                {
                    return Ok(new ResponseEntity { Status = "200", Message = "Category created successfully", Data = result });
                }
                else
                {
                    return Ok(new ResponseEntity { Status = "200", Message = "Category Updated successfully", Data = result });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpGet("CategoryID")]
        public async Task<ActionResult> GetCategoryByID(long ID)
        {
            try
            {
                var category = await _mstCategaryService.GetByID(ID);

                if (category == null)
                    return NotFound(new ResponseEntity
                    {
                        Status = "404",
                        Message = "No category found",
                        Data = null
                    });

                return Ok(new ResponseEntity
                {
                    Status = "200",
                    Message = "category Found",
                    Data = category
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }


        }

        [HttpDelete("CategoryID")]
        public async Task<ActionResult> DeleteCategoryByID(MstCategoryDto dto)
        {
            try
            {
                var category = await _mstCategaryService.DeleteByID(dto);

                if (category == null)
                    return NotFound(new ResponseEntity
                    {
                        Status = "404",
                        Message = "No category found",
                        Data = null
                    });

                return Ok(new ResponseEntity
                {
                    Status = "200",
                    Message = "category Delete",
                    Data = category
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }


        }
    }
}