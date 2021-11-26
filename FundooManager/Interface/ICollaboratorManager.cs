using FundooModel;

namespace FundooManager.Interface
{
    public interface ICollaboratorManager
    {
        string AddCollaborator(CollaboratorModel collaboratorData);
        string DeleteCollaborator(int collaboratorId);
    }
}