namespace Pigeon.Voice.Demo.Agents.SocketAgents
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using Pigeon.Voice.SDK.AgentBase.TCP_IP;
    using Pigeon.Voice.SDK.Sockets.LUT;
    using Pigeon.Voice.Demo.Agents.Data.DB;

    #endregion //Using Directives

    public class LutLogOffAgent : PVLutAgentBase
    {
        #region Methods

        public override void Process(PVLutResponse response)
        {
            try
            {
                AgentsDBContext.Create().LogOff(response.Request.OperatorId);
                response.AddRecord(new List<string>() { 0.ToString(), string.Empty });
            }
            catch (Exception ex)
            {
                response.Records.Clear();
                response.AddRecord(new List<string>() { 1.ToString(), ex.Message });
                throw ex;
            }
        }

        #endregion //Methods
    }
}
