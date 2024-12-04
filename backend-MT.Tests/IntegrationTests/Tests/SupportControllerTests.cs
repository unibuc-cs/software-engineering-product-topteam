namespace backend_MT.Tests.IntegrationTests.Tests;

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using backend_MT.Models;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

public class SupportControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public SupportControllerTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
    {
        _client = factory.CreateClient();
        _output = output;
    }

    // Helper method to log error responses
    private async Task LogErrorResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"Error Response: {errorContent}");
        }
    }

    // Test: Get all support messages
    [Fact]
    public async Task GetAllSupportMessages_ReturnsOk_WithListOfSupportMessages()
    {
        var response = await _client.GetAsync("/api/support");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var messages = await response.Content.ReadFromJsonAsync<List<Support>>();
        messages.Should().NotBeNull();
        messages.Should().HaveCountGreaterThan(0); // Assumes seed data exists
    }

    // Test: Get support message by ID
    [Fact]
    public async Task GetSupportMessageById_ExistingId_ReturnsOk_WithSupportMessage()
    {
        var testId = 1; // Assuming this ID exists
        var response = await _client.GetAsync($"/api/support/{testId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var message = await response.Content.ReadFromJsonAsync<Support>();
        message.Should().NotBeNull();
        message.supportId.Should().Be(testId);
    }

    // Test: Get support message by ID (non-existent ID)
    [Fact]
    public async Task GetSupportMessageById_NonExistentId_ReturnsNotFound()
    {
        var nonExistentId = 99999;
        var response = await _client.GetAsync($"/api/support/{nonExistentId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new support message
    [Fact]
    public async Task AddSupportMessage_ValidInput_ReturnsCreatedSupportMessage()
    {
        var newMessage = new Support
        {
            supportId = 0, // Will be assigned by the DB
            mesaj = "This is a test support message.",
            userId = 1 // Assuming userId 1 exists
        };

        var response = await _client.PostAsJsonAsync("/api/support", newMessage);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdMessage = await response.Content.ReadFromJsonAsync<Support>();
        createdMessage.Should().NotBeNull();
        createdMessage.mesaj.Should().Be(newMessage.mesaj);
        createdMessage.userId.Should().Be(newMessage.userId);
    }

    // Test: Update an existing support message
    [Fact]
    public async Task UpdateSupportMessage_ValidInput_ReturnsNoContent()
    {
        var updatedMessage = new Support
        {
            supportId = 1,  // Ensure this ID exists in seed data
            mesaj = "Updated support message content.",
            userId = 1
        };

        var response = await _client.PutAsJsonAsync($"/api/support/{updatedMessage.supportId}", updatedMessage);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    // Test: Update support message with mismatched ID
    [Fact]
    public async Task UpdateSupportMessage_MismatchedId_ReturnsBadRequest()
    {
        var updatedMessage = new Support
        {
            supportId = 1,
            mesaj = "Mismatched support message content.",
            userId = 1
        };

        var response = await _client.PutAsJsonAsync("/api/support/99999", updatedMessage);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // Test: Delete an existing support message
    [Fact]
    public async Task DeleteSupportMessage_ExistingId_ReturnsNoContent()
    {
        var testId = 1; // Assuming this ID exists
        var response = await _client.DeleteAsync($"/api/support/{testId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var checkResponse = await _client.GetAsync($"/api/support/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete support message with non-existent ID
    [Fact]
    public async Task DeleteSupportMessage_NonExistentId_ReturnsNotFound()
    {
        var nonExistentId = 99999;
        var response = await _client.DeleteAsync($"/api/support/{nonExistentId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
