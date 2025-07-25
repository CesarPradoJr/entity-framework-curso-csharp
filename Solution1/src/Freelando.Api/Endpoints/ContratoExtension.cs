﻿using Freelando.Api.Converters;
using Freelando.Dados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Freelando.Api.Endpoints;

public static class ContratoExtension
{
    public static void AddEndPointContrato(this WebApplication app)
    {
        app.MapGet("/contratos", async ([FromServices] ContratoConverter converter, [FromServices] FreelandoContext context) =>
        {
            var contrato = converter.EntityListToResponseList(context.Contratos.ToList());
            var entries = context.ChangeTracker.Entries();
            return Results.Ok(await Task.FromResult(contrato));
        }).WithTags("Contrato").WithOpenApi();
    }
}
