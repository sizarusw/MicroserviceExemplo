using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Api.Tracking
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : ControllerBase
    {
        public List<Tracking> Trackings { get; set; }

        private ITrackingRepository _tracking;

        public TrackingController(ITrackingRepository tracking = null)
        {
            _tracking = tracking;

            RetornarTracking();

        }

        private void RetornarTracking()
        {

            List<Tracking> listaTracking = new List<Tracking>();

            listaTracking = _tracking.GetAll();

            Trackings = listaTracking;

        }

        [HttpGet]
        public List<Tracking> Get()
        {
            return Trackings;
        }

        [HttpGet("{id:int}")]
        public Tracking Get(int id)
        {
            return Trackings.SingleOrDefault(x => x.IdTracking == id);
        }

        [HttpPost]
        public async void Post()
        {


            string conteudoJSON = "";
            // Lendo os dados do Body
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                conteudoJSON = await reader.ReadToEndAsync();
            }

            Tracking tracking = JsonConvert.DeserializeObject<Tracking>(conteudoJSON);

            Tracking trackingExistente = _tracking.FindFiltrado(tracking.Voo, tracking.Destino, tracking.Origem, tracking.DataEvento);

            if (trackingExistente == null)
            {
                _tracking.Add(tracking);
            }


        }
    }
}
