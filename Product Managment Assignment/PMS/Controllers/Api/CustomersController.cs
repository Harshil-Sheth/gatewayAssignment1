﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using PMS.Dtos;
using PMS.Models;

namespace PMS.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

            public CustomersController()
            {
                _context = new ApplicationDbContext();
            }

            //GET /api/customers
            public IHttpActionResult GetCustomers()
            {
                var customerDtos = _context.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);

                return Ok(customerDtos);
            }
            //GET /api/customer/1
            public IHttpActionResult GetCustomer(int id)
            {
                var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (customer == null)
                    return NotFound();
                return Ok(Mapper.Map<Customer, CustomerDto>(customer));
            }
            //POST /api/customers
            [System.Web.Mvc.HttpPost]
            public IHttpActionResult CreateCustomer(CustomerDto customerDto)
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
                _context.Customers.Add(customer);
                _context.SaveChanges();
                customerDto.Id = customer.Id;
                return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);

            }
            //PUT /api/customers/1
            [System.Web.Mvc.HttpPut]
            public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (customerInDb == null)
                    return NotFound();
                Mapper.Map(customerDto, customerInDb);
                _context.SaveChanges();
                return Ok();
            }
            //DELETE /api/customers/1
            [System.Web.Mvc.HttpDelete]
            public IHttpActionResult DeleteCustomer(int id)
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (customerInDb == null)
                    return NotFound();
                _context.Customers.Remove(customerInDb);
                _context.SaveChanges();
                return Ok();
            }
        }
}
