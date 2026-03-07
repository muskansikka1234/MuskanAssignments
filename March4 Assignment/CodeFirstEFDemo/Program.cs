using CodeFirstEFDemo;
using CodeFirstEFDemo.Data;
using CodeFirstEFDemo.Models;
using Microsoft.EntityFrameworkCore;

var context = new AppDbContext();

// create category
//var electronics = new Category { Name = "Electronics" };

//context.Categories.Add(electronics);
//await context.SaveChangesAsync();

//context.Products.AddRange(
//    new Product { Name = "Laptop", Price = 999.78M, category = electronics },
//    new Product { Name = "Mouse", Price = 678.78M, category = electronics }
//);

//await context.SaveChangesAsync();

//update command
//var laptop = await context.Products.FirstAsync(p => p.Name == "laptop");
//laptop.Price = 789.67M;
//await context.SaveChangesAsync();

////delete command
//context.Products.Remove(laptop);
//context.SaveChangesAsync(); 

//Querying author with courses
//var authors = await context.Authors.Include(x => x.Courses).ToListAsync();

//foreach(var author in authors)
//{
//    Console.WriteLine($"Author : {author.Name}");
//    foreach(var course in author.Courses)
//    {
//        Console.WriteLine($"--{course.Title}--{course.Description}--{course.level}");
//    }
//}

//var newProduct = new Product { Name = "smartphone", Price = 6888.56M, CategoryId = 1 };
//IProductRepository obj = new ProductRepository(context);
//await obj.AddAsync(newProduct);

//var toUpdate = await obj.GetByIdAsync(newProduct.Id);
//if(toUpdate != null)
//{
//    toUpdate.Price = 777.67M;
//    toUpdate.Name = "normal phone";
//    await obj.UpdateAsync(toUpdate);
//    Console.WriteLine($"Updated : {toUpdate.Name}--{toUpdate.Price}");
//}

IProductRepository obj2 = new ProductRepository2(context);
//var newProd = new Product { Name = "Tablet", Price = 233.45M, CategoryId = 2 };

//await obj2.AddAsync(newProd);