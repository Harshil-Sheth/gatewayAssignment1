using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using PMS.Dtos;
using PMS.Models;

namespace PMS.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            return _context.Products.Include(m => m.Category).ToList().Select(Mapper.Map<Product, ProductDto>);
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == id);

            if (product == null)
                return NotFound();

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = Mapper.Map<ProductDto, Product>(productDto);
            _context.Products.Add(product);
            _context.SaveChanges();

            productDto.Id = product.Id;
            return Created(new Uri(Request.RequestUri + "/" + product.Id), productDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productInDb = _context.Products.SingleOrDefault(c => c.Id == id);

            if (productInDb == null)
                return NotFound();

            Mapper.Map(productDto, productInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var productInDb = _context.Products.SingleOrDefault(c => c.Id == id);

            if (productInDb == null)
                return NotFound();

            _context.Products.Remove(productInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
