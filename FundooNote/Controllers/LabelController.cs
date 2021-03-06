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
        [HttpPost]
        [Route("api/addlabelbynoteid")]
        public IActionResult AddLabelByNoteId([FromBody] LabelModel labelData)
        {
            try
            {
                string result = this.labelManager.AddLabelByNoteId(labelData);

                if (result.Equals("Added Label"))
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
        [HttpDelete]
        [Route("api/deletelabel")]
        public IActionResult DeleteLabel(int userId, string labelName)
        {
            try
            {
                string result = this.labelManager.DeleteLabel(userId, labelName);

                if (result.Equals("Label deleted successfully"))
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
        [HttpDelete]
        [Route("api/removelable")]
        public IActionResult RemoveLabel(int labelId)
        {
            try
            {
                string result = this.labelManager.RemoveLabel(labelId);

                if (result.Equals("Label was deleted from the note successfully"))
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
        [HttpPut]
        [Route("api/editlabel")]
        public IActionResult EditLabel([FromBody] LabelModel labelData)
        {
            try
            {
                string result = this.labelManager.EditLabel(labelData);

                if (result.Equals("Label updated successfully"))
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
        [HttpGet]
        [Route("api/getlabelbyuserid")]
        public IActionResult GetLabelByUseriId(int userId)
        {
            try
            {
                IEnumerable<string> result = this.labelManager.GetLabelByUserId(userId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "No label found" });
                }
                else
                {
                    return this.Ok(new ResponseModel<IEnumerable<string>>() { Status = true, Message = "Successfully Retrieved", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/getlabelbynotesid")]
        public IActionResult GetLabelByNoteId(int notesId)
        {
            try
            {
                IEnumerable<LabelModel> result = this.labelManager.GetLabelByNoteId(notesId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Label not found" });
                }
                else
                {
                    return this.Ok(new ResponseModel<IEnumerable<LabelModel>>() { Status = true, Message = "Successfully Retrieved", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
    }
}
