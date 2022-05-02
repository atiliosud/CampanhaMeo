using CampanhaMeo.Atilio.Models;
using CampanhaMeo.Atilio.ModelViews;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CampanhaMeo.Atilio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Survey>()
                .HasOne(b => b.CreateBy)
                .WithMany()
                .HasForeignKey(ub => ub.CreateById)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<Question>()
                .HasOne(b => b.CreateBy)
                .WithMany()
                .HasForeignKey(ub => ub.CreateById)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<Question>()
                .HasOne(b => b.Survey)
                .WithMany(u => u.Questions)
                .HasForeignKey(ub => ub.SurveyId);


            builder.Entity<Answer>()
                .HasOne(b => b.Question)
                .WithMany(u => u.Answers)
                .HasForeignKey(ub => ub.QuestionId);

            builder.Entity<Question>().Property(e => e.Content).HasConversion(
                v => JsonConvert.SerializeObject(v, typeof(IQuestionStruct), new JsonSerializerSettings { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto, NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<IQuestionStruct>(v, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, NullValueHandling = NullValueHandling.Ignore })
                );

            builder.Entity<Answer>().Property(e => e.QuestionAnswered).HasConversion(
            v => JsonConvert.SerializeObject(v, typeof(IAnswerStruct), new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            }),
            v => JsonConvert.DeserializeObject<IAnswerStruct>(v, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto, NullValueHandling = NullValueHandling.Ignore }));
            base.OnModelCreating(builder);
        }
    }
}