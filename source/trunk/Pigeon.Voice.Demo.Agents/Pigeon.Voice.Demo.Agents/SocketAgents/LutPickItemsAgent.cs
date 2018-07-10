namespace Pigeon.Voice.Demo.Agents.SocketAgents
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using Pigeon.Voice.SDK.AgentBase.TCP_IP;
    using Pigeon.Voice.SDK.Sockets.LUT;
    using Pigeon.Voice.Demo.Agents.Data.ORM;
    using Pigeon.Voice.SDK.Sockets;
    using Pigeon.Voice.Demo.Agents.Data.DB;

    #endregion //Using Directives

    public class LutPickItemsAgent : PVLutAgentBase
    {
        #region Methods

        public override void Process(PVLutResponse response)
        {
            try
            {
                GetInputParameters(response.Request, out int pickListNumber);
                List<PickItem> result = AgentsDBContext.Create().GetPickListItems(pickListNumber);
                result.ForEach(p => response.AddRecord(new List<string>()
                {
                    0.ToString(),
                    string.Empty,
                    p.Sku,
                    p.Location,
                    p.CheckDigits,
                    p.QuantityToPick.ToString(),
                    p.QuantityToPick.ToString(), //Quantity remaining. Field used only on the device.
                    p.Description,
                    p.QuantityPicked.HasValue ? p.QuantityPicked.Value.ToString() : 0.ToString(), //Field used only on the device.
                    p.PickStatusCode.HasValue ? p.PickStatusCode.ToString() : string.Empty //Field used only on the device.
                }));
            }
            catch (Exception ex)
            {
                response.Records.Clear();
                response.AddRecord(new List<string>() { 1.ToString(), ex.Message });
                throw ex;
            }
        }

        private void GetInputParameters(PVSocketRequest request, out int pickListNumber)
        {
            if (request.InputRecordFieldValues.Count != 1)
            {
                throw new Exception(string.Format("Invalid number of inputs supplied to {0}.", request.CommandName));
            }
            if (!int.TryParse(request[0], out pickListNumber))
            {
                throw new Exception(string.Format("Pick list number {0} cannot be converted to an integer.", request[0]));
            }
        }

        #endregion //Methods
    }
}
