using Xunit.Abstractions;

namespace backend_MT.Tests.IntegrationTests.Tests;

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using backend_MT.Models;
using FluentAssertions;
using Xunit;

public class TemaControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly ITestOutputHelper _testOutputHelper;

    public TemaControllerTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    // Test: Get all assignments
    [Fact]
    public async Task GetAllAssignments_ReturnsOk_WithListOfAssignments()
    {
        var response = await _client.GetAsync("/api/tema");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var assignments = await response.Content.ReadFromJsonAsync<List<Tema>>();
        assignments.Should().NotBeNull();
        assignments.Should().HaveCountGreaterThan(0); // Assumes seed data exists
    }

    // Test: Get assignment by ID
    [Fact]
    public async Task GetAssignmentById_ExistingId_ReturnsOk_WithAssignment()
    {
        var testId = 1;
        var response = await _client.GetAsync($"/api/tema/{testId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var assignment = await response.Content.ReadFromJsonAsync<Tema>();
        assignment.Should().NotBeNull();
        assignment.temaId.Should().Be(testId);
    }

    // Test: Get assignment by ID (non-existent ID)
    [Fact]
    public async Task GetAssignmentById_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/tema/99999");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new assignment
    [Fact]
    public async Task AddAssignment_ValidInput_ReturnsCreatedAssignment()
    {
        var newAssignment = new Tema
        {
            temaId = 99,
            titlu = "New Assignment",
            descriere = "This is a new assignment.",
            fisier = "assignment.pdf",
            userId = 1 // Assuming userId 1 exists
        };

        var response = await _client.PostAsJsonAsync("/api/tema", newAssignment);
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdAssignment = await response.Content.ReadFromJsonAsync<Tema>();
        createdAssignment.Should().NotBeNull();
        createdAssignment.titlu.Should().Be(newAssignment.titlu);
        createdAssignment.descriere.Should().Be(newAssignment.descriere);
        createdAssignment.fisier.Should().Be(newAssignment.fisier);
        createdAssignment.userId.Should().Be(newAssignment.userId);
    }

    // Test: Update an existing assignment
    [Fact]
    public async Task UpdateAssignment_ValidInput_ReturnsNoContent()
    {
        var updatedAssignment = new Tema
        {
            temaId = 1,
            titlu = "Updated Assignment",
            descriere = "Updated assignment description.",
            fisier = "updated_assignment.pdf",
            userId = 2
        };

        var response = await _client.PutAsJsonAsync($"/api/tema/{updatedAssignment.temaId}", updatedAssignment);
    
        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine($"Error Response: {errorContent}");
        }

        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }


    // Test: Update assignment with mismatched ID
    [Fact]
    public async Task UpdateAssignment_MismatchedId_ReturnsBadRequest()
    {
        var updatedAssignment = new Tema
        {
            temaId = 1,
            titlu = "Mismatched Assignment",
            descriere = "Mismatched assignment description.",
            fisier = "mismatched_assignment.pdf",
            userId = 2
        };

        var response = await _client.PutAsJsonAsync("/api/tema/99999", updatedAssignment);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // Test: Delete an existing assignment
    [Fact]
    public async Task DeleteAssignment_ExistingId_ReturnsNoContent()
    {
        var testId = 1;
        var response = await _client.DeleteAsync($"/api/tema/{testId}");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var checkResponse = await _client.GetAsync($"/api/tema/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete assignment with non-existent ID
    [Fact]
    public async Task DeleteAssignment_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync("/api/tema/99999");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
