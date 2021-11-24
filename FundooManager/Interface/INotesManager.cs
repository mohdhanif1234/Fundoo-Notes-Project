using FundooModel;

namespace FundooManager.Interface
{
    public interface INotesManager
    {
        string MakeANote(NotesModel notesModel);
        string EditNote(NotesModel notesModel);
    }
}