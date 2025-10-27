namespace Trabajo__Final
{
    internal class Program
    {
        static string[,] vehiculos = new string[20, 4]; // marca, modelo, placa, año
        static int[] vehiculoCliente = new int[20]; // índice del cliente asignado o -1
        static int vehiculoContador = 0;

        static string[,] clientes = new string[15, 3]; // nombre, cédula, teléfono
        static int clienteContador = 0;

        static string[,] serviciosTipo = new string[20, 5];
        static string[,] serviciosFecha = new string[20, 5];
        static double[,] serviciosCosto = new double[20, 5];
        static int[] serviciosContador = new int[20];

        static void Main(string[] args)
        {
            for (int i = 0; i < vehiculoCliente.Length; i++) vehiculoCliente[i] = -1; //el clientes no esta asignado a un vehiculo

          while (true)
          { 
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

            if (Opcion == 1)
            {
                GestionVehiculos();
            }
            else if (Opcion == 2)
            {
                GestionClientes();
            }
            else if (Opcion == 3)
            {
                GestionServiciosMantenimiento();
            }
            else if (Opcion == 4)
            {
                Console.WriteLine("Saliendo del programa... Gracias por usar el sistema.");
                break;
            }
          }
        }

        static void GestionVehiculos()
        {

            int opcion;

            Console.WriteLine("1. para registrar un nuevo vehiculo");
            Console.WriteLine("2. para ver la lista de vehiculos registrados");
            Console.WriteLine("3. para editar la informacion de un vehiculo (bucando por el numero de la placa)");
            Console.WriteLine("4. para asignar un vehiculo a un cliente");
            Console.WriteLine("5. para ver los vehiculos de un clientes en especifico");
            Console.WriteLine("6. para salir de la gestion de vehiculos y volver al menu principal");
            Console.WriteLine();
            opcion = Convert.ToInt32(Console.ReadLine());

            while(true) 
            {      
                if (opcion==1)
                { 
                  Console.WriteLine("Ingrese la marca del vehiculo:");
                  vehiculos[vehiculoContador, 0] = Console.ReadLine();
                  Console.WriteLine("Ingrese el modelo del vehiculo;");
                  vehiculos[vehiculoContador, 1] = Console.ReadLine();
                  Console.WriteLine("Ingrese la placa del vehiculo:");
                  vehiculos[vehiculoContador, 2] = Console.ReadLine();
                  Console.WriteLine("Ingrese el año del vehiculo:");
                  vehiculos[vehiculoContador, 3] = Console.ReadLine();

                    vehiculoCliente[vehiculoContador] = -1; //Inicializar como no asignado
                    vehiculoContador++;

                    Console.WriteLine("Desea registrar otro vehiculo? (si/no)");
                    string respuesta = Console.ReadLine().ToLower();

                    if (respuesta != "si")
                    {
                        GestionVehiculos();
                    }

                }
                else if(opcion==2)
                {
                    Console.WriteLine("Lista de vehiculos registrados:");
                    Console.WriteLine();
                    for (int j=0; j< vehiculoContador; j++)
                    {
                        string asignado = vehiculoCliente[j] >= 0 ? $"(Asignado al cliente: {clientes[vehiculoCliente[j], 0]}, cedula: {clientes[vehiculoCliente[j], 1]})" : "(Sin asignar";

                        Console.WriteLine($"Vehiculo {j + 1}: Marca: {vehiculos[j, 0]}, Modelo: {vehiculos[j, 1]}, Placa: {vehiculos[j, 2]}, año: {vehiculos[j, 3]}");

                        if (vehiculoContador==0)
                        {
                            Console.WriteLine("No hay vehiculos registrados.");
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
                    int indice = BuscarVehiculoPorPlaca(placa);

                    if (indice == -1)
                    {
                        Console.WriteLine("Vehiculo no encontrado.");
                    }
                    else
                    {
                        Console.WriteLine("Ingrese la nueva informacion del vehivulo: ");
                        Console.Write($"Marca: ({vehiculos[indice, 0]}): ");
                        string nuevaMarca = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nuevaMarca)) vehiculos[indice, 0] = nuevaMarca;

                        Console.Write($"Modelo: ({vehiculos[indice,1]}): ");
                        string nuevoModelo = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nuevoModelo)) vehiculos[indice, 1] = nuevoModelo;

                        Console.Write($"Placa: ({vehiculos[indice, 2]}): ");
                        string nuevaPlaca = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nuevaPlaca)) vehiculos[indice, 2] = nuevaPlaca;

                        Console.Write($"año: ({vehiculos[indice, 3]}): ");
                        string nuevoAño = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nuevoAño)) vehiculos[indice, 3] = nuevoAño;

                        Console.WriteLine("Vehiculo actualizado.");
                        Console.WriteLine();
                        Console.WriteLine("Desea ver otra funcion? (si/no)");
                        Console.WriteLine();
                        string respuesta = Console.ReadLine().ToLower();

                        if (respuesta != "no")
                        {
                            GestionVehiculos();
                        }
                    }
                }
                else if (opcion == 4)
                {
                    Console.Write("Placa del vehiculo a asignar: ");
                    string placa = Console.ReadLine();
                    int indiceVehiculo = BuscarVehiculoPorPlaca(placa);

                    if (indiceVehiculo == -1)
                    {
                        Console.WriteLine("Vehiculo no encontrado.");
                        Console.WriteLine();
                        GestionVehiculos();
                    }

                    Console.Write("Cedula del cliente al que desea asignar el vehiculo: ");
                    string cedula = Console.ReadLine();
                    int indiceCliente = BuscarClientePorCedula(cedula);

                    if (indiceCliente == -1)
                    {
                        Console.WriteLine("El cliente no fue encontrado.");
                        Console.WriteLine();
                        GestionClientes();
                    }

                    vehiculoCliente[indiceVehiculo] = indiceCliente;
                    Console.WriteLine($"Vehiculo: {vehiculos[indiceVehiculo, 2]}, asignado a: {clientes[indiceCliente, 0]}.");
                    Console.WriteLine();
                    Console.WriteLine("Desea asignar otro vehiculo? (si/no)");
                    Console.WriteLine();
                    string respuesta = Console.ReadLine().ToLower();

                    if (respuesta != "si")
                    {
                        GestionVehiculos();
                    }
                }
                else if (opcion == 5)
                {
                    Console.Write("Cedula del cliente: ");
                    string cedula = Console.ReadLine();
                    int indiceCliente = BuscarClientePorCedula(cedula);
                    if (indiceCliente == -1)
                    {
                        Console.WriteLine("Cliente no encontrado.");
                        Console.WriteLine();
                        GestionVehiculos();
                    }
                    Console.WriteLine($"El vehiculo (s) asignado(s) a {clientes[indiceCliente, opcion]}:");
                    bool encontrado = false;
                    for (int k = 0; k < vehiculoContador; k++)
                    {
                        if (vehiculoCliente[k] == indiceCliente)
                        {
                            Console.WriteLine($"Placa: {vehiculos[k, 2]}, Marca: {vehiculos[k,0]}, Modelo: {vehiculos[k, 1]}, Año: {vehiculos[k, 3]} ");
                            encontrado = true;
                        }
                    }
                    if (!encontrado)
                    {
                        Console.WriteLine("No hay vehiculo asignado a este cliente.");
                    }
                }

                else if (opcion == 6)
                {
                    Console.WriteLine("Saliendo de la gestion de vehiculos y volviendo al menu principal...");
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
            Console.WriteLine("3. Editar informacion de un cliente");
            Console.WriteLine("4. Salir de gestion de clientes (volver al menu principal)");
            Console.WriteLine();
            opcion = Convert.ToInt32(Console.ReadLine());

            while(true)
            {
                if (opcion == 1)
                {
                    if (clienteContador >= 15)
                    {
                        Console.WriteLine("capacidad maxima de clientes alcanzada.");
                        return;
                    }

                    Console.Write("Nombre: ");
                    clientes[clienteContador, 0] = Console.ReadLine();
                    Console.Write("Cedula: ");
                    clientes[clienteContador, 1] = Console.ReadLine();
                    Console.Write("Telefono: ");
                    clientes[clienteContador, 2] = Console.ReadLine();

                    clienteContador++;

                    Console.WriteLine("Dese registrar otro cliente? (si/no)");
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
                            Console.WriteLine($"Cliente {j + 1}: Nombre: {clientes[j, 0]}, cedula:{clientes[j, 1]}, telefono: {clientes[j, 2]}");
                            Console.WriteLine();
                            Console.WriteLine("Desea ver otra funcion? (si/no)");
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
                    Console.WriteLine("Introduce la cedula del cliente a editar: ");
                    string cedula = Console.ReadLine();
                    int indice = BuscarClientePorCedula(cedula);

                    if (indice == -1)
                    {
                     Console.WriteLine("Cliente no encontrado.");
                        GestionClientes();
                    }

                    else
                    {

                     Console.WriteLine("Ingrese la nueva informacion del cliente: ");
                     Console.Write($"Nombre: ({clientes[indice, 0]}): ");
                     string nuevoNombre = Console.ReadLine();
                     if (!string.IsNullOrEmpty(nuevoNombre)) clientes[indice, 0] = nuevoNombre;

                     Console.Write($"Cedula: ({clientes[indice, 1]}): ");
                     string nuevaCedula = Console.ReadLine();
                     if (!string.IsNullOrEmpty(nuevaCedula)) clientes[indice, 1] = nuevaCedula;

                        Console.Write($"Telefono: ({clientes[indice, 2]}): ");
                        string nuevoTelefono = Console.ReadLine();
                        if (!string.IsNullOrEmpty(nuevoTelefono)) clientes[indice, 2] = nuevoTelefono;

                        Console.WriteLine("Cliente actualizado.");
                        Console.WriteLine();
                        Console.WriteLine("Desea ver otra funcion? (si/no)");
                        Console.WriteLine();
                        string respuesta = Console.ReadLine().ToLower();

                        if (respuesta != "no")
                        {
                            GestionClientes();
                        }
                    }
                }
                else if (opcion ==4)
                {
                    Console.WriteLine("Saliendo de la gestion de cliente y volviendo al menu principal...");
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
                Console.WriteLine("1. Registrar servicio de mantenimiento a un vehiculo");
                Console.WriteLine("2. Ver historial de servicios por mantenimiento");
                Console.WriteLine("3. Ver resumen de servicios de todos los vehiculos");
                Console.WriteLine("4. Salir de gestion de servicios (Menu principal)");
                Console.WriteLine();
                int opcion = Convert.ToInt32(Console.ReadLine());

                if (opcion == 1)
                {
                    RegistrarServicios();
                }
                else if (opcion == 2)
                {
                    VerHistorialPorVehiculo();
                }
                else if (opcion ==3)
                {
                    verResumenServicios();
                }
                else if (opcion ==4)
                {
                    Console.WriteLine("Saliendo de la gestion de servicios y volviendo al menu principal...");
                    Console.WriteLine();
                    Main(null);
                    break;
                }
            }

        }

        static void RegistrarServicios()
        {
            while (true)
            {
                Console.WriteLine("Ingrese la placa del vehiculo: ");
                string placa = Console.ReadLine().ToLower();
                int indiceVehiculo = BuscarVehiculoPorPlaca(placa);

                if (indiceVehiculo == -1)
                {
                    Console.WriteLine("vehiculo no encontrado. ");
                    Console.WriteLine();
                    GestionServiciosMantenimiento();
                }

                if (serviciosContador[indiceVehiculo] >= 5)
                {
                    Console.WriteLine("Capacidad maxima de servicios alcanzada para este vehiculo.");
                    Console.WriteLine();
                    GestionServiciosMantenimiento();
                }

                Console.WriteLine("¿Que tipo de servicio desea registrar? ");
                string tipoServicio = Console.ReadLine().ToLower();

                Console.WriteLine("Ingrese la fecha del servicio (dd/mm/aaaa): ");
                string fechaServicio = Console.ReadLine();

                Console.WriteLine("Costo del servicio: ");
                double costoInput = Convert.ToDouble(Console.ReadLine());

                int servicioIndice = serviciosContador[indiceVehiculo];
                serviciosTipo[indiceVehiculo, servicioIndice] = tipoServicio;
                serviciosFecha[indiceVehiculo, servicioIndice] = fechaServicio;
                serviciosCosto[indiceVehiculo, servicioIndice] = costoInput;
                serviciosContador[indiceVehiculo]++;

                Console.WriteLine("servicio registrado");
                Console.WriteLine();
                Console.WriteLine("Desea registrar otro servicio? (si/no)");
                string respuesta = Console.ReadLine().ToLower();

                if (respuesta != "si")
                {
                    GestionServiciosMantenimiento();
                }
            }
        }

        static void VerHistorialPorVehiculo()
        {
            Console.WriteLine("Ingrese la placa del vehiculo: ");
            string placa = Console.ReadLine().ToLower();
            int indiceVehiculo = BuscarVehiculoPorPlaca(placa);

            if (indiceVehiculo == -1)
            {
                Console.WriteLine("Vehiculo no encontrado");
                Console.WriteLine();
                GestionServiciosMantenimiento();
            }

            int contador = serviciosContador[indiceVehiculo];

            if (contador == 0)
            {
                Console.WriteLine("No hay servicios registrados para este vehiculo. ");
                Console.WriteLine();
                GestionServiciosMantenimiento();
            }

            Console.WriteLine($"Historial de servicios pa vehiculo: {vehiculos[indiceVehiculo, 2]}, Modelo: {vehiculos[indiceVehiculo,1]}");

            for (int i=0; i<contador; i++)
            {
                Console.WriteLine($"servicio {i,1}: tipo: {serviciosTipo[indiceVehiculo, i]}, fecha: {serviciosFecha[indiceVehiculo,i]}, costo: {serviciosCosto[indiceVehiculo,i]}");
                Console.WriteLine();
                Console.WriteLine("Desea ver otra funcion? (si/no)");
                string respuesta = Console.ReadLine().ToLower();

                if (respuesta != "si")
                {
                    GestionServiciosMantenimiento();
                }
            }
        }

        static void verResumenServicios()
        {
            bool hayServicios = false;

            for (int i=0; i<=vehiculoContador; i++)
            {
                int contador = serviciosContador[i];

                if (contador > 0)
                {
                    hayServicios = true;

                    double total = 0;

                    Console.WriteLine($"Vehiculos:placa {vehiculos[i,2]}, Marca: {vehiculos[i,0]}, Modelo: {vehiculos[i,1]}");

                    for (int j=0; j<contador; j++)
                    {
                        double costo = serviciosCosto[i, j];
                        Console.WriteLine($"Servicio {j+1}: {serviciosTipo[i,j]} | fecha {serviciosFecha[i,j]} | costo: {serviciosCosto[i,j]}");
                        total += costo;
                    }

                    Console.WriteLine($"Costo total de servicios: {total}");
                    Console.WriteLine();
                    Console.WriteLine("Desea salir al menu de gestion de servicios? (si/no)");
                    string respuesta = Console.ReadLine().ToLower();

                    if (respuesta != "si")
                    {
                        GestionServiciosMantenimiento();
                    }
                }

                if (!hayServicios)
                {
                    Console.WriteLine("No hay servicios registrados en ningun vehiculo.");
                    Console.WriteLine();
                    GestionServiciosMantenimiento();
                }
            }
        }

        static int BuscarVehiculoPorPlaca(string placa)
        {
            for (int i = 0;  i < vehiculoContador;  i++)
            {
                if (!string.IsNullOrEmpty(vehiculos[i, 2]) && vehiculos[i, 2].Equals(placa, StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1; //recomendacion para la edicion por profes de taller
        }

        static int BuscarClientePorCedula(string cedula)
        {
            for (int i = 0; i < clienteContador; i++)
            {
                if (!string.IsNullOrEmpty(clientes[i, 1]) && clientes[i, 1].Equals(cedula, StringComparison.OrdinalIgnoreCase))
                    return i;
            }
            return -1;
        }
    }
}
