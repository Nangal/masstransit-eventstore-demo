using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Contracts.Commands;

namespace Api.Controllers
{
    public class CommandController : ApiController
    {
        [Route("deposant")]
        [HttpPost]
        public async Task<HttpResponseMessage> Deposant()
        {
            var endpoint = await ServiceBusConfig.BusControl.GetSendEndpoint(new Uri("rabbitmq://localhost/deposant"));

            await endpoint.Send<CreateDeposant>(new
            {
                Id = Guid.NewGuid()
            });

            return Request.CreateResponse(new HttpResponseMessage(HttpStatusCode.NoContent));
        }
    }
}
