﻿using FundooModel;
using Microsoft.AspNetCore.Http;

namespace FundooRepository.Interface
{
    public interface INotesRepository
    {
        string MakeANote(NotesModel notesModel);
        string EditNote(NotesModel notesModel);
        string EditColor(int noteId, string color);
        string ArchiveNote(int noteId);
        string NoteAddtionAsPinned(int notesId);
<<<<<<< HEAD
        string AddImage(int noteId, IFormFile imagePath);
=======
        string DeleteANote(int notesId);
>>>>>>> Notes

    }
}