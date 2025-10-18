using Microsoft.Data.Sqlite;
string connectionString = "Data Source=Tienda.db;";
    string createTableQuery = "CREATE TABLE IF NOT EXISTS productos (id INTEGER PRIMARY KEY, nombre TEXT, precio REAL)";
    string insertQuery = "INSERT INTO productos (nombre, precio) VALUES ('Manzana', 0.50), ('Banana', 0.30)";
    string selectQuery = "SELECT * FROM productos";
// Crear conexión a la base de datos
using (SqliteConnection connection = new SqliteConnection(connectionString))
{
    connection.Open();
    // Crear tabla si no existe
    // por lo general este tipo de consultas no se implementa en un porgrama real
    // la aplicamos para poder crear nuestra base de datos desde cero
    using (SqliteCommand createTableCmd = new SqliteCommand(createTableQuery, connection))
    {
        createTableCmd.ExecuteNonQuery();
        Console.WriteLine("Tabla 'productos' creada o ya existe.");
    }

    // Insertar datos
    using (SqliteCommand insertCmd = new SqliteCommand(insertQuery, connection))
    {
        insertCmd.ExecuteNonQuery();
        Console.WriteLine("Datos insertados en la tabla 'productos'.");
    }
    // Leer datos
    using (SqliteCommand selectCmd = new SqliteCommand(selectQuery, connection))
    using (SqliteDataReader reader = selectCmd.ExecuteReader())
    {
        Console.WriteLine("Datos en la tabla 'productos':");
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["idProducto"]}, Nombre: {reader["nombre"]}, Precio: {reader["precio"]}");
        }
    }
    connection.Close();
}