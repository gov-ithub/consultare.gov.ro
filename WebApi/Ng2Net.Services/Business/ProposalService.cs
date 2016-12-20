using Ng2Net.Infrastructure.Interfaces;
using Ng2Net.Model.Business;
using Ng2Net.Infrastructure.Data;
using System.Data.Entity.Infrastructure;
using Ng2Net.Data;
using System.Linq;
using System.Data.Entity;

namespace Ng2Net.Services.Business
{
    public class ProposalService : BaseService<Proposal>, IProposalService
    {
        private DatabaseContext _context; 
        public ProposalService(IRepository<Proposal> repository, DatabaseContext context) : base(repository)
        {
            this._context = context;
        }

        public override void Save()
        {
            var changedEntries = _context.ChangeTracker.Entries().Where(e => new EntityState[] { EntityState.Added, EntityState.Modified, EntityState.Deleted }.Contains(e.State)).Where(e => typeof(ProposalDocument).IsAssignableFrom(e.Entity.GetType())).ToList();

            foreach (var user in changedEntries)
            {
                RunRules(user);
            }

            base.Save();
        }

        private void RunRules(DbEntityEntry ent)
        {
            ProposalDocument pDoc = (ProposalDocument)ent.Entity;
            if (pDoc.Url.LastIndexOf(".") < 0)
            {
                pDoc.Type = "file";
                return;
            }
            pDoc.Type = pDoc.Url.Substring(pDoc.Url.LastIndexOf(".") + 1, pDoc.Url.Length - pDoc.Url.LastIndexOf(".") - 1).ToLower();
            if (pDoc.Type == "docx") pDoc.Type = "doc";
            if (pDoc.Type != "doc" && pDoc.Type != "pdf") pDoc.Type = "file";

        }

    }
}
