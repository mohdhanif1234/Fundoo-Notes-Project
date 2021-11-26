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
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly UserContext userContext;
        public IConfiguration Configuration { get; }
        public CollaboratorRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }
        public string AddCollaborator(CollaboratorModel collaboratorData)
        {
            try
            {
                if (collaboratorData != null)
                {
                    this.userContext.Add(collaboratorData);
                    this.userContext.SaveChanges();
                    return "Collaborator added successfully";
                }
                return "Addition of collaborator is unsuccessful";
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
        public string DeleteCollaborator(int collaboratorId)
        {
            try
            {
                var collabIdCheck = this.userContext.Collaborator.Where(x => x.CollaboratorId == collaboratorId).FirstOrDefault();
                if (collabIdCheck != null)
                {
                    if (collaboratorId != 0)
                    {
                        this.userContext.Remove(collabIdCheck);
                        this.userContext.SaveChanges();
                        return "Collaborator removed successfully";
                    }
                    return "Nothing is present inside the collaborator body";
                }
                return "This collaborator does not exist. Kindly create a new one.";
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
        public List<CollaboratorModel> GetCollaboratorDetails(int noteId)
        {
            try
            {
                List<CollaboratorModel> Collaborator = this.userContext.Collaborator.Where(x => x.NoteId == noteId).ToList();
                if (Collaborator != null)
                {
                    return Collaborator;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
