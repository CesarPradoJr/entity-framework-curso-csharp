﻿using Freelando.Dados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Freelando.Api.Endpoints;

public static class ProjetoExtension
{
    public static void AddEndPointProjeto(this WebApplication app)
    {
        app.MapGet("/projetos", async ([FromServices] ProjetoConverter converter, [FromServices] FreelandoContext context) =>
        {
            var projetos = converter.EntityListToResponseList(context.Projetos.Include(p => p.Cliente).Include(p => p.Especialidades).ToList());
            return Results.Ok(await Task.FromResult(projetos));
        }).WithTags("Projeto").WithOpenApi();
    }
}
