using Microsoft.AspNetCore.Http.Features;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.Configure<FormOptions>(options =>
{
    // Set max file length to 50 MB
    options.MultipartBodyLengthLimit = 50 * 1024 * 1024;
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapPost("/api/upload-pdf", async (IFormFile file) =>
{
    if (file == null || file.Length == 0)
    {
        return Results.BadRequest("No file uploaded.");
    }

    var ext = Path.GetExtension(file.FileName) ?? string.Empty;
    if (!ext.Equals(".pdf", StringComparison.OrdinalIgnoreCase) ||
        !(file.ContentType?.Contains("pdf", StringComparison.OrdinalIgnoreCase) ?? false))
    {
        return Results.BadRequest("Only PDF files are allowed.");
    }

    using MemoryStream memoryStream = new();
    string result = PdfReader.ReadPdfFromStream(memoryStream);
    return Results.Ok(new { Message = result });
}).DisableAntiforgery();

app.Run();