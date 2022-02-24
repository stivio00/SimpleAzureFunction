using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Bogus;


namespace Company.Function
{
    public static class HttpTrigger2
    {

        private class Person{
            public string Name{get;set;}
            public string LastName{get;set;}
            public int Age{get;set;}
            public string Email{get;set;}
            public Person(){}
        };

        [FunctionName("HttpTrigger2")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string qty = req.Query["qty"];

            List<Person> persons = new List<Person>();
            Faker<Person> fake = new Faker<Person>()
                .RuleFor(x=>x.Name, x=>x.Person.FirstName)
                .RuleFor(x=>x.LastName, x=>x.Person.LastName)
                .RuleFor(x=>x.Age, x=>x.Random.Int(10,80))
                .RuleFor(x=>x.Email, x=>x.Person.Email);

            persons = fake.Generate(int.Parse(qty));
            return new OkObjectResult("simple");
        }
    }


}
