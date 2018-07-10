namespace Pigeon.Voice.Demo.Agents.SocketAgents
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using Pigeon.Voice.SDK.AgentBase.TCP_IP;
    using Pigeon.Voice.SDK.Sockets.LUT;
    using Pigeon.Voice.SDK.Sockets;
    using Pigeon.Voice.Demo.Agents.Data.DB;
    using Pigeon.Voice.Demo.Agents.Data.ORM;

    #endregion //Using Directives

    public class LutPickListAgent : PVLutAgentBase
    {
        #region Methods

        public override void Process(PVLutResponse response)
        {
            try
            {   
                PickList result = AgentsDBContext.Create().GetPickList(response.Request.OperatorId);
                response.AddRecord(new List<string>()
                {
                    0.ToString(),
                    string.Empty,
                    result.PickListNumber.ToString(),
                    Convert.ToInt32(result.Picked).ToString(),
                });
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
