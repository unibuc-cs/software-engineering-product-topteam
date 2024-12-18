namespace backend_MT.Tests.IntegrationTests.Tests;

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using backend_MT.Models;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

public class RaspunsTemaControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public RaspunsTemaControllerTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
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

    // Test: Get all responses
    [Fact]
    public async Task GetAllResponses_ReturnsOk_WithListOfResponses()
    {
        var response = await _client.GetAsync("/api/raspunsTema");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responses = await response.Content.ReadFromJsonAsync<List<RaspunsTema>>();
        responses.Should().NotBeNull();
        responses.Should().HaveCountGreaterThan(0); // Assumes seed data exists
    }

    // Test: Get response by ID
    [Fact]
    public async Task GetResponseById_ExistingId_ReturnsOk_WithResponse()
    {
        var testId = 1;
        var response = await _client.GetAsync($"/api/raspunsTema/{testId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseItem = await response.Content.ReadFromJsonAsync<RaspunsTema>();
        responseItem.Should().NotBeNull();
        responseItem.raspunsTemaId.Should().Be(testId);
    }

    // Test: Get response by ID (non-existent ID)
    [Fact]
    public async Task GetResponseById_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/raspunsTema/99999");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new response
    [Fact]
    public async Task AddResponse_ValidInput_ReturnsCreatedResponse()
    {
        var newResponse = new RaspunsTema
        {
            raspunsTemaId = 0,
            fisier = "test_file.txt",
            punctaj = 10,
            temaId = 1, // Assuming TemaId 1 exists
            userId = 1  // Assuming UserId 1 exists
        };

        var response = await _client.PostAsJsonAsync("/api/raspunsTema", newResponse);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdResponse = await response.Content.ReadFromJsonAsync<RaspunsTema>();
        createdResponse.Should().NotBeNull();
        createdResponse.fisier.Should().Be(newResponse.fisier);
        createdResponse.punctaj.Should().Be(newResponse.punctaj);
        createdResponse.temaId.Should().Be(newResponse.temaId);
        createdResponse.userId.Should().Be(newResponse.userId);
    }

    // Test: Update an existing response
    [Fact]
    public async Task UpdateResponse_ValidInput_ReturnsNoContent()
    {
        var updatedResponse = new RaspunsTema
        {
            raspunsTemaId = 1,
            fisier = "updated_file.txt",
            punctaj = 20,
            temaId = 2,
            userId = 2
        };

        var response = await _client.PutAsJsonAsync($"/api/raspunsTema/{updatedResponse.raspunsTemaId}", updatedResponse);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    // Test: Update response with mismatched ID
    [Fact]
    public async Task UpdateResponse_MismatchedId_ReturnsBadRequest()
    {
        var updatedResponse = new RaspunsTema
        {
            raspunsTemaId = 1,
            fisier = "mismatched_file.txt",
            punctaj = 30,
            temaId = 3,
            userId = 3
        };

        var response = await _client.PutAsJsonAsync("/api/raspunsTema/99999", updatedResponse);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // Test: Delete an existing response
    [Fact]
    public async Task DeleteResponse_ExistingId_ReturnsNoContent()
    {
        var testId = 1;
        var response = await _client.DeleteAsync($"/api/raspunsTema/{testId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var checkResponse = await _client.GetAsync($"/api/raspunsTema/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete response with non-existent ID
    [Fact]
    public async Task DeleteResponse_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync("/api/raspunsTema/99999");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
