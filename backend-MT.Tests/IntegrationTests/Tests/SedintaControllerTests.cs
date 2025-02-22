namespace backend_MT.Tests.IntegrationTests.Tests;

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using backend_MT.Models;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

public class SedintaControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _output;

    public SedintaControllerTests(CustomWebApplicationFactory factory, ITestOutputHelper output)
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

    // Test: Get all sessions
    [Fact]
    public async Task GetAllSessions_ReturnsOk_WithListOfSessions()
    {
        var response = await _client.GetAsync("/api/sedinta");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var sessions = await response.Content.ReadFromJsonAsync<List<Sedinta>>();
        sessions.Should().NotBeNull();
        sessions.Should().HaveCountGreaterThan(0); // Assumes seed data exists
    }

    // Test: Get session by ID
    [Fact]
    public async Task GetSessionById_ExistingId_ReturnsOk_WithSession()
    {
        var testId = 1; // Assuming this ID exists
        var response = await _client.GetAsync($"/api/sedinta/{testId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var session = await response.Content.ReadFromJsonAsync<Sedinta>();
        session.Should().NotBeNull();
        session.sedintaId.Should().Be(testId);
    }

    // Test: Get session by ID (non-existent ID)
    [Fact]
    public async Task GetSessionById_NonExistentId_ReturnsNotFound()
    {
        var nonExistentId = 99999;
        var response = await _client.GetAsync($"/api/sedinta/{nonExistentId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new session
    [Fact]
    public async Task AddSession_ValidInput_ReturnsCreatedSession()
    {
        var newSession = new Sedinta
        {
            sedintaId = 0,
            titlu = "Test Session",
            zi = DateTime.UtcNow.Date,
            oraIncepere = DateTime.UtcNow,
            oraIncheiere = DateTime.UtcNow.AddHours(2),
            grupaId = 1 // Assuming GrupaId 1 exists
        };

        var response = await _client.PostAsJsonAsync("/api/sedinta", newSession);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdSession = await response.Content.ReadFromJsonAsync<Sedinta>();
        createdSession.Should().NotBeNull();
        createdSession.titlu.Should().Be(newSession.titlu);
        createdSession.zi.Should().Be(newSession.zi);
        createdSession.grupaId.Should().Be(newSession.grupaId);
    }

    // Test: Update an existing session
    [Fact]
    public async Task UpdateSession_ValidInput_ReturnsNoContent()
    {
        var updatedSession = new Sedinta
        {
            sedintaId = 1,  // Assuming this ID exists
            titlu = "Updated Session",
            zi = DateTime.UtcNow.Date,
            oraIncepere = DateTime.UtcNow.AddHours(1),
            oraIncheiere = DateTime.UtcNow.AddHours(3),
            grupaId = 2
        };

        var response = await _client.PutAsJsonAsync($"/api/sedinta/{updatedSession.sedintaId}", updatedSession);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    // Test: Update session with mismatched ID
    [Fact]
    public async Task UpdateSession_MismatchedId_ReturnsBadRequest()
    {
        var updatedSession = new Sedinta
        {
            sedintaId = 1,
            titlu = "Mismatched Session",
            zi = DateTime.UtcNow.Date,
            oraIncepere = DateTime.UtcNow.AddHours(1),
            oraIncheiere = DateTime.UtcNow.AddHours(3),
            grupaId = 3
        };

        var response = await _client.PutAsJsonAsync("/api/sedinta/99999", updatedSession);

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // Test: Delete an existing session
    [Fact]
    public async Task DeleteSession_ExistingId_ReturnsNoContent()
    {
        var testId = 1; // Assuming this ID exists
        var response = await _client.DeleteAsync($"/api/sedinta/{testId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var checkResponse = await _client.GetAsync($"/api/sedinta/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete session with non-existent ID
    [Fact]
    public async Task DeleteSession_NonExistentId_ReturnsNotFound()
    {
        var nonExistentId = 99999;
        var response = await _client.DeleteAsync($"/api/sedinta/{nonExistentId}");

        // Log error if the response is not successful
        await LogErrorResponse(response);

        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
