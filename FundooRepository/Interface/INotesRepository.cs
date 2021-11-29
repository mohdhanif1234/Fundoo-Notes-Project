﻿using FundooModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace FundooRepository.Interface
{
    public interface INotesRepository
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
        string AddReminder(int notesId, string remindMe);
        string DeleteReminder(int notesId);
        IEnumerable<NotesModel> GetArchiveNotes(int userId);
        IEnumerable<NotesModel> GetReminderNotes(int userId);

    }
}