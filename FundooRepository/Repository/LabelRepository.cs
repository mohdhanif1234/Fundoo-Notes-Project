using FundooModel;
using FundooRepository.Context;
using FundooRepository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRepository.Repository
{
    public class LabelRepository : ILabelRepository
    {
        private readonly UserContext userContext;
        public LabelRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }

        public IConfiguration Configuration { get; }
        public string AddLabelByUserId(LabelModel labelData)
        {
            try
            {
                var validLabel = this.userContext.Labels.Where(x => x.UserId == labelData.UserId && x.LabelName != labelData.LabelName && x.NoteId == null).FirstOrDefault();
                if (validLabel == null)
                {
                    this.userContext.Labels.Add(labelData);
                    this.userContext.SaveChanges();
                    return "Label added successfully";
                }
                return "The label with this name already exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string AddLabelByNoteId(LabelModel labelData)
        {
            try
            {
                var validLabel = this.userContext.Labels.Where(x => x.UserId == labelData.UserId && x.NoteId == labelData.NoteId).FirstOrDefault();
                if (validLabel == null)
                {
                    this.userContext.Labels.Add(labelData);
                    this.userContext.SaveChanges();
                    return "Label added successfully";
                }
                return "The label with this name already exists";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteLabel(int userId, string labelName)
        {
            try
            {
                var validLabel = this.userContext.Labels.Where(x => x.LabelName == labelName && x.UserId == userId).ToList();
                if (validLabel != null)
                {
                    this.userContext.Labels.RemoveRange(validLabel);
                    this.userContext.SaveChanges();
                    return "Label deleted successfully";
                }
                return "Label not exist. Kindly create a new one";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string RemoveLabel(int labelId)
        {
            try
            {
                var validLabel = this.userContext.Labels.Where(x => x.LabelId == labelId).FirstOrDefault();
                if (validLabel != null)
                {
                    this.userContext.Labels.Remove(validLabel);
                    this.userContext.SaveChanges();
                    return "Label was deleted from the note successfully";
                }

                return "There is no label present with this name";
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
                var validLabel = this.userContext.Labels.Where(x => x.LabelId == labelData.LabelId).Select(x => x.LabelName).FirstOrDefault();
                var prevLabelname = this.userContext.Labels.Where(x => x.LabelName == validLabel).ToList();
                prevLabelname.ForEach(x => x.LabelName = labelData.LabelName);
                this.userContext.Labels.UpdateRange(prevLabelname);
                this.userContext.SaveChanges();
                return "Label updated successfully";
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
                IEnumerable<string> validLabel = this.userContext.Labels.Where(x => x.UserId == userId).Select(x => x.LabelName);
                if (validLabel != null)
                {
                    return validLabel;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<LabelModel> GetLabelByNoteId(int notesId)
        {
            try
            {
                IEnumerable<LabelModel> validLabel = this.userContext.Labels.Where(x => x.NoteId == notesId);
                if (validLabel != null)
                {
                    return validLabel;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
