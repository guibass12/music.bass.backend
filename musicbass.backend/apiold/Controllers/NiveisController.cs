﻿using System.Linq;
using System.Net;
using System.Web.Http;
using infra.DataContext;
using System.Net.Http;
using System.Web.Http.Cors;

namespace api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*" )]
    [RoutePrefix("api/v1")]
    public class NiveisController : ApiController
    {
        private musicbassDataContext db = new musicbassDataContext();

        [Route("niveis")]
        public HttpResponseMessage GetNiveis()
        {
            var result = db.Niveis.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
        [Route("aulas")]
        public HttpResponseMessage GetAulas()
        {
            var result = db.Aulas.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("niveis/{nivelId}/aulas")]
        public HttpResponseMessage GetAulasByNiveis(int nivelId)
        {
            var result = db.Aulas.Include("Nivel").Where(x=> x.NivelId == nivelId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}