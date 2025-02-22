﻿using DrinkWholeSale.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrinkWholeSale.WebApi.Tests
{
    public class TestDbInitializer
    {
        public static Packaging getPacking(int quant)
        {
            if (quant >= 6 && quant < 12)
                return Packaging.SHRINK_FILM;
            if (quant >= 12 && quant < 24)
                return Packaging.SALVER;
            if (quant >= 24)
                return Packaging.TRAY;

            return Packaging.PIECE;
        }

        public static void Initialize(DrinkWholeSaleDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.MainCats.Any()) return;

       

            IList<MainCat> defaultLists = new List<MainCat>()
            {
                new MainCat
                {
                    Id = 1,
                    Name = "Alcoholic drinks",
                    SubCats = new List<SubCat>
                    {
                        new SubCat
                        {
                            Id = 1,
                            Name = "Vodka",
                            Products = new List<Product>
                            {
                                new Product
                                {
                                    Name = "Royal Vodka",
                                    Producer = "Pias Kft",
                                    TypeNumber = 1,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "This will take you to the floor",
                                    Quantity = 5,
                                    Pack = getPacking(5),
                                },
                                 new Product
                                {
                                    Name = "Absolut Vodka",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 2,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Very good product",
                                    Quantity = 90,
                                    Pack = getPacking(90)
                                },
                            }
                        },
                        new SubCat
                        {
                            Id = 2,
                            Name = "Whisky",
                            Products = new List<Product>
                            {
                                new Product
                                {
                                    Name = "Jim Whisky",
                                    Producer = "Pias Kft",
                                    TypeNumber = 3,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "Smooth taste",
                                    Quantity = 2000,
                                    Pack = getPacking(2000)
                                },
                                 new Product
                                {
                                    Name = "Whisky Jack",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 4,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Smooth taste",
                                    Quantity = 13,
                                    Pack = getPacking(13)
                                },
                                  new Product
                                {
                                    Name = "Jim Whisky",
                                    Producer = "Pias Kft",
                                    TypeNumber = 3,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "Smooth taste",
                                    Quantity = 2000,
                                    Pack = getPacking(2000)
                                },
                                 new Product
                                {
                                    Name = "Whisky Jack",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 4,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Smooth taste",
                                    Quantity = 13,
                                    Pack = getPacking(13)
                                },
                                  new Product
                                {
                                    Name = "Jim Whisky",
                                    Producer = "Pias Kft",
                                    TypeNumber = 3,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "Smooth taste",
                                    Quantity = 2000,
                                    Pack = getPacking(2000)
                                },
                                 new Product
                                {
                                    Name = "Whisky Jack",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 4,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Smooth taste",
                                    Quantity = 13,
                                    Pack = getPacking(13)
                                },
                                  new Product
                                {
                                    Name = "Jim Whisky",
                                    Producer = "Pias Kft",
                                    TypeNumber = 3,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "Smooth taste",
                                    Quantity = 2000,
                                    Pack = getPacking(2000)
                                },
                                 new Product
                                {
                                    Name = "Whisky Jack",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 4,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Smooth taste",
                                    Quantity = 13,
                                    Pack = getPacking(13)
                                },
                                  new Product
                                {
                                    Name = "Jim Whisky",
                                    Producer = "Pias Kft",
                                    TypeNumber = 3,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "very Smooth taste",
                                    Quantity = 2000,
                                    Pack = getPacking(2000)
                                },
                                 new Product
                                {
                                    Name = "Whisky Jack",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 4,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Smooth taste",
                                    Quantity = 13,
                                    Pack = getPacking(13)
                                },
                                  new Product
                                {
                                    Name = "Jim Whisky",
                                    Producer = "Pias Kft",
                                    TypeNumber = 3,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "Smooth taste",
                                    Quantity = 2000,
                                    Pack = getPacking(2000)
                                },
                                 new Product
                                {
                                    Name = "Whisky Jack",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 4,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Smooth taste",
                                    Quantity = 13,
                                    Pack = getPacking(13)
                                },
                                  new Product
                                {
                                    Name = "Jim Whisky",
                                    Producer = "Pias Kft",
                                    TypeNumber = 3,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "Smooth tastem",
                                    Quantity = 2000,
                                    Pack = getPacking(2000)
                                },
                                 new Product
                                {
                                    Name = "Whisky Jack",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 4,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Smooth taste",
                                    Quantity = 13,
                                    Pack = getPacking(13)
                                },
                                  new Product
                                {
                                    Name = "Jim Whisky",
                                    Producer = "Pias Kft",
                                    TypeNumber = 3,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "Smooth taste",
                                    Quantity = 2000,
                                    Pack = getPacking(2000)
                                },
                                 new Product
                                {
                                    Name = "Whisky Jack",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 4,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Smooth taste",
                                    Quantity = 13,
                                    Pack = getPacking(13)
                                },
                                  new Product
                                {
                                    Name = "Jim Whisky",
                                    Producer = "Pias Kft",
                                    TypeNumber = 3,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "Smooth taste",
                                    Quantity = 2000,
                                    Pack = getPacking(2000)
                                },
                                 new Product
                                {
                                    Name = "Whisky Jack",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 4,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Smooth taste",
                                    Quantity = 13,
                                    Pack = getPacking(13)
                                },
                                  new Product
                                {
                                    Name = "Jim Whisky",
                                    Producer = "Pias Kft",
                                    TypeNumber = 3,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "Smooth taste",
                                    Quantity = 2000,
                                    Pack = getPacking(2000)
                                },
                                 new Product
                                {
                                    Name = "Whisky Jack",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 4,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Smooth taste",
                                    Quantity = 13,
                                    Pack = getPacking(13)
                                },
                                  new Product
                                {
                                    Name = "Jim Whisky",
                                    Producer = "Pias Kft",
                                    TypeNumber = 3,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "Smooth taste",
                                    Quantity = 2000,
                                    Pack = getPacking(2000)
                                },
                                 new Product
                                {
                                    Name = "Whisky Jack",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 4,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Smooth taste",
                                    Quantity = 13,
                                    Pack = getPacking(13)
                                },
                                  new Product
                                {
                                    Name = "Jim Whisky",
                                    Producer = "Pias Kft",
                                    TypeNumber = 3,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "Smooth taste",
                                    Quantity = 2000,
                                    Pack = getPacking(2000)
                                },
                                 new Product
                                {
                                    Name = "Whisky Jack",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 4,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Adom adom",
                                    Quantity = 13,
                                    Pack = getPacking(13)
                                },
                                  new Product
                                {
                                    Name = "Jim Whisky",
                                    Producer = "Pias Kft",
                                    TypeNumber = 3,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "Smooth taste",
                                    Quantity = 2000,
                                    Pack = getPacking(2000)
                                },
                                 new Product
                                {
                                    Name = "Whisky Jack",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 4,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Smooth taste",
                                    Quantity = 13,
                                    Pack = getPacking(13)
                                },
                                  new Product
                                {
                                    Name = "Jim Whisky",
                                    Producer = "Pias Kft",
                                    TypeNumber = 3,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "Smooth taste",
                                    Quantity = 2000,
                                    Pack = getPacking(2000)
                                },
                             
                                 new Product
                                {
                                    Name = "Whisky Jack",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 4,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Adom adom",
                                    Quantity = 13,
                                    Pack = getPacking(13)
                                },
                            }
                        }

                    }
                },
                new MainCat
                {
                    Id = 2,
                    Name = "Alcohol free drinks"
,
                    SubCats = new List<SubCat>
                    {
                        new SubCat
                        {
                            Id = 3,
                            Name = "Viz",
                            Products = new List<Product>
                            {
                                new Product
                                {
                                    Name = "Sparkling water",
                                    Producer = "Pias Kft",
                                    TypeNumber = 5,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "ocean taste",
                                    Quantity = 6,
                                    Pack = getPacking(6)
                                },
                                 new Product
                                {
                                    Name = "Non-carbonated water",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 6,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "better",
                                    Quantity = 99999,
                                    Pack = getPacking(99999)
                                },
                            }
                        },
                        new SubCat
                        {
                            Id = 4,
                            Name = "Orange Juice",
                            Products = new List<Product>
                            {
                                new Product
                                {
                                    Name = "Very good orange2.0",
                                    Producer = "Pias Kft",
                                    TypeNumber = 7,
                                    NetPrice = 1000,
                                    GrossPrice = 1270,
                                    Description = "Juice Juice Juice",
                                    Quantity = 1456,
                                    Pack = getPacking(1456)
                                },
                                 new Product
                                {
                                    Name = "Very good orange",
                                    Producer = "Nagy Pias Kft",
                                    TypeNumber = 8,
                                    NetPrice = 1500,
                                    GrossPrice = 1905,
                                    Description = "Adom adom",
                                    Quantity = 5012,
                                    Pack = getPacking(5012)
                                },
                            }
                        }

                    }

                }
            };

            context.AddRange(defaultLists);

            context.SaveChanges();
        }
    }
}