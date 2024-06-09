using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AddClient();
                AddGenreL();
                AddAutor();
                AddBook();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadLine();
        }

        // CREAR DATOS

        static void AddClient()
        {
            var cl = new CLIENTE();
            //CAMBIAR DE DATOS PARA PROBAR
            cl.CEDULACLIENTE = "1724746530";
            cl.NOMBRECLIENTE = "Alvaro";
            cl.APELLIDOCLIENTE = "Sotomayor";
            cl.FECHANACCLIENTE = new DateTime(2000, 5, 14); // Asignar la fecha correctamente
            cl.TELEFONOCLIENTE = "0983803090";
            cl.DIRECCLIENTE = "Calderom";
            cl.ESTADOCLIENTE = true;

            try
            {
                Validations.VerificaIdentificacion(cl.CEDULACLIENTE);
                Validations.ValidaNombre(cl.NOMBRECLIENTE);
                Validations.ValidaApellido(cl.APELLIDOCLIENTE);
                Validations.ValidaFecha(cl.FECHANACCLIENTE.Value);
                Validations.ValidaTelefono(cl.TELEFONOCLIENTE);
                Validations.ValidaDireccion(cl.DIRECCLIENTE);

                using (var r = RepositoryFactory.CreateRepository())
                {
                    r.Create(cl);
                }

                Console.WriteLine("Id cliente {0}", cl.IDCLIENTE);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Error en la validación de los datos del cliente: {ex.Message}");
            }



        }

        static void AddGenreL()
        {
            var genl = new GENEROLITERARIO();
            genl.NOMBREGL = "Ciencia Ficción";
            genl.DESCRIPGL = "Libros con temática de ciencia ficción";
            try
            {
                Validations.VerificaInputStr(genl.NOMBREGL);
                Validations.VerificaInputStr(genl.DESCRIPGL);



                using (var r = RepositoryFactory.CreateRepository())
                {
                    r.Create(genl);
                }

                Console.WriteLine("Id del género literario {0}", genl.IDGL);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Error en la validación de los datos del gémero del libro: {ex.Message}");
            }

        }
        static void AddAutor()
        {
            var atr = new AUTOR();
            atr.NOMBREAUTOR = "Mary";
            atr.APELLIDOAUTOR = "Shelley";
            atr.NACIONALIDADAUTOR = "Inglesa";
            atr.BIOGRAFIAAUTOR = "Novelista, ensayista, dramaturga y biógrafa inglesa, Mary Shelley logró el reconocimiento mundial por una de las obras más famosas de la literatura occidental: Frankenstein o el Prometeo moderno";

            try
            {
                
                Validations.ValidaNombre(atr.NOMBREAUTOR);
                Validations.ValidaApellido(atr.NOMBREAUTOR);
                Validations.VerificaInputStr(atr.NACIONALIDADAUTOR);
                Validations.VerificaInputStr(atr.BIOGRAFIAAUTOR);
                

                using (var r = RepositoryFactory.CreateRepository())
                {
                    r.Create(atr);
                }

                Console.WriteLine("Id autor {0}", atr.IDAUTOR);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Error en la validación de los datos del autor: {ex.Message}");
            }
        }
        static void AddBook()
        {
            var lb = new LIBRO();
            lb.IDAUTOR = 1;
            lb.IDGL = 1;
            lb.NOMBRELIBRO = "Frankstein";
            lb.ANIOPUBLIBRO = new DateTime(1818, 1, 1);
            lb.IMGLIBRO = "test.jpg";
            lb.ISBNLIBRO = "1234-5678-1425-457";
            lb.ESTADOLIBRO = true;
            lb.EDITORIALLIBRO = "Española";
            lb.STOCKLIBRO = 10;

            try
            {

                Validations.ValidaNombre(lb.NOMBRELIBRO);
                Validations.ValidaFecha(lb.ANIOPUBLIBRO.Value);
                Validations.VerificaInputStr(lb.IMGLIBRO);
                Validations.VerificaInputStr(lb.EDITORIALLIBRO);



                using (var r = RepositoryFactory.CreateRepository())
                {
                    r.Create(lb);
                }

                Console.WriteLine("Id libro {0}", lb.IDLIBRO);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Error en la validación de los datos del libro: {ex.Message}");
            }



        }
    }
}
