namespace backend_MT.Tests.IntegrationTests;

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using backend_MT.Models;
using FluentAssertions;
using Xunit;

public class PrezentaControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public PrezentaControllerTests(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    // Test: Get all prezente
    [Fact]
    public async Task GetAllPrezente_ReturnsOk_WithListOfPrezente()
    {
        var response = await _client.GetAsync("/api/prezenta");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var prezente = await response.Content.ReadFromJsonAsync<List<Prezenta>>();
        prezente.Should().NotBeNull();
        prezente.Should().HaveCountGreaterThan(0); // Assumes seed data exists
    }

    // Test: Get prezenta by ID
    [Fact]
    public async Task GetPrezentaById_ExistingId_ReturnsOk_WithPrezenta()
    {
        var testId = 1;
        var response = await _client.GetAsync($"/api/prezenta/{testId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var prezenta = await response.Content.ReadFromJsonAsync<Prezenta>();
        prezenta.Should().NotBeNull();
        prezenta.prezentaId.Should().Be(testId);
    }

    // Test: Get prezenta by ID (non-existent ID)
    [Fact]
    public async Task GetPrezentaById_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/prezenta/99999");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new prezenta
    [Fact]
    public async Task AddPrezenta_ValidInput_ReturnsCreatedPrezenta()
    {
        var newPrezenta = new Prezenta
        {
            prezentaId = 0,
            userId = 1, // Assuming UserId 1 exists in seed data
            sedintaId = 1 // Assuming SedintaId 1 exists in seed data
        };

        var response = await _client.PostAsJsonAsync("/api/prezenta", newPrezenta);
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdPrezenta = await response.Content.ReadFromJsonAsync<Prezenta>();
        createdPrezenta.Should().NotBeNull();
        createdPrezenta.userId.Should().Be(newPrezenta.userId);
        createdPrezenta.sedintaId.Should().Be(newPrezenta.sedintaId);
    }

    // Test: Update an existing prezenta
    [Fact]
    public async Task UpdatePrezenta_ValidInput_ReturnsNoContent()
    {
        var updatedPrezenta = new Prezenta
        {
            prezentaId = 1,
            userId = 2, // Assuming UserId 2 exists
            sedintaId = 2 // Assuming SedintaId 2 exists
        };

        var response = await _client.PutAsJsonAsync($"/api/prezenta/{updatedPrezenta.prezentaId}", updatedPrezenta);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    // Test: Update prezenta with mismatched ID
    [Fact]
    public async Task UpdatePrezenta_MismatchedId_ReturnsBadRequest()
    {
        var updatedPrezenta = new Prezenta
        {
            prezentaId = 1,
            userId = 3,
            sedintaId = 3
        };

        var response = await _client.PutAsJsonAsync("/api/prezenta/99999", updatedPrezenta);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // Test: Delete an existing prezenta
    [Fact]
    public async Task DeletePrezenta_ExistingId_ReturnsNoContent()
    {
        var testId = 1;
        var response = await _client.DeleteAsync($"/api/prezenta/{testId}");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var checkResponse = await _client.GetAsync($"/api/prezenta/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete prezenta with non-existent ID
    [Fact]
    public async Task DeletePrezenta_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync("/api/prezenta/99999");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
