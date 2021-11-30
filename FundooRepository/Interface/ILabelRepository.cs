using FundooModel;
using Microsoft.Extensions.Configuration;

namespace FundooRepository.Interface
{
    public interface ILabelRepository
    { 
        string AddLabelByUserId(LabelModel labelModel);
        string AddLabelByNoteId(LabelModel labelData);
        string DeleteLabel(int userId, string labelName);
        string RemoveLabel(int labelId);
        string EditLabel(LabelModel labelData);
    }
}