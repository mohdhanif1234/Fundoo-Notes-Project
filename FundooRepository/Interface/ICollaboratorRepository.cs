using FundooModel;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FundooRepository.Interface
{
    public interface ICollaboratorRepository
    {
        string AddCollaborator(CollaboratorModel collaboratorData);
        string DeleteCollaborator(int collaboratorId);
        List<CollaboratorModel> GetCollaboratorDetails(int noteId);
    }
}