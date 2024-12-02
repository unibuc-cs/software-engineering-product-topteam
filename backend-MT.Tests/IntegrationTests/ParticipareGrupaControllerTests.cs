namespace backend_MT.Tests.IntegrationTests;

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using backend_MT.Models;
using FluentAssertions;
using Xunit;

public class ParticipareGrupaControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public ParticipareGrupaControllerTests(CustomWebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    // Test: Get all participari
    [Fact]
    public async Task GetAllParticipari_ReturnsOk_WithListOfParticipari()
    {
        var response = await _client.GetAsync("/api/participaregrupa");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var participari = await response.Content.ReadFromJsonAsync<List<ParticipareGrupa>>();
        participari.Should().NotBeNull();
        participari.Should().HaveCountGreaterThan(0); // Assumes seed data exists
    }

    // Test: Get participare by ID
    [Fact]
    public async Task GetParticipareById_ExistingId_ReturnsOk_WithParticipare()
    {
        var testId = 1;
        var response = await _client.GetAsync($"/api/participaregrupa/{testId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var participare = await response.Content.ReadFromJsonAsync<ParticipareGrupa>();
        participare.Should().NotBeNull();
        participare.participareGrupaId.Should().Be(testId);
    }

    // Test: Get participare by ID (non-existent ID)
    [Fact]
    public async Task GetParticipareById_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/participaregrupa/99999");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new participare
    [Fact]
    public async Task AddParticipare_ValidInput_ReturnsCreatedParticipare()
    {
        var newParticipare = new ParticipareGrupa
        {
            participareGrupaId = 0,
            userId = 1, // Assuming UserId 1 exists in seed data
            grupaId = 1 // Assuming GrupaId 1 exists in seed data
        };

        var response = await _client.PostAsJsonAsync("/api/participaregrupa", newParticipare);
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdParticipare = await response.Content.ReadFromJsonAsync<ParticipareGrupa>();
        createdParticipare.Should().NotBeNull();
        createdParticipare.userId.Should().Be(newParticipare.userId);
        createdParticipare.grupaId.Should().Be(newParticipare.grupaId);
    }

    // Test: Update an existing participare
    [Fact]
    public async Task UpdateParticipare_ValidInput_ReturnsNoContent()
    {
        var updatedParticipare = new ParticipareGrupa
        {
            participareGrupaId = 1,
            userId = 2, // Assuming UserId 2 exists
            grupaId = 2  // Assuming GrupaId 2 exists
        };

        var response = await _client.PutAsJsonAsync($"/api/participaregrupa/{updatedParticipare.participareGrupaId}", updatedParticipare);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    // Test: Update participare with mismatched ID
    [Fact]
    public async Task UpdateParticipare_MismatchedId_ReturnsBadRequest()
    {
        var updatedParticipare = new ParticipareGrupa
        {
            participareGrupaId = 1,
            userId = 2,
            grupaId = 2
        };

        var response = await _client.PutAsJsonAsync("/api/participaregrupa/99999", updatedParticipare);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // Test: Delete an existing participare
    [Fact]
    public async Task DeleteParticipare_ExistingId_ReturnsNoContent()
    {
        var testId = 1;
        var response = await _client.DeleteAsync($"/api/participaregrupa/{testId}");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var checkResponse = await _client.GetAsync($"/api/participaregrupa/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete participare with non-existent ID
    [Fact]
    public async Task DeleteParticipare_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync("/api/participaregrupa/99999");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
