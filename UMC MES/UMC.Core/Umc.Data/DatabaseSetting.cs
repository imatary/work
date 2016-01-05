using System;

namespace Umc.Data
{
    [Serializable, XmlFile("database_config.xml")]
public sealed class DatabaseSetting : XmlSetting
{
    // Fields
    [SerializeMember("ConnectTimeout")]
    private int _connect_timeout = 15;
    [SerializeMember("DataSource")]
    private string _data_source = string.Empty;
    [SerializeMember("DatabaseType")]
    private DatabaseType _database_type = DatabaseType.SqlClient;
    [SerializeMember("InitialCatalog")]
    private string _initial_catalog = string.Empty;
    [SerializeMember("IntegratedSecurity")]
    private bool _integrated_security;
    [SerializeMember("Password")]
    private string _password = string.Empty;
    [SerializeMember("Port")]
    private int _port = 0x599;
    [SerializeMember("UserId")]
    private string _user_id = string.Empty;

    // Methods
    protected override void OnInitializeValidator(IValidator validator)
    {
        base.OnInitializeValidator(validator);
        validator.OnAddingOrModifying(t => string.IsNullOrEmpty(this.DataSource), "InvalidDataSource", new object[0]).OnAddingOrModifying(t => string.IsNullOrEmpty(this.InitialCatalog), "InvalidInitialCatalog", new object[0]).OnAddingOrModifying(t => (!this.IntegratedSecurity && string.IsNullOrEmpty(this.UserId)), "InvalidUserId", new object[0]).OnAddingOrModifying(t => !this.TestSetting(), "TestFailed", new object[0]);
    }

    private bool TestSetting()
    {
        return Database.Create(this).TryOpen();
    }

    // Properties
    [NotifyChange]
    public int ConnectTimeout
    {
        get
        {
            return this._connect_timeout;
        }
        set
        {
            base.OnSetValue("ConnectTimeout", () => this._connect_timeout != value, (Action) (() => (this._connect_timeout = value)));
        }
    }

    [NotifyChange]
    public DatabaseType DatabaseType
    {
        get
        {
            return this._database_type;
        }
        set
        {
            base.OnSetValue("DatabaseType", () => this._database_type != value, (Action) (() => (this._database_type = value)));
        }
    }

    [NotifyChange]
    public string DataSource
    {
        get
        {
            return this._data_source;
        }
        set
        {
            base.OnSetValue("DataSource", () => this._data_source != value, (Action) (() => (this._data_source = value)));
        }
    }

    [NotifyChange]
    public string InitialCatalog
    {
        get
        {
            return this._initial_catalog;
        }
        set
        {
            base.OnSetValue("InitialCatalog", () => this._initial_catalog != value, (Action) (() => (this._initial_catalog = value)));
        }
    }

    [NotifyChange]
    public bool IntegratedSecurity
    {
        get
        {
            return this._integrated_security;
        }
        set
        {
            base.OnSetValue("IntegratedSecurity", () => this._integrated_security != value, (Action) (() => (this._integrated_security = value)));
        }
    }

    [NotifyChange]
    public string Password
    {
        get
        {
            return this._password;
        }
        set
        {
            base.OnSetValue("Password", () => this._password != value, (Action) (() => (this._password = value)));
        }
    }

    [NotifyChange]
    public int Port
    {
        get
        {
            return this._port;
        }
        set
        {
            base.OnSetValue("Port", () => this._port != value, (Action) (() => (this._port = value)));
        }
    }

    [NotifyChange]
    public string UserId
    {
        get
        {
            return this._user_id;
        }
        set
        {
            base.OnSetValue("UserId", () => this._user_id != value, (Action) (() => (this._user_id = value)));
        }
    }
}
 

}