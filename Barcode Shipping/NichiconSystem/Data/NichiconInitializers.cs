using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace NichiconSystem.Data
{
    public class NichiconInitializers : SqliteDropCreateDatabaseWhenModelChanges<NichiconDbContext>
    {
        public NichiconInitializers(DbModelBuilder modelBuilder)
            : base(modelBuilder, typeof(CustomHistory))
        { }

        protected override void Seed(NichiconDbContext context)
        {
            if (!context.Models.Any())
            {
                context.Set<Model>().AddRange(new List<Model>() {
                    new Model { ModelName = "150K31631", By = "IT", Quantity = 16, SerialNo = "V" },
                    new Model { ModelName = "105K31000", By = "IT", Quantity = 16, SerialNo = "V" },
                    new Model { ModelName = "105K32160", By = "IT", Quantity = 16, SerialNo = "V" },
                    new Model { ModelName = "ZSFLB06GA-VU (105K31621K001)", By = "IT", Quantity = 16, SerialNo = "VU" },
                    new Model { ModelName = "ZSFLA18GA-VU( 105K30961K001)", By = "IT", Quantity = 16, SerialNo = "VU" },
                    new Model { ModelName = "105K30981", By = "IT", Quantity = 16, SerialNo = "V02" },
                    new Model { ModelName = "105K32170", By = "IT", Quantity = 16, SerialNo = "V" },
                    new Model { ModelName = "105K30990", By = "IT", Quantity = 16, SerialNo = "V" },
                    new Model { ModelName = "105K30961", By = "IT", Quantity = 16, SerialNo = "V" },
                    new Model { ModelName = "105K31621", By = "IT", Quantity = 16, SerialNo = "V" },
                    new Model { ModelName = "105K31020", By = "IT", Quantity = 16, SerialNo = "V" },
                });
            }

            if (!context.Operators.Any())
            {
                context.Set<Operator>().AddRange(new List<Operator>() {
                    new Operator { ID="16354", Name="Phạm Văn Cương" },
                    new Operator { ID="12345", Name="Nichicon Test" },
                });
            }


        }
    }
}
