namespace backend_MT.Tests.IntegrationTests;

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using backend_MT.Models;
using FluentAssertions;
using Xunit;

public class MaterialControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public MaterialControllerTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    // Test: Get all materials
    [Fact]
    public async Task GetAllMaterials_ReturnsOk_WithListOfMaterials()
    {
        var response = await _client.GetAsync("/api/material");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var materials = await response.Content.ReadFromJsonAsync<List<Material>>();
        materials.Should().NotBeNull();
        materials.Should().HaveCountGreaterThan(0); // Assumes seed data exists
    }

    // Test: Get material by ID
    [Fact]
    public async Task GetMaterialById_ExistingId_ReturnsOk_WithMaterial()
    {
        var testId = 1;
        var response = await _client.GetAsync($"/api/material/{testId}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var material = await response.Content.ReadFromJsonAsync<Material>();
        material.Should().NotBeNull();
        material.materialId.Should().Be(testId);
    }

    // Test: Get material by ID (non-existent ID)
    [Fact]
    public async Task GetMaterialById_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.GetAsync("/api/material/99999");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Add a new material
    [Fact]
    public async Task AddMaterial_ValidInput_ReturnsCreatedMaterial()
    {
        var newMaterial = new Material
        {
            materialId = 99,
            titlu = "Test Material",
            descriere = "This is a test material.",
            userId = 1 // Assuming user with ID 1 exists
        };

        var response = await _client.PostAsJsonAsync("/api/material", newMaterial);
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var createdMaterial = await response.Content.ReadFromJsonAsync<Material>();
        createdMaterial.Should().NotBeNull();
        createdMaterial.titlu.Should().Be(newMaterial.titlu);
        createdMaterial.descriere.Should().Be(newMaterial.descriere);
        createdMaterial.userId.Should().Be(newMaterial.userId);
    }

    // Test: Update an existing material
    [Fact]
    public async Task UpdateMaterial_ValidInput_ReturnsNoContent()
    {
        var updatedMaterial = new Material
        {
            materialId = 1,
            titlu = "Updated Material",
            descriere = "Updated description.",
            userId = 1
        };

        var response = await _client.PutAsJsonAsync($"/api/material/{updatedMaterial.materialId}", updatedMaterial);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    // Test: Update material with mismatched ID
    [Fact]
    public async Task UpdateMaterial_MismatchedId_ReturnsBadRequest()
    {
        var updatedMaterial = new Material
        {
            materialId = 1,
            titlu = "Mismatched Material",
            descriere = "Mismatched description.",
            userId = 1
        };

        var response = await _client.PutAsJsonAsync("/api/material/99999", updatedMaterial);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    // Test: Delete an existing material
    [Fact]
    public async Task DeleteMaterial_ExistingId_ReturnsNoContent()
    {
        var testId = 1;
        var response = await _client.DeleteAsync($"/api/material/{testId}");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var checkResponse = await _client.GetAsync($"/api/material/{testId}");
        checkResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    // Test: Delete material with non-existent ID
    [Fact]
    public async Task DeleteMaterial_NonExistentId_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync("/api/material/99999");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
