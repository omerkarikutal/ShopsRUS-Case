using ShopsRUS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUS.Core.Seed
{
    public static class CreateData
    {
        public static List<UserType> CreateUserTypes()
        {
            return new List<UserType>
            {
                new UserType
                {
                    Id = 1,
                    Name = "Customer"
                },
                new UserType
                {
                    Id = 2,
                    Name = "Employee"
                },
                new UserType
                {
                    Id = 3,
                    Name = "Member"
                }
            };
        }
        public static List<User> CreateUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "Ömer",
                    Surname = "Karikutal 1",
                    UserTypeId = 1
                },
                new User
                {
                    Id = 2,
                    Name = "Ömer",
                    Surname = "Karikutal 2",
                    UserTypeId = 2
                },
                new User
                {
                    Id = 3,
                    Name = "Ömer",
                    Surname = "Karikutal 3",
                    UserTypeId = 3
                }
            };
        }
        public static List<Discount> CreateDiscounts()
        {
            return new List<Discount>
            {
                new Discount
                {
                    Id = 1,
                    UserTypeId = 1,
                    DiscountRate = 5
                },
                new Discount
                {
                    Id = 2,
                    UserTypeId = 2,
                    DiscountRate = 30
                },
                new Discount
                {
                    Id = 3,
                    UserTypeId = 3,
                    DiscountRate = 10
                }
            };
        }
        public static List<ProductType> CreateProductTypes()
        {
            return new List<ProductType>
            {
                new ProductType
                {
                    Id = 1,
                    Name = "Elektrikonik",
                },
                new ProductType
                {
                    Id = 2,
                    Name = "Market",
                },
                new ProductType
                {
                    Id = 3,
                    Name = "Diğer"
                }
            };
        }
        public static List<Product> CreateProducts()
        {
            return new List<Product>
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Test 1",
                        Price = 100,
                        ProductTypeId = 1
                    },
                     new Product
                    {
                        Id = 2,
                        Name = "Test 2",
                        Price = 200,
                        ProductTypeId = 2,
                    }, new Product
                    {
                        Id = 3,
                        Name = "Test 3",
                        Price = 300,
                        ProductTypeId = 3,
                    }, new Product
                    {
                        Id = 4,
                        Name = "Test 4",
                        Price = 400,
                        ProductTypeId = 1,
                    }, new Product
                    {
                        Id = 5,
                        Name = "Test 5",
                        Price = 500,
                        ProductTypeId = 2,
                    }, new Product
                    {
                        Id = 6,
                        Name = "Test 6",
                        Price = 600,
                        ProductTypeId = 3,
                    }, new Product
                    {
                        Id = 7,
                        Name = "Test 7",
                        Price = 700,
                        ProductTypeId = 1,
                    }, new Product
                    {
                        Id = 8,
                        Name = "Test 8",
                        Price = 800,
                        ProductTypeId = 2,
                    }, new Product
                    {
                        Id = 9,
                        Name = "Test 9",
                        Price = 900,
                        ProductTypeId = 3,
                    }
                };
        }
        public static List<Invoice> CreateInvoice()
        {
            return new List<Invoice>
            {
                new Invoice
                {
                    Id =1,
                    Amount = 100,
                    Discount = 50,
                    NetPrice = 50,
                    UserId =1,
                    IsActive = true,
                    InvoiceNumber = "111"
                }
             };
        }
    }
}
