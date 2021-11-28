using FundooModel;
using Microsoft.AspNetCore.Http;

namespace FundooManager.Interface
{
    public interface INotesManager
    {
        string MakeANote(NotesModel notesModel);
        string EditNote(NotesModel notesModel);
        string EditColor(int noteId, string color);
        string ArchiveNote(int noteId);
        string NoteAddtionAsPinned(int notesId);

        string AddImage(int noteId, IFormFile imagePath);

        string DeleteANote(int notesId);
        string RetrieveNoteFromTrash(int notesId);
        string DeleteNoteFromTrash(int notesId);
    }
}