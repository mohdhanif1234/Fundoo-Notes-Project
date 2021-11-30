using FundooManager.Interface;
using FundooModel;
using FundooRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class LabelManager : ILabelManager
    {
        private readonly ILabelRepository labelRepository;

        public LabelManager(ILabelRepository labelRepository)
        {
            this.labelRepository = labelRepository;
        }
        public string AddLabelByUserId(LabelModel labelData)
        {
            try
            {
                return this.labelRepository.AddLabelByUserId(labelData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string AddLabelByNoteId(LabelModel labelData)
        {
            try
            {
                return this.labelRepository.AddLabelByNoteId(labelData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteLabel(int userId, string labelName)
        {
            try
            {
                return this.labelRepository.DeleteLabel(userId, labelName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string RemoveLabel(int labelId)
        {
            try
            {
                return this.labelRepository.RemoveLabel(labelId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EditLabel(LabelModel labelData)
        {
            try
            {
                return this.labelRepository.EditLabel(labelData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<string> GetLabelByUserId(int userId)
        {
            try
            {
                return this.labelRepository.GetLabelByUserId(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
