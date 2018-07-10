namespace Pigeon.Voice.Demo.Agents.SocketAgents
{
    #region Using Directives

    using System;
    using Pigeon.Voice.SDK.Sockets.ODR;
    using Pigeon.Voice.SDK.Sockets;
    using Pigeon.Voice.SDK.AgentBase.TCP_IP;
    using Pigeon.Voice.Demo.Agents.Data.DB;

    #endregion //Using Directives

    public class OdrConfirmPickAgent : PVOdrAgentBase
    {
        #region Methods

        public override void Process(PVOdrResponse response)
        {
            try
            {
                GetInputParameters(response.Request, out int pickListNumber, out string sku, out int quantityPicked, out char pickStatusCode);
                AgentsDBContext.Create().ConfirmPick(response.Request.OperatorId, pickListNumber, sku, quantityPicked, pickStatusCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetInputParameters(
            PVSocketRequest request,
            out int pickListNumber, //0
            out string sku,  //1
            out int quantityPicked, //2
            out char pickedStatusCode) //3
        {
            if (!int.TryParse(request[0], out pickListNumber))
            {
                throw new Exception(string.Format("Pick list number {0} cannot be converted to an integer.", request[0]));
            }
            sku = request[1];
            if (!int.TryParse(request[2], out quantityPicked))
            {
                throw new Exception(string.Format("Quantity picked {0} cannot be converted to an integer.", request[2]));
            }
            if (!char.TryParse(request[3], out pickedStatusCode))
            {
                throw new Exception(string.Format("Pick Status Code {0} cannot be converted to a character.", request[3]));
            }
        }

        #endregion //Methods
    }
}
