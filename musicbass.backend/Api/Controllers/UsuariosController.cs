using System.Net;
using System.Web.Http;
using System.Net.Http;
using service;
using System;
using domain;

namespace api.Controllers
{

    [RoutePrefix("v1/usuarios")]
    public class UsuariosController : ApiController
    {
        UsuarioService _service = new UsuarioService();

        [HttpGet]
        [Route("email/{email}")]
        public HttpResponseMessage GetUsuario(string email)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                var result = _service.Obter(email);
                response =  Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
               response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return response;
            
        }

        [Route("islogged")]
        [HttpGet]
        [Authorize()]
        public HttpResponseMessage IsLogged()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Login com sucesso!");
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Register(Usuario model)
        {
                HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                //Limpando possíveis propriedades injetadas
                model.Id = 0;
                _service.Criar(model);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Nome, email = model.Email });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}