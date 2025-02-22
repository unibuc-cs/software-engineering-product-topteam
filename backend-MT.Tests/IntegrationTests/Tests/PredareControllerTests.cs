namespace backend_MT.Tests.IntegrationTests.Tests;

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using backend_MT.Models;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

public class PredareControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public PredareControllerTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
    {
        _client = factory.CreateClient();
        _output = output;
    }

    // Helper method for logging error responses
    private async Task LogErrorResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"Error Response: {errorContent}");
        }
    }

    // Test: Get all predari
    [Fact]
    public async Task GetAllPredari_ReturnsOk_WithListOfPredari()
    {
        var response = await _client.GetAsync("/api/predare");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var predari = await response.Content.ReadFromJsonAsync<List<Predare>>();
        predari.Should().NotBeNull();
        predari.Should().HaveCountGreaterThan(0); // Assumes seed data exists
    }

    // Test: Get predare by ID
    [Fact]
    public async Task GetPredareById_ExistingId_ReturnsOk_WithPredare()
    {
        var testId = 1;
        var response = await _client.GetAsync($"/api/predare/{testId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var predare = await response.Content.ReadFromJsonAsync<Predare>();
        predare.Should().NotBeNull();
        predare.predareId.Should().Be(testId);
    }

    // Test: Get predare by ID (non-existent ID)
    [Fact]
    public async Task GetPredareById_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/predare/99999");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new predare
    [Fact]
    public async Task AddPredare_ValidInput_ReturnsCreatedPredare()
    {
        var newPredare = new Predare
        {
            predareId = 0,
            userId = 1, // Assuming UserId 1 exists in seed data
            cursId = 1  // Assuming CursId 1 exists in seed data
        };

        var response = await _client.PostAsJsonAsync("/api/predare", newPredare);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdPredare = await response.Content.ReadFromJsonAsync<Predare>();
        createdPredare.Should().NotBeNull();
        createdPredare.userId.Should().Be(newPredare.userId);
        createdPredare.cursId.Should().Be(newPredare.cursId);
    }

    // Test: Update an existing predare
    [Fact]
    public async Task UpdatePredare_ValidInput_ReturnsNoContent()
    {
        var updatedPredare = new Predare
        {
            predareId = 1,
            userId = 2, // Assuming UserId 2 exists
            cursId = 2  // Assuming CursId 2 exists
        };

        var response = await _client.PutAsJsonAsync($"/api/predare/{updatedPredare.predareId}", updatedPredare);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    // Test: Update predare with mismatched ID
    [Fact]
    public async Task UpdatePredare_MismatchedId_ReturnsBadRequest()
    {
        var updatedPredare = new Predare
        {
            predareId = 1,
            userId = 2,
            cursId = 3
        };

        var response = await _client.PutAsJsonAsync("/api/predare/99999", updatedPredare);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // Test: Delete an existing predare
    [Fact]
    public async Task DeletePredare_ExistingId_ReturnsNoContent()
    {
        var testId = 1;
        var response = await _client.DeleteAsync($"/api/predare/{testId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var checkResponse = await _client.GetAsync($"/api/predare/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete predare with non-existent ID
    [Fact]
    public async Task DeletePredare_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync("/api/predare/99999");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
