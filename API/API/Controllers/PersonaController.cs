using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class PersonaController : ApiController
    {

     
        public HttpResponseMessage Get(int id)
        {
            try
            {
                //se retorna la llave con estatus de codigo 200 si la llave es nula se retorna el estatus 400
                string key = Conexion.ConsultaID("select * from tbl_persona where id = '"+id+"'");
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(key);
                return response;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

        }


        public HttpResponseMessage Put([FromBody] Models.Persona persona)
        {
            try
            {
                //Se valida que el no exista la llave
                string valKey = Conexion.ConsultaID("select * from tbl_persona where key_ = '" + persona.key + "'");
                if (valKey != null)
                {
                    //si la llave existe en la BD se responde con el codigo 403
                    return new HttpResponseMessage(HttpStatusCode.Forbidden);
                }
                else {
                    //si la llave no existe se crea un registro y se responde con el codigo 204
                    string sql = "insert into tbl_persona (id,key_,shared_secret) values ('" +
                        persona.key + persona.shared_secret + "', '" + persona.key + "', '" + persona.shared_secret + "' )";
                    
                    Conexion.Insertar(sql);

                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                 
                    return response;
                }
          
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

        }

     
    }
}
