namespace Pigeon.Voice.Demo.Agents.Configuration
{
    using Figlut.Server.Toolkit.Utilities;
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    #endregion //Using Directives

    public class AgentsGlobals
    {
        #region Singleton Setup

        private static AgentsGlobals _instance;

        public static AgentsGlobals Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AgentsGlobals();
                }
                return _instance;
            }
        }

        #endregion //Singleton Setup

        #region Constructors

        private AgentsGlobals()
        {
        }

        #endregion //Constructors

        #region Fields

        private AgentsSettings _settings;

        #endregion //Fields

        #region Properties

        public AgentsSettings Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = GOC.Instance.GetSettings<AgentsSettings>(true, true);
                }
                return _settings;
            }
        }

        #endregion //Properties

        #region Methods



        #endregion //Methods
    }
}