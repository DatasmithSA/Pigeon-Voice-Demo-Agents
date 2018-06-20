### Pigeon Voice Server

[[/images/Pigeon-Logo.png]]

The **Pigeon Voice Training** repository provides source code samples, demo voice applications and documentation to assist Datasmith partners and customers in getting started with Datasmith's **Pigeon Voice Server**.

**Who the Pigeon Voice Server and training is for**:
* **WMS vendors:** that would like to voice enable their WMS and would prefer to handle all the server-side code themselves without requiring Vocollect certified implementation specialists to perform the integration.
* **Vocollect Partners:** that are interested in a middleware server that enables them to easily perform flexible integrations into any WMS/ERP without requiring fairly large R&D efforts i.e. by dealing with the complexities of handling proprietary Vocollect messages to and from devices. The code required to handle a message from the device and supply response can be trimmed down to a few lines of code, which can be written in a few minutes.

The **Pigeon Voice Server** provides an easy and flexible way to integrate Vocollect voice applications into any backend system (e.g. WMS, ERP etc.) without having to deal with the technical complexities and proprietary message formats of messages being sent to and from Vocollect devices. While the Pigeon Voice Server handles the messages to and from the Vocollect devices, an WMS/ERP integrator can simply focus on the integration into the backend WMS/ERP system without requiring extensive knowledge about Vocollect voice solutions. This is achieved by developing plugins on the Pigeon Voice server to handle the device requests by performing queries on the WMS/ERP system and populate the responses to the Vocollect Voice devices. These Pigeon Voice Server plugins are referred to as agents. The agents are developed by implementing the Pigeon Voice SDK and can be coded in any Microsoft .NET based programming language such as C# or VB.NET. Here's an example of a custom Pigeon Voice agent responding to a login request from a Vocollect device:

`



    public class LutLoginAgent : PVLutAgentBase
    {
        public override void Process(PVLutResponse response)
        {
            try
            {
                string password = response.Request[0];
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
    }
`

**Voice technology stack overview:** 

For each given Voice solution to an end customer, the following custom software is required to be developed:

* **Voice Application**: is the client application running on the device, which contains the dialog flow i.e. the dialog between the device and the operator. The dialog remains static: certain prompts are spoken to the operator and the operator is expected to provide one or more expected responses. 
N.B. Due to Vocollect wanting to maintain a high standard of implementations, only Vocollect certified implementation partners that have gone through the Vocollect University training are allowed to develop, install and support these Voice applications.
* **Server Integration**: the voice application will require to download certain data from the server as well as to send data back to the server e.g. a list of picks to be completed for an order, or for a pick confirmation to be sent back to the server. Integration engineers will be required to write code in order to handle the requests from the Vocollect devices, query the WMS and provide responses back to the devices. The formats of messages being sent to and from the devices are proprietary to Vocollect and therefore integrators that are not Vocollect VARs will not have the necessary knowledge to complete the integration. Therefore it is left up to Vocollect certified VARs to perform the integrations. The Pigeon Voice Server facilitates in this integration development effort by providing an easy and flexible way to integrate Vocollect voice applications into any backend system (e.g. WMS, ERP etc.) without having to deal with the technical complexities and/or requiring any knowledge of the Vocollect proprietary formats of messages being sent to and from Vocollect devices. The Pigen Voice Server allows any integration engineer and/or WMS provider to easily develop a voice integration with very little effort and R&D required. Furthermore, even Vocollect certified partners who may not have the expertise and/or may not want to invest in R&D can take advantage of the Pigeon Voice Server.

[[/images/Pigeon-Voice-Stack.png]]