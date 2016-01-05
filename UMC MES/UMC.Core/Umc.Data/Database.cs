using System.Data.Common;

namespace Umc.Data
{
    public abstract class Database
{
    // Fields
    private readonly DatabaseSetting _setting_;

    // Methods
    protected Database(DatabaseSetting setting)
    {
        if (setting == null)
        {
            throw Error.ArgumentNull("setting");
        }
        this._setting_ = setting;
    }

    public static Database Create(DatabaseSetting setting)
    {
        if (setting == null)
        {
            throw Error.ArgumentNull("setting");
        }
        switch (setting.DatabaseType)
        {
            case DatabaseType.SqlClient:
                return new SqlDatabase(setting);

            case DatabaseType.OracleClient:
                return new OracleDatabase(setting);
        }
        return null;
    }

    protected abstract DbConnection CreateConnection();
    public DbProvider CreateProvider()
    {
        return new DbProvider(this.GetConnection(), this._setting_.DatabaseType);
    }

    public DbConnection GetConnection()
    {
        return this.CreateConnection();
    }

    public bool TryOpen()
    {
        try
        {
            using (DbConnection connection = this.CreateConnection())
            {
                if (connection != null)
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
            }
        }
        catch
        {
        }
        return false;
    }

    // Properties
    public DatabaseSetting Setting
    {
        get
        {
            return this._setting_;
        }
    }
}

}