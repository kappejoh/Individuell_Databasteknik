﻿using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class ProjectTypeRepository_Tests
{
    private DataContext GetDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .Options;

        var context = new DataContext(options);
        context.Database.EnsureCreated();

        return context;
    }
}
