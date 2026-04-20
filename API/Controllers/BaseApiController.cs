using System;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{

    protected async Task<ActionResult> CreatePageResult<TEntity, TDto>(
        IGenericRepository<TEntity> repo,
        ISpecification<TEntity> spec,
        int pageIndex,
        int pageSize,
        IMapper mapper)
        where TEntity : BaseEntity
    {
        var items = await repo.ListAsync(spec);
        var totalItems = await repo.CountAsync(spec);
        var mappedItems = mapper.Map<IReadOnlyList<TEntity>, IReadOnlyList<TDto>>(items);
        var pagination = new Pagination<TDto>(pageIndex, pageSize, totalItems, mappedItems);
        return Ok(pagination);
    }
    protected async Task<ActionResult> GetByIdResult<TEntity, TDto>(
        IGenericRepository<TEntity> repo,
        ISpecification<TEntity> spec,
        IMapper mapper)
        where TEntity : BaseEntity
    {
        var entity = await repo.GetEntityWithSpec(spec);
        if (entity == null) return NotFound();
        var mappedEntity = mapper.Map<TEntity, TDto>(entity);
        return Ok(mappedEntity);
    }




}
