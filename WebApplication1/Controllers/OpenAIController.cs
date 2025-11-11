using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenAI.Chat;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Domain;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OpenAIController : ControllerBase
    {
        private readonly ChatClient _chatClient;

        public OpenAIController(IOptions<OpenAiSettings> settings)
        {
            // Initialize ChatClient with your model and API key
            _chatClient = new ChatClient("gpt-4o-mini", settings.Value.ApiKey);
        }

        [HttpPost("OptimizeCustomers")]
        public async Task<IActionResult> OptimizeCustomers([FromBody] List<Customer> customers)
        {
            if (customers == null || customers.Count == 0)
                return BadRequest("No customers provided.");

            var customerList = string.Join("\n", customers.Select(c => $"{c.customerid}: {c.Customername} - {c.email}"));

            // The prompt including system instruction and user message
            string prompt = "You are a customer data optimizer. Output only valid JSON.\n" +
                            "Sort these customers alphabetically and return as JSON:\n" +
                            customerList;

            // Call CompleteChatAsync with prompt, get response string directly
            var completionResult = await _chatClient.CompleteChatAsync(prompt);

            // completionResult is a string containing the model's reply
            return Ok(completionResult);
        }
    }

    public class OpenAiSettings
    {
        public string ApiKey { get; set; }
    }
}
