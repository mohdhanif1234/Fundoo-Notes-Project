using FundooModel;
using System.Collections.Generic;

namespace FundooManager.Interface
{
    public interface ILabelManager
    {
        string AddLabelByUserId(LabelModel labelData);
        string AddLabelByNoteId(LabelModel labelData);
        string DeleteLabel(int userId, string labelName);
        string RemoveLabel(int labelId);
        string EditLabel(LabelModel labelData);
        IEnumerable<string> GetLabelByUserId(int userId);
    }
}