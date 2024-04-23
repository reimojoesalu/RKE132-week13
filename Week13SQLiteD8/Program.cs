using System;
using System.Data.SQLite;


ReadData(CreateConnection());
//InsertCustomer(CreateConnection());
RemoveCustomer(CreateConnection());

SQLiteConnection connection = new SQLiteConnection("Data Source=mydb.db; version = 3; New = True; Compress = True;");

try
{
    connection.Open();
    Console.WriteLine("DB found.");
}
catch
{
    Console.WriteLine("DB not found.");
}
return connection;
}

static void ReadData(SQLLiteConnection myConnection)
{
    Console.Clear();
    SqlLiteDataReader reader;
    SQLLiteCommand command;

    command = myConnection.CreateCommand();
    command.CommandText = "SELECT * FROM customer";

    reader = command.ExecuteReader();

    while (reader.Read())
    {
        String readerRowId = reader.Getstring(0);
        string readerStringFirstName = reader.GetString(0);
        string readerStringLastName = reader.GetString(1);
        string readerStringDob = reader.GetString(2);

        Console.WriteLine($"Full name: {readerStringFirstName} {readerStringLastName}; Dob: {readerStringDob}");
    }

    myConnection.Close();
}

static void InsertCustomer(SQLiteConnection myConnection)
{
    SQLiteCommand command;
    string fName, lName, dob;

    Console.WriteLine("Enter first name:");
    fName = Console.ReadLine();
    Console.WriteLine("Enter last name;");
    lName = Console.ReadLine();
    Console.WriteLine("Enter date of birth (mm-dd-yyyy:");
    command.CommandText = $"INSTER INTO customer(firstName, lastName, dateOfBirth) " +
    $"VALUES ('{fName}','{lName}','{dob}')";

    int rowInserted = command.ExecuteNonQuery();
    Console.WriteLine($"Row inserted: {rowInserted}")ˇ;
    


    ReadData(myConnection);
    myConnection.Close() ;
}

static void RemoveCustomer(SQLliteConnection myconnection)
{
    SQLiteCommand command;

    string idToDelte;
    Console.WriteLine("Enter an id delete a customer:");
    string idToUpdate = Console.ReadLine();

    command = myconnection.CreateCommand();
    command.CommandText = $"DELTE FROM customer WHERE rowid = {idToDelte}";
    int rowRemoved = command.ExecuteNonQuery();
    Console.WriteLine($"{rowRemoved} was removed from table customer.");

    ReadData(myConnection);
}


static void FindCustomer()
{

}