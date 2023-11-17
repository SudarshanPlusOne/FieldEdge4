using FieldEdge4.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
namespace FieldEdge4.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{

    private readonly ILogger<ApiController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ConnectionStringsOption _connectionStringsOption;
    public ApiController(ILogger<ApiController> logger,IHttpClientFactory clientFactory,IOptions<ConnectionStringsOption> options)
    {
        _logger = logger;
        _httpClientFactory = clientFactory;
        _connectionStringsOption = options.Value;
    }

    [HttpGet]
    [Route("customers")]
    public async Task<ActionResult<CustomerCompleteModel>> Get()
    {
        try{
        Console.WriteLine("Inside Get");
        var getCustomerData =  _httpClientFactory.CreateClient();
        var data = await getCustomerData.GetStringAsync(_connectionStringsOption.ApiUrl+Request.Path.Value);
        // Console.WriteLine("RRRRRRRRESSSSUKKKKTT"+data);
        // var objData = JsonSerializer.Deserialize<CustomerCompleteModel>(data);
        var arrayOfObjects = JsonSerializer.Deserialize<object[]>(data);

        // Print the result
        

        return new OkObjectResult(arrayOfObjects);

        }
        catch(Exception ex){
            Console.WriteLine(ex);
            return new BadRequestObjectResult(ex);
        }
    }
    [HttpGet]
    [Route("Customer/{id}")]
    public async Task<ActionResult<CustomerCompleteModel>> GetbyId(string id) //nouse
    {
        try{
        Console.WriteLine("Inside Get");
        var getCustomerData =  _httpClientFactory.CreateClient();
        Console.WriteLine(_connectionStringsOption.ApiUrl+Request.Path.Value);
        var data = await getCustomerData.GetStringAsync(_connectionStringsOption.ApiUrl+Request.Path.Value);
        Console.WriteLine("RRRRRRRRESSSSUKKKKTT"+data);
        var objData = JsonSerializer.Deserialize<CustomerCompleteModel>(data);
        // var arrayOfObjects = JsonSerializer.Deserialize<object[]>(data);

        // Print the result
        

        return new OkObjectResult(objData);

        }
        catch(Exception ex){
            Console.WriteLine(ex);
            return new BadRequestObjectResult(ex);
        }
    }

    [HttpPut]
    [Route("customer/{id}")]
    public async Task<ActionResult<CustomerCompleteModel>> UpdateCustomer(string id,[FromBody] CustomerCompleteModel model) 
    {
        try{
        Console.WriteLine("Inside Get",id,model);
        var getCustomerData =  _httpClientFactory.CreateClient();
        Console.WriteLine(_connectionStringsOption.ApiUrl+Request.Path.Value);
        HttpContent content = new StringContent(JsonSerializer.Serialize(model));
        var data = await getCustomerData.PostAsync(_connectionStringsOption.ApiUrl+Request.Path.Value,content);
        Console.WriteLine("RRRRRRRRESSSSUKKKKTT"+data);
        // var objData = JsonSerializer.Deserialize<CustomerCompleteModel>(data);
        // var arrayOfObjects = JsonSerializer.Deserialize<object[]>(data);

        // Print the result
        

        return new OkObjectResult(data);

        }
        catch(Exception ex){
            Console.WriteLine(ex);
            return new BadRequestObjectResult(ex);
        }
    }
    [HttpGet]
    [Route("CreateCustomerList")]
    public async Task<ActionResult<CustomerCompleteModel>> DeleteListAndCreateNew() //nouse
    {
        try{
        Console.WriteLine("Inside Get");
        var getCustomerData =  _httpClientFactory.CreateClient();
        var data = await getCustomerData.GetStringAsync(_connectionStringsOption.ApiUrl+Request.Path.Value);
        Console.WriteLine("RRRRRRRRESSSSUKKKKTT"+data);
        // var objData = JsonSerializer.Deserialize<CustomerCompleteModel>(data);
        // var arrayOfObjects = JsonSerializer.Deserialize<object[]>(data);

        // Print the result
        

        return new OkObjectResult(data);

        }
        catch(Exception ex){
            Console.WriteLine(ex);
            return new BadRequestObjectResult(ex);
        }
    }

    [HttpPost]
    [Route("customer")]
    public async Task<ActionResult<int>> PostToCustomer([FromBody] CustomerMandatoryModel model)
    {

   
     try{
        // Console.WriteLine("Inside Get",id,model);
        var postCustomerData =  _httpClientFactory.CreateClient();
        Console.WriteLine(_connectionStringsOption.ApiUrl+Request.Path.Value);

        HttpContent content = new StringContent(JsonSerializer.Serialize(model));
        // HttpContent content = new StringContent(model);
        var data = await postCustomerData.PostAsync(_connectionStringsOption.ApiUrl+Request.Path.Value,content);
        // Console.WriteLine("RRRRRRRRESSSSUKKKKTT"+data);
        // var objData = JsonSerializer.Deserialize<CustomerCompleteModel>(data);
        // var arrayOfObjects = JsonSerializer.Deserialize<object[]>(data);

        // Print the result
        

        return new OkObjectResult(data);

        }
        catch(Exception ex){
            Console.WriteLine(ex);
            return new BadRequestObjectResult(ex);
        }
        
    }

    [HttpDelete]
    [Route("customer/{id}")]
    public async Task<IActionResult> DeleteCustomer(string id) 
    {
        try{
        Console.WriteLine("Inside Delete",id);
        var deleteCustomerData =  _httpClientFactory.CreateClient();
        Console.WriteLine(_connectionStringsOption.ApiUrl+Request.Path.Value);
        var data = await deleteCustomerData.DeleteAsync(_connectionStringsOption.ApiUrl+Request.Path.Value);
        Console.WriteLine("RRRRRRRRESSSSUKKKKTT"+data);

        // Print the result
        

        return new OkObjectResult(data);

        }
        catch(Exception ex){
            Console.WriteLine(ex);
            return new BadRequestObjectResult(ex);
        }
    }
}
