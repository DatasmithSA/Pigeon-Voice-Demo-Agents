namespace Pigeon.Voice.Demo.Agents.Configuration
{
    #region Using Directives

    using Figlut.Server.Toolkit.Utilities.SettingsFile;

    #endregion //Using Directives

    public class AgentsSettings : Settings
    {
        #region Properties

        #region Database Settings

        /// <summary>
        /// The connection string to the SQL Server database holding demo data for the agents.
        /// </summary>
        public string DatabaseConnectionString { get; set; }

        /// <summary>
        /// The database command timeout to the SQL Server database holding the demo data for the agents.
        /// </summary>
        public int DatabaseCommandTimeout { get; set; }

        #endregion //Database Settings

        #endregion //Properties

        #region Methods

        public AgentsSettings CreateDefaultSettings()
        {
            return new AgentsSettings()
            {
                DatabaseConnectionString = "Enter connection string here",
                DatabaseCommandTimeout = 30000
            };
        }

        #endregion //Methods
    }
}