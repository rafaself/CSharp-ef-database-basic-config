using EFSimpleQuery.Models;
using Microsoft.EntityFrameworkCore;

using var db = new BloggingContext();

Console.WriteLine(db.DbPath);

// Inserting data
Console.WriteLine("Adicionando um novo blog");

db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Fetching data
Console.WriteLine("Buscando um blog no banco de dados");

var blog = db.Blogs.OrderBy(blog => blog.BlogId).FirstOrDefault();

//Updating data
Console.WriteLine("Atualizando um blog");

blog.Url = "https://www.google.com.br";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" }
);

db.SaveChanges();

// Delete
Console.WriteLine("Deletando um blog");
db.Remove(blog);
db.SaveChanges();

