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

    }
}
