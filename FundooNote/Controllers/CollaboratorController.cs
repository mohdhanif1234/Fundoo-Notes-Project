using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNote.Controllers
{
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorManager collaboratorManager;

        public CollaboratorController(ICollaboratorManager manager)
        {
            this.collaboratorManager = manager;
        }

        [HttpPost]
        [Route("api/addcollaborator")]
        public IActionResult AddCollaborator([FromBody] CollaboratorModel collaboratorData)
        {
            try
            {
                string result = this.collaboratorManager.AddCollaborator(collaboratorData);
                if (result.Equals("Collaborator added successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result,});
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("api/deletecollaborator")]
        public IActionResult DeleteCollaborator(int collaboratorData)
        {
            try
            {
                string result = this.collaboratorManager.DeleteCollaborator(collaboratorData);
                if (result.Equals("Collaborator removed successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }


    }
}
