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
    }
}
