namespace Trabajo__Final
{
    internal class Program
    {

        static string[,] vehiculos = new string[20, 4]; // marca, modelo, placa, año
        static int[] vehiculoCliente = new int[20]; // índice del cliente asignado o -1
        static int vehiculoContador = 0;

        static string[,] clientes = new string[15, 3]; // nombre, cédula, teléfono
        static int clienteContador = 0;

        static void Main(string[] args)
        {
            /* Requisitos técnicos: 
          El sistema debe implementarse exclusivamente con: 
          • Condicionales 
          • Ciclos (while, do while, for) 
          • Arreglos (unidimensionales y bidimensionales) 
          • Programación modular (uso de funciones/métodos) 
          �
          �
           📑 Menú Principal: 
          1. Gestión de vehículos 
          2. Gestión de clientes 
          3. Gestión de servicios de mantenimiento 
          4. Salir del programa 
          �
          �
           🚗 Gestión de Vehículos: 
          (El taller puede atender hasta 20 vehículos distintos) //acumulador
          1. Registrar un nuevo vehículo (marca, modelo, placa, año) 
          2. Ver lista de vehículos registrados 
          3. Editar información de un vehículo (buscar por número de placa) 
          4. Asignar vehículo a un cliente 
          5. Ver vehículos de un cliente específico 
          6. Salir de Gestión de vehículos (volver al Menú principal) 
          �
          �
           👤 Gestión de Clientes: 
          (El sistema puede registrar hasta 15 clientes) //acumulador
          1. Registrar un nuevo cliente (nombre, cédula, teléfono)  //cliente[,]
          2. Ver lista de todos los clientes for (i) y for(j)
          3. Editar información de un cliente 
          4. Salir de Gestión de clientes (volver al Menú principal) 
          �
          �
           🔧 Gestión de Servicios de Mantenimiento: 
          (Se pueden registrar hasta 5 servicios por vehículo) 
          1. Registrar servicio de mantenimiento a un vehículo 
          o Seleccionar vehículo 
          o Ingresar tipo de servicio (ej: cambio de aceite, alineación, etc.) 
          o Ingresar fecha y costo 
          2. Ver historial de servicios por vehículo 
          3. Ver resumen de servicios de todos los vehículos 
          4. Salir de Gestión de servicios (volver al Menú principal) 
          �
          �
           📌 Notas: 
          • Los datos se deben almacenar en arreglos unidimensionales y 
          bidimensionales, según convenga. 
          • El programa debe ser modular: cada submenú y función debe estar 
          separada en métodos bien definidos. 
          • No se permite el uso de bases de datos ni colecciones avanzadas (List,*/


            int Opcion;

            Console.WriteLine("Bienvenido al sistema de gestion del taller");
            Console.WriteLine("Seleccione un numero para acceder a las siguientes gestiones:");
            Console.WriteLine("1. Gestion de vehiculos");
            Console.WriteLine("2. Gestion de clientes");
            Console.WriteLine("3. Gestion de servicio de mantenimiento");
            Console.WriteLine("4. Salir del programa");
            Console.WriteLine();

            Opcion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(); 

            if (Opcion==1)
            {
                GestionVehiculos();
            }
            else if (Opcion==2)
            {
                GestionClientes();
            }
            else if (Opcion==3)
            {
                GestionServiciosMantenimiento();
            }
            else if (Opcion==4)
            {
                Console.WriteLine("Saliendo del programa... Gracias por usar el sistema.");
            }
        }

        static void GestionVehiculos()
        {
            int vehiculoContador = 0;
            int opcion;

            Console.WriteLine("Ingrese 1 para registrar un nuevo vehiculo");
            Console.WriteLine("Ingrese 2 para ver la lista de vehiculos registrados");
            Console.WriteLine("Ingrese 3 para editar la informacion de un vehiculo (bucando por el numero de la placa)");
            Console.WriteLine("Ingrese 4 para asignar un vehiculo a un cliente");
            Console.WriteLine("Ingrese 5 para ver los vehiculos de un clientes en especifico");
            Console.WriteLine("Ingrese 6 para salir de la gestion de vehiculos y volver al menu principal");
            Console.WriteLine();
            opcion = Convert.ToInt32(Console.ReadLine());

            for (int i =0; i<20; i++) //acumulador
            {      
                if (opcion==1)
                { 
                  Console.WriteLine("Ingrese la marca del vehiculo:");
                  vehiculos[i, 0] = Console.ReadLine();
                  Console.WriteLine("Ingrese el modelo del vehiculo;");
                  vehiculos[i, 1] = Console.ReadLine();
                  Console.WriteLine("Ingrese la placa del vehiculo:");
                  vehiculos[i, 2] = Console.ReadLine();
                  Console.WriteLine("Ingrese el año del vehiculo:");
                  vehiculos[i, 3] = Console.ReadLine();

                    Console.WriteLine("Desea registrar otro vehiculo? (si/no)");
                    string respuesta = Console.ReadLine().ToLower();

                    vehiculoCliente[i] = -1; //Inicializar como no asignado

                    if (respuesta != "si")
                    {
                        GestionVehiculos();
                    }

                }
                else if(opcion==2)
                {
                    Console.WriteLine("Lista de vehiculos registrados:");
                    Console.WriteLine();
                    for (int j=0; j<i; j++)
                    {
                        string asignado = vehiculoCliente[j] >= 0 ? $"(Asignado al cliente: {clientes[vehiculoCliente[j], 0]}, cedula: {clientes[vehiculoCliente[j], 1]})" : "(Sin asignar";
                        Console.WriteLine($"Vehiculo {j + 1}: Marca: {vehiculos[j, 0]}, Modelo: {vehiculos[j, 1]}, Placa: {vehiculos[j, 2]}, año: {vehiculos[j, 3]}");
                        if (i==0)
                        {
                            Console.WriteLine("Nohay vehiculos registrados.");
                        }
                        Console.WriteLine("Desea ver otra funcion? (si/no)");
                        string respuesta = Console.ReadLine().ToLower();

                        if (respuesta != "no")
                        {
                            GestionVehiculos();
                        }
                    }
                }
                else if (opcion == 3)
                {
                    Console.WriteLine("Inreoduce la placa del vehiculo que desee editar:");
                    string placa=Console.ReadLine().ToLower();
                }
                else if (opcion == 4)
                {
                }
                else if (opcion == 5)
                {
                }

                else if (opcion == 6)
                {
                }
            }
        }

        static void GestionClientes()
        {

        }

        static void GestionServiciosMantenimiento()
        {

        }
    }
}
