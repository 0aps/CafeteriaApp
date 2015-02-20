namespace CafeteriaApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CafeteriaApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CafeteriaApp.Models.CafeteriaDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CafeteriaApp.Models.CafeteriaDb";
        }
        protected override void Seed(CafeteriaApp.Models.CafeteriaDb context)
        {
            context.Clients.AddOrUpdate(r => r.Nombre,
               new Client
               {
                   Nombre = "Angel Piña",
                   Identificador = "20132338",
                   Cedula = "402-0052277-5",
                   Tipo = "Estudiante",
                   Credito = 2500.50,
                   Registro = new DateTime(2012, 9, 23),
                   Estado = "Activo"
               },
               new Client
               {
                   Nombre = "Pilar Mireles",
                   Identificador = "20132006",
                   Cedula = "402-0052172-9",
                   Tipo = "Estudiante",
                   Credito = 30000.54,
                   Registro = new DateTime(2013, 10, 3),
                   Estado = "Activo"
               },
              new Client
              {
                  Nombre = "Cindy Gomez",
                  Identificador = "20131746",
                  Cedula = "402-0132182-2",
                  Tipo = "Estudiante",
                  Credito = 12345.54,
                  Registro = new DateTime(2010, 1, 12),
                  Estado = "Activo"
              },
              new Client
              {
                  Nombre = "Gabriel Rivas",
                  Identificador = "20131726",
                  Cedula = "402-1253182-4",
                  Tipo = "Estudiante",
                  Credito = 50123.56,
                  Registro = new DateTime(2012, 5, 3),
                  Estado = "Inactivo"
              },
              new Client
              {
                  Nombre = "Juan Pablo",
                  Identificador = "juanpv",
                  Cedula = "001-0668172-2",
                  Tipo = "Profesor",
                  Credito = 60123.59,
                  Registro = new DateTime(2014, 10, 16),
                  Estado = "Activo"
              },
              new Client
              {
                  Nombre = "Jose Apolinar",
                  Identificador = "jose01",
                  Cedula = "001-0056541-8",
                  Tipo = "Profesor",
                  Credito = 150.23,
                  Registro = new DateTime(2008, 9, 3),
                  Estado = "Inactivo"
              },
              new Client
              {
                  Nombre = "Luis Pujols",
                  Identificador = "luispj",
                  Cedula = "402-0987472-5",
                  Tipo = "Visitante",
                  Credito = 65489.2,
                  Registro = new DateTime(2015, 1, 15),
                  Estado = "Activo"
              }
              );
         
            context.Products.AddOrUpdate(r => r.Codigo,
               new Product
               {
                   Codigo = "2356A489",
                   Descripcion = "Botella de Agua",
                   Marca = "Dasani",
                   Costo = 19.99,
                   Proveedor = "Dasani",
                   Existencia = 100,
                   Estado = "Activo"
               },
               new Product
               {
                   Codigo = "89654754",
                   Descripcion = "Botella de Agua",
                   Marca = "Planeta Azul",
                   Costo = 9.99,
                   Proveedor = "Hielo Alaska",
                   Existencia = 50,
                   Estado = "Activo"
               },
               new Product
               {
                   Codigo = "ABC45632",
                   Descripcion = "Galletas Emperador",
                   Marca = "Galletas",
                   Costo = 24.99,
                   Proveedor = "Gamesa",
                   Existencia = 500,
                   Estado = "Activo"
               },
               new Product
               {
                   Codigo = "456238SD",
                   Descripcion = "Doritos",
                   Marca = "Fritos",
                   Costo = 14.99,
                   Proveedor = "Frito Lay",
                   Existencia = 200,
                   Estado = "Inactivo"
               },
               new Product
               {
                   Codigo = "HJ56IU78",
                   Descripcion = "Lay's de Queso",
                   Marca = "Fritos",
                   Costo = 15.99,
                   Proveedor = "Frito Lay's",
                   Existencia = 200,
                   Estado = "Activo"
               },
               new Product
               {
                   Codigo = "ERT85214",
                   Descripcion = "Cheetos",
                   Marca = "Snacks",
                   Costo = 19.99,
                   Proveedor = "Frito Lay's",
                   Existencia = 100,
                   Estado = "Activo"
               },
               new Product
               {
                   Codigo = "38957BCA",
                   Descripcion = "Coca-Cola",
                   Marca = "Gaseosa",
                   Costo = 19.99,
                   Proveedor = "Coca-Cola Company",
                   Existencia = 500,
                   Estado = "Activo"
               },
               new Product
               {
                   Codigo = "GF34WE49",
                   Descripcion = "Sprite",
                   Marca = "Gaseosa",
                   Costo = 19.99,
                   Proveedor = "Coca-Cola Company",
                   Existencia = 500,
                   Estado = "Activo"
               }
            
            );

        }
    }
}
