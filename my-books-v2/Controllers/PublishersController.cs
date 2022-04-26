using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books_v2.Data.Models;
using my_books_v2.Data.Services;
using my_books_v2.Data.ViewModels;
using my_books_v2.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublihersController : ControllerBase
    {
        private PublishersService _publishersService;
        public PublihersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }



        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNumber)
        {
            try
            {
                var _result = _publishersService.GetAllPublishers(sortBy, searchString, pageNumber);
                return Ok(_result);
            }
            catch (Exception)
            {
                return BadRequest("Sorry, we could not load Publishers.");
            }
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch(PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Puublisher name: {ex.PublisherName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            //throw new Exception("This is an exception that will be handled by middleware");

            var _response = _publishersService.GetPublisherById(id);
            
            if(_response != null)
            {
                return Ok(_response);
            }

            return NotFound();
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publishersService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            try
            {
                _publishersService.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message );
            }
        }
    }
}
