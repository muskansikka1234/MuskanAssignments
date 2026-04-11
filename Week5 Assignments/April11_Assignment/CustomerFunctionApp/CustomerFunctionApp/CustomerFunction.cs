using System.IO;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using CustomerFunctionApp.Data;
using CustomerFunctionApp.Models;

public class CustomerFunction
{
    private readonly AppDbContext _context;

    public CustomerFunction(AppDbContext context)
    {
        _context = context;
    }

    // CREATE
    [Function("CreateCustomer")]
    public async Task<HttpResponseData> CreateCustomer(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
    {
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var customer = JsonSerializer.Deserialize<Customer>(requestBody);

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(customer);
        return response;
    }

    // READ ALL
    [Function("GetCustomers")]
    public async Task<HttpResponseData> GetCustomers(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
    {
        var customers = await _context.Customers.ToListAsync();

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(customers);
        return response;
    }

    // READ BY ID
    [Function("GetCustomerById")]
    public async Task<HttpResponseData> GetCustomerById(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "customer/{id}")] HttpRequestData req,
        int id)
    {
        var customer = await _context.Customers.FindAsync(id);

        var response = req.CreateResponse(
            customer == null ? HttpStatusCode.NotFound : HttpStatusCode.OK);

        await response.WriteAsJsonAsync(customer);
        return response;
    }

    // UPDATE
    [Function("UpdateCustomer")]
    public async Task<HttpResponseData> UpdateCustomer(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "customer/{id}")] HttpRequestData req,
        int id)
    {
        var existing = await _context.Customers.FindAsync(id);
        if (existing == null)
        {
            return req.CreateResponse(HttpStatusCode.NotFound);
        }

        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var updated = JsonSerializer.Deserialize<Customer>(requestBody);

        existing.Name = updated.Name;
        existing.Email = updated.Email;
        existing.Phone = updated.Phone;

        await _context.SaveChangesAsync();

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(existing);
        return response;
    }

    // DELETE
    [Function("DeleteCustomer")]
    public async Task<HttpResponseData> DeleteCustomer(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "customer/{id}")] HttpRequestData req,
        int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return req.CreateResponse(HttpStatusCode.NotFound);
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return req.CreateResponse(HttpStatusCode.OK);
    }
}