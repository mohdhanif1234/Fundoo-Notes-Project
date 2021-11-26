using FundooModel;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRepository.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly UserContext userContext;
        public IConfiguration Configuration { get; }
        public NotesRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }
        public string MakeANote(NotesModel notesModel)
        {
            try
            {
                if (notesModel != null)
                {
                    // Adding the data to the database
                    this.userContext.Notes.Add(notesModel);
                    // Saving the changes in the database
                    this.userContext.SaveChanges();
                    return "New note created successfully";
                }
                else
                {
                    return "Note creation is unsuccesful";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EditNote(NotesModel notesModel)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == notesModel.NoteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    if (notesModel != null)
                    {
                        validNoteId.Title = notesModel.Title; 
                        validNoteId.TakeANote = notesModel.TakeANote;
                        this.userContext.Notes.Update(validNoteId);
                        this.userContext.SaveChanges();
                        return "Note is updated successfully";
                    }
                    else
                    {
                        return "Note update is unsuccessful";
                    }
                }
                else
                {
                    return "This note does not exist. Kindly create a new one";
                }
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
                var validNote = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (validNote != null)
                {
                    validNote.Colour = noteColor;
                    this.userContext.Notes.Update(validNote);
                    this.userContext.SaveChanges();
                    return "Color is updated successfully";
                }
                return "Color update is unsuccessful";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string ArchiveNote(int noteId)
        {
            try
            {
                string msg;
                var validNote = this.userContext.Notes.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (validNote != null) 
                {
                    if (validNote.IsArchive == false)
                    {
                        validNote.IsArchive = true; 
                        if (validNote.IsNotePinned == true) 
                        {
                            validNote.IsNotePinned = false;
                            msg = "The note is unpinned and archived successfully";
                        }
                        else
                        {

                            msg = "The note was initially not pinned but now it is archived successfully";
                        }
                    }
                    else
                    {
                        validNote.IsArchive = false;
                        msg = "Note unarchived successfully";
                    }
                    this.userContext.Notes.Update(validNote);
                    this.userContext.SaveChanges();
                }
                else
                {
                    msg = "This note does not exist. Kindly create a new one";
                }
                return msg;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string NoteAddtionAsPinned(int notesId)
        {
            try
            {
                string msg;
                var valiNoteId = this.userContext.Notes.Where(x => x.NoteId == notesId).SingleOrDefault();
                if (valiNoteId != null)
                {
                    if (valiNoteId.IsNotePinned == false)
                    {
                        valiNoteId.IsNotePinned = true;
                        if (valiNoteId.IsNotePinned == true) 
                        {
                            valiNoteId.IsArchive = false;
                            msg = "Note unarchived and pinned successfully";
                        }
                        else
                            msg = "Note pinned successfully";
                    }
                    else
                    {
                        valiNoteId.IsNotePinned = false;
                        msg = "Note unpinned successfully";
                    }
                    this.userContext.Notes.Update(valiNoteId);
                    this.userContext.SaveChanges();
                }
                else
                {
                    msg = "This note does not exist. Kindly create a new one";
                }
                return msg;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
