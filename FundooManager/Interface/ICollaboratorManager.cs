using FundooModel;
using System.Collections.Generic;

namespace FundooManager.Interface
{
    public interface ICollaboratorManager
    {
        string AddCollaborator(CollaboratorModel collaboratorData);
        string DeleteCollaborator(int collaboratorId);
        List<CollaboratorModel> GetCollaboratorDetails(int noteId);
    }
}