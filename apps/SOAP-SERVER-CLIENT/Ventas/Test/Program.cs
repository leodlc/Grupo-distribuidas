using System;
using System.Collections.Generic;
using System.Linq;
using Data;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                ShowMenu();
                string table = Console.ReadLine();

                switch (table)
                {
                    case "1":
                        GestionProductos();
                        break;
                    case "2":
                        GestionCategorias();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("OPCIÓN NO VÁLIDA, POR FAVOR INTENTE DE NUEVO");
                        break;
                }
            }
        }

        static void GestionProductos()
        {
            bool exit = false;

            while (!exit)
            {
                ShowProductMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GetAllProducts();
                        break;
                    case "2":
                        GetFilteredProduct();
                        break;
                    case "3":
                        AddProduct();
                        break;
                    case "4":
                        UpdateProduct();
                        break;
                    case "5":
                        DeleteProduct();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("OPCIÓN NO VÁLIDA, POR FAVOR INTENTE DE NUEVO");
                        break;
                }
            }
        }

        static void GestionCategorias()
        {
            Console.Clear();
            bool exit = false;

            while (!exit)
            {
                ShowCategoryMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        GetAllCategories();
                        break;
                    case "2":
                        GetFilteredCategory();
                        break;
                    case "3":
                        AddCategory();
                        break;
                    case "4":
                        UpdateCategory();
                        break;
                    case "5":
                        DeleteCategory();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("OPCIÓN NO VÁLIDA, POR FAVOR INTENTE DE NUEVO");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("******************************************************** Menú **********************************************************");
            Console.WriteLine("\t\t ___________________________________________________________________________________");
            Console.WriteLine("\t\t|\t\t1. Gestionar Productos \t\t\t\t\t\t    |");
            Console.WriteLine("\t\t|\t\t2. Gestionar Categorías \t\t\t\t\t    |");
            Console.WriteLine("\t\t|\t\t3. Salir \t\t\t\t\t\t\t    |");
            Console.WriteLine("\t\t ___________________________________________________________________________________");
            Console.Write("Seleccione una opción: ");
        }

        static void ShowProductMenu()
        {
            Console.Clear();
            Console.WriteLine("************************************************** Menú de Productos ***************************************************");
            Console.WriteLine("\t\t ___________________________________________________________________________________");

            Console.WriteLine("\t\t|\t\t1. Mostrar todos los productos \t\t\t\t\t    |");
            Console.WriteLine("\t\t|\t\t2. Filtrar productos           \t\t\t\t\t    |");
            Console.WriteLine("\t\t|\t\t3. Agregar producto            \t\t\t\t\t    |");
            Console.WriteLine("\t\t|\t\t4. Actualizar producto         \t\t\t\t\t    |");
            Console.WriteLine("\t\t|\t\t5. Eliminar producto           \t\t\t\t\t    |");
            Console.WriteLine("\t\t|\t\t6. Volver al menú principal    \t\t\t\t\t    |");
            Console.WriteLine("\t\t ___________________________________________________________________________________");

            Console.Write("Seleccione una opción: ");
        }

        static void ShowCategoryMenu()
        {
            Console.WriteLine("*********************** Menú de Categorías ****************************");
            Console.WriteLine("\t\t ___________________________________________________________________________________");

            Console.WriteLine("\t\t|\t\t1. Mostrar todas las categorías \t\t\t\t    |");
            Console.WriteLine("\t\t|\t\t2. Filtrar categorías           \t\t\t\t    |");
            Console.WriteLine("\t\t|\t\t3. Agregar categoría            \t\t\t\t    |");
            Console.WriteLine("\t\t|\t\t4. Actualizar categoría         \t\t\t\t    |");
            Console.WriteLine("\t\t|\t\t5. Eliminar categoría           \t\t\t\t    |");
            Console.WriteLine("\t\t|\t\t6. Volver al menú principal     \t\t\t\t    |");
            Console.WriteLine("\t\t ___________________________________________________________________________________");
            Console.WriteLine("\t\t|\t\tSeleccione una opción:          \t\t\t\t    | ");

        }

        static void GetAllProducts()
        {
            Console.Clear ();
            using (var r = RepositoryFactory.CreateRepository())
            {
                var products = r.Filter<Producto>(p => true);
                foreach (var product in products)
                {
                    Console.WriteLine($"Id: {product.ProductoId}, Nombre: {product.ProductoNombre}, Precio: {product.PrecioUnitario}, En Stock: {product.EnStock}");
                }
            }
            Console.ReadLine();

        }

        static void GetFilteredProduct()
        {
            Console.Clear();

            Console.Write("Ingrese un criterio de filtrado para los productos: ");
            string criteria = Console.ReadLine();

            using (var r = RepositoryFactory.CreateRepository())
            {
                var products = r.Filter<Producto>(p => p.ProductoNombre.Contains(criteria));
                foreach (var product in products)
                {
                    Console.WriteLine($"Id: {product.ProductoId}, Nombre: {product.ProductoNombre}, Precio: {product.PrecioUnitario}, En Stock: {product.EnStock}");
                }
            }
            Console.ReadLine();

        }

        static void AddProduct()
        {
            Console.Clear();
            var p = new Producto();

            Console.Write("Ingrese el nombre del producto: ");
            p.ProductoNombre = Console.ReadLine();

            Console.Write("Ingrese el precio unitario del producto: ");
            p.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.Write("Ingrese la cantidad en stock del producto: ");
            p.EnStock = int.Parse(Console.ReadLine());

            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(p);
            }
            Console.WriteLine("Producto agregado con ID: {0}", p.ProductoId);
        }

        static void UpdateProduct()
        {
            Console.Clear();
            Console.Write("Ingrese el ID del producto a actualizar: ");
            int id = int.Parse(Console.ReadLine());

            using (var r = RepositoryFactory.CreateRepository())
            {
                var product = r.Retrieve<Producto>(p => p.ProductoId == id);
                if (product != null)
                {
                    Console.Write("Ingrese el nuevo nombre del producto: ");
                    product.ProductoNombre = Console.ReadLine();

                    Console.Write("Ingrese el nuevo precio del producto: ");
                    product.PrecioUnitario = decimal.Parse(Console.ReadLine());

                    Console.Write("Ingrese la nueva cantidad en stock del producto: ");
                    product.EnStock = int.Parse(Console.ReadLine());

                    r.Update(product);
                    Console.WriteLine("Producto actualizado correctamente.");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado.");
                }
            }
        }

        static void DeleteProduct()
        {
            Console.Clear();
            Console.Write("Ingrese el ID del producto a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using (var r = RepositoryFactory.CreateRepository())
            {
                var product = r.Retrieve<Producto>(p => p.ProductoId == id);
                if (product != null)
                {
                    r.Delete(product);
                    Console.WriteLine("Producto eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine("Producto no encontrado.");
                }
            }
        }

        static void GetAllCategories()
        {
            Console.Clear();
            using (var r = RepositoryFactory.CreateRepository())
            {
                var categories = r.Filter<Categoria>(c => true);
                foreach (var category in categories)
                {
                    Console.WriteLine($"Id: {category.CategoriaId}, Nombre: {category.CategoriaNombre}, Detalle: {category.Detalle}");
                }
            }
        }

        static void GetFilteredCategory()
        {
            Console.Clear();
            Console.Write("Ingrese un criterio de filtrado para las categorías: ");
            string criteria = Console.ReadLine();

            using (var r = RepositoryFactory.CreateRepository())
            {
                var categories = r.Filter<Categoria>(c => c.CategoriaNombre.Contains(criteria));
                foreach (var category in categories)
                {
                    Console.WriteLine($"Id: {category.CategoriaId}, Nombre: {category.CategoriaNombre}, Detalle: {category.Detalle}");
                }
            }
        }

        static void AddCategory()
        {
            Console.Clear();
            var c = new Categoria();

            Console.Write("Ingrese el nombre de la categoría: ");
            c.CategoriaNombre = Console.ReadLine();

            Console.Write("Ingrese el detalle de la categoría: ");
            c.Detalle = Console.ReadLine();

            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(c);
            }
            Console.WriteLine("Categoría agregada con ID: {0}", c.CategoriaId);
        }

        static void UpdateCategory()
        {
            Console.Clear();
            Console.Write("Ingrese el ID de la categoría a actualizar: ");
            int id = int.Parse(Console.ReadLine());

            using (var r = RepositoryFactory.CreateRepository())
            {
                var category = r.Retrieve<Categoria>(c => c.CategoriaId == id);
                if (category != null)
                {
                    Console.Write("Ingrese el nuevo nombre de la categoría: ");
                    category.CategoriaNombre = Console.ReadLine();

                    Console.Write("Ingrese el nuevo detalle de la categoría: ");
                    category.Detalle = Console.ReadLine();

                    r.Update(category);
                    Console.WriteLine("Categoría actualizada correctamente.");
                }
                else
                {
                    Console.WriteLine("Categoría no encontrada.");
                }
            }
        }

        static void DeleteCategory()
        {
            Console.Clear();
            Console.Write("Ingrese el ID de la categoría a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            using (var r = RepositoryFactory.CreateRepository())
            {
                var category = r.Retrieve<Categoria>(c => c.CategoriaId == id);
                if (category != null)
                {
                    r.Delete(category);
                    Console.WriteLine("Categoría eliminada correctamente.");
                }
                else
                {
                    Console.WriteLine("Categoría no encontrada.");
                }
            }
        }
    }
}
