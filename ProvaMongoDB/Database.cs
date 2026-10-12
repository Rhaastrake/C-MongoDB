namespace ProvaMongoDB;

public class Database
{
    private static Database _instance = null;

    public string Address { get; set; }
    public string Port { get; set; }
    public string DbName { get; set; }
    public string DbCollection { get; set; }
    public string DbUser { get; set; }
    public string DbUserPassword { get; set; }

    private Database(string address, string port, string dbName, string dbCollection, string dbUser, string dbUserPassword)
    {
        Address = address;
        Port = port;
        DbName = dbName;
        DbCollection = dbCollection;
        DbUser = dbUser;
        DbUserPassword = dbUserPassword;
    }

    public static Database GetInstance()
    {
        return _instance;
    }

    public static Database GetInstance(string address, string port, string dbName, string dbCollection, string dbUser, string dbUserPassword)
    {
        if (_instance == null)
        {
            _instance = new Database(address, port, dbName, dbCollection, dbUser, dbUserPassword);
        }

        return _instance;
    }

    public string GetConnectionString()
    {
        string host = Address.Replace("mongodb://", "");
        string password = Uri.EscapeDataString(DbUserPassword);
        return "mongodb://" + DbUser + ":" + password + "@" + host + ":" + Port + "/?authSource=admin&tls=true";
    }
}