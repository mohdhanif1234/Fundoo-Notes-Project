using FundooModel;

namespace FundooRepository.Interface
{
    public interface INotesRepository
    {
        string MakeANote(NotesModel notesModel);
    }
}