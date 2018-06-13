namespace Pigeon.Voice.Demo.Agents.SocketAgents
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Pigeon.Voice.SDK.AgentBase.TCP_IP;
    using Pigeon.Voice.SDK.Sockets.LUT;
    using Pigeon.Voice.SDK.Sockets;
    using Pigeon.Voice.Demo.Agents.Data.DB;

    #endregion //Using Directives

    public class LutLoginAgent : PVLutAgentBase
    {
        #region Methods

        public override void Process(PVLutResponse response)
        {
            try
            {
                GetInputParameters(response.Request, out string password);
                AgentsDBContext.Create().Login(response.Request.OperatorId, password);
                response.AddRecord(new List<string>() { 0.ToString(), string.Empty });
            }
            catch (Exception ex)
            {
                response.Records.Clear();
                response.AddRecord(new List<string>() { 1.ToString(), ex.Message });
                throw ex;
            }
        }

        private void GetInputParameters(PVSocketRequest request, out string password)
        {
            if (request.InputRecordFieldValues.Count != 1)
            {
                throw new Exception(string.Format("Invalid number of inputs supplied to {0}.", request.CommandName));
            }
            password = request[0];
        }

        #endregion //Methods
    }
}
