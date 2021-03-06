﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Add using:
using System.Data.Entity;

namespace MinimalOwinWebApiSelfHost.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("MyDatabase")
        {

        }

        public IDbSet<Company> Companies { get; set; }
        public IDbSet<Document> Documents { get; set; }
    }


    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);
            context.Companies.Add(new Company { Name = "Microsoft" });
            context.Companies.Add(new Company { Name = "Google" });
            context.Companies.Add(new Company { Name = "Apple" });

            context.Documents.Add(new Document() { Name = "Testdokument.docx", CreateDate = DateTime.Now, DocumentID = 1, FilePath = "", Tags = new List<string> { "test", "dok" } });
        }
    }
}
