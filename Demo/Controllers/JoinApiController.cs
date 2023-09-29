using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers
{
    public class JoinApiController : ApiController
    {
        StudentMasterEntities sm = new StudentMasterEntities();
        public IHttpActionResult getList()
        {
            IList<JoinTableClass> jt = sm.displayinfo().Select(x => new JoinTableClass()
            {
                Sname = x.sname, 
                ClassName = x.ClassName, 
                SubjectName = x.SubjectName,
                Type = x.Type,    
                Mark = x.Marks
            }).ToList();
            return Ok(jt);

        }
    }
}
