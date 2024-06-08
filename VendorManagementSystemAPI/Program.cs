using Microsoft.EntityFrameworkCore;
using VendorManagementSystemAPI.Data;
using VendorManagementSystemAPI.Models.DTO;
using VendorManagementSystemAPI.Models.Entities;
using VendorManagementSystemAPI.Repositories;
using VendorManagementSystemAPI.Repositories.Interfaces;
using VendorManagementSystemAPI.Services;
using VendorManagementSystemAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string connectionString = builder.Configuration.GetConnectionString("VendorManagementSystemConnection") ?? throw new InvalidOperationException("Connection string 'VendorManagementSystemConnection' not found.");

builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped<IVendorRepository<Vendor>, VendorRepository>();
builder.Services.AddScoped<IVendorService<VendorDto>, VendorService>();
builder.Services.AddScoped<IPurchaseRepository<PurchaseOrder>, PurchaseRepository>();
builder.Services.AddScoped<IPurchaseService<PurchaseDto>, PurchaseService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
