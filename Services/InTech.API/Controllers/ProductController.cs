using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InTech.Application.Commands;
using InTech.Application.Queries;
using InTech.Application.Response;
using InTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Product>> Get()
        {
            return await _mediator.Send(new GetAllProductQuery());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Product> Get(Int64 id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }

        [HttpGet("name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Product> GetByName(string name)
        {
            return await _mediator.Send(new GetProductByNameQuery(name));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut("EditProduct/{id}")]
        public async Task<ActionResult> EditProduct(int id, [FromBody] EditProductCommand command)
        {
            try
            {
                if (command.Id == id)
                {
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }


        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteProductCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

    }
}
