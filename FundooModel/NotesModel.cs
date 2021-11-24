using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModel
{
    public class NotesModel
    {
        [Key]
        public int NoteId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public RegisterModel registerModel { get; set; }
        public string Title { get; set; }

        public string TakeANote { get; set; }

        public string RemindMe { get; set; }

        public string Colour { get; set; }

        public string Image { get; set; }

        [DefaultValue(false)]
        public bool IsArchive { get; set; }

        [DefaultValue(false)]
        public bool IsTrash { get; set; }

        [DefaultValue(false)]
        public bool IsNotePinned { get; set; }
    }
}
