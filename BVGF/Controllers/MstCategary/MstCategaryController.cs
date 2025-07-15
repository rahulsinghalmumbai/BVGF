
using BVGF.Entities;
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
                        Status = 404,
                        Message = "No categories found",
                        Data = null
                    });

                return Ok(new ResponseEntity
                {
                    Status = 200,
                    Message = "Categaries Founds",
                    Data = categories
                }


                    );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
