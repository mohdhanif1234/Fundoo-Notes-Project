using FundooModel;

namespace FundooManager.Interface
{
    public interface INotesManager
    {
        string MakeANote(NotesModel notesModel);
        string EditNote(NotesModel notesModel);
        string EditColor(int noteId, string color);
        string ArchiveNote(int noteId);
        string NoteAddtionAsPinned(int notesId);
        string DeleteANote(int notesId);
    }
}