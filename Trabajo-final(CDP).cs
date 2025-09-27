using System;

namespace tpIntegrador1
{
	struct Mascota {
		public string Tipo;
		public string Raza;
		public string Nombre;
	}
	
	struct Cliente {
		public string Nombre;
		public string Apellido;
		public int Dni;
		public string Correo;
		public Mascota DatosMascota;
	}
	
	struct Turno {
		public int DniCliente;
		public DateTime FechaHora;
	}

	
	class Program
	{
		static Cliente[] clientes = new Cliente[999];
    	static int cantidadClientes = 0;
    	
    	static Turno[] turnos = new Turno[999];
		static int cantidadTurnos = 0;
    	
		public static void Main(string[] args){
    		bool exit = false;
			
    		while (!exit) {
    			Console.Clear();
    			Console.WriteLine("=== MENÚ PRINCIPAL ===");
    			Console.WriteLine("1. Cargar datos de un cliente");
    			Console.WriteLine("2. Buscar un cliente");
    			Console.WriteLine("3. Buscar una mascota");
    			Console.WriteLine("4. Ver la cantidad de mascotas según la raza");
    			Console.WriteLine("5. Asignar un turno");
    			Console.WriteLine("6. Salir del programa");
    			Console.Write("Ingrese una opción (1-6): ");

    			string entrada = Console.ReadLine();
    			int option;

    			if (!int.TryParse(entrada, out option)) {
    				Console.WriteLine("Opción inválida. Debe ingresar un número del 1 al 6.");
    				Console.WriteLine("\nPresione una tecla para continuar...");
    				Console.ReadKey();
    				continue; // vuelve al inicio del while
    			}

    			switch (option) {
    				case 1:
    					CargarCliente();
    					break;
    				case 2:
    					BuscarCliente();
    					break;
    				case 3:
    					BuscarMascota();
    					break;
    				case 4:
    					VerCantidadPorRaza();
    					break;
    				case 5:
    					AsignarTurno();
    					break;
    				case 6:
    					exit = true;
    					Console.WriteLine("Saliendo del programa...");
    					break;
    				default:
    					Console.WriteLine("Opción fuera de rango. Intente nuevamente.");
    					break;
    			}

    			Console.WriteLine("\nPresione una tecla para continuar...");
    			Console.ReadKey();
    		}	

		}

    	static void CargarCliente(){
    		if (cantidadClientes >= clientes.Length){
        		Console.WriteLine("No se pueden ingresar más clientes. Límite alcanzado.");
       			return;
    		}

			Cliente nuevo = new Cliente();

    		Console.Write("Ingrese nombre del cliente: ");
    		nuevo.Nombre = Console.ReadLine();

    		Console.Write("Ingrese apellido del cliente: ");
    		nuevo.Apellido = Console.ReadLine();

    		Console.Write("Ingrese DNI del cliente: ");
    		bool DniValido = false;

    		while (!DniValido) {
    			string input = Console.ReadLine();
    			int dniTemp;

    			if (!int.TryParse(input, out dniTemp)) {
    				Console.WriteLine("DNI inválido. Debe contener solo números (sin puntos).");
    			} else if (input.Length != 8) {
    				Console.WriteLine("El DNI debe tener exactamente 8 dígitos.");
    			} else {
    				nuevo.Dni = dniTemp;
    				DniValido = true;
    			}
    		}


    		Console.Write("Ingrese correo electrónico: ");
    		nuevo.Correo = Console.ReadLine();

    		Console.Write("Ingrese nombre de la mascota: ");
    		nuevo.DatosMascota.Nombre = Console.ReadLine();

    		Console.Write("Ingrese tipo de mascota (ej. perro, gato): ");
    		nuevo.DatosMascota.Tipo = Console.ReadLine();

    		Console.Write("Ingrese raza de la mascota: ");
    		nuevo.DatosMascota.Raza = Console.ReadLine();

    		clientes[cantidadClientes] = nuevo;
    		cantidadClientes++;

    		Console.WriteLine("Cliente cargado exitosamente.");
    	}
    	
    	static void BuscarCliente() {
    		Console.Write("Ingrese el DNI del cliente a buscar: ");
    		int DniBuscado = 0;
    		bool DniValido = false;
    		while(!DniValido) {
    			string input = Console.ReadLine();
    			int dniTemp;

    			if (!int.TryParse(input, out dniTemp)) {
    				Console.WriteLine("DNI inválido. Debe contener solo números (sin puntos).");
    			} else if (input.Length != 8) {
    				Console.WriteLine("El DNI debe tener exactamente 8 dígitos.");
    			} else {
    				DniBuscado = dniTemp;
    				DniValido = true;
    			}
    		}
    		
    		bool encontrado = false;
    		for (int i = 0; i < cantidadClientes; i++) {
    			if (DniBuscado == clientes[i].Dni) {
            		Console.WriteLine("\nCliente encontrado:");
            		Console.WriteLine("Nombre: " + clientes[i].Nombre);
            		Console.WriteLine("Apellido: " + clientes[i].Apellido);
            		Console.WriteLine("DNI: " + clientes[i].Dni);
            		Console.WriteLine("Correo: " + clientes[i].Correo);
            		Console.WriteLine("Nombre mascota: " + clientes[i].DatosMascota.Nombre);
           	 		Console.WriteLine("Tipo mascota: " + clientes[i].DatosMascota.Tipo);
            		Console.WriteLine("Raza mascota: " + clientes[i].DatosMascota.Raza);
            		encontrado = true;
    			}
    		}

    		if (!encontrado) {
        		Console.WriteLine("No se encontró ningún cliente con ese DNI.");
    		}
    	}
    	
    	static void BuscarMascota() {
    		Console.Write("Ingrese el nombre de la mascota a buscar: ");
    		string nombreBuscado = Console.ReadLine().ToLower();
   			bool encontrado = false;

    		for (int i = 0; i < cantidadClientes; i++) {
        		if (clientes[i].DatosMascota.Nombre.ToLower() == nombreBuscado) {
            	Console.WriteLine("\nMascota encontrada:");
            	Console.WriteLine("Nombre: " + clientes[i].DatosMascota.Nombre);
            	Console.WriteLine("Tipo: " + clientes[i].DatosMascota.Tipo);
            	Console.WriteLine("Raza: " + clientes[i].DatosMascota.Raza);
           	 	Console.WriteLine("Dueño:");
            	Console.WriteLine("  Nombre: " + clientes[i].Nombre);
            	Console.WriteLine("  Apellido: " + clientes[i].Apellido);
            	Console.WriteLine("  DNI: " + clientes[i].Dni);
            	Console.WriteLine("  Correo: " + clientes[i].Correo);
            	encontrado = true;
   				}
   			}
   			
   			if (!encontrado) {
        		Console.WriteLine("No se encontró ninguna mascota con ese nombre.");
   			}
    	}
    	
    	static void VerCantidadPorRaza() {
    		string[] razas = new string[999];
    		int[] cantidades = new int[999];
    		int cantidadRazas = 0;

   			for (int i = 0; i < cantidadClientes; i++) {
        		string razaActual = clientes[i].DatosMascota.Raza;
        		bool existe = false;
				
        		// Verifica si la raza actual ya existe en razas[].
        		for (int j = 0; j < cantidadRazas; j++) {
            		if (razas[j] == razaActual) {
                		cantidades[j]++;
                		existe = true;
                		break;
        			}
        		}

        		if (!existe) {
            		razas[cantidadRazas] = razaActual;
            		cantidades[cantidadRazas] = 1;
            		cantidadRazas++;
        		}
    		}
    		
    		if (cantidadRazas == 0) {
        		Console.WriteLine("No hay mascotas registradas.");
    		} else {
        		Console.WriteLine("Cantidad de mascotas por raza:");
        		for (int i = 0; i < cantidadRazas; i++) {
            		Console.WriteLine("Raza: " + razas[i] + " - Cantidad: " + cantidades[i]);
        		}
    		}
    	}
    	
    	static void AsignarTurno() {
    		if (cantidadTurnos >= turnos.Length) {
        		Console.WriteLine("No se pueden asignar más turnos. Límite alcanzado.");
        		return;
    		}

    		Console.Write("Ingrese DNI del cliente para asignar turno: ");
    		int DniBuscado = 0;
    		bool DniValido = false;
    		while (!DniValido) {
        		string input = Console.ReadLine();
    			int dniTemp;

    			if (!int.TryParse(input, out dniTemp)) {
    				Console.WriteLine("DNI inválido. Debe contener solo números (sin puntos).");
    			} else if (input.Length != 8) {
    				Console.WriteLine("El DNI debe tener exactamente 8 dígitos.");
    			} else {
    				DniBuscado = dniTemp;
    				DniValido = true;
    			}
    		}

    		// Verificar que el cliente exista
    		bool clienteEncontrado = false;
    		for (int i = 0; i < cantidadClientes; i++) {
        		if (clientes[i].Dni == DniBuscado) {
					clienteEncontrado = true;
            		break;
        		}
    		}

    		if (!clienteEncontrado) {
        		Console.WriteLine("Cliente no encontrado.");
        		return;
    		}

   		 	// Validar la fecha y hora del turno
   		 	DateTime fechaHoraTurno = DateTime.MinValue;
    		bool fechaValida = false;
    		while (!fechaValida) {
        		Console.Write("Ingrese fecha y hora del turno (ej: 25/05/2025 14:30): ");
        		string entrada = Console.ReadLine();

        		if (DateTime.TryParse(entrada, out fechaHoraTurno)) {
            		fechaValida = true;
        		} else {
            		Console.WriteLine("Formato inválido. Intente de nuevo.");
       	 		}
    		}

    		// Crear y guardar el turno
    		Turno nuevoTurno;
    		nuevoTurno.DniCliente = DniBuscado;
   			nuevoTurno.FechaHora = fechaHoraTurno;
	
    		turnos[cantidadTurnos] = nuevoTurno;
    		cantidadTurnos++;

    		Console.WriteLine("Turno asignado exitosamente.");
		}
	}
}
