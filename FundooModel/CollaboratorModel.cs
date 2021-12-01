// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorModel.cs" company="KPMG">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Mohammad Hanif"/>
// ----------------------------------------------------------------------------------------------------------

namespace FundooModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    public class CollaboratorModel
    {
        [Key]
        public int CollaboratorId { get; set; }
        public int NoteId { get; set; }
        [ForeignKey("NoteId")]
        public  NotesModel notesModel { get; set; }
        public string EmailId { get; set; }
    }
}
