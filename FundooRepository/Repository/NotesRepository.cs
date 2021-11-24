using FundooModel;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
                    return "Note is added successfully";
                }
                else
                {
                    return "Note addition is unsuccesful";
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
