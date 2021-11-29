using FundooModel;

namespace FundooManager.Interface
{
    public interface ILabelManager
    {
        string AddLabelByUserId(LabelModel labelData);
        string AddLabelByNoteId(LabelModel labelData);
    }
}