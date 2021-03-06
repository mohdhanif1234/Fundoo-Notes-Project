using FundooManager.Interface;
using FundooModel;
using FundooRepository.Interface;
using FundooRepository.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository notesRepository;

        public NotesManager(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }
        public string MakeANote(NotesModel notesModel)
        {
            try
            {
                return this.notesRepository.MakeANote(notesModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EditNote(NotesModel notesModel)
        {
            try
            {
                return this.notesRepository.EditNote(notesModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EditColor(int noteId, string noteColor)
        {
            try
            {
                return this.notesRepository.EditColor(noteId, noteColor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string ArchiveNote(int noteId)
        {
            try
            {
                return this.notesRepository.ArchiveNote(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string NoteAddtionAsPinned(int notesId)
        {
            try
            {
                return this.notesRepository.NoteAddtionAsPinned(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string AddImage(int noteId, IFormFile imagePath)
        {
            try
            {
                return this.notesRepository.AddImage(noteId, imagePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }     
        }
        public string DeleteANote(int notesId)
        {
            try
            {
                return this.notesRepository.DeleteANote(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string RetrieveNoteFromTrash(int notesId)
        {
            try
            {
                return this.notesRepository.RetrieveNoteFromTrash(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteNoteFromTrash(int notesId)
        {
            try
            {
                return this.notesRepository.DeleteNoteFromTrash(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string AddReminder(int notesId, string remindMe)
        {
            try
            {
                return this.notesRepository.AddReminder(notesId, remindMe);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteReminder(int notesId)
        {
            try
            {
                return this.notesRepository.DeleteReminder(notesId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NotesModel> GetArchiveNotes(int userId)
        {
            try
            {
                return this.notesRepository.GetArchiveNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NotesModel> GetReminderNotes(int userId)
        {
            try
            {
                return this.notesRepository.GetReminderNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NotesModel> GetTrashNotes(int userId)
        {
            try
            {
                return this.notesRepository.GetTrashNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NotesModel> GetAllNotes(int userId)
        {
            try
            {
                return this.notesRepository.GetAllNotes(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
 
