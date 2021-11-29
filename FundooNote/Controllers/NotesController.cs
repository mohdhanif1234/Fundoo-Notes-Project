using FundooManager.Interface;
using FundooManager.Manager;
using FundooModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNote.Controllers
{
    //[Authorize]
    public class NotesController : ControllerBase
    {
        private readonly INotesManager notesManager;

        public NotesController(INotesManager notesManager)
        {
            this.notesManager = notesManager;
        }
        [HttpPost]
        [Route("api/addnote")]
        public IActionResult MakeANote([FromBody] NotesModel notesModel)
        {
            try
            {
                string result = this.notesManager.MakeANote(notesModel);
                if (result == "New note created successfully")
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
        [Route("api/editnote")]
        public IActionResult EditNote([FromBody] NotesModel notesModel)
        {
            try
            {
                string result = this.notesManager.EditNote(notesModel);
                if (result.Equals("Note is updated successfully"))
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
        [Route("api/changecolor")]
        public IActionResult EditColor(int noteId, string noteColor)
        {
            try
            {
                string result = this.notesManager.EditColor(noteId, noteColor);
                if (result.Equals("Color is updated successfully"))
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
        [Route("api/archivenote")]
        public IActionResult ArchiveNote(int noteId)
        {
            try
            {
                string result = this.notesManager.ArchiveNote(noteId);
                if (result.Equals("This note does not exist.Kindly create a new one"))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
                else
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/pinnote")]
        public IActionResult NoteAddtionAsPinned(int notesId)
        {
            try
            {
                string result = this.notesManager.NoteAddtionAsPinned(notesId);
                if (result.Equals("This note does not exist. Kindly create a new one"))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
                else
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/addimage")]
        public IActionResult AddImage(int noteId, IFormFile imagePath)
        {
            try
            {
                string result = this.notesManager.AddImage(noteId, imagePath);
                if (result.Equals("Image uploaded successfully"))
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
                return this.NotFound(new ResponseModel<string>() { Status = true, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/deleteanote")]
        public IActionResult DeleteANote(int notesId)
        {
            try
            {
                string result = this.notesManager.DeleteANote(notesId);
                if (result.Equals("This note does not exist. Kindly create a new one"))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
                else
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/retrievenote")]
        public IActionResult RetrieveNoteFromTrash(int notesId)
        {
            try
            {
                string result = this.notesManager.RetrieveNoteFromTrash(notesId);
                if (result.Equals("Note restored successfully"))
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
        [Route("api/deletefromtrash")]
        public IActionResult DeleteNoteFromTrash(int notesId)
        {
            try
            {
                string result = this.notesManager.DeleteNoteFromTrash(notesId);
                if (result.Equals("This note does not exist. Kindly create a new one"))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
                else
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/addreminder")]
        public IActionResult AddReminder(int notesId, string remindMe)
        {
            try
            {
                string result = this.notesManager.AddReminder(notesId, remindMe);
                if (result.Equals("Remind added successfully"))
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
        [Route("api/deletereminder")]
        public IActionResult DeleteReminder(int notesId)
        {
            try
            {
                string result = this.notesManager.DeleteReminder(notesId);
                if (result.Equals("Reminder deleted successfully"))
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
        [Route("api/getarchievednotes")]
        public IActionResult GetArchiveNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetArchiveNotes(userId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "There are no notes in the archive to be retrieved" });
                }
                else
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Notes retrieved successfully",Data=result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/getremindernotes")]
        public IActionResult GetReminderNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetReminderNotes(userId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Reminder not created for any of the note" });
                }
                else
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Reminder for notes retrieved successfully", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/gettrashnotes")]
        public IActionResult GetTrashNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetTrashNotes(userId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Trash is empty" });
                }
                else
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Notes retrieved from the trash successfully", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/getallnotes")]
        public IActionResult GetNotes(int userId)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetAllNotes(userId);

                if (result.Equals(null))
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "No note exists whose data is data is to be retrieved" });
                }
                else
                {
                    return this.Ok(new ResponseModel<IEnumerable<NotesModel>>() { Status = true, Message = "Data for all notes is retrived successfully", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string> { Status = false, Message = ex.Message });
            }
        }
    }
}
