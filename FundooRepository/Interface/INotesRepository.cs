using FundooModel;

namespace FundooRepository.Interface
{
    public interface INotesRepository
    {
        string MakeANote(NotesModel notesModel);
        string EditNote(NotesModel notesModel);
        string EditColor(int noteId, string color);
        string ArchiveNote(int noteId);
        string NoteAddtionAsPinned(int notesId);
        string DeleteANote(int notesId);

    }
}