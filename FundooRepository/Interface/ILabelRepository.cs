using FundooModel;
using Microsoft.Extensions.Configuration;

namespace FundooRepository.Interface
{
    public interface ILabelRepository
    { 
        string AddLabelByUserId(LabelModel labelModel);
        string AddLabelByNoteId(LabelModel labelData);
    }
}