using FundooManager.Interface;
using FundooModel;
using FundooRepository.Interface;
using FundooRepository.Repository;
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

    }
}

