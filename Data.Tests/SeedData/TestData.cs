using Data.Entities;

namespace Data.Tests.SeedData;

public static class TestData
{

    public static readonly AddressTypeEntity[] AddressTypeEntities =
    [
        new AddressTypeEntity { Id = 1, AddressType = "Fakturadress" },
        new AddressTypeEntity { Id = 2, AddressType = "Hemadress" },
        new AddressTypeEntity { Id = 3, AddressType = "Leveransadress" },
    ];

    public static readonly CustomerAddressEntity[] CustomerAddressEntities =
    [
        new CustomerAddressEntity {
        Id = 1,
        CustomerId = 1,
        AddressTypeId = 1,
        AddressLine_1 = "Yrsavägen 3",
        AddressLine_2 = "Gävlegatan 11",
        PostalCodeId = "12345"
        }
    ];

    public static readonly CustomerEntity[] CustomerEntities =
    [
        new CustomerEntity { Id = 1, CustomerName = "Ikea" , Email = "Ikea@info.se"},
        new CustomerEntity { Id = 2, CustomerName = "Volvo", Email = "Volvo@info.se" },
        new CustomerEntity { Id = 3, CustomerName = "Saab", Email = "Saab@info.se" },
    ];


    public static readonly EmployeeEntity[] EmployeeEntities =
    [
        new EmployeeEntity { Id = 1, FirstName = "Kaspar", LastName = "Johansson", Email = "kaspar@domain.com" },
        new EmployeeEntity { Id = 2, FirstName = "Joakim", LastName = "Lindh", Email = "joakim@domain.com" },
        new EmployeeEntity { Id = 3, FirstName = "Alicja", LastName = "mazuga", Email = "alicja@domain.com" }
    ];

    public static readonly InvoiceEntity[] InvoiceEntities =
    [
        new InvoiceEntity {
        Id = 1,
        ProjectId = 1,
        CustomerId = 1,
        InvoiceDate = new DateTime(2025, 02, 28),
        DueDate = new DateTime(2025, 09, 28),
        TotalAmount = 100000,
        Paid = true,
        }
    ];

    public static readonly PostalCodeEntity[] PostalCodeEntities =
    [
        new PostalCodeEntity { Id = 1, PostalCode = "12345", City = "Gävle" },
        new PostalCodeEntity { Id = 2, PostalCode = "23456", City = "Umea" },
        new PostalCodeEntity { Id = 3,  PostalCode = "34567", City = "Varberg"}
    ];

    public static readonly ProjectEntity[] ProjectEntities =
    [
        new ProjectEntity {
        Id = 1,
        ProjectName = "Databasteknik",
        Description = "Kurs i Databaser",
        StartDate = new DateTime(2025, 02, 03),
        EndDate = new DateTime(2025, 02, 28),
        StatusNameId = 1,
        CustomerId = 1,
        ProjectManagerId = 1,
        ProjectTypeId = 1,
        ServiceId = 1
        }
    ];


    public static readonly ProjectTypeEntity[] ProjectTypeEntities =
    [
        new ProjectTypeEntity { Id = 1, TypeName = "Konsultuppdrag", Price = 100, PricingUnit = "Tim" },
        new ProjectTypeEntity { Id = 2, TypeName = "Produktutveckling", Price = 100, PricingUnit = "Tim" },
        new ProjectTypeEntity { Id = 3, TypeName = "Övrigt", Price = 100, PricingUnit = "Tim" }
    ];

    public static readonly RoleEntity[] RoleEntities =
    [
        new RoleEntity { Id = 1, RoleName = "Konsult", },
        new RoleEntity { Id = 2, RoleName = "Webbutvecklare"},
        new RoleEntity { Id = 3, RoleName = "Databastekniker" }
    ];

    public static readonly ServiceEntity[] ServiceEntities =
    [
        new ServiceEntity { Id = 1, ServiceName = "Konsultuppdrag", PricePerHour = 100 },
        new ServiceEntity { Id = 2, ServiceName = "Produktutveckling", PricePerHour = 100 },
        new ServiceEntity { Id = 3, ServiceName = "Övrigt", PricePerHour = 100 }
    ];

    public static readonly StatusEntity[] StatusEntities =
    [
        new StatusEntity { Id = 1, StatusName = "Ej påbörjad" },
        new StatusEntity { Id = 2, StatusName = "Pågår" },
        new StatusEntity { Id = 3, StatusName = "Avslutad" }
    ];

    public static readonly TaskAssignmentEntity[] TaskAssignmentEntities =
    [
        new TaskAssignmentEntity {
        Id = 1,
        ProjectId = 1,
        TaskId = 1,
        EmployeeId = 1,
        AssignedDate = new DateTime(2025, 02, 03),
        CompletedDate = new DateTime(2025, 02, 28),
        }
    ];

    public static readonly TasksEntity[] TasksEntities =
    [
        new TasksEntity { Id = 1, TaskTitle = "Göra Factories", Description = "blablabla" },
        new TasksEntity { Id = 2, TaskTitle = "Göra Models", Description = "blablabla" },
        new TasksEntity { Id = 3, TaskTitle = "Göra Services", Description = "blablabla" }
    ];

    public static readonly UserAddressEntity[] UserAddressEntities =
    [
        new UserAddressEntity {
        Id = 1,
        UserId = 1,
        AddressTypeId = 1,
        AddressLine_1 = "Sundsvallsgatan 22",
        AddressLine_2 = "Falugatan 11",
        PostalCodeId = "12345"
        }
    ];

    public static readonly UserEntity[] UserEntities =
    [
        new UserEntity {
        Id = 1,
        FirstName = "Kaspar",
        LastName = "Johansson",
        Email = "kaspar@domain.se",
        Password = "12345",
        SecurityKey = "12345",
        EmailConfirmed = true,
        Created = new DateTime(2025, 02, 03),
        Modified = new DateTime(2025, 02, 28),
        RoleId = 1
        }
    ];
}

