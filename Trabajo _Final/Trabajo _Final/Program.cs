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

            Console.WriteLine("Bienvenido al sistema de gestión del taller");
            Console.WriteLine("Seleccione un número para acceder a las siguientes gestiones:");
            Console.WriteLine("1. Gestión de vehículos");
            Console.WriteLine("2. Gestión de clientes");
            Console.WriteLine("3. Gestión de servicio de mantenimiento");
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

            int opcion;

            Console.WriteLine("Ingrese 1 para registrar un nuevo vehículo");
            Console.WriteLine("Ingrese 2 para ver la lista de vehículos registrados");
            Console.WriteLine("Ingrese 3 para editar la información de un vehículo (buscando por el número de la placa)");
            Console.WriteLine("Ingrese 4 para asignar un vehículo a un cliente");
            Console.WriteLine("Ingrese 5 para ver los vehículos de un clientes en específico");
            Console.WriteLine("Ingrese 6 para salir de la gestión de vehículos y volver al menú principal");
            Console.WriteLine();
            opcion = Convert.ToInt32(Console.ReadLine());

            while(true) 
            {      
                if (opcion==1)
                { 
                  Console.WriteLine("Ingrese la marca del vehículo:");
                  vehiculos[vehiculoContador, 0] = Console.ReadLine();
                  Console.WriteLine("Ingrese el modelo del vehículo;");
                  vehiculos[vehiculoContador, 1] = Console.ReadLine();
                  Console.WriteLine("Ingrese la placa del vehículo:");
                  vehiculos[vehiculoContador, 2] = Console.ReadLine();
                  Console.WriteLine("Ingrese el año del vehículo:");
                  vehiculos[vehiculoContador, 3] = Console.ReadLine();

                    Console.WriteLine("¿Desea registrar otro vehículo? (si/no)");
                    string respuesta = Console.ReadLine().ToLower();

                    vehiculoCliente[vehiculoContador] = -1; //Inicializar como no asignado
                    vehiculoContador++;


                    if (respuesta != "si")
                    {
                        GestionVehiculos();
                    }

                }
                else if(opcion==2)
                {
                    Console.WriteLine("Lista de vehículos registrados:");
                    Console.WriteLine();
                    for (int j=0; j< vehiculoContador; j++)
                    {
                        string asignado = vehiculoCliente[j] >= 0 ? $"(Asignado al cliente: {clientes[vehiculoCliente[j], 0]}, cédula: {clientes[vehiculoCliente[j], 1]})" : "(Sin asignar";

                        Console.WriteLine($"Vehículo {j + 1}: Marca: {vehiculos[j, 0]}, Modelo: {vehiculos[j, 1]}, Placa: {vehiculos[j, 2]}, año: {vehiculos[j, 3]}");

                        if (vehiculoContador==0)
                        {
                            Console.WriteLine("No hay vehículos registrados.");
                        }

                        Console.WriteLine("¿Desea ver otra función? (si/no)");
                        string respuesta = Console.ReadLine().ToLower();

                        if (respuesta != "no")
                        {
                            GestionVehiculos();
                        }
                    }
                }
                else if (opcion == 3)
                {
                    Console.WriteLine("Introducir la placa del vehículo que desee editar:");
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
                    Console.WriteLine("Saliendo de la gestiín de vehículos y volviendo al menú principal...");
                    Console.WriteLine();
                    Main(null);
                    break;
                }
            }
        }

        static void GestionClientes()
        {
            int opcion;

            Console.WriteLine("1. Registrar un nuevo cliente");
            Console.WriteLine("2. Ver lista de todos los clientes");
            Console.WriteLine("3. Editar información de un cliente");
            Console.WriteLine("4. Salir de gestión de clientes (volver al menu principal)");
            opcion = Convert.ToInt32(Console.ReadLine());

            while(true)
            {
                if (opcion == 1)
                {
                    if (clienteContador >= 15)
                    {
                        Console.WriteLine("Capacidad máxima de clientes alcanzada.");
                        return;
                    }

                    Console.Write("Nombre: ");
                    clientes[clienteContador, 0] = Console.ReadLine();
                    Console.Write("Cédula: ");
                    clientes[clienteContador, 1] = Console.ReadLine();
                    Console.Write("Teléfono: ");
                    clientes[clienteContador, 2] = Console.ReadLine();

                    clienteContador++;

                    Console.WriteLine("¿Desea registrar otro cliente? (si/no)");
                    string respuesta = Console.ReadLine().ToLower();

                    if (respuesta != "si")
                    {
                        GestionClientes();
                    }
                }
                else if (opcion == 2)
                {
                    Console.WriteLine("Lista de clientes:");
                    {
                        for (int j = 0; j < clienteContador; j++)
                        {
                            Console.WriteLine($"Cliente {j + 1}: Nombre: {clientes[j, 0]}, cédula:{clientes[j, 1]}, teléfono: {clientes[j, 2]}");
                            Console.WriteLine();
                            Console.WriteLine("¿Desea ver otra función? (si/no)");
                            string respuesta = Console.ReadLine().ToLower();

                            if (respuesta != "no")
                            {
                                GestionClientes();
                            }
                        }
                    }
                }
                else if (opcion == 3)
                {
                    Console.WriteLine("Introducir la cédula del cliente a editar: ");
                    string cedula = Console.ReadLine();
                }
                else if (opcion ==4)
                {
                    Console.WriteLine("Saliendo de la gestión de cliente y volviendo al menú principal...");
                    Console.WriteLine();
                    Main(null);
                    break;
                }
            }
        }

        static void GestionServiciosMantenimiento()
        {
            while(true)
            {
                Console.WriteLine("1. Registrar servicio de mantenimiento a un vehículo");
                Console.WriteLine("2. Ver historial de servicios por mantenimiento");
                Console.WriteLine("3. Ver resúmen de servicios de todos los vehículos");
                Console.WriteLine("4. Salir de gesti+on de servicios (Men+u principal)");
                Console.WriteLine();
            }

        }

        static int BuscarVehiculoPorPlaca(string placa)
        {
            for (int i = 0;  i < vehiculoContador;  i++)
            {
                if (!string.IsNullOrEmpty(vehiculos[i, 2]) && vehiculos[i, 2].Equals(placa, StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }
    }
}
