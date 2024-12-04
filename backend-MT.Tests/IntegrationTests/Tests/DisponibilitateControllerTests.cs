namespace backend_MT.Tests.IntegrationTests.Tests;

using Xunit.Abstractions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using backend_MT.Models;
using FluentAssertions;
using Xunit;

public class DisponibilitateControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public DisponibilitateControllerTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
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

    // Test: Get all disponibilitati
    [Fact]
    public async Task GetAllDisponibilitati_ReturnsOk_WithListOfDisponibilitati()
    {
        var response = await _client.GetAsync("/api/disponibilitate");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var disponibilitati = await response.Content.ReadFromJsonAsync<List<Disponibilitate>>();
        disponibilitati.Should().NotBeNull();
        disponibilitati.Should().HaveCountGreaterThan(0); // Assumes seed data exists
    }

    // Test: Get disponibilitate by ID
    [Fact]
    public async Task GetDisponibilitateById_ExistingId_ReturnsOk_WithDisponibilitate()
    {
        var testId = 1;
        var response = await _client.GetAsync($"/api/disponibilitate/{testId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var disponibilitate = await response.Content.ReadFromJsonAsync<Disponibilitate>();
        disponibilitate.Should().NotBeNull();
        disponibilitate.disponibilitateId.Should().Be(testId);
    }

    // Test: Get disponibilitate by ID (non-existent ID)
    [Fact]
    public async Task GetDisponibilitateById_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/disponibilitate/99999");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new disponibilitate
    [Fact]
    public async Task AddDisponibilitate_ValidInput_ReturnsCreatedDisponibilitate()
    {
        var newDisponibilitate = new Disponibilitate
        {
            disponibilitateId = 99,
            zi = DayOfWeek.Monday,
            oraIncepere = new TimeSpan(9, 0, 0),
            userId = 1 // Assuming user with ID 1 exists
        };

        var response = await _client.PostAsJsonAsync("/api/disponibilitate", newDisponibilitate);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdDisponibilitate = await response.Content.ReadFromJsonAsync<Disponibilitate>();
        createdDisponibilitate.Should().NotBeNull();
        createdDisponibilitate.zi.Should().Be(newDisponibilitate.zi);
        createdDisponibilitate.oraIncepere.Should().Be(newDisponibilitate.oraIncepere);
        createdDisponibilitate.userId.Should().Be(newDisponibilitate.userId);
    }

    // Test: Update an existing disponibilitate
    [Fact]
    public async Task UpdateDisponibilitate_ValidInput_ReturnsNoContent()
    {
        var updatedDisponibilitate = new Disponibilitate
        {
            disponibilitateId = 1,
            zi = DayOfWeek.Tuesday,
            oraIncepere = new TimeSpan(10, 0, 0),
            userId = 1
        };

        var response = await _client.PutAsJsonAsync($"/api/disponibilitate/{updatedDisponibilitate.disponibilitateId}", updatedDisponibilitate);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    // Test: Update disponibilitate with mismatched ID
    [Fact]
    public async Task UpdateDisponibilitate_MismatchedId_ReturnsBadRequest()
    {
        var updatedDisponibilitate = new Disponibilitate
        {
            disponibilitateId = 1,
            zi = DayOfWeek.Tuesday,
            oraIncepere = new TimeSpan(10, 0, 0),
            userId = 1
        };

        var response = await _client.PutAsJsonAsync("/api/disponibilitate/99999", updatedDisponibilitate);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // Test: Delete an existing disponibilitate
    [Fact]
    public async Task DeleteDisponibilitate_ExistingId_ReturnsNoContent()
    {
        var testId = 1;
        var response = await _client.DeleteAsync($"/api/disponibilitate/{testId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var checkResponse = await _client.GetAsync($"/api/disponibilitate/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete disponibilitate with non-existent ID
    [Fact]
    public async Task DeleteDisponibilitate_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync("/api/disponibilitate/99999");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
