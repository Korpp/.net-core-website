using Microsoft.EntityFrameworkCore;
using MyWebPage.Data;
namespace MyWebPage.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyWebPageContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyWebPageContext>>()))
            {
                if (context == null || context.Movies == null || context.AppFiles == null || context.ApplicantWorkExperiences == null || context.Items == null || context.ApplicantDetails == null || context.ApplicantSkills == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any Experience.
                if (context.AppFiles.Any())
                {
                    return;   // DB has been seeded
                }
                context.AppFiles.AddRange(
                  new AppFile
                  {
                      FileName = "Ghostbusters.jpg"
                  },
                  new AppFile
                  {
                      FileName = "Ghostbusters2.jpg"
                  },
                  new AppFile
                  {
                      FileName = "thumbnail.png"
                  },
                  new AppFile
                  {
                      FileName = "thumbnail_2.png"
                  });
                context.SaveChanges();
                // Look for any Details.
                if (context.Items.Any())
                {
                    return;   // DB has been seeded
                }
                context.Items.AddRange(
                  new Item
                  {
                      ImageUrl = "thumbnail.png",
                      ItemName = "user1",
                      Price = 12.99M
                  },
                  new Item
                  {
                      ImageUrl = "thumbnail_2.png",
                      ItemName = "user2",
                      Price = 15.99M
                  });
                context.SaveChanges();
                // Look for any Details.
                if (context.ApplicantDetails.Any())
                {
                    return;   // DB has been seeded
                }
                context.ApplicantDetails.AddRange(
                  new ApplicantDetails
                  {

                      FirstName = "Jukka",
                      LastName = "Jokunen",
                      Age = DateTime.Parse("1996-2-21"),
                      Address = "Hämeenkatu 1",
                      PostalCode = 12100,
                      City = "Helsinki",
                      Phonenumber = 0403330052,
                      Email = "Jukka@gmail.fi",
                      LinkedIn = "Jukker",
                      GitHub = "Jukker",
                      profileImage = "thumbnail.png"
                  },

                new ApplicantDetails
                {
                    profileImage = "thumbnail.png"
                });
                context.SaveChanges();
                // Look for any Skills.
                if (context.ApplicantSkills.Any())
                {
                    return;   // DB has been seeded
                }
                context.ApplicantSkills.AddRange(
                  new ApplicantSkills
                  {
                      Skill = "C#",
                      Description = "programming language"
                  },
                  new ApplicantSkills
                  {
                      Skill = "C#/.Net Core",
                      Description = "programming language"
                  });
                // Look for any Experience.
                if (context.ApplicantWorkExperiences.Any())
                {
                    return;   // DB has been seeded
                }
                context.ApplicantWorkExperiences.AddRange(
                  new ApplicantWorkExperience
                  {
                      Company = "Softwares OY",
                      Employer = "Joku Työnantaja",
                      Description = "Software Developer",
                      StartDate = DateTime.Parse("2020-6-01"),
                      EndDate = DateTime.Parse("2021-3-31")

                  });

                context.SaveChanges();
                // Look for any movies.
                if (context.Movies.Any())
                {
                    return;   // DB has been seeded
                }


                context.Movies.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "R",

                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "R",
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "R",
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "R"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
