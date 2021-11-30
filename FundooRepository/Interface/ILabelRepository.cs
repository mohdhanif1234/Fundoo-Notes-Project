using FundooModel;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FundooRepository.Interface
{
    public interface ILabelRepository
    { 
        string AddLabelByUserId(LabelModel labelModel);
        string AddLabelByNoteId(LabelModel labelData);
        string DeleteLabel(int userId, string labelName);
        string RemoveLabel(int labelId);
        string EditLabel(LabelModel labelData);
        IEnumerable<string> GetLabelByUserId(int userId);
        IEnumerable<LabelModel> GetLabelByNoteId(int notesId);
    }
}