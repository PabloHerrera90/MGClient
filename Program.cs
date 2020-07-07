using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using TestMGAPI.controllers;
using TestMGAPI.models;

namespace TestMGAPI
{
    class Program
    {

        static putController AuthenticateController = new putController();
        static postController PostMessage = new postController();
        static getMessageController GetMessage = new getMessageController();
        static getMessagesController GetMessages = new getMessagesController();

        static void Main(string[] args)
        {
            while (true)
            {
                Menu();

                Int32 opcion;

                try
                {
                    opcion = Convert.ToInt32(Console.ReadLine());

                    if (opcion == 1)
                    {
                        string cClave, cSecret;

                        Console.WriteLine("Ingrese clave: ");
                        cClave = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese Secret: ");
                        cSecret = Console.ReadLine();

                        Authenticate oAuthenticate = new Authenticate();

                        oAuthenticate = AuthenticateController.putAuthenticate(cClave, cSecret);

                        Console.WriteLine(" ");
                        Console.WriteLine("Respuesta: " + oAuthenticate.code);
                        Console.WriteLine("- fin -");
                        Console.ReadLine();

                        Console.Clear();
                    }
                    else if (opcion == 2)
                    {
                        string cKey, cRoute, cMessage, cTag;

                        Console.WriteLine("Ingrese X-Key: ");
                        cKey = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese X-Route: ");
                        cRoute = Console.ReadLine();
                        Console.WriteLine("Ingrese message: ");
                        cMessage = Console.ReadLine();
                        Console.WriteLine("Ingrese tags: ");
                        cTag = Console.ReadLine();

                        Post oPost = new Post();

                        oPost = PostMessage.postMessage(cKey, cRoute, cMessage, cTag);

                        Console.WriteLine(" ");
                        Console.WriteLine("id: " + oPost._id);
                        Console.WriteLine("- fin -");
                        Console.ReadLine();

                        Console.Clear();

                    }
                    else if (opcion == 3)
                    {
                        string cKey, cRoute, cId;

                        Console.WriteLine("Ingrese X-Key: ");
                        cKey = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese X-Route: ");
                        cRoute = Console.ReadLine();
                        Console.WriteLine("Ingrese Id: ");
                        cId = Console.ReadLine();

                        getMessage oGet = new getMessage();

                        oGet = GetMessage.getMessage(cKey, cRoute, cId);

                        Console.WriteLine(" ");
                        Console.WriteLine("id: " + oGet._id);
                        Console.WriteLine("message: " + oGet.message);
                        Console.WriteLine("tag: " + oGet.tags);
                        Console.WriteLine("- fin -");
                        Console.ReadLine();

                        Console.Clear();
                    }
                    else if (opcion == 4)
                    {
                        string cKey, cRoute, cTag;

                        Console.WriteLine("Ingrese X-Key: ");
                        cKey = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese X-Route: ");
                        cRoute = Console.ReadLine();
                        Console.WriteLine("Ingrese Tag: ");
                        cTag = Console.ReadLine();

                        getMessages oGet = new getMessages();

                        oGet = GetMessages.getMessage(cKey, cRoute, cTag);


                        Console.WriteLine(" ");
                        foreach(data row in oGet.data)
                        {
                            Console.WriteLine("id: " + row._id);
                            Console.WriteLine("message: " + row.message);
                            Console.WriteLine("tag: " + row.tags);
                            Console.WriteLine(" ");
                        }

                        Console.WriteLine("- fin -");
                        Console.ReadLine();

                        Console.Clear();
                    }
                    else if (opcion == 9)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Opcion no existente.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                catch (SystemException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }                
        }

        private static void Menu()
        {
            Console.WriteLine("  Menu de opciones ");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. usar ruta PUT");
            Console.WriteLine("2. usar ruta POST");
            Console.WriteLine("3. usar ruta GET message (by Id");
            Console.WriteLine("4. usar ruta GET messages (by Tag)");
            Console.WriteLine("9. Salir");
            Console.WriteLine("");
            Console.WriteLine("Ingrese opcion a ejecutar");
        }
    }
}
