using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNote.Controllers
{
    public class LabelController : ControllerBase
    {
        private readonly ILabelManager labelManager;
        public LabelController(ILabelManager labelManager)
        {
            this.labelManager = labelManager;
        }
        [HttpPost]
        [Route("api/addlabelbyuserid")]
        public IActionResult AddLabelByUserId([FromBody] LabelModel labelData)
        {
            try
            {
                string result = this.labelManager.AddLabelByUserId(labelData);

                if (result.Equals("Label added successfully"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
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
